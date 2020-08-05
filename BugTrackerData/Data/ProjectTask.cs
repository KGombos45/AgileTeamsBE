using BugTrackerData.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BugTrackerData.Models
{
    public class ProjectTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string TicketID { get; set; }
        [Column(TypeName = "nvarchar(120)")]
        [Required]
        public string TicketTitle { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string TicketDescription { get; set; }
        public string AssignedTo { get; set; }
        public string Submitter { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime CreatedOn { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime? UpdatedOn { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime? ClosedOn { get; set; }

        public virtual Project Project { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ProjectTaskStatus Status { get; set; }
        public virtual ProjectTaskPriority Priority { get; set; }

        public ICollection<TaskComment> Comments { get; set; }

    }
}
