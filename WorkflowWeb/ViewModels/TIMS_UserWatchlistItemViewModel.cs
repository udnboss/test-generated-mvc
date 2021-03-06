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
    public partial class TIMS_UserWatchlistItemViewModel : BaseViewModel<TIMS_UserWatchlistItem>, IValidatableObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID is required.")]
		[DisplayName("ID")]
		public Guid ID { get; set; }
		
		[DisplayName("User")]
		public Guid? UserID { get; set; }
		
		[DisplayName("Project Interface Point")]
		public Guid? ProjectInterfacePointID { get; set; }
		
		[DisplayName("Project Interface Agreement")]
		public Guid? ProjectInterfaceAgreementID { get; set; }
		
		[DisplayName("Project Action Item")]
		public Guid? ProjectActionItemID { get; set; }
		
		[DisplayName("TIMS_Project Action Item")]
		public TIMS_ProjectActionItemViewModel TIMS_ProjectActionItem { get; set; }
		
		[DisplayName("TIMS_Project Interface Agreement")]
		public TIMS_ProjectInterfaceAgreementViewModel TIMS_ProjectInterfaceAgreement { get; set; }
		
		[DisplayName("TIMS_Project Interface Point")]
		public TIMS_ProjectInterfacePointViewModel TIMS_ProjectInterfacePoint { get; set; }
		
		[DisplayName("TIMS_User")]
		public TIMS_UserViewModel TIMS_User { get; set; }
		

        public TIMS_UserWatchlistItemViewModel()
        {

        }

        public TIMS_UserWatchlistItemViewModel(TIMS_UserWatchlistItem m, bool convertSubs = false)
        {
            if (m != null)
            {
                this.ID = m.ID;
				this.UserID = m.UserID;
				this.ProjectInterfacePointID = m.ProjectInterfacePointID;
				this.ProjectInterfaceAgreementID = m.ProjectInterfaceAgreementID;
				this.ProjectActionItemID = m.ProjectActionItemID;
				this.TIMS_ProjectActionItem = convertSubs ? new TIMS_ProjectActionItemViewModel(m.TIMS_ProjectActionItem) : null;
				this.TIMS_ProjectInterfaceAgreement = convertSubs ? new TIMS_ProjectInterfaceAgreementViewModel(m.TIMS_ProjectInterfaceAgreement) : null;
				this.TIMS_ProjectInterfacePoint = convertSubs ? new TIMS_ProjectInterfacePointViewModel(m.TIMS_ProjectInterfacePoint) : null;
				this.TIMS_User = convertSubs ? new TIMS_UserViewModel(m.TIMS_User) : null;
            }
        }

        public override TIMS_UserWatchlistItem ToModel(bool convertSubs = false)
        {
            var m = new TIMS_UserWatchlistItem();

            m.ID = this.ID;
			m.UserID = this.UserID;
			m.ProjectInterfacePointID = this.ProjectInterfacePointID;
			m.ProjectInterfaceAgreementID = this.ProjectInterfaceAgreementID;
			m.ProjectActionItemID = this.ProjectActionItemID;
			m.TIMS_ProjectActionItem = convertSubs && this.TIMS_ProjectActionItem != null ?  this.TIMS_ProjectActionItem.ToModel() : null;
			m.TIMS_ProjectInterfaceAgreement = convertSubs && this.TIMS_ProjectInterfaceAgreement != null ?  this.TIMS_ProjectInterfaceAgreement.ToModel() : null;
			m.TIMS_ProjectInterfacePoint = convertSubs && this.TIMS_ProjectInterfacePoint != null ?  this.TIMS_ProjectInterfacePoint.ToModel() : null;
			m.TIMS_User = convertSubs && this.TIMS_User != null ?  this.TIMS_User.ToModel() : null;

            return m;
        }

        public override BaseViewModel<TIMS_UserWatchlistItem> FromModel<M>(M mo, bool convertSubs)
        {
            var m = mo as TIMS_UserWatchlistItem;
            if (m != null)
            {
                this.ID = m.ID;
				this.UserID = m.UserID;
				this.ProjectInterfacePointID = m.ProjectInterfacePointID;
				this.ProjectInterfaceAgreementID = m.ProjectInterfaceAgreementID;
				this.ProjectActionItemID = m.ProjectActionItemID;
				this.TIMS_ProjectActionItem = convertSubs ? new TIMS_ProjectActionItemViewModel(m.TIMS_ProjectActionItem) : null;
				this.TIMS_ProjectInterfaceAgreement = convertSubs ? new TIMS_ProjectInterfaceAgreementViewModel(m.TIMS_ProjectInterfaceAgreement) : null;
				this.TIMS_ProjectInterfacePoint = convertSubs ? new TIMS_ProjectInterfacePointViewModel(m.TIMS_ProjectInterfacePoint) : null;
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