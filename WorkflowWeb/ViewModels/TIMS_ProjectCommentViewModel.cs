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
    public partial class TIMS_ProjectCommentViewModel : BaseViewModel<TIMS_ProjectComment>, IValidatableObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID is required.")]
		[DisplayName("ID")]
		public Guid ID { get; set; }
		
		[DisplayName("Comment")]
		public String Comment { get; set; }
		
		[DisplayName("Project Interface Point Workflow")]
		public Guid? ProjectInterfacePointWorkflowID { get; set; }
		
		[DisplayName("Project Interface Agreement Workflow")]
		public Guid? ProjectInterfaceAgreementWorkflowID { get; set; }
		
		[DisplayName("Project Action Item Workflow")]
		public Guid? ProjectActionItemWorkflowID { get; set; }
		
		[DisplayName("User")]
		public Guid? UserID { get; set; }
		
		[DisplayName("Date Added")]
		public DateTime? DateAdded { get; set; }
		
		[DisplayName("TIMS_Project Action Item Workflow")]
		public TIMS_ProjectActionItemWorkflowViewModel TIMS_ProjectActionItemWorkflow { get; set; }
		
		[DisplayName("TIMS_Project Interface Agreement Workflow")]
		public TIMS_ProjectInterfaceAgreementWorkflowViewModel TIMS_ProjectInterfaceAgreementWorkflow { get; set; }
		
		[DisplayName("TIMS_Project Interface Point Workflow")]
		public TIMS_ProjectInterfacePointWorkflowViewModel TIMS_ProjectInterfacePointWorkflow { get; set; }
		
		[DisplayName("TIMS_User")]
		public TIMS_UserViewModel TIMS_User { get; set; }
		

        public TIMS_ProjectCommentViewModel()
        {

        }

        public TIMS_ProjectCommentViewModel(TIMS_ProjectComment m, bool convertSubs = false)
        {
            if (m != null)
            {
                this.ID = m.ID;
				this.Comment = m.Comment;
				this.ProjectInterfacePointWorkflowID = m.ProjectInterfacePointWorkflowID;
				this.ProjectInterfaceAgreementWorkflowID = m.ProjectInterfaceAgreementWorkflowID;
				this.ProjectActionItemWorkflowID = m.ProjectActionItemWorkflowID;
				this.UserID = m.UserID;
				this.DateAdded = m.DateAdded;
				this.TIMS_ProjectActionItemWorkflow = convertSubs ? new TIMS_ProjectActionItemWorkflowViewModel(m.TIMS_ProjectActionItemWorkflow) : null;
				this.TIMS_ProjectInterfaceAgreementWorkflow = convertSubs ? new TIMS_ProjectInterfaceAgreementWorkflowViewModel(m.TIMS_ProjectInterfaceAgreementWorkflow) : null;
				this.TIMS_ProjectInterfacePointWorkflow = convertSubs ? new TIMS_ProjectInterfacePointWorkflowViewModel(m.TIMS_ProjectInterfacePointWorkflow) : null;
				this.TIMS_User = convertSubs ? new TIMS_UserViewModel(m.TIMS_User) : null;
            }
        }

        public override TIMS_ProjectComment ToModel(bool convertSubs = false)
        {
            var m = new TIMS_ProjectComment();

            m.ID = this.ID;
			m.Comment = this.Comment;
			m.ProjectInterfacePointWorkflowID = this.ProjectInterfacePointWorkflowID;
			m.ProjectInterfaceAgreementWorkflowID = this.ProjectInterfaceAgreementWorkflowID;
			m.ProjectActionItemWorkflowID = this.ProjectActionItemWorkflowID;
			m.UserID = this.UserID;
			m.DateAdded = this.DateAdded;
			m.TIMS_ProjectActionItemWorkflow = convertSubs && this.TIMS_ProjectActionItemWorkflow != null ?  this.TIMS_ProjectActionItemWorkflow.ToModel() : null;
			m.TIMS_ProjectInterfaceAgreementWorkflow = convertSubs && this.TIMS_ProjectInterfaceAgreementWorkflow != null ?  this.TIMS_ProjectInterfaceAgreementWorkflow.ToModel() : null;
			m.TIMS_ProjectInterfacePointWorkflow = convertSubs && this.TIMS_ProjectInterfacePointWorkflow != null ?  this.TIMS_ProjectInterfacePointWorkflow.ToModel() : null;
			m.TIMS_User = convertSubs && this.TIMS_User != null ?  this.TIMS_User.ToModel() : null;

            return m;
        }

        public override BaseViewModel<TIMS_ProjectComment> FromModel<M>(M mo, bool convertSubs)
        {
            var m = mo as TIMS_ProjectComment;
            if (m != null)
            {
                this.ID = m.ID;
				this.Comment = m.Comment;
				this.ProjectInterfacePointWorkflowID = m.ProjectInterfacePointWorkflowID;
				this.ProjectInterfaceAgreementWorkflowID = m.ProjectInterfaceAgreementWorkflowID;
				this.ProjectActionItemWorkflowID = m.ProjectActionItemWorkflowID;
				this.UserID = m.UserID;
				this.DateAdded = m.DateAdded;
				this.TIMS_ProjectActionItemWorkflow = convertSubs ? new TIMS_ProjectActionItemWorkflowViewModel(m.TIMS_ProjectActionItemWorkflow) : null;
				this.TIMS_ProjectInterfaceAgreementWorkflow = convertSubs ? new TIMS_ProjectInterfaceAgreementWorkflowViewModel(m.TIMS_ProjectInterfaceAgreementWorkflow) : null;
				this.TIMS_ProjectInterfacePointWorkflow = convertSubs ? new TIMS_ProjectInterfacePointWorkflowViewModel(m.TIMS_ProjectInterfacePointWorkflow) : null;
				this.TIMS_User = convertSubs ? new TIMS_UserViewModel(m.TIMS_User) : null;
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