using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTrackerData;
using BugTrackerData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
            var statuses = _context.ProjectStatuses.ToList();
            var users = _context.ApplicationUsers.ToList(); ;


            foreach (var status in statuses)
            {
                if (status.ProjectStatusId == project.ProjectStatus.ProjectStatusId)
                {
                    project.ProjectStatus = status;
                }
            }

            foreach (var user in users)
            {
                if (user.Id == project.ProjectOwner.Id)
                {
                    project.ProjectOwner = user;
                }
            }



            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        [Route("UpdateProject")]
        //PUT : /api/Project/UpdateProject
        public async Task<IActionResult> UpdateProject(Project project)
        {
            var user = await _userManager.FindByIdAsync(project.ProjectOwner.Id);
           
            project.ProjectOwner = user;

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
            var projects = _context.Projects.ToList();
            var statuses = _context.ProjectStatuses.ToList();
            var users = _context.ApplicationUsers.ToList(); ; 

            return Ok(projects);

        }
    }
}