using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugTrackerData.Models
{
    public class ApplicationUserRole 
    {
        public string Id { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
