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
    public partial class TIMS_UserRoleViewModel : BaseViewModel<TIMS_UserRole>, IValidatableObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID is required.")]
		[DisplayName("ID")]
		public Guid ID { get; set; }
		
		[DisplayName("User")]
		public Guid? UserID { get; set; }
		
		[DisplayName("Project")]
		public Guid? ProjectID { get; set; }
		
		[DisplayName("Project Package")]
		public Guid? ProjectPackageID { get; set; }
		
		[DisplayName("Role")]
		public Guid? RoleID { get; set; }
		
		[DisplayName("TIMS_Project")]
		public TIMS_ProjectViewModel TIMS_Project { get; set; }
		
		[DisplayName("TIMS_Project Package")]
		public TIMS_ProjectPackageViewModel TIMS_ProjectPackage { get; set; }
		
		[DisplayName("TIMS_Role")]
		public TIMS_RoleViewModel TIMS_Role { get; set; }
		
		[DisplayName("TIMS_User")]
		public TIMS_UserViewModel TIMS_User { get; set; }
		

        public TIMS_UserRoleViewModel()
        {

        }

        public TIMS_UserRoleViewModel(TIMS_UserRole m, bool convertSubs = false)
        {
            if (m != null)
            {
                this.ID = m.ID;
				this.UserID = m.UserID;
				this.ProjectID = m.ProjectID;
				this.ProjectPackageID = m.ProjectPackageID;
				this.RoleID = m.RoleID;
				this.TIMS_Project = convertSubs ? new TIMS_ProjectViewModel(m.TIMS_Project) : null;
				this.TIMS_ProjectPackage = convertSubs ? new TIMS_ProjectPackageViewModel(m.TIMS_ProjectPackage) : null;
				this.TIMS_Role = convertSubs ? new TIMS_RoleViewModel(m.TIMS_Role) : null;
				this.TIMS_User = convertSubs ? new TIMS_UserViewModel(m.TIMS_User) : null;
            }
        }

        public override TIMS_UserRole ToModel(bool convertSubs = false)
        {
            var m = new TIMS_UserRole();

            m.ID = this.ID;
			m.UserID = this.UserID;
			m.ProjectID = this.ProjectID;
			m.ProjectPackageID = this.ProjectPackageID;
			m.RoleID = this.RoleID;
			m.TIMS_Project = convertSubs && this.TIMS_Project != null ?  this.TIMS_Project.ToModel() : null;
			m.TIMS_ProjectPackage = convertSubs && this.TIMS_ProjectPackage != null ?  this.TIMS_ProjectPackage.ToModel() : null;
			m.TIMS_Role = convertSubs && this.TIMS_Role != null ?  this.TIMS_Role.ToModel() : null;
			m.TIMS_User = convertSubs && this.TIMS_User != null ?  this.TIMS_User.ToModel() : null;

            return m;
        }

        public override BaseViewModel<TIMS_UserRole> FromModel<M>(M mo, bool convertSubs)
        {
            var m = mo as TIMS_UserRole;
            if (m != null)
            {
                this.ID = m.ID;
				this.UserID = m.UserID;
				this.ProjectID = m.ProjectID;
				this.ProjectPackageID = m.ProjectPackageID;
				this.RoleID = m.RoleID;
				this.TIMS_Project = convertSubs ? new TIMS_ProjectViewModel(m.TIMS_Project) : null;
				this.TIMS_ProjectPackage = convertSubs ? new TIMS_ProjectPackageViewModel(m.TIMS_ProjectPackage) : null;
				this.TIMS_Role = convertSubs ? new TIMS_RoleViewModel(m.TIMS_Role) : null;
				this.TIMS_User = convertSubs ? new TIMS_UserViewModel(m.TIMS_User) : null;
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