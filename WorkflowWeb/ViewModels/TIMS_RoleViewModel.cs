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
    public partial class TIMS_RoleViewModel : BaseViewModel<TIMS_Role>, IValidatableObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID is required.")]
		[DisplayName("ID")]
		public Guid ID { get; set; }
		
		[Required(AllowEmptyStrings = false, ErrorMessage = "Name is required.")]
		[DisplayName("Name")]
		public String Name { get; set; }
		
		[DisplayName("TIMS_User Role")]
		public List<TIMS_UserRoleViewModel> TIMS_UserRole { get; set; }
		

        public TIMS_RoleViewModel()
        {

        }

        public TIMS_RoleViewModel(TIMS_Role m, bool convertSubs = false)
        {
            if (m != null)
            {
                this.ID = m.ID;
				this.Name = m.Name;
				this.TIMS_UserRole = convertSubs && m.TIMS_UserRole != null ? m.TIMS_UserRole.Select(x => new TIMS_UserRoleViewModel(x)).ToList() : null;
            }
        }

        public override TIMS_Role ToModel(bool convertSubs = false)
        {
            var m = new TIMS_Role();

            m.ID = this.ID;
			m.Name = this.Name;
			m.TIMS_UserRole = convertSubs && this.TIMS_UserRole != null  ? this.TIMS_UserRole.Select(x => x.ToModel()).ToList() : null;

            return m;
        }

        public override BaseViewModel<TIMS_Role> FromModel<M>(M mo, bool convertSubs)
        {
            var m = mo as TIMS_Role;
            if (m != null)
            {
                this.ID = m.ID;
				this.Name = m.Name;
				this.TIMS_UserRole = convertSubs && m.TIMS_UserRole != null ? m.TIMS_UserRole.Select(x => new TIMS_UserRoleViewModel(x)).ToList() : null;
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