using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgileTeamsData.Models
{
    public class WorkItemComment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string CommentID { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Comment { get; set; }
        public string SubmittedBy { get; set; }
        [DataType(DataType.DateTime)]
        [Column(TypeName = "DateTime")]
        public DateTime SubmittedOn { get; set; }
        [ForeignKey("WorkItem")]
        public string CommentWorkItemID { get; set; }
        public WorkItem WorkItem { get; set; }

    }
}
