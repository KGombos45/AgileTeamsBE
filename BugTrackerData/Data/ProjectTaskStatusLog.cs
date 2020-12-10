using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BugTrackerData.Models
{
    public class ProjectTaskStatusLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ProjectTaskStatusId { get; set; }

        public virtual Ticket Ticket { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual TicketStatus Status { get; set; }
        public DateTime LogDate { get; set; }
    }
}
