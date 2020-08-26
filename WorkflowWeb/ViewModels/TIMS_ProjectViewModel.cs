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
    public partial class TIMS_ProjectViewModel : BaseViewModel<TIMS_Project>, IValidatableObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID is required.")]
		[DisplayName("ID")]
		public Guid ID { get; set; }
		
		[Required(AllowEmptyStrings = false, ErrorMessage = "Name is required.")]
		[DisplayName("Name")]
		public String Name { get; set; }
		
		[DisplayName("TIMS_Project Action Item")]
		public List<TIMS_ProjectActionItemViewModel> TIMS_ProjectActionItem { get; set; }
		
		[DisplayName("TIMS_Project Area")]
		public List<TIMS_ProjectAreaViewModel> TIMS_ProjectArea { get; set; }
		
		[DisplayName("TIMS_Project Contractor")]
		public List<TIMS_ProjectContractorViewModel> TIMS_ProjectContractor { get; set; }
		
		[DisplayName("TIMS_Project Discipline")]
		public List<TIMS_ProjectDisciplineViewModel> TIMS_ProjectDiscipline { get; set; }
		
		[DisplayName("TIMS_Project Interface Point")]
		public List<TIMS_ProjectInterfacePointViewModel> TIMS_ProjectInterfacePoint { get; set; }
		
		[DisplayName("TIMS_Project Package")]
		public List<TIMS_ProjectPackageViewModel> TIMS_ProjectPackage { get; set; }
		
		[DisplayName("TIMS_Project Physical Area")]
		public List<TIMS_ProjectPhysicalAreaViewModel> TIMS_ProjectPhysicalArea { get; set; }
		
		[DisplayName("TIMS_User Role")]
		public List<TIMS_UserRoleViewModel> TIMS_UserRole { get; set; }
		
		[DisplayName("TIMS_Project Comment")]
		public List<TIMS_ProjectCommentViewModel> TIMS_ProjectComment { get; set; }
		
		[DisplayName("TIMS_Project Interface Agreement")]
		public List<TIMS_ProjectInterfaceAgreementViewModel> TIMS_ProjectInterfaceAgreement { get; set; }
		

        public TIMS_ProjectViewModel()
        {

        }

        public TIMS_ProjectViewModel(TIMS_Project m, bool convertSubs = false)
        {
            if (m != null)
            {
                this.ID = m.ID;
				this.Name = m.Name;
				this.TIMS_ProjectActionItem = convertSubs && m.TIMS_ProjectActionItem != null ? m.TIMS_ProjectActionItem.Select(x => new TIMS_ProjectActionItemViewModel(x)).ToList() : null;
				this.TIMS_ProjectArea = convertSubs && m.TIMS_ProjectArea != null ? m.TIMS_ProjectArea.Select(x => new TIMS_ProjectAreaViewModel(x)).ToList() : null;
				this.TIMS_ProjectContractor = convertSubs && m.TIMS_ProjectContractor != null ? m.TIMS_ProjectContractor.Select(x => new TIMS_ProjectContractorViewModel(x)).ToList() : null;
				this.TIMS_ProjectDiscipline = convertSubs && m.TIMS_ProjectDiscipline != null ? m.TIMS_ProjectDiscipline.Select(x => new TIMS_ProjectDisciplineViewModel(x)).ToList() : null;
				this.TIMS_ProjectInterfacePoint = convertSubs && m.TIMS_ProjectInterfacePoint != null ? m.TIMS_ProjectInterfacePoint.Select(x => new TIMS_ProjectInterfacePointViewModel(x)).ToList() : null;
				this.TIMS_ProjectPackage = convertSubs && m.TIMS_ProjectPackage != null ? m.TIMS_ProjectPackage.Select(x => new TIMS_ProjectPackageViewModel(x)).ToList() : null;
				this.TIMS_ProjectPhysicalArea = convertSubs && m.TIMS_ProjectPhysicalArea != null ? m.TIMS_ProjectPhysicalArea.Select(x => new TIMS_ProjectPhysicalAreaViewModel(x)).ToList() : null;
				this.TIMS_UserRole = convertSubs && m.TIMS_UserRole != null ? m.TIMS_UserRole.Select(x => new TIMS_UserRoleViewModel(x)).ToList() : null;
				this.TIMS_ProjectComment = convertSubs && m.TIMS_ProjectComment != null ? m.TIMS_ProjectComment.Select(x => new TIMS_ProjectCommentViewModel(x)).ToList() : null;
				this.TIMS_ProjectInterfaceAgreement = convertSubs && m.TIMS_ProjectInterfaceAgreement != null ? m.TIMS_ProjectInterfaceAgreement.Select(x => new TIMS_ProjectInterfaceAgreementViewModel(x)).ToList() : null;
            }
        }

        public override TIMS_Project ToModel(bool convertSubs = false)
        {
            var m = new TIMS_Project();

            m.ID = this.ID;
			m.Name = this.Name;
			m.TIMS_ProjectActionItem = convertSubs && this.TIMS_ProjectActionItem != null  ? this.TIMS_ProjectActionItem.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_ProjectArea = convertSubs && this.TIMS_ProjectArea != null  ? this.TIMS_ProjectArea.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_ProjectContractor = convertSubs && this.TIMS_ProjectContractor != null  ? this.TIMS_ProjectContractor.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_ProjectDiscipline = convertSubs && this.TIMS_ProjectDiscipline != null  ? this.TIMS_ProjectDiscipline.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_ProjectInterfacePoint = convertSubs && this.TIMS_ProjectInterfacePoint != null  ? this.TIMS_ProjectInterfacePoint.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_ProjectPackage = convertSubs && this.TIMS_ProjectPackage != null  ? this.TIMS_ProjectPackage.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_ProjectPhysicalArea = convertSubs && this.TIMS_ProjectPhysicalArea != null  ? this.TIMS_ProjectPhysicalArea.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_UserRole = convertSubs && this.TIMS_UserRole != null  ? this.TIMS_UserRole.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_ProjectComment = convertSubs && this.TIMS_ProjectComment != null  ? this.TIMS_ProjectComment.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_ProjectInterfaceAgreement = convertSubs && this.TIMS_ProjectInterfaceAgreement != null  ? this.TIMS_ProjectInterfaceAgreement.Select(x => x.ToModel()).ToList() : null;

            return m;
        }

        public override BaseViewModel<TIMS_Project> FromModel<M>(M mo, bool convertSubs)
        {
            var m = mo as TIMS_Project;
            if (m != null)
            {
                this.ID = m.ID;
				this.Name = m.Name;
				this.TIMS_ProjectActionItem = convertSubs && m.TIMS_ProjectActionItem != null ? m.TIMS_ProjectActionItem.Select(x => new TIMS_ProjectActionItemViewModel(x)).ToList() : null;
				this.TIMS_ProjectArea = convertSubs && m.TIMS_ProjectArea != null ? m.TIMS_ProjectArea.Select(x => new TIMS_ProjectAreaViewModel(x)).ToList() : null;
				this.TIMS_ProjectContractor = convertSubs && m.TIMS_ProjectContractor != null ? m.TIMS_ProjectContractor.Select(x => new TIMS_ProjectContractorViewModel(x)).ToList() : null;
				this.TIMS_ProjectDiscipline = convertSubs && m.TIMS_ProjectDiscipline != null ? m.TIMS_ProjectDiscipline.Select(x => new TIMS_ProjectDisciplineViewModel(x)).ToList() : null;
				this.TIMS_ProjectInterfacePoint = convertSubs && m.TIMS_ProjectInterfacePoint != null ? m.TIMS_ProjectInterfacePoint.Select(x => new TIMS_ProjectInterfacePointViewModel(x)).ToList() : null;
				this.TIMS_ProjectPackage = convertSubs && m.TIMS_ProjectPackage != null ? m.TIMS_ProjectPackage.Select(x => new TIMS_ProjectPackageViewModel(x)).ToList() : null;
				this.TIMS_ProjectPhysicalArea = convertSubs && m.TIMS_ProjectPhysicalArea != null ? m.TIMS_ProjectPhysicalArea.Select(x => new TIMS_ProjectPhysicalAreaViewModel(x)).ToList() : null;
				this.TIMS_UserRole = convertSubs && m.TIMS_UserRole != null ? m.TIMS_UserRole.Select(x => new TIMS_UserRoleViewModel(x)).ToList() : null;
				this.TIMS_ProjectComment = convertSubs && m.TIMS_ProjectComment != null ? m.TIMS_ProjectComment.Select(x => new TIMS_ProjectCommentViewModel(x)).ToList() : null;
				this.TIMS_ProjectInterfaceAgreement = convertSubs && m.TIMS_ProjectInterfaceAgreement != null ? m.TIMS_ProjectInterfaceAgreement.Select(x => new TIMS_ProjectInterfaceAgreementViewModel(x)).ToList() : null;
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