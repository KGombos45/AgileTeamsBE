using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgileTeamsData.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Column(TypeName = "nvarchar(36)")]
        public string FirstName { get; set; }
        [Column(TypeName = "nvarchar(36)")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string About { get; set; }        
    }
}
