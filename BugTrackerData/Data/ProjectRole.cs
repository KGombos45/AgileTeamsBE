using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BugTrackerData.Models
{
    public class ProjectRole
    {
        public int ProjectRoleId { get; set; }
        [Required]
        public string ProjectRoleName { get; set; }
    }
}
