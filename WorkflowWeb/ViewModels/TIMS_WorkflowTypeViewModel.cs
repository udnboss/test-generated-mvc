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
    public partial class TIMS_WorkflowTypeViewModel : BaseViewModel<TIMS_WorkflowType>, IValidatableObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID is required.")]
		[DisplayName("ID")]
		public String ID { get; set; }
		
		[Required(AllowEmptyStrings = false, ErrorMessage = "Name is required.")]
		[DisplayName("Name")]
		public String Name { get; set; }
		
		[DisplayName("TIMS_Project Action Item Workflow")]
		public List<TIMS_ProjectActionItemWorkflowViewModel> TIMS_ProjectActionItemWorkflow { get; set; }
		
		[DisplayName("TIMS_Project Interface Agreement Workflow")]
		public List<TIMS_ProjectInterfaceAgreementWorkflowViewModel> TIMS_ProjectInterfaceAgreementWorkflow { get; set; }
		
		[DisplayName("TIMS_Project Interface Point Workflow")]
		public List<TIMS_ProjectInterfacePointWorkflowViewModel> TIMS_ProjectInterfacePointWorkflow { get; set; }
		

        public TIMS_WorkflowTypeViewModel()
        {

        }

        public TIMS_WorkflowTypeViewModel(TIMS_WorkflowType m, bool convertSubs = false)
        {
            if (m != null)
            {
                this.ID = m.ID;
				this.Name = m.Name;
				this.TIMS_ProjectActionItemWorkflow = convertSubs && m.TIMS_ProjectActionItemWorkflow != null ? m.TIMS_ProjectActionItemWorkflow.Select(x => new TIMS_ProjectActionItemWorkflowViewModel(x)).ToList() : null;
				this.TIMS_ProjectInterfaceAgreementWorkflow = convertSubs && m.TIMS_ProjectInterfaceAgreementWorkflow != null ? m.TIMS_ProjectInterfaceAgreementWorkflow.Select(x => new TIMS_ProjectInterfaceAgreementWorkflowViewModel(x)).ToList() : null;
				this.TIMS_ProjectInterfacePointWorkflow = convertSubs && m.TIMS_ProjectInterfacePointWorkflow != null ? m.TIMS_ProjectInterfacePointWorkflow.Select(x => new TIMS_ProjectInterfacePointWorkflowViewModel(x)).ToList() : null;
            }
        }

        public override TIMS_WorkflowType ToModel(bool convertSubs = false)
        {
            var m = new TIMS_WorkflowType();

            m.ID = this.ID;
			m.Name = this.Name;
			m.TIMS_ProjectActionItemWorkflow = convertSubs && this.TIMS_ProjectActionItemWorkflow != null  ? this.TIMS_ProjectActionItemWorkflow.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_ProjectInterfaceAgreementWorkflow = convertSubs && this.TIMS_ProjectInterfaceAgreementWorkflow != null  ? this.TIMS_ProjectInterfaceAgreementWorkflow.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_ProjectInterfacePointWorkflow = convertSubs && this.TIMS_ProjectInterfacePointWorkflow != null  ? this.TIMS_ProjectInterfacePointWorkflow.Select(x => x.ToModel()).ToList() : null;

            return m;
        }

        public override BaseViewModel<TIMS_WorkflowType> FromModel<M>(M mo, bool convertSubs)
        {
            var m = mo as TIMS_WorkflowType;
            if (m != null)
            {
                this.ID = m.ID;
				this.Name = m.Name;
				this.TIMS_ProjectActionItemWorkflow = convertSubs && m.TIMS_ProjectActionItemWorkflow != null ? m.TIMS_ProjectActionItemWorkflow.Select(x => new TIMS_ProjectActionItemWorkflowViewModel(x)).ToList() : null;
				this.TIMS_ProjectInterfaceAgreementWorkflow = convertSubs && m.TIMS_ProjectInterfaceAgreementWorkflow != null ? m.TIMS_ProjectInterfaceAgreementWorkflow.Select(x => new TIMS_ProjectInterfaceAgreementWorkflowViewModel(x)).ToList() : null;
				this.TIMS_ProjectInterfacePointWorkflow = convertSubs && m.TIMS_ProjectInterfacePointWorkflow != null ? m.TIMS_ProjectInterfacePointWorkflow.Select(x => new TIMS_ProjectInterfacePointWorkflowViewModel(x)).ToList() : null;
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