using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTrackerData;
using BugTrackerData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly BugTrackerContext _context;

        public TaskController(BugTrackerContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("Create")]
        //POST: api/Ticket/Create
        public async Task<ActionResult<ProjectTask>> CreateTicket(ProjectTask projectTask)
        {
            await _context.ProjectTasks.AddAsync(projectTask);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}