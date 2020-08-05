using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BugTrackerData.Models
{
    public class ProjectTaskStatus
    {
        [Key]
        public int ProjectStatusId { get; set; }
        [Required]
        public string ProjectStatusName { get; set; }
    }
}
