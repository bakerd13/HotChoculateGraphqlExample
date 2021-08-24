using HotChoculate.Infrastructure.Data.Models.Common;
using System;

namespace HotChoculate.Infrastructure.Data.Models.EmployeeModels
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public Guid? EmployeeDataHubID { get; set; }
        public string EmployeeDataHubSourceID { get; set; }
        public string EmployeeDataHubSourceApplicationID { get; set; }
        public int? ApplicantID { get; set; }
        public Title Title { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeMiddleInitial { get; set; }
        public string EmployeeLastName { get; set; }
        public DateTime? EmployeeDateOfBirth { get; set; }
        public int? EmployeeEthnicOriginUniqueNumber { get; set; }
        public string EmployeeSSNNI { get; set; }
        public DateTime? EmployeeStartDate { get; set; }
        public DateTime? EmployeeTerminationDate { get; set; }
        public bool? EmployeeFullTime { get; set; }
        public bool? EmployeeDisabled { get; set; }
        public bool? EmployeeVirtual { get; set; }
        public bool? EmployeeVietnamVeteran { get; set; }
        public int EmployeePayrollRunUniqueNumber { get; set; }
        public short? EmployeeStatus { get; set; }
        public string EmployeeAddressLine1 { get; set; }
        public string EmployeeAddressLine2 { get; set; }
        public string EmployeeAddressLine3 { get; set; }
        public string EmployeeAddressCityTown { get; set; }
        public string EmployeeAddressCounty { get; set; }
        public string EmployeeAddressStateCode { get; set; }
        public string EmployeeAddressZipPostCode { get; set; }
        public string EmployeeContactHome { get; set; }
        public string EmployeeContactHomeNotes { get; set; }
        public string EmployeeContactCellMobile { get; set; }
        public string EmployeeContactCellMobileNotes { get; set; }
        public string EmployeeContactOther { get; set; }
        public string EmployeeContactOtherNotes { get; set; }
        public string EmployeeContactPager { get; set; }
        public string EmployeeContactPagerNotes { get; set; }
        public string EmployeeContactEmail { get; set; }
        public string EmployeeContactEmailNotes { get; set; }
        public DateTime? EmployeeImageUploadTimeStamp { get; set; }
        public string EmployeePinNumber { get; set; }
        public string EmployeeExternalID { get; set; }
        public string EmployeeBankAccountName { get; set; }
        public string EmployeeBankAccountNumber { get; set; }
        public string EmployeeBankAccountSortCode { get; set; }
        public int? EmployeeVacationSchemeUniqueNumber { get; set; }
        public string EmployeeBankAccountRoleNumber { get; set; }
        public int? EmployeeReligionUniqueNumber { get; set; }
        public string EmployeeBankName { get; set; }
        public bool? EmployeeHasMedicalCondition { get; set; }
        public int? EmployeeTitleUniqueNumber { get; set; }
        public int? EmployeeGenderUniqueNumber { get; set; }
        public int? EmployeeMaritalStatusUniqueNumber { get; set; }
        public int? EmployeeEmploymentReasonUniqueNumber { get; set; }
        public string EmployeePreferredName { get; set; }
        public bool? EmployeeTUPE { get; set; }
        public DateTime? EmployeeTUPEContinuousServiceDate { get; set; }
        public string EmployeeTUPENotes { get; set; }
        public int? EmployeeTerminologySchemeUniqueNumber { get; set; }
        public DateTime? EmployeeCreatedDateTime { get; set; }
        public int? EmployeeCreatedByUserInformationID { get; set; }
        public DateTime? EmployeeLastUpdatedDateTime { get; set; }
        public int? EmployeeLastUpdatedByUserInformationID { get; set; }
        public int? EmployeeRunUniqueNumber { get; set; }
        public long? EmployeeInfoCareEmployeeID { get; set; }
        public byte? EmployeeAddressValidated { get; set; }
        public byte? EmployeePostcodeValidated { get; set; }
        public int? EmployeeSexualityUniqueNumber { get; set; }
        public int? EmployeeNationalityUniqueNumber { get; set; }
        public int? EmployeeReasonableAdjustment { get; set; }
        public string EmployeeReasonableAdjustmentDetails { get; set; }
        public string EmployeeDisabledDetails { get; set; }
        public byte? EmployeeTimeSheetStatus { get; set; }
        public byte? EmployeeGrossPayslipStatus { get; set; }
        public string EmployeeMobileAppDeviceId { get; set; }
        public short? EmployeePayrollTypeUniqueNumber { get; set; }
        public string EmployeeNFCData { get; set; }
        public bool? EmployeeObfuscated { get; set; }
        public byte? EmployeeConsentStatus { get; set; }
        public DateTime? EmployeeConsentDate { get; set; }
        public string EmployeeConsentNotes { get; set; }
        public DateTime? EmployeeSageDetailsLastUpdated { get; set; }
        public int? EmployeeBreakRuleProfileTemplateId { get; set; }
        public Guid? WorkspaceUserId { get; set; }
    }
}
