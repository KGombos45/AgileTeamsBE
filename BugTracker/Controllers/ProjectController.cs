using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTrackerData;
using BugTrackerData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly BugTrackerContext _context;
        private UserManager<ApplicationUser> _userManager;

        public ProjectController(BugTrackerContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        
        [HttpPost]
        [Route("Create")]
        //POST: api/Project/Create
        public async Task<ActionResult<Project>> CreateProject(Project project)
        {                                          
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        [Route("UpdateProject")]
        //PUT : /api/Project/UpdateProject
        public async Task<IActionResult> UpdateProject(Project project)
        {
            project.ProjectOwner = await _userManager.FindByIdAsync(project.ProjectOwnerID);
           
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpPost]
        [Route("DeleteProject")]
        public async Task<IActionResult> DeleteProject(Project project)
        {
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]        
        [Route("Statuses")]
        //GET : /api/Project/Statuses
        public async Task<IActionResult> GetStatuses()
        {
            var Statuses = _context.ProjectStatuses.ToList();

            return Ok(Statuses);

        }

        [HttpGet]
        [Route("Projects")]
        //GET : /api/Project/Projects
        public async Task<IActionResult> GetProjects()
        {
            var projects = _context.Projects.Include(p => p.ProjectStatus)
                .Include(p => p.ProjectOwner)
                .Include(p => p.Tickets).ThenInclude(t => t.TicketOwner)
                .Include(p => p.Tickets).ThenInclude(t => t.TicketStatus);


            return Ok(projects);

        }
    }
}