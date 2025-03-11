using RestaurantApplication.DTOs;
using RestaurantApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using System.Net;
using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;
using RestaurantApplication.Models;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Diagnostics;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity.EntityFramework;
using AuthorizeAttribute = System.Web.Http.AuthorizeAttribute;

namespace RestaurantApplication.Controllers
{
    [RoutePrefix("api/orders")]
    public class OrderController : ApiController
    {

        private readonly OrderService _orderService;

        public OrderController()
        {
            _orderService = new OrderService();
            
           
            
            var sid = 12;
            Debug.WriteLine(new IdentityUser());
            Debug.WriteLine("here after sid");
        }


        [Authorize]
        [Route("fetch/{restaurantId:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetOrders(int restaurantId, int? status = null, string sortBy = "", string username = "")
        {
            try
            {
                
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
                return NotFound();
            }
        }

        [HttpPut]
        [Route("{orderId:int}")]
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
                return NotFound();
            }
        }
    }
}

//protected override void Dispose(bool disposing)
//{
//    if (disposing)
//    {
//        (_orderService as IDisposable)?.Dispose();
//    }
//    base.Dispose(disposing);
//}
//    }
//}