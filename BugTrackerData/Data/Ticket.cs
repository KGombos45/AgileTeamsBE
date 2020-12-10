using BugTrackerData.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BugTrackerData.Models
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string TicketID { get; set; }
        [Column(TypeName = "nvarchar(120)")]
        [Required]
        public string TicketName { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string TicketDescription { get; set; }
        public string CreatedBy { get; set; }
        [ForeignKey("TicketStatus")]
        public int TicketStatusID { get; set; }
        public TicketStatus TicketStatus { get; set; }
        [ForeignKey("TicketOwner")]
        public string TicketOwnerID { get; set; }
        public ApplicationUser TicketOwner { get; set; }
        [ForeignKey("TicketProject")]
        public string TicketProjectID { get; set; }
        public Project TicketProject { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime CreatedOn { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime? UpdatedOn { get; set; }

        public ICollection<TaskComment> Comments { get; set; }

    }
}
