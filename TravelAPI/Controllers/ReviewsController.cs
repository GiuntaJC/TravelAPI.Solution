using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TravelAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using TravelAPI.Services;
using TravelAPI.Entities;

namespace TravelAPI.Models
{
  [Route("api/[controller]")]
  [ApiController]
  public class ReviewsController : ControllerBase
  {
    
    private TravelAPIContext _db;
    private IUserService _userService;
    public ReviewsController(TravelAPIContext db)
    {
      _db =db;
    }
    
    // GET api/Reviews

    [Authorize]
    [HttpGet]
    public ActionResult<IEnumerable<Review>> Get(string username, string password, string city, string country, int rating)
    {
      var query = _db.Reviews.AsQueryable();
      if (username != null)
      {
        query = query.Where(entry => entry.Username == username);
      }
      if (password != null)
      {
        query = query.Where(entry => entry.Password == password);
      }
      if (rating != 0)
      {
        query = query.Where(entry => entry.Rating == rating);
      }
      return query.ToList();
    }
    // POST api/Reviews
    [HttpPost]
    public void Post([FromBody] Review review)
    {
      _db.Reviews.Add(review);
      _db.SaveChanges();
    }
    // GET api/Reviews/{id}
    // [Authorize]
    [HttpGet("{id}")]
    public ActionResult<Review> Get(int id)
    {
      return _db.Reviews.FirstOrDefault(entry => entry.ReviewId == id);
    }
    // PUT api/Reviews/{id}

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Review review)
    {
      review.ReviewId = id;
      _db.Entry(review).State = EntityState.Modified;
      _db.SaveChanges();
    }
    // DELETE api/Reviews/{id}
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var ReviewToDelete = _db.Reviews.FirstOrDefault(entry => entry.ReviewId == id);
      _db.Reviews.Remove(ReviewToDelete);
      _db.SaveChanges();
    }

    [AllowAnonymous]
    [HttpPost("authenticate")]
    public IActionResult Authenticate([FromBody] Review review)
    {
      var user = _userService.Authenticate(review.Username, review.Password);


      if (user == null)
        return BadRequest(new { message = "Username or password is incorrect"});

      return Ok(user);  
    }

    [HttpGet]
      public IActionResult GetAll()
      {
          var users =  _userService.GetAll();
          return Ok(users);
      }
  }
}