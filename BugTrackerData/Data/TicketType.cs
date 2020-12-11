using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BugTrackerData.Models
{
    public class TicketType
    {
        [Key]
        public int TypeID { get; set; }
        [Required]
        public string TypeName { get; set; }
    }
}
