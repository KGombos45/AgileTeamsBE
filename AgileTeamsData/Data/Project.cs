using AgileTeamsData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgileTeamsData.Data
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }

        public virtual IEnumerable<WorkItem> WorkItems { get; set; }
    }
}
