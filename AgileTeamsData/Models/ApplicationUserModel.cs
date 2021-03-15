using System;
using System.Collections.Generic;
using System.Text;

namespace AgileTeamsData.Models
{
    public class ApplicationUserModel
    {
        public string ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string About { get; set; }
        public string Role { get; set; }

    }
}
