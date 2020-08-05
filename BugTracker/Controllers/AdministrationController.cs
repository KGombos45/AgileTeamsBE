using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTrackerData;
using BugTrackerData.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrationController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly BugTrackerContext _context;

        public AdministrationController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, BugTrackerContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }               

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("Users")]
        //GET : /api/Administration/Users
        public async Task<IActionResult> GetUserProfiles()
        {
            var usersList = await _context.ApplicationUsers.ToListAsync();

            ApplicationUsersAndRoleModel ApplicationUserModel = new ApplicationUsersAndRoleModel();

            List<ApplicationUserModel> AllUsersAndRole = new List<ApplicationUserModel>();

            foreach (var user in usersList)
            {
                var roles = await _userManager.GetRolesAsync(user);

                var model = new ApplicationUserModel
                {
                    Id = user.Id,
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

                AllUsersAndRole.Add(model);

            }

            ApplicationUserModel.UsersAndRole = AllUsersAndRole;

            return Ok(ApplicationUserModel.UsersAndRole);

        }

        [HttpPut]
        [Route("UpdateRole/{id}")]
        [Authorize(Roles = "Admin")]
        //PUT : /api/Administration/
        public async Task<IActionResult> UpdateUserRole(string id, ApplicationUserModel applicationUserModel)
        {
            var user = await _userManager.FindByIdAsync(id);
            var role = await _roleManager.FindByNameAsync(applicationUserModel.Role);
            var oldRoles = await _userManager.GetRolesAsync(user);

            if (role == null)
            {
                return BadRequest();
            }

            IdentityResult result = null;

            if (oldRoles != null)
            {            
                result = await _userManager.RemoveFromRolesAsync(user, oldRoles.ToArray());
                if (result.Succeeded)
                {
                    result = await _userManager.AddToRoleAsync(user, role.Name);
                }                  
            } else
            {
                result = await _userManager.AddToRoleAsync(user, role.Name);
            }

            return Ok(result);

        }

        [HttpPost]
        [Route("DeleteUser/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return BadRequest();
            }

            IdentityResult result = await _userManager.DeleteAsync(user);

            return Ok(result);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("Roles")]
        //GET : /api/Administration/Users
        public async Task<IActionResult> GetRoles()
        {
            var Roles = _roleManager.Roles.Select(role => role.Name);

            return Ok(Roles);

        }


        private bool ApplicationUserExists(string id)
        {
            return _context.ApplicationUsers.Any(e => e.Id == id);
        }

    }

}

