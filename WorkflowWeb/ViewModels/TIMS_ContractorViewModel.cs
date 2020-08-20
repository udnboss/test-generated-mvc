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
    public class TIMS_ContractorViewModel : IValidatableObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID is required.")]
		[DisplayName("ID")]
		public Guid ID { get; set; }
		
		[Required(AllowEmptyStrings = false, ErrorMessage = "Name is required.")]
		[DisplayName("Name")]
		public String Name { get; set; }
		
		[DisplayName("TIMS_Project Contractor")]
		public List<TIMS_ProjectContractorViewModel> TIMS_ProjectContractor { get; set; }
		

        public TIMS_ContractorViewModel()
        {

        }

        public TIMS_ContractorViewModel(TIMS_Contractor m, bool convertSubs = false)
        {
            if (m != null)
            {
                this.ID = m.ID;
				this.Name = m.Name;
				this.TIMS_ProjectContractor = convertSubs && m.TIMS_ProjectContractor != null ? m.TIMS_ProjectContractor.Select(x => new TIMS_ProjectContractorViewModel(x)).ToList() : null;
            }
        }

        public TIMS_Contractor ToModel(bool convertSubs = false)
        {
            var m = new TIMS_Contractor();

            m.ID = this.ID;
			m.Name = this.Name;
			m.TIMS_ProjectContractor = convertSubs ? this.TIMS_ProjectContractor.Select(x => x.ToModel()).ToList() : null;

            return m;
        }

        public string ToRouteFilter()
        {
            var route_filter = JsonConvert.SerializeObject(new { ID,Name });
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