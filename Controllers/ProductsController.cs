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
    public class ProductsController : ControllerBase
    {

        private readonly DataContext db;

        public ProductsController(DataContext context)
        {
            db = context;
        }

        // GET: api/Products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return db.products; ;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        //[Route("api/Products/VendorProduct/{id}")]
        public IActionResult GetAllProduct(int id)
        {
            var p = db.products.Find(id);
            if (p == null)
            {
                return NotFound();
            }

            return Ok(p);
        }

        // POST: api/Products
        [HttpPost]
        public void Post([FromBody] Product u)
        {
            db.products.Add(u);
            db.SaveChanges();
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product pr)
        {
            var entity = db.products.FirstOrDefault(p => p.productId == id);
            entity.productName = pr.productName;
            entity.availability = pr.availability;
            entity.price = pr.price;
            db.SaveChanges();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var v = db.products.Find(id);
            if (v == null)
            {
                return BadRequest("No Record found against this Product Id");
            }
            db.Remove(v);
            db.SaveChanges();
            return Ok("Product Deleted");
        }
    }
}
