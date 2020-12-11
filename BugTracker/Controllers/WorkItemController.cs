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
    public class WorkItemController : ControllerBase
    {
        private readonly BugTrackerContext _context;
        private UserManager<ApplicationUser> _userManager;

        public WorkItemController(BugTrackerContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        
        [HttpPost]
        [Route("Create")]
        //POST: api/WorkItem/Create
        public async Task<ActionResult<WorkItem>> CreatWorkItem(WorkItem workItem)
        {                                          
            await _context.WorkItems.AddAsync(workItem);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        [Route("updateWorkItem")]
        //PUT : /api/WorkItem/Update
        public async Task<IActionResult> UpdateWorkItem(WorkItem workItem)
        {
            workItem.WorkItemOwner = await _userManager.FindByIdAsync(workItem.WorkItemOwnerID);
           
            _context.WorkItems.Update(workItem);
            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpPost]
        [Route("DeleteWorkItem")]
        public async Task<IActionResult> DeleteWorkItem(WorkItem workItem)
        {
            _context.Tickets.RemoveRange(workItem.Tickets);
            _context.WorkItems.Remove(workItem);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]        
        [Route("Statuses")]
        //GET : /api/WorkItem/Statuses
        public async Task<IActionResult> GetStatuses()
        {
            var statuses = _context.WorkItemStatuses.ToList();

            return Ok(statuses);

        }

        [HttpGet]
        [Route("Types")]
        //GET : /api/WorkItem/Types
        public async Task<IActionResult> GetTypes()
        {
            var types = _context.WorkItemTypes.ToList();

            return Ok(types);

        }

        [HttpGet]
        [Route("WorkItems")]
        //GET : /api/WorkItem/WorkItems
        public async Task<IActionResult> GetWorkItems()
        {
            var workItems = _context.WorkItems
                .Include(w => w.Project)
                .Include(w => w.WorkItemStatus)
                .Include(w => w.WorkItemType)
                .Include(w => w.WorkItemOwner)
                .Include(w => w.Tickets).ThenInclude(t => t.TicketOwner)
                .Include(w => w.Tickets).ThenInclude(t => t.TicketStatus);


            return Ok(workItems);

        }

        [HttpGet]
        [Route("WorkItems/{userId}")]
        //GET : /api/WorkItem/WorkItems
        public async Task<IActionResult> GetUserWorkItems(string userId)
        {
            var workItems = _context.WorkItems                
                .Include(w => w.Project)
                .Include(w => w.WorkItemStatus)
                .Include(w => w.WorkItemType)
                .Include(w => w.WorkItemOwner)
                .Include(w => w.Tickets).ThenInclude(t => t.TicketOwner)
                .Include(w => w.Tickets).ThenInclude(t => t.TicketStatus)
                .Where(w => w.WorkItemOwnerID.Equals(userId));


            return Ok(workItems);

        }
    }
}