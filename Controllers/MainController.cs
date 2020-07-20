using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;
using OnlineStoreApi.Models;

namespace OnlineStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        //private DataContext db = new DataContext();

        private readonly DataContext db;

        public MainController(DataContext context)
        {
            db = context;
        }

        // GET: api/Main
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return db.users; ;
        }

        // GET: api/Main/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = db.users.Find(id);
            if(user==null)
            {
                return NotFound();
            }
            
            return Ok(user);
        }

        // POST: api/Main
        [HttpPost]
        public void Post([FromBody] User u)
        {
            db.users.Add(u);
            db.SaveChanges();
        }

        // PUT: api/Main/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User usr)
        {
            var entity = db.users.FirstOrDefault(u => u.UserId == id);
            entity.fullName = usr.fullName;
            entity.dob = usr.dob;
            entity.contactNumber = usr.contactNumber;
            entity.address = usr.address;
            entity.password = usr.password;
            entity.confirmPassword = usr.confirmPassword;
            db.SaveChanges();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var v = db.users.Find(id);
            if(v==null)
            {
                return BadRequest("No Record found against this User Id");
            }
            db.Remove(v);
            db.SaveChanges();
            return Ok("User Deleted");
        }

        
    }
}
