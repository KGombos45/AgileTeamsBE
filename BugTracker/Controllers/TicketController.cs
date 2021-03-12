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
using Newtonsoft.Json;

namespace BugTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly BugTrackerContext _context;
        private UserManager<ApplicationUser> _userManager;

        public TicketController(BugTrackerContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("Create")]
        //POST: api/Ticket/Create
        public async Task<ActionResult<Ticket>> CreateTicket(Ticket ticket)
        {

            await _context.Tickets.AddAsync(ticket);
            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpPut]
        [Route("UpdateTicket")]
        //PUT : /api/Ticket/UpdateTicket
        public async Task<IActionResult> UpdateTicket(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        [Route("DeleteTicket")]
        public async Task<IActionResult> DeleteTicket(Ticket ticket)
        {
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpGet]
        [Route("Statuses")]
        //GET : /api/Project/Statuses
        public async Task<IActionResult> GetStatuses()
        {
            var statuses = _context.TicketStatuses.ToList();

            return Ok(statuses);

        }

        [HttpGet]
        [Route("Types")]
        //GET : /api/Ticket/Types
        public async Task<IActionResult> GetTypes()
        {
            var types = _context.TicketTypes.ToList();

            return Ok(types);

        }


        [HttpGet]
        [Route("GetTicketStatusCount")]
        //GET : /api/Ticket/GetTicketStatusCount
        public async Task<IActionResult> GetTicketStatusCount()
        {

            var counts = _context.Tickets.Select(x => x.TicketStatus).GroupBy(i => i.StatusName).ToDictionary(g => g.Key, g => g.Count());

            var list = new List<Array>();

            foreach (var count in counts)
            {
                object[] countString = new object[] { count.Key, count.Value };

                list.Add(countString.ToArray());
            }

            return Ok(list);
        }


        [HttpGet]
        [Route("GetTicketTypeCount")]
        //GET : /api/Ticket/GetTicketTypeCount
        public async Task<IActionResult> GetTicketTypeCount()
        {

            var counts = _context.Tickets.Select(x => x.TicketType).GroupBy(i => i.TypeName).ToDictionary(g => g.Key, g => g.Count());

            var list = new List<Array>();

            foreach (var count in counts)
            {
                object[] countString = new object[] { count.Key, count.Value };

                list.Add(countString.ToArray());
            }

            return Ok(list);
        }


        [HttpGet]
        [Route("GetTicketOwnerCount")]
        //GET : /api/Ticket/GetTicketOwnerCount
        public async Task<IActionResult> GetTicketOwnerCount()
        {

            var counts = _context.Tickets.Select(x => x.TicketOwner).GroupBy(i => i.UserName).ToDictionary(g => g.Key, g => g.Count());

            var list = new List<Array>();

            foreach (var count in counts)
            {
                object[] countString = new object[] { count.Key, count.Value };

                list.Add(countString.ToArray());
            }

            return Ok(list);
        }

        [HttpGet]
        [Route("Tickets")]
        //GET : /api/Ticket/Tickets
        public IActionResult GetTickets()
        {
            var tickets = _context.Tickets.Include(t => t.TicketOwner)
                                            .Include(t => t.TicketWorkItem)
                                            .Include(t => t.TicketStatus)
                                            .Include(t => t.TicketType).ToList();
                                            

            return Ok(tickets);
        }

        [HttpGet]
        [Route("Tickets/{userId}")]
        //GET : /api/Ticket/Tickets
        public IActionResult GetUserTickets(string userId)
        {
            var tickets =  _context.Tickets.Include(t => t.TicketOwner)
                                            .Include(t => t.TicketWorkItem)
                                            .Include(t => t.TicketStatus)
                                            .Include(t => t.TicketType)
                                            .Where(t => t.TicketOwnerID.Equals(userId)).ToList();

            return Ok(tickets);
        }
    }
}