using Microsoft.IdentityModel.Tokens;
using RestaurantApplication.DTOs;
using RestaurantApplication.Models;
using RestaurantApplication.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RestaurantApplication.Services
{
    public class AuthService
    {
        private readonly AuthRepository _authRepo;
        private readonly string _jwtSecret = "THIS_IS_A_SECRET_KEY_CHANGE_IT";

        public AuthService()
        {
            _authRepo = new AuthRepository();
        }

        public async Task<bool> Register(RegisterDTO dto)
        {
            var result = await _authRepo.RegisterUser(dto.FullName, dto.Email, dto.Password, dto.Role);
            return result.Succeeded;
        }
    }
}