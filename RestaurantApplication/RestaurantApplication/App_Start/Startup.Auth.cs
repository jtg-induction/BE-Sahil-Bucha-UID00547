////using Microsoft.IdentityModel.Tokens;
////using Microsoft.Owin.Security.Jwt;
////using Owin;
////using System;
////using System.Collections.Generic;
////using System.Diagnostics;
////using System.Linq;
////using System.Text;
////using System.Web;

////namespace RestaurantApplication
////{
////	public partial class Startup
////	{
////        public void ConfigureAuth(IAppBuilder app)
////        {
////            Debug.WriteLine("here");
////            //var issuer = "yourIssuer";  // Set your issuer
////            //var audience = "yourAudience";  // Set your audience
////            var secret = Encoding.UTF8.GetBytes("secret_key_for_my_app");  // Secret key

////            // Enable JWT authentication
////            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
////            {
////                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
////                TokenValidationParameters = new TokenValidationParameters
////                {
////                    //ValidIssuer = false,
////                    //ValidAudience = false,
////                    IssuerSigningKey = new SymmetricSecurityKey(secret),
////                    ValidateIssuerSigningKey = true,
////                    ValidateIssuer = true,
////                    ValidateAudience = true,
////                    ValidateLifetime = true
////                }
////            });
////        }
////    }
////}

//using Microsoft.Owin;
//using Microsoft.Owin.Security.OAuth;
//using Owin;
//using RestaurantApplication;
//using System;
//using System.Web.Http;

//public class Startup
//{
//    public void Configuration(IAppBuilder app)
//    {
//        HttpConfiguration config = new HttpConfiguration();

//        ConfigureOAuth(app);

//        WebApiConfig.Register(config);
//        app.UseWebApi(config);
//    }

//    public void ConfigureOAuth(IAppBuilder app)
//    {
//        var authOptions = new OAuthBearerAuthenticationOptions
//        {
//            AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active
//        };

//        app.UseOAuthBearerAuthentication(authOptions);
//    }
//}
