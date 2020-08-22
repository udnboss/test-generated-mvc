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
    public class TIMS_ProjectInterfaceAgreementViewModel : BaseViewModel<TIMS_ProjectInterfaceAgreement>, IValidatableObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID is required.")]
		[DisplayName("ID")]
		public Guid ID { get; set; }
		
		[Required(AllowEmptyStrings = false, ErrorMessage = "Name is required.")]
		[DisplayName("Name")]
		public String Name { get; set; }
		
		[DisplayName("Interface Point")]
		public Guid? InterfacePointID { get; set; }
		
		[DisplayName("Requestor Package")]
		public Guid? RequestorPackageID { get; set; }
		
		[DisplayName("Responder Package")]
		public Guid? ResponderPackageID { get; set; }
		
		[DisplayName("Requestor User")]
		public Guid? RequestorUserID { get; set; }
		
		[DisplayName("Requestor Technical Contact")]
		public Guid? RequestorTechnicalContactID { get; set; }
		
		[DisplayName("Responder Interface Manager")]
		public Guid? ResponderInterfaceManagerID { get; set; }
		
		[DisplayName("Responder Technical Contact")]
		public Guid? ResponderTechnicalContactID { get; set; }
		
		[DisplayName("Create Date")]
		public DateTime? CreateDate { get; set; }
		
		[DisplayName("Need Date")]
		public DateTime? NeedDate { get; set; }
		
		[DisplayName("Issued Date")]
		public DateTime? IssuedDate { get; set; }
		
		[DisplayName("Accepted Date")]
		public DateTime? AcceptedDate { get; set; }
		
		[DisplayName("Response Date")]
		public DateTime? ResponseDate { get; set; }
		
		[DisplayName("Close Date")]
		public DateTime? CloseDate { get; set; }
		
		[DisplayName("TIMS_Project Action Item")]
		public List<TIMS_ProjectActionItemViewModel> TIMS_ProjectActionItem { get; set; }
		
		[DisplayName("TIMS_Project Interface Point")]
		public TIMS_ProjectInterfacePointViewModel TIMS_ProjectInterfacePoint { get; set; }
		
		[DisplayName("TIMS_Project Package")]
		public TIMS_ProjectPackageViewModel TIMS_ProjectPackage { get; set; }
		
		[DisplayName("TIMS_Project Package1")]
		public TIMS_ProjectPackageViewModel TIMS_ProjectPackage1 { get; set; }
		
		[DisplayName("TIMS_Project Interface Agreement Workflow")]
		public List<TIMS_ProjectInterfaceAgreementWorkflowViewModel> TIMS_ProjectInterfaceAgreementWorkflow { get; set; }
		
		[DisplayName("TIMS_User Watchlist Item")]
		public List<TIMS_UserWatchlistItemViewModel> TIMS_UserWatchlistItem { get; set; }
		

        public TIMS_ProjectInterfaceAgreementViewModel()
        {

        }

        public TIMS_ProjectInterfaceAgreementViewModel(TIMS_ProjectInterfaceAgreement m, bool convertSubs = false)
        {
            if (m != null)
            {
                this.ID = m.ID;
				this.Name = m.Name;
				this.InterfacePointID = m.InterfacePointID;
				this.RequestorPackageID = m.RequestorPackageID;
				this.ResponderPackageID = m.ResponderPackageID;
				this.RequestorUserID = m.RequestorUserID;
				this.RequestorTechnicalContactID = m.RequestorTechnicalContactID;
				this.ResponderInterfaceManagerID = m.ResponderInterfaceManagerID;
				this.ResponderTechnicalContactID = m.ResponderTechnicalContactID;
				this.CreateDate = m.CreateDate;
				this.NeedDate = m.NeedDate;
				this.IssuedDate = m.IssuedDate;
				this.AcceptedDate = m.AcceptedDate;
				this.ResponseDate = m.ResponseDate;
				this.CloseDate = m.CloseDate;
				this.TIMS_ProjectActionItem = convertSubs && m.TIMS_ProjectActionItem != null ? m.TIMS_ProjectActionItem.Select(x => new TIMS_ProjectActionItemViewModel(x)).ToList() : null;
				this.TIMS_ProjectInterfacePoint = convertSubs ? new TIMS_ProjectInterfacePointViewModel(m.TIMS_ProjectInterfacePoint) : null;
				this.TIMS_ProjectPackage = convertSubs ? new TIMS_ProjectPackageViewModel(m.TIMS_ProjectPackage) : null;
				this.TIMS_ProjectPackage1 = convertSubs ? new TIMS_ProjectPackageViewModel(m.TIMS_ProjectPackage1) : null;
				this.TIMS_ProjectInterfaceAgreementWorkflow = convertSubs && m.TIMS_ProjectInterfaceAgreementWorkflow != null ? m.TIMS_ProjectInterfaceAgreementWorkflow.Select(x => new TIMS_ProjectInterfaceAgreementWorkflowViewModel(x)).ToList() : null;
				this.TIMS_UserWatchlistItem = convertSubs && m.TIMS_UserWatchlistItem != null ? m.TIMS_UserWatchlistItem.Select(x => new TIMS_UserWatchlistItemViewModel(x)).ToList() : null;
            }
        }

        public override TIMS_ProjectInterfaceAgreement ToModel(bool convertSubs = false)
        {
            var m = new TIMS_ProjectInterfaceAgreement();

            m.ID = this.ID;
			m.Name = this.Name;
			m.InterfacePointID = this.InterfacePointID;
			m.RequestorPackageID = this.RequestorPackageID;
			m.ResponderPackageID = this.ResponderPackageID;
			m.RequestorUserID = this.RequestorUserID;
			m.RequestorTechnicalContactID = this.RequestorTechnicalContactID;
			m.ResponderInterfaceManagerID = this.ResponderInterfaceManagerID;
			m.ResponderTechnicalContactID = this.ResponderTechnicalContactID;
			m.CreateDate = this.CreateDate;
			m.NeedDate = this.NeedDate;
			m.IssuedDate = this.IssuedDate;
			m.AcceptedDate = this.AcceptedDate;
			m.ResponseDate = this.ResponseDate;
			m.CloseDate = this.CloseDate;
			m.TIMS_ProjectActionItem = convertSubs && this.TIMS_ProjectActionItem != null  ? this.TIMS_ProjectActionItem.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_ProjectInterfacePoint = convertSubs && this.TIMS_ProjectInterfacePoint != null ?  this.TIMS_ProjectInterfacePoint.ToModel() : null;
			m.TIMS_ProjectPackage = convertSubs && this.TIMS_ProjectPackage != null ?  this.TIMS_ProjectPackage.ToModel() : null;
			m.TIMS_ProjectPackage1 = convertSubs && this.TIMS_ProjectPackage1 != null ?  this.TIMS_ProjectPackage1.ToModel() : null;
			m.TIMS_ProjectInterfaceAgreementWorkflow = convertSubs && this.TIMS_ProjectInterfaceAgreementWorkflow != null  ? this.TIMS_ProjectInterfaceAgreementWorkflow.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_UserWatchlistItem = convertSubs && this.TIMS_UserWatchlistItem != null  ? this.TIMS_UserWatchlistItem.Select(x => x.ToModel()).ToList() : null;

            return m;
        }

        public override BaseViewModel<TIMS_ProjectInterfaceAgreement> FromModel<M>(M mo, bool convertSubs)
        {
            var m = mo as TIMS_ProjectInterfaceAgreement;
            if (m != null)
            {
                this.ID = m.ID;
				this.Name = m.Name;
				this.InterfacePointID = m.InterfacePointID;
				this.RequestorPackageID = m.RequestorPackageID;
				this.ResponderPackageID = m.ResponderPackageID;
				this.RequestorUserID = m.RequestorUserID;
				this.RequestorTechnicalContactID = m.RequestorTechnicalContactID;
				this.ResponderInterfaceManagerID = m.ResponderInterfaceManagerID;
				this.ResponderTechnicalContactID = m.ResponderTechnicalContactID;
				this.CreateDate = m.CreateDate;
				this.NeedDate = m.NeedDate;
				this.IssuedDate = m.IssuedDate;
				this.AcceptedDate = m.AcceptedDate;
				this.ResponseDate = m.ResponseDate;
				this.CloseDate = m.CloseDate;
				this.TIMS_ProjectActionItem = convertSubs && m.TIMS_ProjectActionItem != null ? m.TIMS_ProjectActionItem.Select(x => new TIMS_ProjectActionItemViewModel(x)).ToList() : null;
				this.TIMS_ProjectInterfacePoint = convertSubs ? new TIMS_ProjectInterfacePointViewModel(m.TIMS_ProjectInterfacePoint) : null;
				this.TIMS_ProjectPackage = convertSubs ? new TIMS_ProjectPackageViewModel(m.TIMS_ProjectPackage) : null;
				this.TIMS_ProjectPackage1 = convertSubs ? new TIMS_ProjectPackageViewModel(m.TIMS_ProjectPackage1) : null;
				this.TIMS_ProjectInterfaceAgreementWorkflow = convertSubs && m.TIMS_ProjectInterfaceAgreementWorkflow != null ? m.TIMS_ProjectInterfaceAgreementWorkflow.Select(x => new TIMS_ProjectInterfaceAgreementWorkflowViewModel(x)).ToList() : null;
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