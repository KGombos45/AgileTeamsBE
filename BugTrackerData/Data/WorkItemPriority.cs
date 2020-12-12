using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BugTrackerData.Data
{
    public class WorkItemPriority
    {
        [Key]
        public int PriorityID { get; set; }
        [Required]
        public string PriorityName { get; set; }
    }
}
