using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BugTrackerData.Models
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ProjectId { get; set; }
        [Column(TypeName = "nvarchar(120)")]
        [Required]
        public string ProjectName { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string ProjectDescription { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public ApplicationUser ProjectOwner { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime? TargetEndDate { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime? ActualEndDate { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public virtual IEnumerable<ProjectTask> Tasks { get; set; }

    }
}
