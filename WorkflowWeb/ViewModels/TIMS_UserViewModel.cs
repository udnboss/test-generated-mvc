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
    public class TIMS_UserViewModel : BaseViewModel<TIMS_User>, IValidatableObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID is required.")]
		[DisplayName("ID")]
		public Guid ID { get; set; }
		
		[Required(AllowEmptyStrings = false, ErrorMessage = "Name is required.")]
		[DisplayName("Name")]
		public String Name { get; set; }
		
		[DisplayName("TIMS_Project Action Item Workflow")]
		public List<TIMS_ProjectActionItemWorkflowViewModel> TIMS_ProjectActionItemWorkflow { get; set; }
		
		[DisplayName("TIMS_Project Attachment")]
		public List<TIMS_ProjectAttachmentViewModel> TIMS_ProjectAttachment { get; set; }
		
		[DisplayName("TIMS_Project Comment")]
		public List<TIMS_ProjectCommentViewModel> TIMS_ProjectComment { get; set; }
		
		[DisplayName("TIMS_Project Interface Agreement Workflow")]
		public List<TIMS_ProjectInterfaceAgreementWorkflowViewModel> TIMS_ProjectInterfaceAgreementWorkflow { get; set; }
		
		[DisplayName("TIMS_Project Interface Point Workflow")]
		public List<TIMS_ProjectInterfacePointWorkflowViewModel> TIMS_ProjectInterfacePointWorkflow { get; set; }
		
		[DisplayName("TIMS_User Role")]
		public List<TIMS_UserRoleViewModel> TIMS_UserRole { get; set; }
		
		[DisplayName("TIMS_User Watchlist Item")]
		public List<TIMS_UserWatchlistItemViewModel> TIMS_UserWatchlistItem { get; set; }
		

        public TIMS_UserViewModel()
        {

        }

        public TIMS_UserViewModel(TIMS_User m, bool convertSubs = false)
        {
            if (m != null)
            {
                this.ID = m.ID;
				this.Name = m.Name;
				this.TIMS_ProjectActionItemWorkflow = convertSubs && m.TIMS_ProjectActionItemWorkflow != null ? m.TIMS_ProjectActionItemWorkflow.Select(x => new TIMS_ProjectActionItemWorkflowViewModel(x)).ToList() : null;
				this.TIMS_ProjectAttachment = convertSubs && m.TIMS_ProjectAttachment != null ? m.TIMS_ProjectAttachment.Select(x => new TIMS_ProjectAttachmentViewModel(x)).ToList() : null;
				this.TIMS_ProjectComment = convertSubs && m.TIMS_ProjectComment != null ? m.TIMS_ProjectComment.Select(x => new TIMS_ProjectCommentViewModel(x)).ToList() : null;
				this.TIMS_ProjectInterfaceAgreementWorkflow = convertSubs && m.TIMS_ProjectInterfaceAgreementWorkflow != null ? m.TIMS_ProjectInterfaceAgreementWorkflow.Select(x => new TIMS_ProjectInterfaceAgreementWorkflowViewModel(x)).ToList() : null;
				this.TIMS_ProjectInterfacePointWorkflow = convertSubs && m.TIMS_ProjectInterfacePointWorkflow != null ? m.TIMS_ProjectInterfacePointWorkflow.Select(x => new TIMS_ProjectInterfacePointWorkflowViewModel(x)).ToList() : null;
				this.TIMS_UserRole = convertSubs && m.TIMS_UserRole != null ? m.TIMS_UserRole.Select(x => new TIMS_UserRoleViewModel(x)).ToList() : null;
				this.TIMS_UserWatchlistItem = convertSubs && m.TIMS_UserWatchlistItem != null ? m.TIMS_UserWatchlistItem.Select(x => new TIMS_UserWatchlistItemViewModel(x)).ToList() : null;
            }
        }

        public override TIMS_User ToModel(bool convertSubs = false)
        {
            var m = new TIMS_User();

            m.ID = this.ID;
			m.Name = this.Name;
			m.TIMS_ProjectActionItemWorkflow = convertSubs && this.TIMS_ProjectActionItemWorkflow != null  ? this.TIMS_ProjectActionItemWorkflow.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_ProjectAttachment = convertSubs && this.TIMS_ProjectAttachment != null  ? this.TIMS_ProjectAttachment.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_ProjectComment = convertSubs && this.TIMS_ProjectComment != null  ? this.TIMS_ProjectComment.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_ProjectInterfaceAgreementWorkflow = convertSubs && this.TIMS_ProjectInterfaceAgreementWorkflow != null  ? this.TIMS_ProjectInterfaceAgreementWorkflow.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_ProjectInterfacePointWorkflow = convertSubs && this.TIMS_ProjectInterfacePointWorkflow != null  ? this.TIMS_ProjectInterfacePointWorkflow.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_UserRole = convertSubs && this.TIMS_UserRole != null  ? this.TIMS_UserRole.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_UserWatchlistItem = convertSubs && this.TIMS_UserWatchlistItem != null  ? this.TIMS_UserWatchlistItem.Select(x => x.ToModel()).ToList() : null;

            return m;
        }

        public override BaseViewModel<TIMS_User> FromModel<M>(M mo, bool convertSubs)
        {
            var m = mo as TIMS_User;
            if (m != null)
            {
                this.ID = m.ID;
				this.Name = m.Name;
				this.TIMS_ProjectActionItemWorkflow = convertSubs && m.TIMS_ProjectActionItemWorkflow != null ? m.TIMS_ProjectActionItemWorkflow.Select(x => new TIMS_ProjectActionItemWorkflowViewModel(x)).ToList() : null;
				this.TIMS_ProjectAttachment = convertSubs && m.TIMS_ProjectAttachment != null ? m.TIMS_ProjectAttachment.Select(x => new TIMS_ProjectAttachmentViewModel(x)).ToList() : null;
				this.TIMS_ProjectComment = convertSubs && m.TIMS_ProjectComment != null ? m.TIMS_ProjectComment.Select(x => new TIMS_ProjectCommentViewModel(x)).ToList() : null;
				this.TIMS_ProjectInterfaceAgreementWorkflow = convertSubs && m.TIMS_ProjectInterfaceAgreementWorkflow != null ? m.TIMS_ProjectInterfaceAgreementWorkflow.Select(x => new TIMS_ProjectInterfaceAgreementWorkflowViewModel(x)).ToList() : null;
				this.TIMS_ProjectInterfacePointWorkflow = convertSubs && m.TIMS_ProjectInterfacePointWorkflow != null ? m.TIMS_ProjectInterfacePointWorkflow.Select(x => new TIMS_ProjectInterfacePointWorkflowViewModel(x)).ToList() : null;
				this.TIMS_UserRole = convertSubs && m.TIMS_UserRole != null ? m.TIMS_UserRole.Select(x => new TIMS_UserRoleViewModel(x)).ToList() : null;
				this.TIMS_UserWatchlistItem = convertSubs && m.TIMS_UserWatchlistItem != null ? m.TIMS_UserWatchlistItem.Select(x => new TIMS_UserWatchlistItemViewModel(x)).ToList() : null;
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