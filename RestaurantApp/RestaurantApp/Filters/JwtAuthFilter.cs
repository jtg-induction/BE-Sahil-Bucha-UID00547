//using Microsoft.IdentityModel.Tokens;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.IdentityModel.Tokens.Jwt;
//using System.Linq;
//using System.Net.Http;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;
//using System.Threading;
//using System.Web;
//using System.Configuration;

//public class JwtAuthFilter : DelegatingHandler
//{
//    private readonly string _secretKey = ConfigurationManager.AppSettings["JwtSecretKey"];

//    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
//    {
//        var authHeader = request.Headers.Authorization;
//        var val = "12";
//        Debug.WriteLine("authHeader : ", authHeader, val);
//        if (authHeader == null || authHeader.Scheme != "Bearer" || string.IsNullOrEmpty(authHeader.Parameter))
//        {
//            Debug.WriteLine("here");
//            return request.CreateResponse(HttpStatusCode.Unauthorized, "Missing or invalid token");
//        }

//        try
//        {
//            Debug.WriteLine("hrer");
//            var tokenHandler = new JwtSecurityTokenHandler();
//            var key = Encoding.UTF8.GetBytes(_secretKey);

//            var validationParams = new TokenValidationParameters
//            {
//                ValidateIssuer = false,
//                ValidateAudience = false,
//                ValidateIssuerSigningKey = true,
//                IssuerSigningKey = new SymmetricSecurityKey(key),
//                ValidateLifetime = true,
//                ClockSkew = TimeSpan.Zero
//            };

//            var principal = tokenHandler.ValidateToken(authHeader.Parameter, validationParams, out _);
//            Debug.WriteLine("principal : ", principal);
//            Thread.CurrentPrincipal = principal; // Attach user info to request
//        }
//        catch (Exception)
//        {
//            return request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid or expired token");
//        }

//        Debug.WriteLine("here");
//        return await base.SendAsync(request, cancellationToken);
//    }
//}

using System;
using System.Configuration;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Microsoft.IdentityModel.Tokens;

public class JwtAuthFilter : AuthorizeAttribute
{
    protected override bool AuthorizeCore(HttpContextBase httpContext)
    {
        var token = httpContext.Request.Headers["Authorization"];
        Debug.WriteLine("token is : ", token);
        if (string.IsNullOrEmpty(token)) return false;

        token = token.Replace("Bearer ", "");

        try
        {
            var secretKey = ConfigurationManager.AppSettings["JwtSecretKey"];
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            var tokenHandler = new JwtSecurityTokenHandler();

            var validationParams = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateLifetime = true
            };

            SecurityToken validatedToken;
            var principal = tokenHandler.ValidateToken(token, validationParams, out validatedToken);
            Debug.WriteLine("principal is : ", principal);
            var identity = principal.Identity as ClaimsIdentity;

            if (identity == null) return false;

            var userIdClaim = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            httpContext.User = new ClaimsPrincipal(identity);

            return userIdClaim != null;
        }
        catch
        {
            return false;
        }
    }
}
