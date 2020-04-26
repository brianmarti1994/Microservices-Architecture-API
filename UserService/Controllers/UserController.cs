using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Database;
using UserService.Database.Entities;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        DatabaseContext db;
        public UserController()
        {
            db = new DatabaseContext();

           
        }
        
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return db.Users.ToList();
        }


        
        [HttpGet(template: "GetUsers")]
        public IEnumerable<User> GetUser()
        {
            return db.Users.ToList();
        }

        [HttpPost(template: "AddUsers")]
        public IActionResult AddUsers([FromBody] User user)
        {
            try
            {
                db.Users.Add(user);
                db.SaveChanges();
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,ex);
            }
        }

       
    }
}
