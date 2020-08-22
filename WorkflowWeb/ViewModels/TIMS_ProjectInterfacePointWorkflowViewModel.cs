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
    public class TIMS_ProjectInterfacePointWorkflowViewModel : BaseViewModel<TIMS_ProjectInterfacePointWorkflow>, IValidatableObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID is required.")]
		[DisplayName("ID")]
		public Guid ID { get; set; }
		
		[DisplayName("Workflow Type")]
		public String WorkflowTypeID { get; set; }
		
		[DisplayName("Interface Point")]
		public Guid? InterfacePointID { get; set; }
		
		[DisplayName("Date Initiated")]
		public DateTime? DateInitiated { get; set; }
		
		[DisplayName("Lead State")]
		public String LeadStateID { get; set; }
		
		[DisplayName("Interface State")]
		public String InterfaceStateID { get; set; }
		
		[DisplayName("Support State")]
		public String SupportStateID { get; set; }
		
		[DisplayName("Project Area")]
		public Guid? ProjectAreaID { get; set; }
		
		[DisplayName("Project Physical Area")]
		public Guid? ProjectPhysicalAreaID { get; set; }
		
		[DisplayName("Phase")]
		public String PhaseID { get; set; }
		
		[DisplayName("Interface Type")]
		public Guid? InterfaceTypeID { get; set; }
		
		[DisplayName("User")]
		public Guid? UserID { get; set; }
		
		[DisplayName("Is Draft")]
		public Boolean? IsDraft { get; set; }
		
		[DisplayName("TIMS_Phase")]
		public TIMS_PhaseViewModel TIMS_Phase { get; set; }
		
		[DisplayName("TIMS_Project Area")]
		public TIMS_ProjectAreaViewModel TIMS_ProjectArea { get; set; }
		
		[DisplayName("TIMS_Project Attachment")]
		public List<TIMS_ProjectAttachmentViewModel> TIMS_ProjectAttachment { get; set; }
		
		[DisplayName("TIMS_Project Comment")]
		public List<TIMS_ProjectCommentViewModel> TIMS_ProjectComment { get; set; }
		
		[DisplayName("TIMS_Project Discipline Interface Type")]
		public TIMS_ProjectDisciplineInterfaceTypeViewModel TIMS_ProjectDisciplineInterfaceType { get; set; }
		
		[DisplayName("TIMS_Project Interface Point Field Entry")]
		public List<TIMS_ProjectInterfacePointFieldEntryViewModel> TIMS_ProjectInterfacePointFieldEntry { get; set; }
		
		[DisplayName("TIMS_Project Physical Area")]
		public TIMS_ProjectPhysicalAreaViewModel TIMS_ProjectPhysicalArea { get; set; }
		
		[DisplayName("TIMS_User")]
		public TIMS_UserViewModel TIMS_User { get; set; }
		
		[DisplayName("TIMS_Workflow State")]
		public TIMS_WorkflowStateViewModel TIMS_WorkflowState { get; set; }
		
		[DisplayName("TIMS_Workflow State1")]
		public TIMS_WorkflowStateViewModel TIMS_WorkflowState1 { get; set; }
		
		[DisplayName("TIMS_Workflow State2")]
		public TIMS_WorkflowStateViewModel TIMS_WorkflowState2 { get; set; }
		
		[DisplayName("TIMS_Workflow Type")]
		public TIMS_WorkflowTypeViewModel TIMS_WorkflowType { get; set; }
		

        public TIMS_ProjectInterfacePointWorkflowViewModel()
        {

        }

        public TIMS_ProjectInterfacePointWorkflowViewModel(TIMS_ProjectInterfacePointWorkflow m, bool convertSubs = false)
        {
            if (m != null)
            {
                this.ID = m.ID;
				this.WorkflowTypeID = m.WorkflowTypeID;
				this.InterfacePointID = m.InterfacePointID;
				this.DateInitiated = m.DateInitiated;
				this.LeadStateID = m.LeadStateID;
				this.InterfaceStateID = m.InterfaceStateID;
				this.SupportStateID = m.SupportStateID;
				this.ProjectAreaID = m.ProjectAreaID;
				this.ProjectPhysicalAreaID = m.ProjectPhysicalAreaID;
				this.PhaseID = m.PhaseID;
				this.InterfaceTypeID = m.InterfaceTypeID;
				this.UserID = m.UserID;
				this.IsDraft = m.IsDraft;
				this.TIMS_Phase = convertSubs ? new TIMS_PhaseViewModel(m.TIMS_Phase) : null;
				this.TIMS_ProjectArea = convertSubs ? new TIMS_ProjectAreaViewModel(m.TIMS_ProjectArea) : null;
				this.TIMS_ProjectAttachment = convertSubs && m.TIMS_ProjectAttachment != null ? m.TIMS_ProjectAttachment.Select(x => new TIMS_ProjectAttachmentViewModel(x)).ToList() : null;
				this.TIMS_ProjectComment = convertSubs && m.TIMS_ProjectComment != null ? m.TIMS_ProjectComment.Select(x => new TIMS_ProjectCommentViewModel(x)).ToList() : null;
				this.TIMS_ProjectDisciplineInterfaceType = convertSubs ? new TIMS_ProjectDisciplineInterfaceTypeViewModel(m.TIMS_ProjectDisciplineInterfaceType) : null;
				this.TIMS_ProjectInterfacePointFieldEntry = convertSubs && m.TIMS_ProjectInterfacePointFieldEntry != null ? m.TIMS_ProjectInterfacePointFieldEntry.Select(x => new TIMS_ProjectInterfacePointFieldEntryViewModel(x)).ToList() : null;
				this.TIMS_ProjectPhysicalArea = convertSubs ? new TIMS_ProjectPhysicalAreaViewModel(m.TIMS_ProjectPhysicalArea) : null;
				this.TIMS_User = convertSubs ? new TIMS_UserViewModel(m.TIMS_User) : null;
				this.TIMS_WorkflowState = convertSubs ? new TIMS_WorkflowStateViewModel(m.TIMS_WorkflowState) : null;
				this.TIMS_WorkflowState1 = convertSubs ? new TIMS_WorkflowStateViewModel(m.TIMS_WorkflowState1) : null;
				this.TIMS_WorkflowState2 = convertSubs ? new TIMS_WorkflowStateViewModel(m.TIMS_WorkflowState2) : null;
				this.TIMS_WorkflowType = convertSubs ? new TIMS_WorkflowTypeViewModel(m.TIMS_WorkflowType) : null;
            }
        }

        public override TIMS_ProjectInterfacePointWorkflow ToModel(bool convertSubs = false)
        {
            var m = new TIMS_ProjectInterfacePointWorkflow();

            m.ID = this.ID;
			m.WorkflowTypeID = this.WorkflowTypeID;
			m.InterfacePointID = this.InterfacePointID;
			m.DateInitiated = this.DateInitiated;
			m.LeadStateID = this.LeadStateID;
			m.InterfaceStateID = this.InterfaceStateID;
			m.SupportStateID = this.SupportStateID;
			m.ProjectAreaID = this.ProjectAreaID;
			m.ProjectPhysicalAreaID = this.ProjectPhysicalAreaID;
			m.PhaseID = this.PhaseID;
			m.InterfaceTypeID = this.InterfaceTypeID;
			m.UserID = this.UserID;
			m.IsDraft = this.IsDraft;
			m.TIMS_Phase = convertSubs && this.TIMS_Phase != null ?  this.TIMS_Phase.ToModel() : null;
			m.TIMS_ProjectArea = convertSubs && this.TIMS_ProjectArea != null ?  this.TIMS_ProjectArea.ToModel() : null;
			m.TIMS_ProjectAttachment = convertSubs && this.TIMS_ProjectAttachment != null  ? this.TIMS_ProjectAttachment.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_ProjectComment = convertSubs && this.TIMS_ProjectComment != null  ? this.TIMS_ProjectComment.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_ProjectDisciplineInterfaceType = convertSubs && this.TIMS_ProjectDisciplineInterfaceType != null ?  this.TIMS_ProjectDisciplineInterfaceType.ToModel() : null;
			m.TIMS_ProjectInterfacePointFieldEntry = convertSubs && this.TIMS_ProjectInterfacePointFieldEntry != null  ? this.TIMS_ProjectInterfacePointFieldEntry.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_ProjectPhysicalArea = convertSubs && this.TIMS_ProjectPhysicalArea != null ?  this.TIMS_ProjectPhysicalArea.ToModel() : null;
			m.TIMS_User = convertSubs && this.TIMS_User != null ?  this.TIMS_User.ToModel() : null;
			m.TIMS_WorkflowState = convertSubs && this.TIMS_WorkflowState != null ?  this.TIMS_WorkflowState.ToModel() : null;
			m.TIMS_WorkflowState1 = convertSubs && this.TIMS_WorkflowState1 != null ?  this.TIMS_WorkflowState1.ToModel() : null;
			m.TIMS_WorkflowState2 = convertSubs && this.TIMS_WorkflowState2 != null ?  this.TIMS_WorkflowState2.ToModel() : null;
			m.TIMS_WorkflowType = convertSubs && this.TIMS_WorkflowType != null ?  this.TIMS_WorkflowType.ToModel() : null;

            return m;
        }

        public override BaseViewModel<TIMS_ProjectInterfacePointWorkflow> FromModel<M>(M mo, bool convertSubs)
        {
            var m = mo as TIMS_ProjectInterfacePointWorkflow;
            if (m != null)
            {
                this.ID = m.ID;
				this.WorkflowTypeID = m.WorkflowTypeID;
				this.InterfacePointID = m.InterfacePointID;
				this.DateInitiated = m.DateInitiated;
				this.LeadStateID = m.LeadStateID;
				this.InterfaceStateID = m.InterfaceStateID;
				this.SupportStateID = m.SupportStateID;
				this.ProjectAreaID = m.ProjectAreaID;
				this.ProjectPhysicalAreaID = m.ProjectPhysicalAreaID;
				this.PhaseID = m.PhaseID;
				this.InterfaceTypeID = m.InterfaceTypeID;
				this.UserID = m.UserID;
				this.IsDraft = m.IsDraft;
				this.TIMS_Phase = convertSubs ? new TIMS_PhaseViewModel(m.TIMS_Phase) : null;
				this.TIMS_ProjectArea = convertSubs ? new TIMS_ProjectAreaViewModel(m.TIMS_ProjectArea) : null;
				this.TIMS_ProjectAttachment = convertSubs && m.TIMS_ProjectAttachment != null ? m.TIMS_ProjectAttachment.Select(x => new TIMS_ProjectAttachmentViewModel(x)).ToList() : null;
				this.TIMS_ProjectComment = convertSubs && m.TIMS_ProjectComment != null ? m.TIMS_ProjectComment.Select(x => new TIMS_ProjectCommentViewModel(x)).ToList() : null;
				this.TIMS_ProjectDisciplineInterfaceType = convertSubs ? new TIMS_ProjectDisciplineInterfaceTypeViewModel(m.TIMS_ProjectDisciplineInterfaceType) : null;
				this.TIMS_ProjectInterfacePointFieldEntry = convertSubs && m.TIMS_ProjectInterfacePointFieldEntry != null ? m.TIMS_ProjectInterfacePointFieldEntry.Select(x => new TIMS_ProjectInterfacePointFieldEntryViewModel(x)).ToList() : null;
				this.TIMS_ProjectPhysicalArea = convertSubs ? new TIMS_ProjectPhysicalAreaViewModel(m.TIMS_ProjectPhysicalArea) : null;
				this.TIMS_User = convertSubs ? new TIMS_UserViewModel(m.TIMS_User) : null;
				this.TIMS_WorkflowState = convertSubs ? new TIMS_WorkflowStateViewModel(m.TIMS_WorkflowState) : null;
				this.TIMS_WorkflowState1 = convertSubs ? new TIMS_WorkflowStateViewModel(m.TIMS_WorkflowState1) : null;
				this.TIMS_WorkflowState2 = convertSubs ? new TIMS_WorkflowStateViewModel(m.TIMS_WorkflowState2) : null;
				this.TIMS_WorkflowType = convertSubs ? new TIMS_WorkflowTypeViewModel(m.TIMS_WorkflowType) : null;
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