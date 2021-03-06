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
    public partial class T_CommentViewModel : BaseViewModel<T_Comment>, IValidatableObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID is required.")]
		[DisplayName("ID")]
		public Guid ID { get; set; }
		
		[DisplayName("Domain")]
		public String DomainID { get; set; }
		
		[DisplayName("Path")]
		public String Path { get; set; }
		
		[DisplayName("IP")]
		public String IP { get; set; }
		
		[Required(AllowEmptyStrings = false, ErrorMessage = "Name is required.")]
		[DisplayName("Name")]
		public String Name { get; set; }
		
		[DisplayName("Comment")]
		public String Comment { get; set; }
		
		[DisplayName("Parent")]
		public Guid? ParentID { get; set; }
		
		[DisplayName("Date Posted")]
		public DateTime DatePosted { get; set; }
		
		[DisplayName("Query String")]
		public String QueryString { get; set; }
		
		[DisplayName("T_Comment1")]
		[JsonIgnore]
		public List<T_CommentViewModel> T_Comment1 { get; set; }
		
		[DisplayName("T_Comment2")]
		public T_CommentViewModel T_Comment2 { get; set; }
		
		[DisplayName("T_Domain")]
		public T_DomainViewModel T_Domain { get; set; }
		
		[DisplayName("T_Comment Vote")]
		[JsonIgnore]
		public List<T_CommentVoteViewModel> T_CommentVote { get; set; }
		

        public T_CommentViewModel()
        {
			DatePosted = DateTime.Now;

		}

        public T_CommentViewModel(T_Comment m, bool convertSubs = false)
        {
            if (m != null)
            {
                this.ID = m.ID;
				this.DomainID = m.DomainID;
				this.Path = m.Path;
				this.IP = m.IP;
				this.Name = m.Name;
				this.Comment = m.Comment;
				this.ParentID = m.ParentID;
				this.DatePosted = m.DatePosted;
				this.QueryString = m.QueryString;
				this.T_Comment1 = convertSubs && m.T_Comment1 != null ? m.T_Comment1.Select(x => new T_CommentViewModel(x)).ToList() : null;
				this.T_Comment2 = convertSubs ? new T_CommentViewModel(m.T_Comment2) : null;
				this.T_Domain = convertSubs ? new T_DomainViewModel(m.T_Domain) : null;
				this.T_CommentVote = convertSubs && m.T_CommentVote != null ? m.T_CommentVote.Select(x => new T_CommentVoteViewModel(x)).ToList() : null;
            }
        }

        public override T_Comment ToModel(bool convertSubs = false)
        {
            var m = new T_Comment();

            m.ID = this.ID;
			m.DomainID = this.DomainID;
			m.Path = this.Path;
			m.IP = this.IP;
			m.Name = this.Name;
			m.Comment = this.Comment;
			m.ParentID = this.ParentID;
			m.DatePosted = this.DatePosted;
			m.QueryString = this.QueryString;
			m.T_Comment1 = convertSubs && this.T_Comment1 != null  ? this.T_Comment1.Select(x => x.ToModel()).ToList() : null;
			m.T_Comment2 = convertSubs && this.T_Comment2 != null ?  this.T_Comment2.ToModel() : null;
			m.T_Domain = convertSubs && this.T_Domain != null ?  this.T_Domain.ToModel() : null;
			m.T_CommentVote = convertSubs && this.T_CommentVote != null  ? this.T_CommentVote.Select(x => x.ToModel()).ToList() : null;

            return m;
        }



		public Row ToRow()
		{

			var row = new Row { 
				PrimaryKey = ID.ToString(), 
				Cells = new Dictionary<string, Cell> {
					{"ID", new Cell { Value = ID, DisplayValue = ID.ToString(), Color = null } },
					{"DomainID", new Cell { Value = DomainID, DisplayValue = DomainID != null ? Str(T_Domain.Host) : null, Color = null } },
					{"Path", new Cell { Value = Path, DisplayValue = Str(Path), Color = null } },
					{"IP", new Cell { Value = IP, DisplayValue = Str(IP), Color = null } },
					{"Name", new Cell { Value = Name, DisplayValue = Str(Name), Color = null } },
					{"Comment", new Cell { Value = Comment, DisplayValue = Str(Comment), Color = null } },
					{"DatePosted", new Cell { Value = DatePosted, DisplayValue = Str(DatePosted), Color = null } },
					{"QueryString", new Cell { Value = QueryString, DisplayValue = Str(QueryString), Color = null } }
				}
			};

			return row;
        }

        public override BaseViewModel<T_Comment> FromModel<M>(M mo, bool convertSubs)
        {
            var m = mo as T_Comment;
            if (m != null)
            {
                this.ID = m.ID;
				this.DomainID = m.DomainID;
				this.Path = m.Path;
				this.IP = m.IP;
				this.Name = m.Name;
				this.Comment = m.Comment;
				this.ParentID = m.ParentID;
				this.DatePosted = m.DatePosted;
				this.QueryString = m.QueryString;
				this.T_Comment1 = convertSubs && m.T_Comment1 != null ? m.T_Comment1.Select(x => new T_CommentViewModel(x)).ToList() : null;
				this.T_Comment2 = convertSubs ? new T_CommentViewModel(m.T_Comment2) : null;
				this.T_Domain = convertSubs ? new T_DomainViewModel(m.T_Domain) : null;
				this.T_CommentVote = convertSubs && m.T_CommentVote != null ? m.T_CommentVote.Select(x => new T_CommentVoteViewModel(x)).ToList() : null;
            }

            return this;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            

            return errors.AsEnumerable();
        }
    		
	}

	public class Table
    {
		public Dictionary<string, Column> Columns { get; set; }
		public List<Row> Rows { get; set; }
    }
	public class Column
    {
		public string Name { get; set; }
		public string DisplayName { get; set; }
		public string Type { get; set; }
		public string Component { get; set; }
    }
	public class Row
    {
		public string PrimaryKey { get; set; }
		public Dictionary<string, Cell> Cells { get; set; }

		public Row()
        {
			Cells = new Dictionary<string, Cell>();
        }
    }

	public class Cell
    {
		public string Color { get; set; }
		public object Value { get; set; }
		public string DisplayValue { get; set; }
    }
}