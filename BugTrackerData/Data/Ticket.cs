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
        public int TicketStatusID { get; set; }
        public TicketStatus TicketStatus { get; set; }
        public int TicketTypeID { get; set; }
        public TicketType TicketType { get; set; }
        public string TicketOwnerID { get; set; }
        public ApplicationUserRole TicketOwner { get; set; }
        [ForeignKey("TicketWorkItem")]
        public string TicketWorkItemID { get; set; }
        public WorkItem TicketWorkItem { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime CreatedOn { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

    }
}
