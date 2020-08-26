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
    public partial class TIMS_ProjectActionItemViewModel : BaseViewModel<TIMS_ProjectActionItem>, IValidatableObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID is required.")]
		[DisplayName("ID")]
		public Guid ID { get; set; }
		
		[Required(AllowEmptyStrings = false, ErrorMessage = "Name is required.")]
		[DisplayName("Name")]
		public String Name { get; set; }
		
		[DisplayName("Project")]
		public Guid? ProjectID { get; set; }
		
		[DisplayName("Interface Agreement")]
		public Guid? InterfaceAgreementID { get; set; }
		
		[DisplayName("Interface Point")]
		public Guid? InterfacePointID { get; set; }
		
		[DisplayName("TIMS_Project")]
		public TIMS_ProjectViewModel TIMS_Project { get; set; }
		
		[DisplayName("TIMS_Project Interface Agreement")]
		public TIMS_ProjectInterfaceAgreementViewModel TIMS_ProjectInterfaceAgreement { get; set; }
		
		[DisplayName("TIMS_Project Action Item Workflow")]
		public List<TIMS_ProjectActionItemWorkflowViewModel> TIMS_ProjectActionItemWorkflow { get; set; }
		
		[DisplayName("TIMS_User Watchlist Item")]
		public List<TIMS_UserWatchlistItemViewModel> TIMS_UserWatchlistItem { get; set; }
		
		[DisplayName("TIMS_Project Interface Point")]
		public TIMS_ProjectInterfacePointViewModel TIMS_ProjectInterfacePoint { get; set; }
		

        public TIMS_ProjectActionItemViewModel()
        {

        }

        public TIMS_ProjectActionItemViewModel(TIMS_ProjectActionItem m, bool convertSubs = false)
        {
            if (m != null)
            {
                this.ID = m.ID;
				this.Name = m.Name;
				this.ProjectID = m.ProjectID;
				this.InterfaceAgreementID = m.InterfaceAgreementID;
				this.InterfacePointID = m.InterfacePointID;
				this.TIMS_Project = convertSubs ? new TIMS_ProjectViewModel(m.TIMS_Project) : null;
				this.TIMS_ProjectInterfaceAgreement = convertSubs ? new TIMS_ProjectInterfaceAgreementViewModel(m.TIMS_ProjectInterfaceAgreement) : null;
				this.TIMS_ProjectActionItemWorkflow = convertSubs && m.TIMS_ProjectActionItemWorkflow != null ? m.TIMS_ProjectActionItemWorkflow.Select(x => new TIMS_ProjectActionItemWorkflowViewModel(x)).ToList() : null;
				this.TIMS_UserWatchlistItem = convertSubs && m.TIMS_UserWatchlistItem != null ? m.TIMS_UserWatchlistItem.Select(x => new TIMS_UserWatchlistItemViewModel(x)).ToList() : null;
				this.TIMS_ProjectInterfacePoint = convertSubs ? new TIMS_ProjectInterfacePointViewModel(m.TIMS_ProjectInterfacePoint) : null;
            }
        }

        public override TIMS_ProjectActionItem ToModel(bool convertSubs = false)
        {
            var m = new TIMS_ProjectActionItem();

            m.ID = this.ID;
			m.Name = this.Name;
			m.ProjectID = this.ProjectID;
			m.InterfaceAgreementID = this.InterfaceAgreementID;
			m.InterfacePointID = this.InterfacePointID;
			m.TIMS_Project = convertSubs && this.TIMS_Project != null ?  this.TIMS_Project.ToModel() : null;
			m.TIMS_ProjectInterfaceAgreement = convertSubs && this.TIMS_ProjectInterfaceAgreement != null ?  this.TIMS_ProjectInterfaceAgreement.ToModel() : null;
			m.TIMS_ProjectActionItemWorkflow = convertSubs && this.TIMS_ProjectActionItemWorkflow != null  ? this.TIMS_ProjectActionItemWorkflow.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_UserWatchlistItem = convertSubs && this.TIMS_UserWatchlistItem != null  ? this.TIMS_UserWatchlistItem.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_ProjectInterfacePoint = convertSubs && this.TIMS_ProjectInterfacePoint != null ?  this.TIMS_ProjectInterfacePoint.ToModel() : null;

            return m;
        }

        public override BaseViewModel<TIMS_ProjectActionItem> FromModel<M>(M mo, bool convertSubs)
        {
            var m = mo as TIMS_ProjectActionItem;
            if (m != null)
            {
                this.ID = m.ID;
				this.Name = m.Name;
				this.ProjectID = m.ProjectID;
				this.InterfaceAgreementID = m.InterfaceAgreementID;
				this.InterfacePointID = m.InterfacePointID;
				this.TIMS_Project = convertSubs ? new TIMS_ProjectViewModel(m.TIMS_Project) : null;
				this.TIMS_ProjectInterfaceAgreement = convertSubs ? new TIMS_ProjectInterfaceAgreementViewModel(m.TIMS_ProjectInterfaceAgreement) : null;
				this.TIMS_ProjectActionItemWorkflow = convertSubs && m.TIMS_ProjectActionItemWorkflow != null ? m.TIMS_ProjectActionItemWorkflow.Select(x => new TIMS_ProjectActionItemWorkflowViewModel(x)).ToList() : null;
				this.TIMS_UserWatchlistItem = convertSubs && m.TIMS_UserWatchlistItem != null ? m.TIMS_UserWatchlistItem.Select(x => new TIMS_UserWatchlistItemViewModel(x)).ToList() : null;
				this.TIMS_ProjectInterfacePoint = convertSubs ? new TIMS_ProjectInterfacePointViewModel(m.TIMS_ProjectInterfacePoint) : null;
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