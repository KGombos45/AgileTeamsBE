using BugTrackerData.Data;
using BugTrackerData.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace BugTrackerData
{
    public class BugTrackerContext : IdentityDbContext<ApplicationUser>
    {
        public BugTrackerContext(DbContextOptions<BugTrackerContext> options) : base(options) {  }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }

        public DbSet<WorkItem> WorkItems { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<WorkItemStatus> WorkItemStatuses { get; set; }
        public DbSet<WorkItemPriority> WorkItemPriorities { get; set; }
        public DbSet<WorkItemComment> WorkItemComments { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketStatus> TicketStatuses { get; set; }
        public DbSet<WorkItemType> WorkItemTypes { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }

        public DbSet<ProjectTaskStatusLog> ProjectTaskStatusLogs { get; set; }
    }
}
