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
    public class TIMS_ProjectActionItemWorkflowViewModel : IValidatableObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID is required.")]
		[DisplayName("ID")]
		public Guid ID { get; set; }
		
		[DisplayName("Workflow Type ID")]
		public String WorkflowTypeID { get; set; }
		
		[DisplayName("Action Item ID")]
		public Guid? ActionItemID { get; set; }
		
		[DisplayName("Date Initiated")]
		public DateTime? DateInitiated { get; set; }
		
		[DisplayName("Lead State ID")]
		public String LeadStateID { get; set; }
		
		[DisplayName("Interface State ID")]
		public String InterfaceStateID { get; set; }
		
		[DisplayName("User ID")]
		public Guid? UserID { get; set; }
		
		[DisplayName("Is Draft")]
		public Boolean? IsDraft { get; set; }
		
		[DisplayName("TIMS_Project Action Item")]
		public TIMS_ProjectActionItemViewModel TIMS_ProjectActionItem { get; set; }
		
		[DisplayName("TIMS_User")]
		public TIMS_UserViewModel TIMS_User { get; set; }
		
		[DisplayName("TIMS_Workflow Type")]
		public TIMS_WorkflowTypeViewModel TIMS_WorkflowType { get; set; }
		
		[DisplayName("TIMS_Project Attachment")]
		public List<TIMS_ProjectAttachmentViewModel> TIMS_ProjectAttachment { get; set; }
		
		[DisplayName("TIMS_Project Comment")]
		public List<TIMS_ProjectCommentViewModel> TIMS_ProjectComment { get; set; }
		

        public TIMS_ProjectActionItemWorkflowViewModel()
        {

        }

        public TIMS_ProjectActionItemWorkflowViewModel(TIMS_ProjectActionItemWorkflow m, bool convertSubs = false)
        {
            if (m != null)
            {
                this.ID = m.ID;
				this.WorkflowTypeID = m.WorkflowTypeID;
				this.ActionItemID = m.ActionItemID;
				this.DateInitiated = m.DateInitiated;
				this.LeadStateID = m.LeadStateID;
				this.InterfaceStateID = m.InterfaceStateID;
				this.UserID = m.UserID;
				this.IsDraft = m.IsDraft;
				this.TIMS_ProjectActionItem = convertSubs ? new TIMS_ProjectActionItemViewModel(m.TIMS_ProjectActionItem) : null;
				this.TIMS_User = convertSubs ? new TIMS_UserViewModel(m.TIMS_User) : null;
				this.TIMS_WorkflowType = convertSubs ? new TIMS_WorkflowTypeViewModel(m.TIMS_WorkflowType) : null;
				this.TIMS_ProjectAttachment = convertSubs && m.TIMS_ProjectAttachment != null ? m.TIMS_ProjectAttachment.Select(x => new TIMS_ProjectAttachmentViewModel(x)).ToList() : null;
				this.TIMS_ProjectComment = convertSubs && m.TIMS_ProjectComment != null ? m.TIMS_ProjectComment.Select(x => new TIMS_ProjectCommentViewModel(x)).ToList() : null;
            }
        }

        public TIMS_ProjectActionItemWorkflow ToModel(bool convertSubs = false)
        {
            var m = new TIMS_ProjectActionItemWorkflow();

            m.ID = this.ID;
			m.WorkflowTypeID = this.WorkflowTypeID;
			m.ActionItemID = this.ActionItemID;
			m.DateInitiated = this.DateInitiated;
			m.LeadStateID = this.LeadStateID;
			m.InterfaceStateID = this.InterfaceStateID;
			m.UserID = this.UserID;
			m.IsDraft = this.IsDraft;
			m.TIMS_ProjectActionItem = convertSubs ? this.TIMS_ProjectActionItem.ToModel() : null;
			m.TIMS_User = convertSubs ? this.TIMS_User.ToModel() : null;
			m.TIMS_WorkflowType = convertSubs ? this.TIMS_WorkflowType.ToModel() : null;
			m.TIMS_ProjectAttachment = convertSubs ? this.TIMS_ProjectAttachment.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_ProjectComment = convertSubs ? this.TIMS_ProjectComment.Select(x => x.ToModel()).ToList() : null;

            return m;
        }

        public string ToRouteFilter()
        {
            var route_filter = JsonConvert.SerializeObject(new { ID,WorkflowTypeID,ActionItemID,DateInitiated,LeadStateID,InterfaceStateID,UserID,IsDraft });
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