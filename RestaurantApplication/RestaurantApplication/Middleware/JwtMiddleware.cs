////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Net.Http;
////using System.Net;
////using System.Threading.Tasks;
////using System.Threading;
////using System.Web;

////namespace RestaurantApplication.Middleware
////{
////	public class JwtMiddleware
////	{
////	}
////}

//using System.Diagnostics;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Web.Http;

//public class JwtMiddleware : DelegatingHandler
//{
//    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
//    {
//        Debug.WriteLine("request is : ", request.ToString());
//        var token = request.Headers;
//        Debug.WriteLine("token is : ", token);
//        if (token == null)
//        {
//            Debug.WriteLine("token is : ", token);
//            return request.CreateResponse(HttpStatusCode.Unauthorized, "Missing token");
//        }
//        return await base.SendAsync(request, cancellationToken);
//    }
//}

using System;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.IdentityModel.Tokens;

public class JwtMiddleware : DelegatingHandler
{
    private readonly string _secretKey = "secret_key_for_my_app_secret_key_for_my_app_secret_key_for_my_app"; // Store securely in appsettings

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var authHeader = request.Headers.Authorization;
        var val = "12";
        Debug.WriteLine("authHeader : ", authHeader, val);
        if (authHeader == null || authHeader.Scheme != "Bearer" || string.IsNullOrEmpty(authHeader.Parameter))
        {
            Debug.WriteLine("here");
            return request.CreateResponse(HttpStatusCode.Unauthorized, "Missing or invalid token");
        }

        try
        {
            Debug.WriteLine("hrer");
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_secretKey);

            var validationParams = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            var principal = tokenHandler.ValidateToken(authHeader.Parameter, validationParams, out _);
            Debug.WriteLine("principal : ", principal);
            Thread.CurrentPrincipal = principal; // Attach user info to request
        }
        catch (Exception)
        {
            return request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid or expired token");
        }

        Debug.WriteLine("here");
        return await base.SendAsync(request, cancellationToken);
    }
}
