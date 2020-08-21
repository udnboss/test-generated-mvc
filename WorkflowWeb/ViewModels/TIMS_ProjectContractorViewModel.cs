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
    public class TIMS_ProjectContractorViewModel : IValidatableObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID is required.")]
		[DisplayName("ID")]
		public Guid ID { get; set; }
		
		[Required(AllowEmptyStrings = false, ErrorMessage = "Name is required.")]
		[DisplayName("Name")]
		public String Name { get; set; }
		
		[DisplayName("Project")]
		public Guid? ProjectID { get; set; }
		
		[DisplayName("Contractor")]
		public Guid? ContractorID { get; set; }
		
		[DisplayName("TIMS_Contractor")]
		public TIMS_ContractorViewModel TIMS_Contractor { get; set; }
		
		[DisplayName("TIMS_Project")]
		public TIMS_ProjectViewModel TIMS_Project { get; set; }
		
		[DisplayName("TIMS_Project Package")]
		public List<TIMS_ProjectPackageViewModel> TIMS_ProjectPackage { get; set; }
		

        public TIMS_ProjectContractorViewModel()
        {

        }

        public TIMS_ProjectContractorViewModel(TIMS_ProjectContractor m, bool convertSubs = false)
        {
            if (m != null)
            {
                this.ID = m.ID;
				this.Name = m.Name;
				this.ProjectID = m.ProjectID;
				this.ContractorID = m.ContractorID;
				this.TIMS_Contractor = convertSubs ? new TIMS_ContractorViewModel(m.TIMS_Contractor) : null;
				this.TIMS_Project = convertSubs ? new TIMS_ProjectViewModel(m.TIMS_Project) : null;
				this.TIMS_ProjectPackage = convertSubs && m.TIMS_ProjectPackage != null ? m.TIMS_ProjectPackage.Select(x => new TIMS_ProjectPackageViewModel(x)).ToList() : null;
            }
        }

        public TIMS_ProjectContractor ToModel(bool convertSubs = false)
        {
            var m = new TIMS_ProjectContractor();

            m.ID = this.ID;
			m.Name = this.Name;
			m.ProjectID = this.ProjectID;
			m.ContractorID = this.ContractorID;
			m.TIMS_Contractor = convertSubs ? this.TIMS_Contractor.ToModel() : null;
			m.TIMS_Project = convertSubs ? this.TIMS_Project.ToModel() : null;
			m.TIMS_ProjectPackage = convertSubs ? this.TIMS_ProjectPackage.Select(x => x.ToModel()).ToList() : null;

            return m;
        }

        public string ToRouteFilter()
        {
            var route_filter = JsonConvert.SerializeObject(new { ID, Name, ProjectID, ContractorID });
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