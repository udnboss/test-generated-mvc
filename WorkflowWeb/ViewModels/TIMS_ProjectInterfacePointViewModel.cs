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
    public class TIMS_ProjectInterfacePointViewModel : IValidatableObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID is required.")]
		[DisplayName("ID")]
		public Guid ID { get; set; }
		
		[DisplayName("Project ID")]
		public Guid? ProjectID { get; set; }
		
		[DisplayName("Lead Package ID")]
		public Guid? LeadPackageID { get; set; }
		
		[DisplayName("Interface Package ID")]
		public Guid? InterfacePackageID { get; set; }
		
		[DisplayName("Support Package ID")]
		public Guid? SupportPackageID { get; set; }
		
		[DisplayName("Create Date")]
		public DateTime? CreateDate { get; set; }
		
		[DisplayName("Issue Date")]
		public DateTime? IssueDate { get; set; }
		
		[DisplayName("Finalize Date")]
		public DateTime? FinalizeDate { get; set; }
		
		[DisplayName("Close Date")]
		public DateTime? CloseDate { get; set; }
		
		[DisplayName("TIMS_Project")]
		public TIMS_ProjectViewModel TIMS_Project { get; set; }
		
		[DisplayName("TIMS_Project Interface Agreement")]
		public List<TIMS_ProjectInterfaceAgreementViewModel> TIMS_ProjectInterfaceAgreement { get; set; }
		
		[DisplayName("TIMS_Project Package")]
		public TIMS_ProjectPackageViewModel TIMS_ProjectPackage { get; set; }
		
		[DisplayName("TIMS_Project Package1")]
		public TIMS_ProjectPackageViewModel TIMS_ProjectPackage1 { get; set; }
		
		[DisplayName("TIMS_Project Package2")]
		public TIMS_ProjectPackageViewModel TIMS_ProjectPackage2 { get; set; }
		
		[DisplayName("TIMS_User Watchlist Item")]
		public List<TIMS_UserWatchlistItemViewModel> TIMS_UserWatchlistItem { get; set; }
		

        public TIMS_ProjectInterfacePointViewModel()
        {

        }

        public TIMS_ProjectInterfacePointViewModel(TIMS_ProjectInterfacePoint m, bool convertSubs = false)
        {
            if (m != null)
            {
                this.ID = m.ID;
				this.ProjectID = m.ProjectID;
				this.LeadPackageID = m.LeadPackageID;
				this.InterfacePackageID = m.InterfacePackageID;
				this.SupportPackageID = m.SupportPackageID;
				this.CreateDate = m.CreateDate;
				this.IssueDate = m.IssueDate;
				this.FinalizeDate = m.FinalizeDate;
				this.CloseDate = m.CloseDate;
				this.TIMS_Project = convertSubs ? new TIMS_ProjectViewModel(m.TIMS_Project) : null;
				this.TIMS_ProjectInterfaceAgreement = convertSubs && m.TIMS_ProjectInterfaceAgreement != null ? m.TIMS_ProjectInterfaceAgreement.Select(x => new TIMS_ProjectInterfaceAgreementViewModel(x)).ToList() : null;
				this.TIMS_ProjectPackage = convertSubs ? new TIMS_ProjectPackageViewModel(m.TIMS_ProjectPackage) : null;
				this.TIMS_ProjectPackage1 = convertSubs ? new TIMS_ProjectPackageViewModel(m.TIMS_ProjectPackage1) : null;
				this.TIMS_ProjectPackage2 = convertSubs ? new TIMS_ProjectPackageViewModel(m.TIMS_ProjectPackage2) : null;
				this.TIMS_UserWatchlistItem = convertSubs && m.TIMS_UserWatchlistItem != null ? m.TIMS_UserWatchlistItem.Select(x => new TIMS_UserWatchlistItemViewModel(x)).ToList() : null;
            }
        }

        public TIMS_ProjectInterfacePoint ToModel(bool convertSubs = false)
        {
            var m = new TIMS_ProjectInterfacePoint();

            m.ID = this.ID;
			m.ProjectID = this.ProjectID;
			m.LeadPackageID = this.LeadPackageID;
			m.InterfacePackageID = this.InterfacePackageID;
			m.SupportPackageID = this.SupportPackageID;
			m.CreateDate = this.CreateDate;
			m.IssueDate = this.IssueDate;
			m.FinalizeDate = this.FinalizeDate;
			m.CloseDate = this.CloseDate;
			m.TIMS_Project = convertSubs ? this.TIMS_Project.ToModel() : null;
			m.TIMS_ProjectInterfaceAgreement = convertSubs ? this.TIMS_ProjectInterfaceAgreement.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_ProjectPackage = convertSubs ? this.TIMS_ProjectPackage.ToModel() : null;
			m.TIMS_ProjectPackage1 = convertSubs ? this.TIMS_ProjectPackage1.ToModel() : null;
			m.TIMS_ProjectPackage2 = convertSubs ? this.TIMS_ProjectPackage2.ToModel() : null;
			m.TIMS_UserWatchlistItem = convertSubs ? this.TIMS_UserWatchlistItem.Select(x => x.ToModel()).ToList() : null;

            return m;
        }

        public string ToRouteFilter()
        {
            var route_filter = JsonConvert.SerializeObject(new { ID,ProjectID,LeadPackageID,InterfacePackageID,SupportPackageID,CreateDate,IssueDate,FinalizeDate,CloseDate });
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