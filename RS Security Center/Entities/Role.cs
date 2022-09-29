// *********************************************************************
// Created by : Latebound Constants Generator 1.2021.12.1 for XrmToolBox
// Author     : Jonas Rapp https://jonasr.app/
// GitHub     : https://github.com/rappen/LCG-UDG/
// Source Org : https://engage365demoDEdev.crm4.dynamics.com
// Filename   : C:\Users\schlansr\Desktop\Role.cs
// Created    : 2022-09-16 21:34:42
// *********************************************************************

namespace RS_Security_Center
{
    /// <summary>DisplayName: Security Role, OwnershipType: BusinessOwned, IntroducedVersion: 5.0.0.0</summary>
    public static class Role
    {
        public const string EntityName = "role";
        public const string EntityCollectionName = "roles";

        #region Attributes

        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        public const string PrimaryKey = "roleid";
        /// <summary>Type: String, RequiredLevel: SystemRequired, MaxLength: 100, Format: Text</summary>
        public const string PrimaryName = "name";
        /// <summary>Type: Lookup, RequiredLevel: SystemRequired, Targets: businessunit</summary>
        public const string BusinessUnitId = "businessunitid";
        /// <summary>Type: ManagedProperty, RequiredLevel: SystemRequired</summary>
        public const string Canbedeleted = "canbedeleted";
        /// <summary>Type: Picklist, RequiredLevel: SystemRequired, DisplayName: Component State, OptionSetType: Picklist, DefaultFormValue: -1</summary>
        public const string ComponentState = "componentstate";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: systemuser</summary>
        public const string CreatedBy = "createdby";
        /// <summary>Type: DateTime, RequiredLevel: None, Format: DateAndTime, DateTimeBehavior: UserLocal</summary>
        public const string CreatedOn = "createdon";
        /// <summary>Type: ManagedProperty, RequiredLevel: SystemRequired</summary>
        public const string Iscustomizable = "iscustomizable";
        /// <summary>Type: Picklist, RequiredLevel: SystemRequired, DisplayName: Is Inherited, OptionSetType: Picklist, DefaultFormValue: 1</summary>
        public const string Isinherited = "isinherited";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: systemuser</summary>
        public const string ModifiedBy = "modifiedby";
        /// <summary>Type: DateTime, RequiredLevel: None, Format: DateAndTime, DateTimeBehavior: UserLocal</summary>
        public const string ModifiedOn = "modifiedon";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        public const string OrganizationId = "organizationid";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: role</summary>
        public const string ParentRoleId = "parentroleid";
        /// <summary>Type: Lookup, RequiredLevel: SystemRequired, Targets: role</summary>
        public const string ParentRootroleId = "parentrootroleid";
        /// <summary>Type: DateTime, RequiredLevel: SystemRequired, Format: DateOnly, DateTimeBehavior: UserLocal</summary>
        public const string Overwritetime = "overwritetime";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: roletemplate</summary>
        public const string RoletemplateId = "roletemplateid";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        public const string SolutionId = "solutionid";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: None</summary>
        public const string SupportingsolutionId = "supportingsolutionid";
        /// <summary>Type: Boolean, RequiredLevel: SystemRequired, True: 1, False: 0, DefaultValue: False</summary>
        public const string Ismanaged = "ismanaged";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        public const string Roleidunique = "roleidunique";

        #endregion Attributes

        #region OptionSets

        public enum ComponentState_OptionSet
        {
            Published = 0,
            Unpublished = 1,
            Deleted = 2,
            DeletedUnpublished = 3
        }
        public enum Isinherited_OptionSet
        {
            TeamPrivilegesonly = 0,
            DirectUserBasicaccessLevelAndTeamPrivileges = 1
        }

        #endregion OptionSets
    }
}
