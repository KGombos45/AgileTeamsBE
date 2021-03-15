using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgileTeamsData;
using AgileTeamsData.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgileTeams.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrationController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AgileTeamsContext _context;

        public AdministrationController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, AgileTeamsContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }               

        [HttpGet]
        [Route("Users")]
        //GET : /api/Administration/Users
        public async Task<IActionResult> GetUserProfiles()
        {
            var usersList = await _context.ApplicationUserRoles.ToListAsync();

            return Ok(usersList);

        }

        [HttpPut]
        [Route("UpdateRole/{id}")]
        [Authorize(Roles = "Admin")]
        //PUT : /api/Administration/
        public async Task<IActionResult> UpdateUserRole(string id, ApplicationUserRole applicationUserRole)
        {
            var user = await _userManager.FindByIdAsync(id);
            var role = await _roleManager.FindByNameAsync(applicationUserRole.Role);
            var oldRoles = await _userManager.GetRolesAsync(user);

            if (role == null)
            {
                return BadRequest();
            }

            IdentityResult result = null;

            if (oldRoles != null)
            {            
                result = await _userManager.RemoveFromRolesAsync(user, oldRoles.ToArray());

                _context.ApplicationUserRoles.Update(applicationUserRole);

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
        public async Task<IActionResult> DeleteUser(string id, ApplicationUserRole applicationUserRole)
        {
            var user = await _userManager.FindByIdAsync(id);

            _context.ApplicationUserRoles.Remove(applicationUserRole);

            _context.SaveChanges();

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

