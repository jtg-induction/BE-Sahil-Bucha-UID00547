using Microsoft.AspNet.Identity.EntityFramework;
using RestaurantApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;
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


        [JwtAuthFilter]
        [Route("restaurant/{restaurantId:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetOrders(int restaurantId, int? status = null, string sortBy = "", string username = "")
        {
            try
            {

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

        [HttpPut]
        [Route("update/{orderId:int}")]
        public async Task<IHttpActionResult> UpdateOrderStatus(int orderId, [FromBody] int status)

        {
            try
            {
                Console.WriteLine("here");
                await _orderService.UpdateOrderStatus(orderId, status);
                return Ok("Order status updated.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest($"Not able to update the status {e}");
            }
        }
    }
}