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
    public class TIMS_ProjectActionItemViewModel : IValidatableObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID is required.")]
		[DisplayName("ID")]
		public Guid ID { get; set; }
		
		[Required(AllowEmptyStrings = false, ErrorMessage = "Name is required.")]
		[DisplayName("Name")]
		public String Name { get; set; }
		
		[DisplayName("Project ID")]
		public Guid? ProjectID { get; set; }
		
		[DisplayName("Interface Agreement ID")]
		public Guid? InterfaceAgreementID { get; set; }
		
		[DisplayName("TIMS_Project")]
		public TIMS_ProjectViewModel TIMS_Project { get; set; }
		
		[DisplayName("TIMS_Project Interface Agreement")]
		public TIMS_ProjectInterfaceAgreementViewModel TIMS_ProjectInterfaceAgreement { get; set; }
		
		[DisplayName("TIMS_Project Action Item Workflow")]
		public List<TIMS_ProjectActionItemWorkflowViewModel> TIMS_ProjectActionItemWorkflow { get; set; }
		
		[DisplayName("TIMS_User Watchlist Item")]
		public List<TIMS_UserWatchlistItemViewModel> TIMS_UserWatchlistItem { get; set; }
		

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
				this.TIMS_Project = convertSubs ? new TIMS_ProjectViewModel(m.TIMS_Project) : null;
				this.TIMS_ProjectInterfaceAgreement = convertSubs ? new TIMS_ProjectInterfaceAgreementViewModel(m.TIMS_ProjectInterfaceAgreement) : null;
				this.TIMS_ProjectActionItemWorkflow = convertSubs && m.TIMS_ProjectActionItemWorkflow != null ? m.TIMS_ProjectActionItemWorkflow.Select(x => new TIMS_ProjectActionItemWorkflowViewModel(x)).ToList() : null;
				this.TIMS_UserWatchlistItem = convertSubs && m.TIMS_UserWatchlistItem != null ? m.TIMS_UserWatchlistItem.Select(x => new TIMS_UserWatchlistItemViewModel(x)).ToList() : null;
            }
        }

        public TIMS_ProjectActionItem ToModel(bool convertSubs = false)
        {
            var m = new TIMS_ProjectActionItem();

            m.ID = this.ID;
			m.Name = this.Name;
			m.ProjectID = this.ProjectID;
			m.InterfaceAgreementID = this.InterfaceAgreementID;
			m.TIMS_Project = convertSubs ? this.TIMS_Project.ToModel() : null;
			m.TIMS_ProjectInterfaceAgreement = convertSubs ? this.TIMS_ProjectInterfaceAgreement.ToModel() : null;
			m.TIMS_ProjectActionItemWorkflow = convertSubs ? this.TIMS_ProjectActionItemWorkflow.Select(x => x.ToModel()).ToList() : null;
			m.TIMS_UserWatchlistItem = convertSubs ? this.TIMS_UserWatchlistItem.Select(x => x.ToModel()).ToList() : null;

            return m;
        }

        public string ToRouteFilter()
        {
            var route_filter = JsonConvert.SerializeObject(new { ID,Name,ProjectID,InterfaceAgreementID });
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