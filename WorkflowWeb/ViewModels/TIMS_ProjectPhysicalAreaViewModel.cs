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
    public class TIMS_ProjectPhysicalAreaViewModel : IValidatableObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID is required.")]
		[DisplayName("ID")]
		public Guid ID { get; set; }
		
		[Required(AllowEmptyStrings = false, ErrorMessage = "Name is required.")]
		[DisplayName("Name")]
		public String Name { get; set; }
		
		[DisplayName("Project ID")]
		public Guid? ProjectID { get; set; }
		
		[DisplayName("TIMS_Project")]
		public TIMS_ProjectViewModel TIMS_Project { get; set; }
		
		[DisplayName("TIMS_Project Interface Point Workflow")]
		public List<TIMS_ProjectInterfacePointWorkflowViewModel> TIMS_ProjectInterfacePointWorkflow { get; set; }
		

        public TIMS_ProjectPhysicalAreaViewModel()
        {

        }

        public TIMS_ProjectPhysicalAreaViewModel(TIMS_ProjectPhysicalArea m, bool convertSubs = false)
        {
            if (m != null)
            {
                this.ID = m.ID;
				this.Name = m.Name;
				this.ProjectID = m.ProjectID;
				this.TIMS_Project = convertSubs ? new TIMS_ProjectViewModel(m.TIMS_Project) : null;
				this.TIMS_ProjectInterfacePointWorkflow = convertSubs && m.TIMS_ProjectInterfacePointWorkflow != null ? m.TIMS_ProjectInterfacePointWorkflow.Select(x => new TIMS_ProjectInterfacePointWorkflowViewModel(x)).ToList() : null;
            }
        }

        public TIMS_ProjectPhysicalArea ToModel(bool convertSubs = false)
        {
            var m = new TIMS_ProjectPhysicalArea();

            m.ID = this.ID;
			m.Name = this.Name;
			m.ProjectID = this.ProjectID;
			m.TIMS_Project = convertSubs ? this.TIMS_Project.ToModel() : null;
			m.TIMS_ProjectInterfacePointWorkflow = convertSubs ? this.TIMS_ProjectInterfacePointWorkflow.Select(x => x.ToModel()).ToList() : null;

            return m;
        }

        public string ToRouteFilter()
        {
            var route_filter = JsonConvert.SerializeObject(new { ID,Name,ProjectID });
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