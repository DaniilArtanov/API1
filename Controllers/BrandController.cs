using API1.Models;
using Microsoft.AspNetCore.Mvc;

namespace API1.Controllers
{
    //http://localhost:5324/product
    [ApiController]
    [Route("/brand")]
    public class BrandController : ControllerBase
    {

        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var db = new TwoFunnyShoesContext();
            return Ok(db.Brands);
        }

        [HttpPost]
        public IActionResult Add(Brand brand)
        {
            var db = new TwoFunnyShoesContext();
            db.Brands.Add(brand);
            db.SaveChanges();
            return Ok(brand);
        }
        [HttpPut]
        public IActionResult Update(Brand brand)
        {
            var db = new TwoFunnyShoesContext();
            db.Brands.Update(brand);
            db.SaveChanges();
            return Ok(brand);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remove(int id)
        {
            var db = new TwoFunnyShoesContext();
            var brand = db.Brands.FirstOrDefault(p => p.Id == id);
            if (brand == null) { return NotFound(); };
            db.Brands.Remove(brand);
            db.SaveChanges();
            return Ok();
        }
    }
}

