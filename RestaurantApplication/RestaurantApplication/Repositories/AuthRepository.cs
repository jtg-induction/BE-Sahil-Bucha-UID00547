using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using RestaurantApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using RestaurantApplication.Helpers;

namespace RestaurantApplication.Repositories
{
    public class AuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AuthRepository()
        {
            var context = new ApplicationDbContext();
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            _roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(context));
        }

        public async Task<IdentityResult> RegisterUser(string fullName, string email, string password, string role)
        {
            var user = new ApplicationUser { UserName = email, Email = email, FullName = fullName };
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded && !string.IsNullOrEmpty(role))
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new ApplicationRole(role));
                }
                await _userManager.AddToRoleAsync(user.Id, role);
            }

            return result;
        }

        public async Task<(string token, string error)> Login(string email, string password)
        {
            var user = await _userManager.FindAsync(email, password);
            if (user == null) return (null, "Invalid credentials");

            var roles = await _userManager.GetRolesAsync(user.Id);
            return (JwtHelper.GenerateToken(user, roles[0]), null);
        }
    }

}