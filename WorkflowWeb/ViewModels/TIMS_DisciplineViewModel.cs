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
    public class TIMS_DisciplineViewModel : IValidatableObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID is required.")]
		[DisplayName("ID")]
		public Guid ID { get; set; }
		
		[Required(AllowEmptyStrings = false, ErrorMessage = "Name is required.")]
		[DisplayName("Name")]
		public String Name { get; set; }
		
		[DisplayName("TIMS_Project Discipline")]
		public List<TIMS_ProjectDisciplineViewModel> TIMS_ProjectDiscipline { get; set; }
		

        public TIMS_DisciplineViewModel()
        {

        }

        public TIMS_DisciplineViewModel(TIMS_Discipline m, bool convertSubs = false)
        {
            if (m != null)
            {
                this.ID = m.ID;
				this.Name = m.Name;
				this.TIMS_ProjectDiscipline = convertSubs && m.TIMS_ProjectDiscipline != null ? m.TIMS_ProjectDiscipline.Select(x => new TIMS_ProjectDisciplineViewModel(x)).ToList() : null;
            }
        }

        public TIMS_Discipline ToModel(bool convertSubs = false)
        {
            var m = new TIMS_Discipline();

            m.ID = this.ID;
			m.Name = this.Name;
			m.TIMS_ProjectDiscipline = convertSubs ? this.TIMS_ProjectDiscipline.Select(x => x.ToModel()).ToList() : null;

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