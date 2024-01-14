// *********************************************************************
// Created by : Latebound Constants Generator 1.2021.12.1 for XrmToolBox
// Author     : Jonas Rapp https://jonasr.app/
// GitHub     : https://github.com/rappen/LCG-UDG/
// Created    : 2022-09-16 21:34:42
// *********************************************************************

namespace RS_Security_Center
{
    /// <summary>DisplayName: User, OwnershipType: BusinessOwned, IntroducedVersion: 5.0.0.0</summary>
    public static class SystemUser
    {
        public const string EntityName = "systemuser";
        public const string EntityCollectionName = "systemusers";

        #region Attributes

        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        public const string PrimaryKey = "systemuserid";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 200, Format: Text</summary>
        public const string PrimaryName = "fullname";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: None</summary>
        public const string StageId = "stageid";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 1250, Format: Text</summary>
        public const string Traversedpath = "traversedpath";
        /// <summary>Type: Picklist, RequiredLevel: SystemRequired, DisplayName: Access Mode, OptionSetType: Picklist, DefaultFormValue: 0</summary>
        public const string Accessmode = "accessmode";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: None</summary>
        public const string ActivedirectoryguId = "activedirectoryguid";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: None</summary>
        public const string ApplicationId = "applicationid";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 1024, Format: Text</summary>
        public const string Applicationiduri = "applicationiduri";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: None</summary>
        public const string AzureactivedirectoryobjectId = "azureactivedirectoryobjectid";
        /// <summary>Type: DateTime, RequiredLevel: None, Format: DateAndTime, DateTimeBehavior: UserLocal</summary>
        public const string Azuredeletedon = "azuredeletedon";
        /// <summary>Type: Picklist, RequiredLevel: SystemRequired, DisplayName: Azure State, OptionSetType: Picklist, DefaultFormValue: 0</summary>
        public const string AzureState = "azurestate";
        /// <summary>Type: Lookup, RequiredLevel: SystemRequired, Targets: businessunit</summary>
        public const string BusinessUnitId = "businessunitid";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: calendar</summary>
        public const string CalendarId = "calendarid";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: systemuser</summary>
        public const string CreatedBy = "createdby";
        /// <summary>Type: DateTime, RequiredLevel: None, Format: DateAndTime, DateTimeBehavior: UserLocal</summary>
        public const string CreatedOn = "createdon";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: transactioncurrency</summary>
        public const string TransactioncurrencyId = "transactioncurrencyid";
        /// <summary>Type: Boolean, RequiredLevel: SystemRequired, True: 1, False: 0, DefaultValue: False</summary>
        public const string Defaultfilterspopulated = "defaultfilterspopulated";
        /// <summary>Type: String, RequiredLevel: SystemRequired, MaxLength: 200, Format: Text</summary>
        public const string DefaultodbfolderName = "defaultodbfoldername";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: queue</summary>
        public const string QueueId = "queueid";
        /// <summary>Type: Picklist, RequiredLevel: SystemRequired, DisplayName: Delete State, OptionSetType: Picklist, DefaultFormValue: 0</summary>
        public const string DeletedState = "deletedstate";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 500, Format: Text</summary>
        public const string Disabledreason = "disabledreason";
        /// <summary>Type: Boolean, RequiredLevel: None, True: 1, False: 0, DefaultValue: False</summary>
        public const string Displayinserviceviews = "displayinserviceviews";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 100, Format: Email</summary>
        public const string PersonaleMailAddress = "personalemailaddress";
        /// <summary>Type: Boolean, RequiredLevel: SystemRequired, True: 1, False: 0, DefaultValue: False</summary>
        public const string IseMailAddressApprovedbyo365admin = "isemailaddressapprovedbyo365admin";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 100, Format: Text</summary>
        public const string EmployeeId = "employeeid";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: None</summary>
        public const string EntityImageId = "entityimageid";
        /// <summary>Type: Decimal, RequiredLevel: None, MinValue: 0,0000000001, MaxValue: 100000000000, Precision: 10</summary>
        public const string ExchangeRate = "exchangerate";
        /// <summary>Type: String, RequiredLevel: ApplicationRequired, MaxLength: 256, Format: Text</summary>
        public const string FirstName = "firstname";
        /// <summary>Type: Boolean, RequiredLevel: None, True: 1, False: 0, DefaultValue: False</summary>
        public const string MsdynGdproptout = "msdyn_gdproptout";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 100, Format: Text</summary>
        public const string GovernmentId = "governmentid";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 50, Format: Text</summary>
        public const string HomePhone = "homephone";
        /// <summary>Type: Picklist, RequiredLevel: SystemRequired, DisplayName: Incoming Email Delivery Method, OptionSetType: Picklist, DefaultFormValue: 1</summary>
        public const string IncomingeMailDeliveryMethod = "incomingemaildeliverymethod";
        /// <summary>Type: Boolean, RequiredLevel: SystemRequired, True: 1, False: 0, DefaultValue: False</summary>
        public const string IsintegrationUser = "isintegrationuser";
        /// <summary>Type: Picklist, RequiredLevel: ApplicationRequired, DisplayName: Invitation Status, OptionSetType: Picklist, DefaultFormValue: 0</summary>
        public const string InviteStatusCode = "invitestatuscode";
        /// <summary>Type: Boolean, RequiredLevel: SystemRequired, True: 1, False: 0, DefaultValue: True</summary>
        public const string IsactivedirectoryUser = "isactivedirectoryuser";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 100, Format: Text</summary>
        public const string Jobtitle = "jobtitle";
        /// <summary>Type: String, RequiredLevel: ApplicationRequired, MaxLength: 256, Format: Text</summary>
        public const string LastName = "lastname";
        /// <summary>Type: DateTime, RequiredLevel: None, Format: DateAndTime, DateTimeBehavior: UserLocal</summary>
        public const string Latestupdatetime = "latestupdatetime";
        /// <summary>Type: Picklist, RequiredLevel: SystemRequired, DisplayName: CAL Type, OptionSetType: Picklist, DefaultFormValue: 0</summary>
        public const string CalType = "caltype";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: mailbox</summary>
        public const string DefaultMailBox = "defaultmailbox";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: systemuser</summary>
        public const string ParentSystemUserId = "parentsystemuserid";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 50, Format: Text</summary>
        public const string MiddleName = "middlename";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 100, Format: Email</summary>
        public const string MobilealerteMail = "mobilealertemail";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: mobileofflineprofile</summary>
        public const string MobileofflineprofileId = "mobileofflineprofileid";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 64, Format: Text</summary>
        public const string MobilePhone = "mobilephone";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: systemuser</summary>
        public const string ModifiedBy = "modifiedby";
        /// <summary>Type: DateTime, RequiredLevel: None, Format: DateAndTime, DateTimeBehavior: UserLocal</summary>
        public const string ModifiedOn = "modifiedon";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 50, Format: Text</summary>
        public const string NickName = "nickname";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        public const string OrganizationId = "organizationid";
        /// <summary>Type: Picklist, RequiredLevel: SystemRequired, DisplayName: Outgoing Email Delivery Method, OptionSetType: Picklist, DefaultFormValue: 1</summary>
        public const string OutgoingeMailDeliveryMethod = "outgoingemaildeliverymethod";
        /// <summary>Type: Integer, RequiredLevel: None, MinValue: 0, MaxValue: 1000000000</summary>
        public const string Passporthi = "passporthi";
        /// <summary>Type: Integer, RequiredLevel: None, MinValue: 0, MaxValue: 1000000000</summary>
        public const string Passportlo = "passportlo";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 200, Format: Url</summary>
        public const string Photourl = "photourl";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: position</summary>
        public const string PositionId = "positionid";
        /// <summary>Type: Picklist, RequiredLevel: None, DisplayName: Preferred Address, OptionSetType: Picklist, DefaultFormValue: 1</summary>
        public const string PreferredAddressCode = "preferredaddresscode";
        /// <summary>Type: Picklist, RequiredLevel: None, DisplayName: Preferred Email, OptionSetType: Picklist, DefaultFormValue: 1</summary>
        public const string PreferredEMailCode = "preferredemailcode";
        /// <summary>Type: Picklist, RequiredLevel: None, DisplayName: Preferred Phone, OptionSetType: Picklist, DefaultFormValue: 1</summary>
        public const string PreferredPhoneCode = "preferredphonecode";
        /// <summary>Type: String, RequiredLevel: SystemRequired, MaxLength: 100, Format: Email</summary>
        public const string InternalEMailAddress = "internalemailaddress";
        /// <summary>Type: Picklist, RequiredLevel: SystemRequired, DisplayName: Shows whether the email address is approved for each mailbox for processing email through server-side synchronization or the Email Router., OptionSetType: Picklist, DefaultFormValue: 0</summary>
        public const string EMailRouteraccessapproval = "emailrouteraccessapproval";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: None</summary>
        public const string ProcessId = "processid";
        /// <summary>Type: Boolean, RequiredLevel: SystemRequired, True: 1, False: 0, DefaultValue: False</summary>
        public const string SetupUser = "setupuser";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 20, Format: Text</summary>
        public const string Salutation = "salutation";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 1024, Format: Text</summary>
        public const string SharepointeMailAddress = "sharepointemailaddress";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: site</summary>
        public const string SiteId = "siteid";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 100, Format: Text</summary>
        public const string Skills = "skills";
        /// <summary>Type: Boolean, RequiredLevel: None, True: 1, False: 0, DefaultValue: False</summary>
        public const string Isdisabled = "isdisabled";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: territory</summary>
        public const string TerritoryId = "territoryid";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 128, Format: Text</summary>
        public const string Title = "title";
        /// <summary>Type: Integer, RequiredLevel: SystemRequired, MinValue: -2147483648, MaxValue: 2147483647</summary>
        public const string IdEntityId = "identityid";
        /// <summary>Type: Integer, RequiredLevel: SystemRequired, MinValue: -2147483648, MaxValue: 2147483647</summary>
        public const string UserLicenseType = "userlicensetype";
        /// <summary>Type: Boolean, RequiredLevel: SystemRequired, True: 1, False: 0, DefaultValue: False</summary>
        public const string Islicensed = "islicensed";
        /// <summary>Type: String, RequiredLevel: SystemRequired, MaxLength: 1024, Format: Text</summary>
        public const string DomainName = "domainname";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 100, Format: Text</summary>
        public const string UserPuId = "userpuid";
        /// <summary>Type: Boolean, RequiredLevel: SystemRequired, True: 1, False: 0, DefaultValue: False</summary>
        public const string Issyncwithdirectory = "issyncwithdirectory";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 1024, Format: Email</summary>
        public const string WindowsliveId = "windowsliveid";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 200, Format: Email</summary>
        public const string YammereMailAddress = "yammeremailaddress";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 128, Format: Text</summary>
        public const string YammerUserId = "yammeruserid";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 64, Format: PhoneticGuide</summary>
        public const string YomiFirstName = "yomifirstname";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 200, Format: PhoneticGuide</summary>
        public const string YomiFullname = "yomifullname";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 64, Format: PhoneticGuide</summary>
        public const string YomiLastName = "yomilastname";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 50, Format: PhoneticGuide</summary>
        public const string YomiMiddleName = "yomimiddlename";

        #endregion Attributes

        #region OptionSets

        public enum Accessmode_OptionSet
        {
            ReadWrite = 0,
            Administrative = 1,
            Read = 2,
            SupportUser = 3,
            NonInteractive = 4,
            DelegatedAdmin = 5
        }
        public enum AzureState_OptionSet
        {
            Exists = 0,
            Softdeleted = 1,
            Notfoundorharddeleted = 2
        }
        public enum DeletedState_OptionSet
        {
            Notdeleted = 0,
            Softdeleted = 1
        }
        public enum IncomingeMailDeliveryMethod_OptionSet
        {
            None = 0,
            MicrosoftDynamics365forOutlook = 1,
            ServerSideSynchronizationorEMailRouter = 2,
            ForwardMailBox = 3
        }
        public enum InviteStatusCode_OptionSet
        {
            InvitationNotSent = 0,
            Invited = 1,
            InvitationNearExpired = 2,
            InvitationExpired = 3,
            InvitationAccepted = 4,
            InvitationRejected = 5,
            InvitationRevoked = 6
        }
        public enum CalType_OptionSet
        {
            Professional = 0,
            Administrative = 1,
            Basic = 2,
            DeviceProfessional = 3,
            DeviceBasic = 4,
            Essential = 5,
            DeviceEssential = 6,
            Enterprise = 7,
            DeviceEnterprise = 8,
            Sales = 9,
            Service = 10,
            FieldService = 11,
            ProjectService = 12
        }
        public enum OutgoingeMailDeliveryMethod_OptionSet
        {
            None = 0,
            MicrosoftDynamics365forOutlook = 1,
            ServerSideSynchronizationorEMailRouter = 2
        }
        public enum PreferredAddressCode_OptionSet
        {
            MailIngAddress = 1,
            OtherAddress = 2
        }
        public enum PreferredEMailCode_OptionSet
        {
            DefaultValue = 1
        }
        public enum PreferredPhoneCode_OptionSet
        {
            MainPhone = 1,
            OtherPhone = 2,
            HomePhone = 3,
            MobilePhone = 4
        }
        public enum EMailRouteraccessapproval_OptionSet
        {
            Empty = 0,
            Approved = 1,
            PendingApproval = 2,
            Rejected = 3
        }

        #endregion OptionSets
    }
}
