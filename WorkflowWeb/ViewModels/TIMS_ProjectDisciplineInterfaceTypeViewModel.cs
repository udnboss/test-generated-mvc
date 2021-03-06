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
    public partial class TIMS_ProjectDisciplineInterfaceTypeViewModel : BaseViewModel<TIMS_ProjectDisciplineInterfaceType>, IValidatableObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID is required.")]
		[DisplayName("ID")]
		public Guid ID { get; set; }
		
		[Required(AllowEmptyStrings = false, ErrorMessage = "Name is required.")]
		[DisplayName("Name")]
		public String Name { get; set; }
		
		[DisplayName("Project IDiscipline")]
		public Guid? ProjectIDisciplineID { get; set; }
		
		[DisplayName("TIMS_Project Discipline")]
		public TIMS_ProjectDisciplineViewModel TIMS_ProjectDiscipline { get; set; }
		
		[DisplayName("TIMS_Project Discipline Interface Type Field")]
		[JsonIgnore]
		public List<TIMS_ProjectDisciplineInterfaceTypeFieldViewModel> TIMS_ProjectDisciplineInterfaceTypeField { get; set; }
		
		[DisplayName("TIMS_Project Interface Point Workflow")]
		[JsonIgnore]
		public List<TIMS_ProjectInterfacePointWorkflowViewModel> TIMS_ProjectInterfacePointWorkflow { get; set; }
		

        public TIMS_ProjectDisciplineInterfaceTypeViewModel()
        {

        }

        public TIMS_ProjectDisciplineInterfaceTypeViewModel(TIMS_ProjectDisciplineInterfaceType m, bool convertSubs = false)
        {
            if (m != null)
            {
                this.ID = m.ID;
				this.Name = m.Name;
				this.ProjectIDisciplineID = m.ProjectIDisciplineID;
				this.TIMS_ProjectDiscipline = convertSubs ? new TIMS_ProjectDisciplineViewModel(m.TIMS_ProjectDiscipline) : null;
				this.TIMS_ProjectDisciplineInterfaceTypeField = convertSubs && m.TIMS_ProjectDisciplineInterfaceTypeField != null ? m.TIMS_ProjectDisciplineInterfaceTypeField.Select(x => new TIMS_ProjectDisciplineInterfaceTypeFieldViewModel(x)).ToList() : null;
				this.TIMS_ProjectInterfacePointWorkflow = convertSubs && m.TIMS_ProjectInterfacePointWorkflow != null ? m.TIMS_ProjectInterfacePointWorkflow.Select(x => new TIMS_ProjectInterfacePointWorkflowViewModel(x)).ToList() : null;
            }
        }

        public override TIMS_ProjectDisciplineInterfaceType ToModel(bool convertSubs = false)
        {
            var m = new TIMS_ProjectDisciplineInterfaceType();

            m.ID = this.ID;
			m.Name = this.Name;
			m.ProjectIDisciplineID = this.ProjectIDisciplineID;
			m.TIMS_ProjectDiscipline = convertSubs && this.TIMS_ProjectDiscipline != null ?  this.TIMS_ProjectDiscipline.ToModel() : null;
			m.TIMS_ProjectDisciplineInterfaceTypeField = convertSubs && this.TIMS_ProjectDisciplineInterfaceTypeField != null  ? this.TIMS_ProjectDisciplineInterfaceTypeField.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_ProjectInterfacePointWorkflow = convertSubs && this.TIMS_ProjectInterfacePointWorkflow != null  ? this.TIMS_ProjectInterfacePointWorkflow.Select(x => x.ToModel()).ToList() : null;

            return m;
        }

        public override BaseViewModel<TIMS_ProjectDisciplineInterfaceType> FromModel<M>(M mo, bool convertSubs)
        {
            var m = mo as TIMS_ProjectDisciplineInterfaceType;
            if (m != null)
            {
                this.ID = m.ID;
				this.Name = m.Name;
				this.ProjectIDisciplineID = m.ProjectIDisciplineID;
				this.TIMS_ProjectDiscipline = convertSubs ? new TIMS_ProjectDisciplineViewModel(m.TIMS_ProjectDiscipline) : null;
				this.TIMS_ProjectDisciplineInterfaceTypeField = convertSubs && m.TIMS_ProjectDisciplineInterfaceTypeField != null ? m.TIMS_ProjectDisciplineInterfaceTypeField.Select(x => new TIMS_ProjectDisciplineInterfaceTypeFieldViewModel(x)).ToList() : null;
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