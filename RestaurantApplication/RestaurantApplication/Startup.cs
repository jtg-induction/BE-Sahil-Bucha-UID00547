////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Web;

////namespace RestaurantApplication
////{
////	public partial class Startup
////    {
////        public void Configuration(IAppBuilder app)
////        {
////            ConfigureAuth(app);
////        }
////    }
////}

////using System;
////using System.Text;
////using Microsoft.Owin;
////using Microsoft.Owin.Security.Jwt;
////using Microsoft.Owin.Security.OAuth;
////using Owin;
////using Microsoft.IdentityModel.Tokens;

////[assembly: OwinStartup(typeof(ProjectRoot.Startup))]

////public class Startup
////{
////    public void Configuration(IAppBuilder app)
////    {
////        //var issuer = "yourIssuer";  // Set your issuer
////        //var audience = "yourAudience";  // Set your audience
////        var secret = Encoding.UTF8.GetBytes("secret_key_for_my_app");  // Secret key

////        // Enable JWT authentication
////        app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
////        {
////            AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
////            TokenValidationParameters = new TokenValidationParameters
////            {
////                //ValidIssuer = false,
////                //ValidAudience = false,
////                IssuerSigningKey = new SymmetricSecurityKey(secret),
////                ValidateIssuerSigningKey = true,
////                ValidateIssuer = true,
////                ValidateAudience = true,
////                ValidateLifetime = true
////            }
////        });
////    }
////}


//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using Microsoft.Owin;
//using Owin;

//[assembly: OwinStartup(typeof(RestaurantApplication.Startup))]

//namespace RestaurantApplication
//{
//    public partial class Startup
//    {
//        public void Configuration(IAppBuilder app)
//        {
//            Debug.WriteLine("here");
//            ConfigureAuth(app);
//        }
//    }
//}
