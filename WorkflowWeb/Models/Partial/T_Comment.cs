using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WorkflowWeb.Models
{
    public class T_CommentMeta
    {
        [JsonIgnore]
        public Guid? ParentID { get; set; }


        [JsonIgnore]
        public T_Comment T_Comment2 { get; set; }

        [JsonIgnore]
        public ICollection<T_Comment> T_Comment1 { get; set; }

        [JsonIgnore]
        public ICollection<T_CommentVote> T_CommentVote { get; set; }


        [JsonIgnore]
        public T_Domain T_Domain { get; set; }

    }

    [MetadataType(typeof(T_CommentMeta))]
    public partial class T_Comment
    {

    }

}