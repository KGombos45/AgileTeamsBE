using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BugTrackerData.Data
{
    public class ProjectTaskPriority
    {
        [Key]
        public int ProjectPriorityId { get; set; }
        [Required]
        public string ProjectPriorityName { get; set; }
    }
}
