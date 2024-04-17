using API1.Models;
using Microsoft.AspNetCore.Mvc;

namespace API1.Controllers
{
    //http://localhost:5324/product
    [ApiController]
    [Route("/productcategory")]
    public class ProductCategoryController : ControllerBase
    {

        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var db = new TwoFunnyShoesContext();
            return Ok(db.ProductCategories);
        }

        [HttpPost]
        public IActionResult Add(ProductCategory productCategory)
        {
            var db = new TwoFunnyShoesContext();
            db.ProductCategories.Add(productCategory);
            db.SaveChanges();
            return Ok(productCategory);
        }
        [HttpPut]
        public IActionResult Update(ProductCategory productCategory)
        {
            var db = new TwoFunnyShoesContext();
            db.ProductCategories.Update(productCategory);
            db.SaveChanges();
            return Ok(productCategory);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remove(int id)
        {
            var db = new TwoFunnyShoesContext();
            var productCategory = db.ProductCategories.FirstOrDefault(p => p.Id == id);
            if (productCategory == null) { return NotFound(); };
            db.ProductCategories.Remove(productCategory);
            db.SaveChanges();
            return Ok();
        }
    }
}
