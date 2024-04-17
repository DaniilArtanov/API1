using Microsoft.AspNetCore.Mvc;
using API1.Models;

namespace API1.Controllers
{
    //http://localhost:5324/product
    [ApiController]
    [Route("/bankcard")]
    public class BankCardController : ControllerBase
    {

        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var db = new TwoFunnyShoesContext();
            return Ok(db.BankCards);
        }

        [HttpPost]
        public IActionResult Add(BankCard bankCard)
        {
            var db = new TwoFunnyShoesContext();
            db.BankCards.Add(bankCard);
            db.SaveChanges();
            return Ok(bankCard);
        }
        [HttpPut]
        public IActionResult Update(BankCard bankCard)
        {
            var db = new TwoFunnyShoesContext();
            db.BankCards.Update(bankCard);
            db.SaveChanges();
            return Ok(bankCard);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remove(int id)
        {
            var db = new TwoFunnyShoesContext();
            var bankCard = db.BankCards.FirstOrDefault( p => p.Id == id);
            if (bankCard == null) { return NotFound(); };
            db.BankCards.Remove(bankCard);
            db.SaveChanges();
            return Ok();
        }
    }
}
