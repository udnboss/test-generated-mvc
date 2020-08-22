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
    public class TIMS_ProjectDisciplineInterfaceTypeFieldViewModel : BaseViewModel<TIMS_ProjectDisciplineInterfaceTypeField>, IValidatableObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID is required.")]
		[DisplayName("ID")]
		public Guid ID { get; set; }
		
		[Required(AllowEmptyStrings = false, ErrorMessage = "Name is required.")]
		[DisplayName("Name")]
		public String Name { get; set; }
		
		[DisplayName("Interface Type")]
		public Guid? InterfaceTypeID { get; set; }
		
		[DisplayName("TIMS_Project Discipline Interface Type")]
		public TIMS_ProjectDisciplineInterfaceTypeViewModel TIMS_ProjectDisciplineInterfaceType { get; set; }
		
		[DisplayName("TIMS_Project Interface Point Field Entry")]
		public List<TIMS_ProjectInterfacePointFieldEntryViewModel> TIMS_ProjectInterfacePointFieldEntry { get; set; }
		

        public TIMS_ProjectDisciplineInterfaceTypeFieldViewModel()
        {

        }

        public TIMS_ProjectDisciplineInterfaceTypeFieldViewModel(TIMS_ProjectDisciplineInterfaceTypeField m, bool convertSubs = false)
        {
            if (m != null)
            {
                this.ID = m.ID;
				this.Name = m.Name;
				this.InterfaceTypeID = m.InterfaceTypeID;
				this.TIMS_ProjectDisciplineInterfaceType = convertSubs ? new TIMS_ProjectDisciplineInterfaceTypeViewModel(m.TIMS_ProjectDisciplineInterfaceType) : null;
				this.TIMS_ProjectInterfacePointFieldEntry = convertSubs && m.TIMS_ProjectInterfacePointFieldEntry != null ? m.TIMS_ProjectInterfacePointFieldEntry.Select(x => new TIMS_ProjectInterfacePointFieldEntryViewModel(x)).ToList() : null;
            }
        }

        public override TIMS_ProjectDisciplineInterfaceTypeField ToModel(bool convertSubs = false)
        {
            var m = new TIMS_ProjectDisciplineInterfaceTypeField();

            m.ID = this.ID;
			m.Name = this.Name;
			m.InterfaceTypeID = this.InterfaceTypeID;
			m.TIMS_ProjectDisciplineInterfaceType = convertSubs && this.TIMS_ProjectDisciplineInterfaceType != null ?  this.TIMS_ProjectDisciplineInterfaceType.ToModel() : null;
			m.TIMS_ProjectInterfacePointFieldEntry = convertSubs && this.TIMS_ProjectInterfacePointFieldEntry != null  ? this.TIMS_ProjectInterfacePointFieldEntry.Select(x => x.ToModel()).ToList() : null;

            return m;
        }

        public override BaseViewModel<TIMS_ProjectDisciplineInterfaceTypeField> FromModel<M>(M mo, bool convertSubs)
        {
            var m = mo as TIMS_ProjectDisciplineInterfaceTypeField;
            if (m != null)
            {
                this.ID = m.ID;
				this.Name = m.Name;
				this.InterfaceTypeID = m.InterfaceTypeID;
				this.TIMS_ProjectDisciplineInterfaceType = convertSubs ? new TIMS_ProjectDisciplineInterfaceTypeViewModel(m.TIMS_ProjectDisciplineInterfaceType) : null;
				this.TIMS_ProjectInterfacePointFieldEntry = convertSubs && m.TIMS_ProjectInterfacePointFieldEntry != null ? m.TIMS_ProjectInterfacePointFieldEntry.Select(x => new TIMS_ProjectInterfacePointFieldEntryViewModel(x)).ToList() : null;
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