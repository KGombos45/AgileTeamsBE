using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AgileTeamsData.Models
{
    public class WorkItemStatus
    {
        [Key]
        public int StatusID { get; set; }
        [Required]
        public string StatusName { get; set; }
    }
}
