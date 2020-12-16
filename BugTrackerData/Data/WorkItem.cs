using BugTrackerData.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BugTrackerData.Models
{
    public class WorkItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string WorkItemID { get; set; }
        [Column(TypeName = "nvarchar(120)")]
        [Required]
        public string WorkItemName { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string WorkItemDescription { get; set; }
        [ForeignKey("Project")]
        public string WorkItemProjectID { get; set; }
        public Project Project { get; set; }
        public int WorkItemStatusID { get; set; }
        public WorkItemStatus WorkItemStatus { get; set; }
        public int WorkItemTypeID { get; set; }
        public WorkItemType WorkItemType { get; set; }
        public int WorkItemPriorityID { get; set; }
        public WorkItemPriority WorkItemPriority { get; set; }
        public string WorkItemOwnerID { get; set; }
        public ApplicationUserRole WorkItemOwner { get; set; }
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

        public virtual IEnumerable<WorkItemComment> Comments { get; set; }
        public virtual IEnumerable<Ticket> Tickets { get; set; }

    }
}
