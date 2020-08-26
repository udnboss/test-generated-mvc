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
    public partial class T_CommentVoteViewModel : BaseViewModel<T_CommentVote>, IValidatableObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID is required.")]
		[DisplayName("ID")]
		public Guid ID { get; set; }
		
		[DisplayName("Vote")]
		public Int32 Vote { get; set; }
		
		[DisplayName("IP")]
		public String IP { get; set; }
		
		[DisplayName("Comment")]
		public Guid CommentID { get; set; }
		
		[DisplayName("T_Comment")]
		public T_CommentViewModel T_Comment { get; set; }
		

        public T_CommentVoteViewModel()
        {

        }

        public T_CommentVoteViewModel(T_CommentVote m, bool convertSubs = false)
        {
            if (m != null)
            {
                this.ID = m.ID;
				this.Vote = m.Vote;
				this.IP = m.IP;
				this.CommentID = m.CommentID;
				this.T_Comment = convertSubs ? new T_CommentViewModel(m.T_Comment) : null;
            }
        }

        public override T_CommentVote ToModel(bool convertSubs = false)
        {
            var m = new T_CommentVote();

            m.ID = this.ID;
			m.Vote = this.Vote;
			m.IP = this.IP;
			m.CommentID = this.CommentID;
			m.T_Comment = convertSubs && this.T_Comment != null ?  this.T_Comment.ToModel() : null;

            return m;
        }

        public override BaseViewModel<T_CommentVote> FromModel<M>(M mo, bool convertSubs)
        {
            var m = mo as T_CommentVote;
            if (m != null)
            {
                this.ID = m.ID;
				this.Vote = m.Vote;
				this.IP = m.IP;
				this.CommentID = m.CommentID;
				this.T_Comment = convertSubs ? new T_CommentViewModel(m.T_Comment) : null;
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