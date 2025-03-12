using RestaurantApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using RestaurantApp.Services;
using System.Diagnostics;

namespace RestaurantApp.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        private readonly AuthService _authService;

        public AuthController()
        {
            _authService = new AuthService();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IHttpActionResult> Register(RegisterDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _authService.RegisterUser(dto.FullName, dto.Email, dto.Password, dto.Role);
            if (!result.Succeeded) return BadRequest(result.Errors.ToString());
            return Ok("User registered successfully.");
        }

        [HttpPost]
        [Route("login")]
        public async Task<IHttpActionResult> Login(LoginDTO dto)
        {
            var (user, error) = await _authService.Login(dto.Email, dto.Password);
            Debug.WriteLine("good it is : ", user, error);
            if (user.Token == null) return Unauthorized();
            return Ok(user);
        }
    }
}