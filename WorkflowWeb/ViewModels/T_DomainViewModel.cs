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
    public partial class T_DomainViewModel : BaseViewModel<T_Domain>, IValidatableObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID is required.")]
		[DisplayName("ID")]
		public String ID { get; set; }
		
		[DisplayName("Host")]
		public String Host { get; set; }
		
		[DisplayName("Port")]
		public Int32? Port { get; set; }
		
		[DisplayName("T_Comment")]
		public List<T_CommentViewModel> T_Comment { get; set; }
		

        public T_DomainViewModel()
        {

        }

        public T_DomainViewModel(T_Domain m, bool convertSubs = false)
        {
            if (m != null)
            {
                this.ID = m.ID;
				this.Host = m.Host;
				this.Port = m.Port;
				this.T_Comment = convertSubs && m.T_Comment != null ? m.T_Comment.Select(x => new T_CommentViewModel(x)).ToList() : null;
            }
        }

        public override T_Domain ToModel(bool convertSubs = false)
        {
            var m = new T_Domain();

            m.ID = this.ID;
			m.Host = this.Host;
			m.Port = this.Port;
			m.T_Comment = convertSubs && this.T_Comment != null  ? this.T_Comment.Select(x => x.ToModel()).ToList() : null;

            return m;
        }

        public override BaseViewModel<T_Domain> FromModel<M>(M mo, bool convertSubs)
        {
            var m = mo as T_Domain;
            if (m != null)
            {
                this.ID = m.ID;
				this.Host = m.Host;
				this.Port = m.Port;
				this.T_Comment = convertSubs && m.T_Comment != null ? m.T_Comment.Select(x => new T_CommentViewModel(x)).ToList() : null;
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