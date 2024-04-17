using API1.Models;
using Microsoft.AspNetCore.Mvc;

namespace API1.Controllers
{
    //http://localhost:5324/product
    [ApiController]
    [Route("/user")]
    public class UserCotroller : ControllerBase
    {

        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var db = new TwoFunnyShoesContext();
            return Ok(db.Users);
        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            var db = new TwoFunnyShoesContext();
            db.Users.Add(user);
            db.SaveChanges();
            return Ok(user);
        }
        [HttpPut]
        public IActionResult Update(User user)
        {
            var db = new TwoFunnyShoesContext();
            db.Users.Update(user);
            db.SaveChanges();
            return Ok(user);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remove(int id)
        {
            var db = new TwoFunnyShoesContext();
            var user = db.Users.FirstOrDefault(p => p.Id == id);
            if (user == null) { return NotFound(); };
            db.Users.Remove(user);
            db.SaveChanges();
            return Ok();
        }
    }
}
