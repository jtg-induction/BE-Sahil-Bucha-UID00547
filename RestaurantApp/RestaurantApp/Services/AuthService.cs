using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using RestaurantApp.Data;
using RestaurantApp.DTOs;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using RestaurantApp.Helpers;

namespace RestaurantApp.Services
{
    public class AuthService: IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AuthService()
        {
            var context = new AuthDbContext();
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
            Debug.WriteLine("result is : ", result);
            return result;
        }

        public async Task<(UserDTO user, string error)> Login(string email, string password)
        {
            var user = await _userManager.FindAsync(email, password);
            if (user == null) return (null, "Invalid credentials");
            Debug.WriteLine(user);
            var roles = await _userManager.GetRolesAsync(user.Id);
            var validUser = new UserDTO
            {
                FullName = user.FullName,
                Role = roles[0],
                Email = user.Email,
                Token = JwtHelper.GenerateToken(user, roles[0]),
            };
            return (validUser, null);
        }
    }
}