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
    public partial class TIMS_WorkflowActionViewModel : BaseViewModel<TIMS_WorkflowAction>, IValidatableObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID is required.")]
		[DisplayName("ID")]
		public String ID { get; set; }
		
		[Required(AllowEmptyStrings = false, ErrorMessage = "Name is required.")]
		[DisplayName("Name")]
		public String Name { get; set; }
		

        public TIMS_WorkflowActionViewModel()
        {

        }

        public TIMS_WorkflowActionViewModel(TIMS_WorkflowAction m, bool convertSubs = false)
        {
            if (m != null)
            {
                this.ID = m.ID;
				this.Name = m.Name;
            }
        }

        public override TIMS_WorkflowAction ToModel(bool convertSubs = false)
        {
            var m = new TIMS_WorkflowAction();

            m.ID = this.ID;
			m.Name = this.Name;

            return m;
        }

        public override BaseViewModel<TIMS_WorkflowAction> FromModel<M>(M mo, bool convertSubs)
        {
            var m = mo as TIMS_WorkflowAction;
            if (m != null)
            {
                this.ID = m.ID;
				this.Name = m.Name;
            }

            return this;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ID == null)
            {
                yield return new ValidationResult("Error", new string[] { "Error Detail" });
            }
        }
    }

}