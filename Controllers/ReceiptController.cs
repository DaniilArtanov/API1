using API1.Models;
using Microsoft.AspNetCore.Mvc;

namespace API1.Controllers
{
    //http://localhost:5324/product
    [ApiController]
    [Route("/receipt")]
    public class ReceiptController : ControllerBase
    {

        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var db = new TwoFunnyShoesContext();
            return Ok(db.Receipts);
        }

        [HttpPost]
        public IActionResult Add(Receipt receipt)
        {
            var db = new TwoFunnyShoesContext();
            db.Receipts.Add(receipt);
            db.SaveChanges();
            return Ok(receipt);
        }
        [HttpPut]
        public IActionResult Update(Receipt receipt)
        {
            var db = new TwoFunnyShoesContext();
            db.Receipts.Update(receipt);
            db.SaveChanges();
            return Ok(receipt);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remove(int id)
        {
            var db = new TwoFunnyShoesContext();
            var receipt = db.Receipts.FirstOrDefault(p => p.Id == id);
            if (receipt == null) { return NotFound(); };
            db.Receipts.Remove(receipt);
            db.SaveChanges();
            return Ok();
        }
    }
}
