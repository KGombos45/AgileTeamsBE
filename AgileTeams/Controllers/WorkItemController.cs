using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgileTeamsData;
using AgileTeamsData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgileTeams.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkItemController : ControllerBase
    {
        private readonly AgileTeamsContext _context;
        private UserManager<ApplicationUser> _userManager;

        public WorkItemController(AgileTeamsContext context, UserManager<ApplicationUser> userManager)
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

        [HttpPost]
        [Route("AddComment")]
        //POST: api/WorkItem/AddComment
        public async Task<ActionResult<WorkItem>> CreateComment(WorkItemComment workItemComment)
        {
            await _context.WorkItemComments.AddAsync(workItemComment);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        [Route("updateWorkItem")]
        //PUT : /api/WorkItem/Update
        public async Task<IActionResult> UpdateWorkItem(WorkItem workItem)
        {
            _context.WorkItems.Update(workItem);
            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpPost]
        [Route("DeleteWorkItem")]
        public async Task<IActionResult> DeleteWorkItem(WorkItem workItem)
        {
            _context.WorkItemComments.RemoveRange(workItem.Comments);
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
        [Route("Priorities")]
        //GET : /api/WorkItem/Priorities
        public async Task<IActionResult> GetPriorities()
        {
            var priorities = _context.WorkItemPriorities.ToList();

            return Ok(priorities);

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
                .Include(w => w.WorkItemPriority)
                .Include(w => w.Comments)
                .Include(w => w.Tickets).ThenInclude(t => t.TicketOwner)
                .Include(w => w.Tickets).ThenInclude(t => t.TicketStatus);



            return Ok(workItems);

        }


        [HttpGet]
        [Route("GetWorkItemStatusCount")]
        //GET : /api/WorkItem/GetWorkItemStatusCounts
        public async Task<IActionResult> GetWorkItemStatusCount()
        {

            var counts = _context.WorkItems.Select(x => x.WorkItemStatus).GroupBy(i => i.StatusName).ToDictionary(g => g.Key, g => g.Count());

            var list = new List<Array>();

            foreach (var count in counts)
            {
                object[] countString = new object[] { count.Key, count.Value };

                list.Add(countString.ToArray());
            }

            return Ok(list);
        }


        [HttpGet]
        [Route("GetWorkItemPriorityCount")]
        //GET : /api/WorkItem/GetWorkItemPriorityCounts
        public async Task<IActionResult> GetWorkItemPriorityCount()
        {

            var counts = _context.WorkItems.Select(x => x.WorkItemPriority).GroupBy(i => i.PriorityName).ToDictionary(g => g.Key, g => g.Count());

            var list = new List<Array>();

            foreach (var count in counts)
            {
                object[] countString = new object[] { count.Key, count.Value };

                list.Add(countString.ToArray());
            }

            return Ok(list);
        }

        [HttpGet]
        [Route("GetWorkItemOwnerCount")]
        //GET : /api/WorkItem/GetWorkItemOwnerCounts
        public async Task<IActionResult> GetWorkItemOwnerCount()
        {

            var counts = _context.WorkItems.Select(x => x.WorkItemOwner).GroupBy(i => i.UserName).ToDictionary(g => g.Key, g => g.Count());

            var list = new List<Array>();

            foreach (var count in counts)
            {
                object[] countString = new object[] { count.Key, count.Value };

                list.Add(countString.ToArray());
            }

            return Ok(list);
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
                .Include(w => w.WorkItemPriority)
                .Include(w => w.Comments)
                .Include(w => w.Tickets).ThenInclude(t => t.TicketOwner)
                .Include(w => w.Tickets).ThenInclude(t => t.TicketStatus)
                .Where(w => w.WorkItemOwnerID.Equals(userId));


            return Ok(workItems);

        }
    }
}