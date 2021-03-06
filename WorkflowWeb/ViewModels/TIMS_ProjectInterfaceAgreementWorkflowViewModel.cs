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
    public partial class TIMS_ProjectInterfaceAgreementWorkflowViewModel : BaseViewModel<TIMS_ProjectInterfaceAgreementWorkflow>, IValidatableObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID is required.")]
		[DisplayName("ID")]
		public Guid ID { get; set; }
		
		[DisplayName("Workflow Type")]
		public String WorkflowTypeID { get; set; }
		
		[DisplayName("Interface Agreement")]
		public Guid? InterfaceAgreementID { get; set; }
		
		[DisplayName("Date Initiated")]
		public DateTime? DateInitiated { get; set; }
		
		[DisplayName("Lead State")]
		public String LeadStateID { get; set; }
		
		[DisplayName("Interface State")]
		public String InterfaceStateID { get; set; }
		
		[DisplayName("User")]
		public Guid? UserID { get; set; }
		
		[DisplayName("Is Draft")]
		public Boolean? IsDraft { get; set; }
		
		[DisplayName("Discipline")]
		public Guid? DisciplineID { get; set; }
		
		[DisplayName("System")]
		public Guid? SystemID { get; set; }
		
		[DisplayName("Area")]
		public Guid? AreaID { get; set; }
		
		[DisplayName("Short Description")]
		public String ShortDescription { get; set; }
		
		[DisplayName("Detailed Description")]
		public String DetailedDescription { get; set; }
		
		[DisplayName("TIMS_Project Area")]
		public TIMS_ProjectAreaViewModel TIMS_ProjectArea { get; set; }
		
		[DisplayName("TIMS_Project Attachment")]
		[JsonIgnore]
		public List<TIMS_ProjectAttachmentViewModel> TIMS_ProjectAttachment { get; set; }
		
		[DisplayName("TIMS_Project Comment")]
		[JsonIgnore]
		public List<TIMS_ProjectCommentViewModel> TIMS_ProjectComment { get; set; }
		
		[DisplayName("TIMS_Project Discipline")]
		public TIMS_ProjectDisciplineViewModel TIMS_ProjectDiscipline { get; set; }
		
		[DisplayName("TIMS_Project Interface Agreement")]
		public TIMS_ProjectInterfaceAgreementViewModel TIMS_ProjectInterfaceAgreement { get; set; }
		
		[DisplayName("TIMS_User")]
		public TIMS_UserViewModel TIMS_User { get; set; }
		
		[DisplayName("TIMS_Workflow Type")]
		public TIMS_WorkflowTypeViewModel TIMS_WorkflowType { get; set; }
		

        public TIMS_ProjectInterfaceAgreementWorkflowViewModel()
        {

        }

        public TIMS_ProjectInterfaceAgreementWorkflowViewModel(TIMS_ProjectInterfaceAgreementWorkflow m, bool convertSubs = false)
        {
            if (m != null)
            {
                this.ID = m.ID;
				this.WorkflowTypeID = m.WorkflowTypeID;
				this.InterfaceAgreementID = m.InterfaceAgreementID;
				this.DateInitiated = m.DateInitiated;
				this.LeadStateID = m.LeadStateID;
				this.InterfaceStateID = m.InterfaceStateID;
				this.UserID = m.UserID;
				this.IsDraft = m.IsDraft;
				this.DisciplineID = m.DisciplineID;
				this.SystemID = m.SystemID;
				this.AreaID = m.AreaID;
				this.ShortDescription = m.ShortDescription;
				this.DetailedDescription = m.DetailedDescription;
				this.TIMS_ProjectArea = convertSubs ? new TIMS_ProjectAreaViewModel(m.TIMS_ProjectArea) : null;
				this.TIMS_ProjectAttachment = convertSubs && m.TIMS_ProjectAttachment != null ? m.TIMS_ProjectAttachment.Select(x => new TIMS_ProjectAttachmentViewModel(x)).ToList() : null;
				this.TIMS_ProjectComment = convertSubs && m.TIMS_ProjectComment != null ? m.TIMS_ProjectComment.Select(x => new TIMS_ProjectCommentViewModel(x)).ToList() : null;
				this.TIMS_ProjectDiscipline = convertSubs ? new TIMS_ProjectDisciplineViewModel(m.TIMS_ProjectDiscipline) : null;
				this.TIMS_ProjectInterfaceAgreement = convertSubs ? new TIMS_ProjectInterfaceAgreementViewModel(m.TIMS_ProjectInterfaceAgreement) : null;
				this.TIMS_User = convertSubs ? new TIMS_UserViewModel(m.TIMS_User) : null;
				this.TIMS_WorkflowType = convertSubs ? new TIMS_WorkflowTypeViewModel(m.TIMS_WorkflowType) : null;
            }
        }

        public override TIMS_ProjectInterfaceAgreementWorkflow ToModel(bool convertSubs = false)
        {
            var m = new TIMS_ProjectInterfaceAgreementWorkflow();

            m.ID = this.ID;
			m.WorkflowTypeID = this.WorkflowTypeID;
			m.InterfaceAgreementID = this.InterfaceAgreementID;
			m.DateInitiated = this.DateInitiated;
			m.LeadStateID = this.LeadStateID;
			m.InterfaceStateID = this.InterfaceStateID;
			m.UserID = this.UserID;
			m.IsDraft = this.IsDraft;
			m.DisciplineID = this.DisciplineID;
			m.SystemID = this.SystemID;
			m.AreaID = this.AreaID;
			m.ShortDescription = this.ShortDescription;
			m.DetailedDescription = this.DetailedDescription;
			m.TIMS_ProjectArea = convertSubs && this.TIMS_ProjectArea != null ?  this.TIMS_ProjectArea.ToModel() : null;
			m.TIMS_ProjectAttachment = convertSubs && this.TIMS_ProjectAttachment != null  ? this.TIMS_ProjectAttachment.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_ProjectComment = convertSubs && this.TIMS_ProjectComment != null  ? this.TIMS_ProjectComment.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_ProjectDiscipline = convertSubs && this.TIMS_ProjectDiscipline != null ?  this.TIMS_ProjectDiscipline.ToModel() : null;
			m.TIMS_ProjectInterfaceAgreement = convertSubs && this.TIMS_ProjectInterfaceAgreement != null ?  this.TIMS_ProjectInterfaceAgreement.ToModel() : null;
			m.TIMS_User = convertSubs && this.TIMS_User != null ?  this.TIMS_User.ToModel() : null;
			m.TIMS_WorkflowType = convertSubs && this.TIMS_WorkflowType != null ?  this.TIMS_WorkflowType.ToModel() : null;

            return m;
        }

        public override BaseViewModel<TIMS_ProjectInterfaceAgreementWorkflow> FromModel<M>(M mo, bool convertSubs)
        {
            var m = mo as TIMS_ProjectInterfaceAgreementWorkflow;
            if (m != null)
            {
                this.ID = m.ID;
				this.WorkflowTypeID = m.WorkflowTypeID;
				this.InterfaceAgreementID = m.InterfaceAgreementID;
				this.DateInitiated = m.DateInitiated;
				this.LeadStateID = m.LeadStateID;
				this.InterfaceStateID = m.InterfaceStateID;
				this.UserID = m.UserID;
				this.IsDraft = m.IsDraft;
				this.DisciplineID = m.DisciplineID;
				this.SystemID = m.SystemID;
				this.AreaID = m.AreaID;
				this.ShortDescription = m.ShortDescription;
				this.DetailedDescription = m.DetailedDescription;
				this.TIMS_ProjectArea = convertSubs ? new TIMS_ProjectAreaViewModel(m.TIMS_ProjectArea) : null;
				this.TIMS_ProjectAttachment = convertSubs && m.TIMS_ProjectAttachment != null ? m.TIMS_ProjectAttachment.Select(x => new TIMS_ProjectAttachmentViewModel(x)).ToList() : null;
				this.TIMS_ProjectComment = convertSubs && m.TIMS_ProjectComment != null ? m.TIMS_ProjectComment.Select(x => new TIMS_ProjectCommentViewModel(x)).ToList() : null;
				this.TIMS_ProjectDiscipline = convertSubs ? new TIMS_ProjectDisciplineViewModel(m.TIMS_ProjectDiscipline) : null;
				this.TIMS_ProjectInterfaceAgreement = convertSubs ? new TIMS_ProjectInterfaceAgreementViewModel(m.TIMS_ProjectInterfaceAgreement) : null;
				this.TIMS_User = convertSubs ? new TIMS_UserViewModel(m.TIMS_User) : null;
				this.TIMS_WorkflowType = convertSubs ? new TIMS_WorkflowTypeViewModel(m.TIMS_WorkflowType) : null;
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