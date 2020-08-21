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
    public class TIMS_WorkflowStateViewModel : IValidatableObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID is required.")]
		[DisplayName("ID")]
		public String ID { get; set; }
		
		[Required(AllowEmptyStrings = false, ErrorMessage = "Name is required.")]
		[DisplayName("Name")]
		public String Name { get; set; }
		
		[DisplayName("TIMS_Project Interface Point Workflow")]
		public List<TIMS_ProjectInterfacePointWorkflowViewModel> TIMS_ProjectInterfacePointWorkflow { get; set; }
		
		[DisplayName("TIMS_Project Interface Point Workflow1")]
		public List<TIMS_ProjectInterfacePointWorkflowViewModel> TIMS_ProjectInterfacePointWorkflow1 { get; set; }
		
		[DisplayName("TIMS_Project Interface Point Workflow2")]
		public List<TIMS_ProjectInterfacePointWorkflowViewModel> TIMS_ProjectInterfacePointWorkflow2 { get; set; }
		

        public TIMS_WorkflowStateViewModel()
        {

        }

        public TIMS_WorkflowStateViewModel(TIMS_WorkflowState m, bool convertSubs = false)
        {
            if (m != null)
            {
                this.ID = m.ID;
				this.Name = m.Name;
				this.TIMS_ProjectInterfacePointWorkflow = convertSubs && m.TIMS_ProjectInterfacePointWorkflow != null ? m.TIMS_ProjectInterfacePointWorkflow.Select(x => new TIMS_ProjectInterfacePointWorkflowViewModel(x)).ToList() : null;
				this.TIMS_ProjectInterfacePointWorkflow1 = convertSubs && m.TIMS_ProjectInterfacePointWorkflow1 != null ? m.TIMS_ProjectInterfacePointWorkflow1.Select(x => new TIMS_ProjectInterfacePointWorkflowViewModel(x)).ToList() : null;
				this.TIMS_ProjectInterfacePointWorkflow2 = convertSubs && m.TIMS_ProjectInterfacePointWorkflow2 != null ? m.TIMS_ProjectInterfacePointWorkflow2.Select(x => new TIMS_ProjectInterfacePointWorkflowViewModel(x)).ToList() : null;
            }
        }

        public TIMS_WorkflowState ToModel(bool convertSubs = false)
        {
            var m = new TIMS_WorkflowState();

            m.ID = this.ID;
			m.Name = this.Name;
			m.TIMS_ProjectInterfacePointWorkflow = convertSubs ? this.TIMS_ProjectInterfacePointWorkflow.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_ProjectInterfacePointWorkflow1 = convertSubs ? this.TIMS_ProjectInterfacePointWorkflow1.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_ProjectInterfacePointWorkflow2 = convertSubs ? this.TIMS_ProjectInterfacePointWorkflow2.Select(x => x.ToModel()).ToList() : null;

            return m;
        }

        public string ToRouteFilter()
        {
            var route_filter = JsonConvert.SerializeObject(new { ID, Name });
            var bytes = System.Text.Encoding.ASCII.GetBytes(route_filter);
            route_filter = Convert.ToBase64String(bytes);
            return route_filter;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ID == null)
            {
                yield return new ValidationResult("Error", new string[] { "Error Detail" });
            }
        }
    }

}