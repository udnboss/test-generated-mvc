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
    public partial class T_UploadViewModel : BaseViewModel<T_Upload>, IValidatableObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID is required.")]
		[DisplayName("ID")]
		public Guid ID { get; set; }
		
		[Required(AllowEmptyStrings = false, ErrorMessage = "Name is required.")]
		[DisplayName("Name")]
		public String Name { get; set; }
		
		[DisplayName("Path")]
		public String Path { get; set; }
		
		[DisplayName("Size")]
		public Int32? Size { get; set; }
		
		[DisplayName("Upload Date")]
		public DateTime? UploadDate { get; set; }
		
		[DisplayName("Parent")]
		public Guid? ParentID { get; set; }
		

        public T_UploadViewModel()
        {

        }

        public T_UploadViewModel(T_Upload m, bool convertSubs = false)
        {
            if (m != null)
            {
                this.ID = m.ID;
				this.Name = m.Name;
				this.Path = m.Path;
				this.Size = m.Size;
				this.UploadDate = m.UploadDate;
				this.ParentID = m.ParentID;
            }
        }

        public override T_Upload ToModel(bool convertSubs = false)
        {
            var m = new T_Upload();

            m.ID = this.ID;
			m.Name = this.Name;
			m.Path = this.Path;
			m.Size = this.Size;
			m.UploadDate = this.UploadDate;
			m.ParentID = this.ParentID;

            return m;
        }

        public override BaseViewModel<T_Upload> FromModel<M>(M mo, bool convertSubs)
        {
            var m = mo as T_Upload;
            if (m != null)
            {
                this.ID = m.ID;
				this.Name = m.Name;
				this.Path = m.Path;
				this.Size = m.Size;
				this.UploadDate = m.UploadDate;
				this.ParentID = m.ParentID;
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