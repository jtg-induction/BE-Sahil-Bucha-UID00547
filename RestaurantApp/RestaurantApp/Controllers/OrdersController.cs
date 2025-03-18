using Microsoft.AspNet.Identity.EntityFramework;
using RestaurantApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPatchAttribute = System.Web.Http.HttpPatchAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;


namespace RestaurantApp.Controllers
{
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiController
    {

        private readonly OrderService _orderService;

        public OrdersController()
        {
            _orderService = new OrderService();



            var sid = 12;
            Debug.WriteLine(new IdentityUser());
            Debug.WriteLine("here after sid");
        }


        [JwtAuthFilter("owner")]
        [Route("restaurant/{restaurantId:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetOrders(int restaurantId, int? status = null, string sortBy = "", string username = "")
        {
            try
            {
                var identity = User.Identity as ClaimsIdentity;
                Debug.WriteLine(identity);

                //if (identity == null || !identity.IsAuthenticated)
                //{
                //    return Unauthorized();
                //}

                // 🔹 Extract User ID from Claims
                var userIdClaim = identity.FindFirst(ClaimTypes.NameIdentifier);
                Debug.WriteLine(userIdClaim);
                //if (userIdClaim == null)
                //{
                //    return Unauthorized();
                //}

                string userId = userIdClaim.Value;
                Debug.WriteLine(userId);
                //return Ok(new { Message = "User is authenticated", UserId = userId });

                //Debug.WriteLine("good one : ", httpContext.User.Identity.Name);
                Debug.WriteLine("here we are ");
                //Console.ReadLine();

                //, int status = 0, string sortBy = "", string username = ""
                //var orders = _orderService.GetOrders(restaurantId, sortBy, username, status);
                var orders = await _orderService.GetOrders(restaurantId, sortBy, username, status);
                return Json(orders);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                //Console.ReadLine();
                return BadRequest($"Not able to fetch {e}");
            }
        }

        [HttpPatch]
        [Route("update/{orderId:int}")]
        public async Task<IHttpActionResult> UpdateOrderStatus(int orderId, [FromBody] int status)

        {
            try
            {
                Debug.WriteLine("here", status);
                await _orderService.UpdateOrderStatus(orderId, status);
                return Ok("Order status updated.");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return BadRequest($"Not able to update the status {e}");
            }
        }
    }
}