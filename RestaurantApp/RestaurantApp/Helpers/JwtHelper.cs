//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.IdentityModel.Tokens;
//using System.Security.Claims;
//using System.Security.Cryptography;
//using System.Text;
//using Newtonsoft.Json;
//using RestaurantApp.Models;

//public static class JwtHelper
//{
//    private static string _secretKey = ConfigurationManager.AppSettings["JwtSecretKey"]; // Ensure this is a strong key

//    public static string GenerateToken(ApplicationUser user, string role)
//    {
//        if (string.IsNullOrEmpty(_secretKey))
//            throw new InvalidOperationException("Secret key is not set.");

//        var header = new Dictionary<string, object>
//        {
//            { "alg", "HS256" },
//            { "typ", "JWT" }
//        };

//        var payload = new Dictionary<string, object>
//        {
//            { "sub", user.UserName },
//            { "id", user.Id },
//            { "role", role },
//            { "exp", DateTimeOffset.UtcNow.AddHours(24).ToUnixTimeSeconds() }
//        };

//        string headerJson = JsonConvert.SerializeObject(header);
//        string payloadJson = JsonConvert.SerializeObject(payload);

//        string headerBase64 = Base64UrlEncode(Encoding.UTF8.GetBytes(headerJson));
//        string payloadBase64 = Base64UrlEncode(Encoding.UTF8.GetBytes(payloadJson));

//        string signature = ComputeHmacSha256(headerBase64 + "." + payloadBase64, _secretKey);

//        return $"{headerBase64}.{payloadBase64}.{signature}";
//    }

//    private static string ComputeHmacSha256(string data, string secret)
//    {
//        using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret)))
//        {
//            byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
//            return Base64UrlEncode(hash);
//        }
//    }

//    private static string Base64UrlEncode(byte[] bytes)
//    {
//        return Convert.ToBase64String(bytes)
//            .TrimEnd('=')
//            .Replace('+', '-')
//            .Replace('/', '_');
//    }
//}


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
        public static string GenerateToken(ApplicationUser user, string role)
        {
            Debug.WriteLine(user);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_secretKey);
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
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
            //return tokenHandler.CreateToken(tokenDescriptor);
        }
    }
}