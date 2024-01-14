using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace RS_Security_Center
{
    public partial class MyPluginControl : PluginControlBase, IPayPalPlugin
    {
        #region IPayPalPlugin implementation
        public string DonationDescription => @"Donation for ""RS Security Center"" - XrmToolBox";
        public string EmailAccount => "RSchlanstedt@gmx.net";
        #endregion IPayPalPlugin implementation
        private Settings mySettings;

        public MyPluginControl()
        {
            InitializeComponent();
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }

            ExecuteMethod(RetrieveAll);

            ShowInfoNotification("There is a list of special system and application users that is created when the system is provisioned.\r\nDo not delete or modify these users including changing or reassigning security role.", new Uri("https://learn.microsoft.com/en-us/power-platform/admin/system-application-users"), 32);
        }

        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);

                ExecuteMethod(RetrieveAll);
            }
        }
        private void ListBoxSystemusers_Click(object sender, EventArgs e)
        {
            Systemusers_UpdateRoles();
        }
        private void Systemusers_UpdateRoles()
        {
            SystemUserObj systemUserObj = (SystemUserObj)listBoxSystemusers.SelectedItem;

            listBoxRoles.DataSource = new List<SystemUserRolesObj>(GlobalControl._systemuserRoles.Where(x => x.Systemuserid == systemUserObj.Id).ToList());
            listBoxRoles.DisplayMember = "Name";
        }
        private void ListBoxSystemusersCopyTo_Click(object sender, EventArgs e)
        {
            SystemusersCopyTo_UpdateRoles();
        }
        private void SystemusersCopyTo_UpdateRoles()
        {
            SystemUserObj systemUserCopyToObj = (SystemUserObj)listBoxSystemusersCopyTo.SelectedItem;

            listBoxRolesCopyTo.DataSource = new List<SystemUserRolesObj>(GlobalControl._systemuserRolesCopyTo.Where(x => x.Systemuserid == systemUserCopyToObj.Id).ToList());
            listBoxRolesCopyTo.DisplayMember = "Name";
        }
        private void GetRoles()
        {
            //
            GlobalControl._systemuserRoles.Clear();
            GlobalControl._systemuserRolesCopyTo.Clear();

            //
            QueryExpression query = new QueryExpression("systemuserroles");
            query.ColumnSet.AddColumns("systemuserroleid", "systemuserid");

            LinkEntity leRole = query.AddLink("role", "roleid", "roleid", JoinOperator.Inner);
            leRole.Columns.AddColumns("roleid", "name");
            leRole.EntityAlias = "leRole";

            //
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Retrieving Roles",
                Work = (worker, args) =>
                {
                    args.Result = Service.RetrieveMultiple(query);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    var result = args.Result as EntityCollection;
                    if (result != null)
                    {
                        //
                        foreach (var item in result.Entities)
                        {
                            //
                            GlobalControl._systemuserRoles.Add(new SystemUserRolesObj
                            {
                                Systemuserroleid = item.GetAttributeValue<Guid>("systemuserroleid"),
                                Name = (string)item.GetAttributeValue<AliasedValue>("leRole." + Role.PrimaryName).Value,
                                Roleid = (Guid)item.GetAttributeValue<AliasedValue>("leRole." + Role.PrimaryKey).Value,
                                Systemuserid = item.GetAttributeValue<Guid>("systemuserid")
                            });

                            //
                            GlobalControl._systemuserRolesCopyTo.Add(new SystemUserRolesObj
                            {
                                Systemuserroleid = item.GetAttributeValue<Guid>("systemuserroleid"),
                                Name = (string)item.GetAttributeValue<AliasedValue>("leRole." + Role.PrimaryName).Value,
                                Roleid = (Guid)item.GetAttributeValue<AliasedValue>("leRole." + Role.PrimaryKey).Value,
                                Systemuserid = item.GetAttributeValue<Guid>("systemuserid")
                            });
                        }

                        GlobalControl._systemuserRoles.Sort((x, y) => x.Name.CompareTo(y.Name));
                        GlobalControl._systemuserRolesCopyTo.Sort((x, y) => x.Name.CompareTo(y.Name));

                        //
                        SystemUserObj systemUserObj = (SystemUserObj)listBoxSystemusers.SelectedItem;

                        listBoxRoles.DataSource = new List<SystemUserRolesObj>(GlobalControl._systemuserRoles.Where(x => x.Systemuserid == systemUserObj.Id).ToList());
                        listBoxRoles.DisplayMember = "Name";

                        SystemUserObj systemUserCopyToObj = (SystemUserObj)listBoxSystemusersCopyTo.SelectedItem;

                        listBoxRolesCopyTo.DataSource = new List<SystemUserRolesObj>(GlobalControl._systemuserRolesCopyTo.Where(x => x.Systemuserid == systemUserCopyToObj.Id).ToList());
                        listBoxRolesCopyTo.DisplayMember = "Name";
                    }
                }
            });
        }
        private void RetrieveSystemuser()
        {
            //
            GlobalControl._systemuser.Clear();
            GlobalControl._systemuserCopyTo.Clear();

            // Exclude - https://learn.microsoft.com/en-us/power-platform/admin/system-application-users
            string[] systemAndApplicationUsers = { "SYSTEM", "Support user", "Delegated admin", "Business Application Platform Service account", "App Management User", "Dataverse Dataverse search", "Dynamics 365 Office Data Service", "Dynamics 365 Athena-CDStoAzuredatalake", "Dynamics 365 Athena2-CDStoAzuredatalake", "EnterpriseSales", "Finance and Operations Runtime Integration User", "# SIAutoCapture", "# Dynamics 365 Sales", "Microsoft Project", "Power Apps Checker Application", "Powerqueryonline-CDStoAzuredatalake", "Provision User", "DataLakeStorage", "JobServicePreProd", "JobServiceProd", "# CCADataAnalyticsML", "# CDSReportService", "Power Platform Dataflows", "AIBuilderProd", "PowerAutomate-ProcessMining", "AriaMdlExporter", "CDSFileStorage", "CDSUserManagement", "GDSGlobalDiscovery", "BAP", "Microsoft Forms Pro", "PowerVIrtualAgents", "BizQA", "ProductInsights", "Dynamics365 SalesForecasting", "# Omnichannel", "# Flow-RP" };

            QueryExpression query = new QueryExpression("systemuser")
            {
                ColumnSet = new ColumnSet("systemuserid", "fullname", "createdby", "isdisabled"),
                Criteria =
                {
                    Filters =
                    {
                        new FilterExpression
                        {
                            FilterOperator = LogicalOperator.And,
                            Conditions =
                            {
                                // Exclude - https://learn.microsoft.com/en-us/power-platform/admin/system-application-users
                                new ConditionExpression("fullname", ConditionOperator.NotIn, systemAndApplicationUsers),
                                new ConditionExpression("fullname", ConditionOperator.NotLike, "# DataSyncService-%"),
                                new ConditionExpression("fullname", ConditionOperator.NotLike, "# DataSyncFramework-%"),
                                new ConditionExpression("fullname", ConditionOperator.NotLike, "# Flow-CDSNativeConnector%"),
                                new ConditionExpression("fullname", ConditionOperator.NotLike, "# PowerAutomate-%")
                            },
                        }
                    }
                }
            };

            //
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting systemusers",
                Work = (worker, args) =>
                {
                    args.Result = Service.RetrieveMultiple(query);

                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    var result = args.Result as EntityCollection;
                    if (result != null)
                    {
                        //
                        labelSystemusers.Text = $"Systemusers - Retrieved {result.Entities.Count}";

                        //
                        foreach (var item in result.Entities)
                        {
                            //
                            if (item.GetAttributeValue<EntityReference>(SystemUser.CreatedBy)?.Name == "SYSTEM")
                                continue;

                            //
                            GlobalControl._systemuser.Add(new SystemUserObj
                            {
                                Fullname = item.GetAttributeValue<string>(SystemUser.PrimaryName),
                                Id = item.GetAttributeValue<Guid>(SystemUser.PrimaryKey),
                                CreatedBy = item.GetAttributeValue<EntityReference>(SystemUser.CreatedBy)?.Name,
                                IsDisabled = item.GetAttributeValue<bool>(SystemUser.Isdisabled)

                            });

                            //
                            GlobalControl._systemuserCopyTo.Add(new SystemUserObj
                            {
                                Fullname = item.GetAttributeValue<string>(SystemUser.PrimaryName),
                                Id = item.GetAttributeValue<Guid>(SystemUser.PrimaryKey),
                                CreatedBy = item.GetAttributeValue<EntityReference>(SystemUser.CreatedBy)?.Name,
                                IsDisabled = item.GetAttributeValue<bool>(SystemUser.Isdisabled)
                            });
                        }

                        GlobalControl._systemuser.Sort((x, y) => x.Fullname.CompareTo(y.Fullname));
                        GlobalControl._systemuserCopyTo.Sort((x, y) => x.Fullname.CompareTo(y.Fullname));

                        FilterSystemuser();
                        FilterSystemuserCopyTo();
                    }
                }
            });
        }
        private void buttonSynchronize_Click(object sender, EventArgs e)
        {
            ExecuteMethod(Synchronize);
        }
        private void Synchronize()
        {
            //
            if (listBoxRoles.Items.Count == 0)
                return;

            //
            SystemUserObj systemUserObjCopyTo = (SystemUserObj)listBoxSystemusersCopyTo.SelectedItem;

            #region Disassociate
            //
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Disassociate roles",
                Work = (worker, args) =>
                {
                    //
                    Service.Disassociate(
                    "systemuser",
                    systemUserObjCopyTo.Id,
                    new Relationship("systemuserroles_association"),
                    new EntityReferenceCollection(RolesToDisassociate(AllRoles: true))
                    );
                },
                PostWorkCallBack = (args) =>
                {
                }
            });
            #endregion

            #region Associate
            //
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Associate roles",
                Work = (worker, args) =>
                {
                    //
                    Service.Associate(
                    "systemuser",
                    systemUserObjCopyTo.Id,
                    new Relationship("systemuserroles_association"),
                    new EntityReferenceCollection(RolesToAssociate(AllRoles: true))
                    );
                },
                PostWorkCallBack = (args) =>
                {
                    GetRoles();
                }
            });
            #endregion
        }
        private void buttonAssociate_Click(object sender, EventArgs e)
        {
            ExecuteMethod(Associate);
        }
        private void Associate()
        {
            //
            if (listBoxRoles.Items.Count == 0)
                return;

            //
            SystemUserObj systemUserObjCopyTo = (SystemUserObj)listBoxSystemusersCopyTo.SelectedItem;

            //
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Associate roles",
                Work = (worker, args) =>
                {
                    //
                    Service.Associate(
                    "systemuser",
                    systemUserObjCopyTo.Id,
                    new Relationship("systemuserroles_association"),
                    new EntityReferenceCollection(RolesToAssociate(AllRoles: false))
                    );
                },
                PostWorkCallBack = (args) =>
                {
                    GetRoles();
                }
            });
        }
        private void buttonDisassociate_Click(object sender, EventArgs e)
        {
            ExecuteMethod(Disassociate);
        }
        private void Disassociate()
        {
            //
            if (listBoxRolesCopyTo.Items.Count == 0)
                return;

            //
            SystemUserObj systemUserObjCopyTo = (SystemUserObj)listBoxSystemusersCopyTo.SelectedItem;

            //
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Disassociate roles",
                Work = (worker, args) =>
                {
                    //
                    Service.Disassociate(
                    "systemuser",
                    systemUserObjCopyTo.Id,
                    new Relationship("systemuserroles_association"),
                    new EntityReferenceCollection(RolesToDisassociate(AllRoles: false))
                    );
                },
                PostWorkCallBack = (args) =>
                {
                    GetRoles();
                }
            });
        }
        private EntityReferenceCollection RolesToAssociate(bool AllRoles)
        {
            //
            EntityReferenceCollection entityReferences = new EntityReferenceCollection();

            //
            if (AllRoles)
            {
                //
                foreach (SystemUserRolesObj systemUserRolesObj in listBoxRoles.Items)
                {
                    //
                    var match = false;

                    //
                    foreach (SystemUserRolesObj systemUserRolesObjCopyTo in listBoxRolesCopyTo.Items)
                    {
                        //
                        if (systemUserRolesObj.Roleid == systemUserRolesObjCopyTo.Roleid)
                        {
                            match = true;
                            break;
                        }
                    }

                    //
                    if (!match)
                    {
                        //
                        entityReferences.Add(new EntityReference("role", systemUserRolesObj.Roleid));
                    }
                }
            }
            else
            {
                //
                foreach (SystemUserRolesObj systemUserRolesObj in listBoxRoles.SelectedItems)
                {
                    //
                    var match = false;

                    //
                    foreach (SystemUserRolesObj systemUserRolesObjCopyTo in listBoxRolesCopyTo.Items)
                    {
                        //
                        if (systemUserRolesObj.Roleid == systemUserRolesObjCopyTo.Roleid)
                        {
                            match = true;
                            break;
                        }
                    }

                    //
                    if (!match)
                    {
                        //
                        entityReferences.Add(new EntityReference("role", systemUserRolesObj.Roleid));
                    }
                }
            }

            return entityReferences;
        }
        private EntityReferenceCollection RolesToDisassociate(bool AllRoles)
        {
            //
            EntityReferenceCollection entityReferences = new EntityReferenceCollection();

            //
            if (AllRoles)
            {
                //
                foreach (SystemUserRolesObj systemUserRolesObjCopyTo in listBoxRolesCopyTo.Items)
                {
                    //
                    var match = true;

                    //
                    foreach (SystemUserRolesObj systemUserRolesObj in listBoxRoles.Items)
                    {
                        //
                        if (systemUserRolesObj.Roleid == systemUserRolesObjCopyTo.Roleid)
                        {
                            match = false;
                            break;
                        }
                    }

                    //
                    if (match)
                    {
                        //
                        entityReferences.Add(new EntityReference("role", systemUserRolesObjCopyTo.Roleid));
                    }
                }
            }
            else
            {
                //
                foreach (SystemUserRolesObj systemUserRolesObjCopyTo in listBoxRolesCopyTo.SelectedItems)
                {
                    //
                    entityReferences.Add(new EntityReference("role", systemUserRolesObjCopyTo.Roleid));
                }
            }

            return entityReferences;
        }
        private void tSB_RetrieveAll_Click(object sender, EventArgs e)
        {
            ExecuteMethod(RetrieveAll);
        }
        private void RetrieveAll()
        {
            RetrieveSystemuser();
            GetRoles();
        }
        private void txtBoxSystemusersSearch_TextChanged(object sender, EventArgs e)
        {
            FilterSystemuser();
        }
        private void txtBoxSystemusersCopyToSearch_TextChanged(object sender, EventArgs e)
        {
            FilterSystemuserCopyTo();
        }
        private void checkBoxInactive_CheckedChanged(object sender, EventArgs e)
        {
            FilterSystemuser();
            FilterSystemuserCopyTo();
        }
        private void FilterSystemuser()
        {
            //
            var listToFilter = new List<SystemUserObj>(GlobalControl._systemuser.ToList());

            //
            if (!checkBoxInactive.Checked)
            {
                listToFilter = listToFilter.Where(x => x.IsDisabled == false).ToList();
            }

            //
            if (!checkBoxSystemuser.Checked)
            {
                listToFilter = listToFilter.Where(x => x.CreatedBy is null || x.CreatedBy != "SYSTEM").ToList();
            }

            //
            if (!string.IsNullOrEmpty(txtBoxSystemusersSearch.Text))
            {
                listToFilter = listToFilter.Where(x => x.Fullname.ToLowerInvariant().Contains(txtBoxSystemusersSearch.Text.ToLowerInvariant())).ToList();
            }

            listBoxSystemusers.DataSource = listToFilter;
            listBoxSystemusers.DisplayMember = "Fullname";

            if (listBoxSystemusers.Items.Count == 1)
                Systemusers_UpdateRoles();
            else
                listBoxRoles.DataSource = null;
        }
        private void FilterSystemuserCopyTo()
        {
            //
            var listToFilter = new List<SystemUserObj>(GlobalControl._systemuser.ToList());

            //
            if (!checkBoxInactive.Checked)
            {
                listToFilter = listToFilter.Where(x => x.IsDisabled == false).ToList();
            }

            //
            if (!checkBoxSystemuser.Checked)
            {
                listToFilter = listToFilter.Where(x => x.CreatedBy is null || x.CreatedBy != "SYSTEM").ToList();
            }

            //
            if (!string.IsNullOrEmpty(txtBoxSystemusersCopyToSearch.Text))
            {
                listToFilter = listToFilter.Where(x => x.Fullname.ToLowerInvariant().Contains(txtBoxSystemusersCopyToSearch.Text.ToLowerInvariant())).ToList();
            }

            listBoxSystemusersCopyTo.DataSource = listToFilter;
            listBoxSystemusersCopyTo.DisplayMember = "Fullname";

            if (listBoxSystemusersCopyTo.Items.Count == 1)
                SystemusersCopyTo_UpdateRoles();
            else
                listBoxRolesCopyTo.DataSource = null;
        }
        private void checkBoxSystemuser_CheckedChanged(object sender, EventArgs e)
        {
            FilterSystemuser();
            FilterSystemuserCopyTo();
        }

        private void listBoxSystemusers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    public class GlobalControl
    {
        public static readonly List<SystemUserObj> _systemuser = new List<SystemUserObj>();
        public static readonly List<SystemUserObj> _systemuserCopyTo = new List<SystemUserObj>();
        public static readonly List<SystemUserRolesObj> _systemuserRoles = new List<SystemUserRolesObj>();
        public static readonly List<SystemUserRolesObj> _systemuserRolesCopyTo = new List<SystemUserRolesObj>();
    }
}