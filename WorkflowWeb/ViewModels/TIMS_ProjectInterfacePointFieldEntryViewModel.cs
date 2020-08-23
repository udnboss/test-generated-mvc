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
    public partial class TIMS_ProjectInterfacePointFieldEntryViewModel : BaseViewModel<TIMS_ProjectInterfacePointFieldEntry>, IValidatableObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID is required.")]
		[DisplayName("ID")]
		public Guid ID { get; set; }
		
		[DisplayName("Interface Point Workflow")]
		public Guid? InterfacePointWorkflowID { get; set; }
		
		[DisplayName("Interface Type Field")]
		public Guid? InterfaceTypeFieldID { get; set; }
		
		[DisplayName("Value")]
		public String Value { get; set; }
		
		[DisplayName("TIMS_Project Discipline Interface Type Field")]
		public TIMS_ProjectDisciplineInterfaceTypeFieldViewModel TIMS_ProjectDisciplineInterfaceTypeField { get; set; }
		
		[DisplayName("TIMS_Project Interface Point Workflow")]
		public TIMS_ProjectInterfacePointWorkflowViewModel TIMS_ProjectInterfacePointWorkflow { get; set; }
		

        public TIMS_ProjectInterfacePointFieldEntryViewModel()
        {

        }

        public TIMS_ProjectInterfacePointFieldEntryViewModel(TIMS_ProjectInterfacePointFieldEntry m, bool convertSubs = false)
        {
            if (m != null)
            {
                this.ID = m.ID;
				this.InterfacePointWorkflowID = m.InterfacePointWorkflowID;
				this.InterfaceTypeFieldID = m.InterfaceTypeFieldID;
				this.Value = m.Value;
				this.TIMS_ProjectDisciplineInterfaceTypeField = convertSubs ? new TIMS_ProjectDisciplineInterfaceTypeFieldViewModel(m.TIMS_ProjectDisciplineInterfaceTypeField) : null;
				this.TIMS_ProjectInterfacePointWorkflow = convertSubs ? new TIMS_ProjectInterfacePointWorkflowViewModel(m.TIMS_ProjectInterfacePointWorkflow) : null;
            }
        }

        public override TIMS_ProjectInterfacePointFieldEntry ToModel(bool convertSubs = false)
        {
            var m = new TIMS_ProjectInterfacePointFieldEntry();

            m.ID = this.ID;
			m.InterfacePointWorkflowID = this.InterfacePointWorkflowID;
			m.InterfaceTypeFieldID = this.InterfaceTypeFieldID;
			m.Value = this.Value;
			m.TIMS_ProjectDisciplineInterfaceTypeField = convertSubs && this.TIMS_ProjectDisciplineInterfaceTypeField != null ?  this.TIMS_ProjectDisciplineInterfaceTypeField.ToModel() : null;
			m.TIMS_ProjectInterfacePointWorkflow = convertSubs && this.TIMS_ProjectInterfacePointWorkflow != null ?  this.TIMS_ProjectInterfacePointWorkflow.ToModel() : null;

            return m;
        }

        public override BaseViewModel<TIMS_ProjectInterfacePointFieldEntry> FromModel<M>(M mo, bool convertSubs)
        {
            var m = mo as TIMS_ProjectInterfacePointFieldEntry;
            if (m != null)
            {
                this.ID = m.ID;
				this.InterfacePointWorkflowID = m.InterfacePointWorkflowID;
				this.InterfaceTypeFieldID = m.InterfaceTypeFieldID;
				this.Value = m.Value;
				this.TIMS_ProjectDisciplineInterfaceTypeField = convertSubs ? new TIMS_ProjectDisciplineInterfaceTypeFieldViewModel(m.TIMS_ProjectDisciplineInterfaceTypeField) : null;
				this.TIMS_ProjectInterfacePointWorkflow = convertSubs ? new TIMS_ProjectInterfacePointWorkflowViewModel(m.TIMS_ProjectInterfacePointWorkflow) : null;
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