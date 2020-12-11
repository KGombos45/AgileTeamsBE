using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BugTrackerData.Data
{
    public class WorkItemType
    {
        [Key]
        public int TypeID { get; set; }
        [Required]
        public string TypeName { get; set; }
    }
}
