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
    public partial class TIMS_ProjectDisciplineViewModel : BaseViewModel<TIMS_ProjectDiscipline>, IValidatableObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID is required.")]
		[DisplayName("ID")]
		public Guid ID { get; set; }
		
		[Required(AllowEmptyStrings = false, ErrorMessage = "Name is required.")]
		[DisplayName("Name")]
		public String Name { get; set; }
		
		[DisplayName("Project")]
		public Guid? ProjectID { get; set; }
		
		[DisplayName("Discipline")]
		public Guid? DisciplineID { get; set; }
		
		[DisplayName("TIMS_Discipline")]
		public TIMS_DisciplineViewModel TIMS_Discipline { get; set; }
		
		[DisplayName("TIMS_Project")]
		public TIMS_ProjectViewModel TIMS_Project { get; set; }
		
		[DisplayName("TIMS_Project Discipline Interface Type")]
		[JsonIgnore]
		public List<TIMS_ProjectDisciplineInterfaceTypeViewModel> TIMS_ProjectDisciplineInterfaceType { get; set; }
		
		[DisplayName("TIMS_Project Interface Agreement Workflow")]
		[JsonIgnore]
		public List<TIMS_ProjectInterfaceAgreementWorkflowViewModel> TIMS_ProjectInterfaceAgreementWorkflow { get; set; }
		

        public TIMS_ProjectDisciplineViewModel()
        {

        }

        public TIMS_ProjectDisciplineViewModel(TIMS_ProjectDiscipline m, bool convertSubs = false)
        {
            if (m != null)
            {
                this.ID = m.ID;
				this.Name = m.Name;
				this.ProjectID = m.ProjectID;
				this.DisciplineID = m.DisciplineID;
				this.TIMS_Discipline = convertSubs ? new TIMS_DisciplineViewModel(m.TIMS_Discipline) : null;
				this.TIMS_Project = convertSubs ? new TIMS_ProjectViewModel(m.TIMS_Project) : null;
				this.TIMS_ProjectDisciplineInterfaceType = convertSubs && m.TIMS_ProjectDisciplineInterfaceType != null ? m.TIMS_ProjectDisciplineInterfaceType.Select(x => new TIMS_ProjectDisciplineInterfaceTypeViewModel(x)).ToList() : null;
				this.TIMS_ProjectInterfaceAgreementWorkflow = convertSubs && m.TIMS_ProjectInterfaceAgreementWorkflow != null ? m.TIMS_ProjectInterfaceAgreementWorkflow.Select(x => new TIMS_ProjectInterfaceAgreementWorkflowViewModel(x)).ToList() : null;
            }
        }

        public override TIMS_ProjectDiscipline ToModel(bool convertSubs = false)
        {
            var m = new TIMS_ProjectDiscipline();

            m.ID = this.ID;
			m.Name = this.Name;
			m.ProjectID = this.ProjectID;
			m.DisciplineID = this.DisciplineID;
			m.TIMS_Discipline = convertSubs && this.TIMS_Discipline != null ?  this.TIMS_Discipline.ToModel() : null;
			m.TIMS_Project = convertSubs && this.TIMS_Project != null ?  this.TIMS_Project.ToModel() : null;
			m.TIMS_ProjectDisciplineInterfaceType = convertSubs && this.TIMS_ProjectDisciplineInterfaceType != null  ? this.TIMS_ProjectDisciplineInterfaceType.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_ProjectInterfaceAgreementWorkflow = convertSubs && this.TIMS_ProjectInterfaceAgreementWorkflow != null  ? this.TIMS_ProjectInterfaceAgreementWorkflow.Select(x => x.ToModel()).ToList() : null;

            return m;
        }

        public override BaseViewModel<TIMS_ProjectDiscipline> FromModel<M>(M mo, bool convertSubs)
        {
            var m = mo as TIMS_ProjectDiscipline;
            if (m != null)
            {
                this.ID = m.ID;
				this.Name = m.Name;
				this.ProjectID = m.ProjectID;
				this.DisciplineID = m.DisciplineID;
				this.TIMS_Discipline = convertSubs ? new TIMS_DisciplineViewModel(m.TIMS_Discipline) : null;
				this.TIMS_Project = convertSubs ? new TIMS_ProjectViewModel(m.TIMS_Project) : null;
				this.TIMS_ProjectDisciplineInterfaceType = convertSubs && m.TIMS_ProjectDisciplineInterfaceType != null ? m.TIMS_ProjectDisciplineInterfaceType.Select(x => new TIMS_ProjectDisciplineInterfaceTypeViewModel(x)).ToList() : null;
				this.TIMS_ProjectInterfaceAgreementWorkflow = convertSubs && m.TIMS_ProjectInterfaceAgreementWorkflow != null ? m.TIMS_ProjectInterfaceAgreementWorkflow.Select(x => new TIMS_ProjectInterfaceAgreementWorkflowViewModel(x)).ToList() : null;
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