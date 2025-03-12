using Microsoft.AspNet.Identity;
using RestaurantApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Services
{
    interface IAuthService
    {
        Task<IdentityResult> RegisterUser(string fullName, string email, string password, string role);
        Task<(UserDTO user, string error)> Login(string email, string password);
    }
}
