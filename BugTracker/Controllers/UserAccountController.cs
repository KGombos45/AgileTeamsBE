using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTrackerData;
using BugTrackerData.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BugTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly BugTrackerContext _context;

        public UserAccountController(UserManager<ApplicationUser> userManager, BugTrackerContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        [Authorize]
        //Get : /api/UserAccount
        public async Task<Object> GetUserAccount()
        {
            string userId = User.Claims.First(x => x.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            var roles = await _userManager.GetRolesAsync(user);

            return new
            {
                user.Id,
                user.FirstName,
                user.LastName,
                user.Email,
                user.UserName,
                user.Address,
                user.City,
                user.State,
                user.Zip,
                user.About,
                role = roles.FirstOrDefault()
        };

        }

        [HttpPut("{id}")]
        //Put : /api/UserAccount/id
        public async Task<IActionResult> PutUserAccount(string id, ApplicationUserModel model)
        {
            ApplicationUser applicationUser = await _userManager.FindByNameAsync(model.UserName);

            if (id != applicationUser.Id)
            {
                return BadRequest();
            }            

            try
            {                
                applicationUser.FirstName = model.FirstName;
                applicationUser.LastName = model.LastName;
                applicationUser.Email = model.Email;
                applicationUser.UserName = model.UserName;
                applicationUser.Address = model.Address;
                applicationUser.City = model.City;
                applicationUser.State = model.State;
                applicationUser.Zip = model.Zip;
                applicationUser.About = model.About;

                IdentityResult result = await _userManager.UpdateAsync(applicationUser);

                return Ok(result);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool ApplicationUserExists(string id)
        {
            return _context.ApplicationUsers.Any(e => e.Id == id);
        }


    }
}