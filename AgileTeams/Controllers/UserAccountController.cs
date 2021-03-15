using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgileTeamsData;
using AgileTeamsData.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AgileTeams.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly AgileTeamsContext _context;

        public UserAccountController(UserManager<ApplicationUser> userManager, AgileTeamsContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        [Authorize]
        //Get : /api/UserAccount
        public async Task<IActionResult> GetUserAccount()
        {
            string userId = User.Claims.First(x => x.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            var roles = await _userManager.GetRolesAsync(user);

            var applicationUser = new ApplicationUserModel
            {
                ID = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName,
                Address = user.Address,
                City = user.City,
                State = user.State,
                Zip = user.Zip,
                About = user.About,
                Role = roles.FirstOrDefault()
            };

            return Ok(applicationUser);

        }

        [HttpGet]
        [Route("GetProjectUserProfile/{userId}")]
        //Get : /api/UserAccount/UserProfile/
        public async Task<IActionResult> GetProjectUserProfile(string userId)
        {          
            var user = await _userManager.FindByIdAsync(userId);
            var roles = await _userManager.GetRolesAsync(user);

            var applicationUser = new ApplicationUserModel
            {
                ID = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName,
                Address = user.Address,
                City = user.City,
                State = user.State,
                Zip = user.Zip,
                About = user.About,
                Role = roles.FirstOrDefault()
            };

            return Ok(applicationUser);

        }

        //[HttpGet]
        //[Authorize]
        ////Get : /api/UserAccountAndRole
        //public async Task<IActionResult> GetUserAccountAndRole()
        //{
        //    string userId = User.Claims.First(x => x.Type == "UserID").Value;
        //    var user = _context.ApplicationUserRoles.Where(u => u.ID.Equals(userId));

        //    return Ok(user);

        //}

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