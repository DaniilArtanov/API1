using API1.Models;
using Microsoft.AspNetCore.Mvc;

namespace API1.Controllers
{
    //http://localhost:5324/product
    [ApiController]
    [Route("/productfromthereceipt")]
    public class ProductsFromTheReceiptController : ControllerBase
    {

        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var db = new TwoFunnyShoesContext();
            return Ok(db.ProductsFromTheReceipts);
        }

        [HttpPost]
        public IActionResult Add(ProductsFromTheReceipt productsFromTheReceipt)
        {
            var db = new TwoFunnyShoesContext();
            db.ProductsFromTheReceipts.Add(productsFromTheReceipt);
            db.SaveChanges();
            return Ok(productsFromTheReceipt);
        }
        [HttpPut]
        public IActionResult Update(ProductsFromTheReceipt productsFromTheReceipt)
        {
            var db = new TwoFunnyShoesContext();
            db.ProductsFromTheReceipts.Update(productsFromTheReceipt);
            db.SaveChanges();
            return Ok(productsFromTheReceipt);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remove(int id)
        {
            var db = new TwoFunnyShoesContext();
            var productsFromTheReceipt = db.ProductsFromTheReceipts.FirstOrDefault(p => p.Id == id);
            if (productsFromTheReceipt == null) { return NotFound(); };
            db.ProductsFromTheReceipts.Remove(productsFromTheReceipt);
            db.SaveChanges();
            return Ok();
        }
    }
}
