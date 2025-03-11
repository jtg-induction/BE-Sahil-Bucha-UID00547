using RestaurantApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using RestaurantApplication.DTOs;
using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using RestaurantApplication.Repositories;

namespace RestaurantApplication.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        private readonly AuthRepository _authRepo;

        public AuthController()
        {
            _authRepo = new AuthRepository();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IHttpActionResult> Register(RegisterDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _authRepo.RegisterUser(dto.FullName, dto.Email, dto.Password, dto.Role);
            if (!result.Succeeded) return BadRequest(result.Errors.ToString());
            return Ok("User registered successfully.");
        }

        [HttpPost]
        [Route("login")]
        public async Task<IHttpActionResult> Login(LoginDTO dto)
        {
            var (token, error) = await _authRepo.Login(dto.Email, dto.Password);
            if (token == null) return Unauthorized();
            return Ok(token);
        }
    }
}
