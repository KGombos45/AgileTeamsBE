using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BugTrackerData.Models
{
    public class ProjectStatus
    {
        [Key]
        public int ProjectStatusId { get; set; }
        public string ProjectStatusName { get; set; }
    }
}
