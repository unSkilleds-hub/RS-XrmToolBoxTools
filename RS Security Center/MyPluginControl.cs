using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using NuGet.Packaging.Signing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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

            RetrieveSystemuser();
            GetRoles();

            ShowInfoNotification("Excluded System and application users", new Uri("https://learn.microsoft.com/en-us/power-platform/admin/system-application-users"), 32);
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

                RetrieveSystemuser();
                GetRoles();
            }
        }
        private void ListBoxSystemusers_Click(object sender, EventArgs e)
        {
            SystemUserObj systemUserObj = (SystemUserObj)listBoxSystemusers.SelectedItem;

            listBoxRoles.DataSource = new List<SystemUserRolesObj>(GlobalControl._systemuserRoles.Where(x => x.Systemuserid == systemUserObj.Id).ToList());
            listBoxRoles.DisplayMember = "Name";
        }
        private void ListBoxSystemusersCopyTo_Click(object sender, EventArgs e)
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
                ColumnSet = new ColumnSet("systemuserid", "fullname"),
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
                            GlobalControl._systemuser.Add(new SystemUserObj
                            {
                                Fullname = item.GetAttributeValue<string>(SystemUser.PrimaryName),
                                Id = item.GetAttributeValue<Guid>(SystemUser.PrimaryKey)
                            });

                            //
                            GlobalControl._systemuserCopyTo.Add(new SystemUserObj
                            {
                                Fullname = item.GetAttributeValue<string>(SystemUser.PrimaryName),
                                Id = item.GetAttributeValue<Guid>(SystemUser.PrimaryKey)
                            });
                        }

                        GlobalControl._systemuser.Sort((x, y) => x.Fullname.CompareTo(y.Fullname));
                        GlobalControl._systemuserCopyTo.Sort((x, y) => x.Fullname.CompareTo(y.Fullname));

                        listBoxSystemusers.DataSource = new List<SystemUserObj>(GlobalControl._systemuser.ToList());
                        listBoxSystemusers.DisplayMember = "Fullname";

                        listBoxSystemusersCopyTo.DataSource = new List<SystemUserObj>(GlobalControl._systemuserCopyTo.ToList());
                        listBoxSystemusersCopyTo.DisplayMember = "Fullname";
                    }
                }
            });
        }
        private void buttonSynchronize_Click(object sender, EventArgs e)
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
            RetrieveSystemuser();
            GetRoles();

            listBoxRoles.DataSource = null;
            listBoxRolesCopyTo.DataSource = null;
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