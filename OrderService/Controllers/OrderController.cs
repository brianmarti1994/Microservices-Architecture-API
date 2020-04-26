using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Database.Entities;
using OrderService.Database;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        DatabaseContext db;
        public OrderController()
        {
            db = new DatabaseContext();


        }

        [HttpGet(template: "GetOrders")]
        public IEnumerable<Order> GetOrders()
        {
            return db.Orders.ToList();
        }

        
     
        [HttpPost(template: "AddOrder")]
        public IActionResult AddOrder([FromBody] Order order)
        {
            try
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

       
    }
}
