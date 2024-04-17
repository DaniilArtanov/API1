using API1.Models;
using Microsoft.AspNetCore.Mvc;

namespace API1.Controllers
{
    //http://localhost:5324/product
    [ApiController]
    [Route("/product")]
    public class ProductController : ControllerBase
    {

        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var db = new TwoFunnyShoesContext();
            return Ok(db.Products);
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            var db = new TwoFunnyShoesContext();
            db.Products.Add(product);
            db.SaveChanges();
            return Ok(product);
        }
        [HttpPut]
        public IActionResult Update(Product product)
        {
            var db = new TwoFunnyShoesContext();
            db.Products.Update(product);
            db.SaveChanges();
            return Ok(product);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remove(int id)
        {
            var db = new TwoFunnyShoesContext();
            var product = db.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) { return NotFound(); };
            db.Products.Remove(product);
            db.SaveChanges();
            return Ok();
        }
    }
}
