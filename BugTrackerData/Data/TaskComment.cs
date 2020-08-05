using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BugTrackerData.Models
{
    public class TaskComment
    {
        [Key]
        public int CommentID { get; set; }
        public string SubmittedBy { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Details { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime Created { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime Updated { get; set; }

    }
}
