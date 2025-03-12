using Microsoft.IdentityModel.Tokens;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace RestaurantApp.Helpers
{
    public class JwtHelper
    {


        private static readonly string _secretKey = ConfigurationManager.AppSettings["JwtSecretKey"];
        public static SecurityToken GenerateToken(ApplicationUser user, string role)
        {
            Debug.WriteLine(user);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);
            Debug.WriteLine("key is : ", _secretKey, " ", key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            //return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
            return tokenHandler.CreateToken(tokenDescriptor);
        }
    }
}