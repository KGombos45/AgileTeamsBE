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

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectStatus> ProjectStatuses { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketStatus> TicketStatuses { get; set; }
        public DbSet<ProjectTaskPriority> ProjectTaskPriorities { get; set; }
        public DbSet<ProjectTaskStatusLog> ProjectTaskStatusLogs { get; set; }
        public DbSet<TaskComment> TaskComments { get; set; }
    }
}
