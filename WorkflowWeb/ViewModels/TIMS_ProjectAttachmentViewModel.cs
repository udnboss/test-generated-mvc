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
    public class TIMS_ProjectAttachmentViewModel : IValidatableObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID is required.")]
		[DisplayName("ID")]
		public Guid ID { get; set; }
		
		[Required(AllowEmptyStrings = false, ErrorMessage = "Name is required.")]
		[DisplayName("Name")]
		public String Name { get; set; }
		
		[DisplayName("Project Interface Point Workflow ID")]
		public Guid? ProjectInterfacePointWorkflowID { get; set; }
		
		[DisplayName("Project Interface Agreement Workflow ID")]
		public Guid? ProjectInterfaceAgreementWorkflowID { get; set; }
		
		[DisplayName("Project Action Item Workflow ID")]
		public Guid? ProjectActionItemWorkflowID { get; set; }
		
		[DisplayName("Package ID")]
		public Guid? PackageID { get; set; }
		
		[DisplayName("Filename")]
		public String Filename { get; set; }
		
		[DisplayName("Date Uploaded")]
		public DateTime? DateUploaded { get; set; }
		
		[DisplayName("User ID")]
		public Guid? UserID { get; set; }
		
		[DisplayName("TIMS_Project Action Item Workflow")]
		public TIMS_ProjectActionItemWorkflowViewModel TIMS_ProjectActionItemWorkflow { get; set; }
		
		[DisplayName("TIMS_Project Interface Agreement Workflow")]
		public TIMS_ProjectInterfaceAgreementWorkflowViewModel TIMS_ProjectInterfaceAgreementWorkflow { get; set; }
		
		[DisplayName("TIMS_Project Interface Point Workflow")]
		public TIMS_ProjectInterfacePointWorkflowViewModel TIMS_ProjectInterfacePointWorkflow { get; set; }
		
		[DisplayName("TIMS_Project Package")]
		public TIMS_ProjectPackageViewModel TIMS_ProjectPackage { get; set; }
		
		[DisplayName("TIMS_User")]
		public TIMS_UserViewModel TIMS_User { get; set; }
		

        public TIMS_ProjectAttachmentViewModel()
        {

        }

        public TIMS_ProjectAttachmentViewModel(TIMS_ProjectAttachment m, bool convertSubs = false)
        {
            if (m != null)
            {
                this.ID = m.ID;
				this.Name = m.Name;
				this.ProjectInterfacePointWorkflowID = m.ProjectInterfacePointWorkflowID;
				this.ProjectInterfaceAgreementWorkflowID = m.ProjectInterfaceAgreementWorkflowID;
				this.ProjectActionItemWorkflowID = m.ProjectActionItemWorkflowID;
				this.PackageID = m.PackageID;
				this.Filename = m.Filename;
				this.DateUploaded = m.DateUploaded;
				this.UserID = m.UserID;
				this.TIMS_ProjectActionItemWorkflow = convertSubs ? new TIMS_ProjectActionItemWorkflowViewModel(m.TIMS_ProjectActionItemWorkflow) : null;
				this.TIMS_ProjectInterfaceAgreementWorkflow = convertSubs ? new TIMS_ProjectInterfaceAgreementWorkflowViewModel(m.TIMS_ProjectInterfaceAgreementWorkflow) : null;
				this.TIMS_ProjectInterfacePointWorkflow = convertSubs ? new TIMS_ProjectInterfacePointWorkflowViewModel(m.TIMS_ProjectInterfacePointWorkflow) : null;
				this.TIMS_ProjectPackage = convertSubs ? new TIMS_ProjectPackageViewModel(m.TIMS_ProjectPackage) : null;
				this.TIMS_User = convertSubs ? new TIMS_UserViewModel(m.TIMS_User) : null;
            }
        }

        public TIMS_ProjectAttachment ToModel(bool convertSubs = false)
        {
            var m = new TIMS_ProjectAttachment();

            m.ID = this.ID;
			m.Name = this.Name;
			m.ProjectInterfacePointWorkflowID = this.ProjectInterfacePointWorkflowID;
			m.ProjectInterfaceAgreementWorkflowID = this.ProjectInterfaceAgreementWorkflowID;
			m.ProjectActionItemWorkflowID = this.ProjectActionItemWorkflowID;
			m.PackageID = this.PackageID;
			m.Filename = this.Filename;
			m.DateUploaded = this.DateUploaded;
			m.UserID = this.UserID;
			m.TIMS_ProjectActionItemWorkflow = convertSubs ? this.TIMS_ProjectActionItemWorkflow.ToModel() : null;
			m.TIMS_ProjectInterfaceAgreementWorkflow = convertSubs ? this.TIMS_ProjectInterfaceAgreementWorkflow.ToModel() : null;
			m.TIMS_ProjectInterfacePointWorkflow = convertSubs ? this.TIMS_ProjectInterfacePointWorkflow.ToModel() : null;
			m.TIMS_ProjectPackage = convertSubs ? this.TIMS_ProjectPackage.ToModel() : null;
			m.TIMS_User = convertSubs ? this.TIMS_User.ToModel() : null;

            return m;
        }

        public string ToRouteFilter()
        {
            var route_filter = JsonConvert.SerializeObject(new { ID,Name,ProjectInterfacePointWorkflowID,ProjectInterfaceAgreementWorkflowID,ProjectActionItemWorkflowID,PackageID,Filename,DateUploaded,UserID });
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