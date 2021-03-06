using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;
using WorkflowWeb.Models;

namespace WorkflowWeb.ViewModels
{
    public partial class TIMS_ProjectPackageViewModel : BaseViewModel<TIMS_ProjectPackage>, IValidatableObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID is required.")]
		[DisplayName("ID")]
		public Guid ID { get; set; }
		
		[Required(AllowEmptyStrings = false, ErrorMessage = "Name is required.")]
		[DisplayName("Name")]
		public String Name { get; set; }
		
		[DisplayName("Project")]
		public Guid? ProjectID { get; set; }
		
		[DisplayName("Project Contractor")]
		public Guid? ProjectContractorID { get; set; }
		
		[DisplayName("TIMS_Project")]
		public TIMS_ProjectViewModel TIMS_Project { get; set; }
		
		[DisplayName("TIMS_Project Attachment")]
		[JsonIgnore]
		public List<TIMS_ProjectAttachmentViewModel> TIMS_ProjectAttachment { get; set; }
		
		[DisplayName("TIMS_Project Contractor")]
		public TIMS_ProjectContractorViewModel TIMS_ProjectContractor { get; set; }
		
		[DisplayName("TIMS_Project Interface Agreement")]
		[JsonIgnore]
		public List<TIMS_ProjectInterfaceAgreementViewModel> TIMS_ProjectInterfaceAgreement { get; set; }
		
		[DisplayName("TIMS_Project Interface Agreement1")]
		[JsonIgnore]
		public List<TIMS_ProjectInterfaceAgreementViewModel> TIMS_ProjectInterfaceAgreement1 { get; set; }
		
		[DisplayName("TIMS_Project Interface Point")]
		[JsonIgnore]
		public List<TIMS_ProjectInterfacePointViewModel> TIMS_ProjectInterfacePoint { get; set; }
		
		[DisplayName("TIMS_Project Interface Point1")]
		[JsonIgnore]
		public List<TIMS_ProjectInterfacePointViewModel> TIMS_ProjectInterfacePoint1 { get; set; }
		
		[DisplayName("TIMS_Project Interface Point2")]
		[JsonIgnore]
		public List<TIMS_ProjectInterfacePointViewModel> TIMS_ProjectInterfacePoint2 { get; set; }
		
		[DisplayName("TIMS_User Role")]
		[JsonIgnore]
		public List<TIMS_UserRoleViewModel> TIMS_UserRole { get; set; }
		

        public TIMS_ProjectPackageViewModel()
        {

        }

        public TIMS_ProjectPackageViewModel(TIMS_ProjectPackage m, bool convertSubs = false)
        {
            if (m != null)
            {
                this.ID = m.ID;
				this.Name = m.Name;
				this.ProjectID = m.ProjectID;
				this.ProjectContractorID = m.ProjectContractorID;
				this.TIMS_Project = convertSubs ? new TIMS_ProjectViewModel(m.TIMS_Project) : null;
				this.TIMS_ProjectAttachment = convertSubs && m.TIMS_ProjectAttachment != null ? m.TIMS_ProjectAttachment.Select(x => new TIMS_ProjectAttachmentViewModel(x)).ToList() : null;
				this.TIMS_ProjectContractor = convertSubs ? new TIMS_ProjectContractorViewModel(m.TIMS_ProjectContractor) : null;
				this.TIMS_ProjectInterfaceAgreement = convertSubs && m.TIMS_ProjectInterfaceAgreement != null ? m.TIMS_ProjectInterfaceAgreement.Select(x => new TIMS_ProjectInterfaceAgreementViewModel(x)).ToList() : null;
				this.TIMS_ProjectInterfaceAgreement1 = convertSubs && m.TIMS_ProjectInterfaceAgreement1 != null ? m.TIMS_ProjectInterfaceAgreement1.Select(x => new TIMS_ProjectInterfaceAgreementViewModel(x)).ToList() : null;
				this.TIMS_ProjectInterfacePoint = convertSubs && m.TIMS_ProjectInterfacePoint != null ? m.TIMS_ProjectInterfacePoint.Select(x => new TIMS_ProjectInterfacePointViewModel(x)).ToList() : null;
				this.TIMS_ProjectInterfacePoint1 = convertSubs && m.TIMS_ProjectInterfacePoint1 != null ? m.TIMS_ProjectInterfacePoint1.Select(x => new TIMS_ProjectInterfacePointViewModel(x)).ToList() : null;
				this.TIMS_ProjectInterfacePoint2 = convertSubs && m.TIMS_ProjectInterfacePoint2 != null ? m.TIMS_ProjectInterfacePoint2.Select(x => new TIMS_ProjectInterfacePointViewModel(x)).ToList() : null;
				this.TIMS_UserRole = convertSubs && m.TIMS_UserRole != null ? m.TIMS_UserRole.Select(x => new TIMS_UserRoleViewModel(x)).ToList() : null;
            }
        }

        public override TIMS_ProjectPackage ToModel(bool convertSubs = false)
        {
            var m = new TIMS_ProjectPackage();

            m.ID = this.ID;
			m.Name = this.Name;
			m.ProjectID = this.ProjectID;
			m.ProjectContractorID = this.ProjectContractorID;
			m.TIMS_Project = convertSubs && this.TIMS_Project != null ?  this.TIMS_Project.ToModel() : null;
			m.TIMS_ProjectAttachment = convertSubs && this.TIMS_ProjectAttachment != null  ? this.TIMS_ProjectAttachment.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_ProjectContractor = convertSubs && this.TIMS_ProjectContractor != null ?  this.TIMS_ProjectContractor.ToModel() : null;
			m.TIMS_ProjectInterfaceAgreement = convertSubs && this.TIMS_ProjectInterfaceAgreement != null  ? this.TIMS_ProjectInterfaceAgreement.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_ProjectInterfaceAgreement1 = convertSubs && this.TIMS_ProjectInterfaceAgreement1 != null  ? this.TIMS_ProjectInterfaceAgreement1.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_ProjectInterfacePoint = convertSubs && this.TIMS_ProjectInterfacePoint != null  ? this.TIMS_ProjectInterfacePoint.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_ProjectInterfacePoint1 = convertSubs && this.TIMS_ProjectInterfacePoint1 != null  ? this.TIMS_ProjectInterfacePoint1.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_ProjectInterfacePoint2 = convertSubs && this.TIMS_ProjectInterfacePoint2 != null  ? this.TIMS_ProjectInterfacePoint2.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_UserRole = convertSubs && this.TIMS_UserRole != null  ? this.TIMS_UserRole.Select(x => x.ToModel()).ToList() : null;

            return m;
        }

        public override BaseViewModel<TIMS_ProjectPackage> FromModel<M>(M mo, bool convertSubs)
        {
            var m = mo as TIMS_ProjectPackage;
            if (m != null)
            {
                this.ID = m.ID;
				this.Name = m.Name;
				this.ProjectID = m.ProjectID;
				this.ProjectContractorID = m.ProjectContractorID;
				this.TIMS_Project = convertSubs ? new TIMS_ProjectViewModel(m.TIMS_Project) : null;
				this.TIMS_ProjectAttachment = convertSubs && m.TIMS_ProjectAttachment != null ? m.TIMS_ProjectAttachment.Select(x => new TIMS_ProjectAttachmentViewModel(x)).ToList() : null;
				this.TIMS_ProjectContractor = convertSubs ? new TIMS_ProjectContractorViewModel(m.TIMS_ProjectContractor) : null;
				this.TIMS_ProjectInterfaceAgreement = convertSubs && m.TIMS_ProjectInterfaceAgreement != null ? m.TIMS_ProjectInterfaceAgreement.Select(x => new TIMS_ProjectInterfaceAgreementViewModel(x)).ToList() : null;
				this.TIMS_ProjectInterfaceAgreement1 = convertSubs && m.TIMS_ProjectInterfaceAgreement1 != null ? m.TIMS_ProjectInterfaceAgreement1.Select(x => new TIMS_ProjectInterfaceAgreementViewModel(x)).ToList() : null;
				this.TIMS_ProjectInterfacePoint = convertSubs && m.TIMS_ProjectInterfacePoint != null ? m.TIMS_ProjectInterfacePoint.Select(x => new TIMS_ProjectInterfacePointViewModel(x)).ToList() : null;
				this.TIMS_ProjectInterfacePoint1 = convertSubs && m.TIMS_ProjectInterfacePoint1 != null ? m.TIMS_ProjectInterfacePoint1.Select(x => new TIMS_ProjectInterfacePointViewModel(x)).ToList() : null;
				this.TIMS_ProjectInterfacePoint2 = convertSubs && m.TIMS_ProjectInterfacePoint2 != null ? m.TIMS_ProjectInterfacePoint2.Select(x => new TIMS_ProjectInterfacePointViewModel(x)).ToList() : null;
				this.TIMS_UserRole = convertSubs && m.TIMS_UserRole != null ? m.TIMS_UserRole.Select(x => new TIMS_UserRoleViewModel(x)).ToList() : null;
            }

            return this;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            

            return errors.AsEnumerable();
        }
    }

}