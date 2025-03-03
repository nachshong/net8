using Microsoft.AspNetCore.Mvc;
using University.Data;
using University.Database.Models;

namespace University.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private UniversityDbContext _db;

        public StudentsController(UniversityDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        [Route("login")]
        public ActionResult Login(string username, string paswword)
        {
            var id = _db.Users.SingleOrDefault(s => s.Username == username && s.Password == paswword)?.Id;

            if (!String.IsNullOrEmpty(id))
            {
                return Content(id);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("{userId}/works")]
        public IEnumerable<Work> Works(string userId)
        {
            return _db.Works.Where(s => s.UserId == userId);
        }

        [HttpPost]
        [Route("/init")]
        public ActionResult InitDb()
        {
            _db.Users.Add(new User { Id = "1", Username = "user1", Password = "1234" });
            _db.Users.Add(new User { Id = "2", Username = "user2", Password = "1234" });

            _db.Works.Add(new Work { Id = 1, Title = "Test 1", UserId = "1", Score = 100, CreatedDate = DateTime.Now.AddDays(-30) });
            _db.Works.Add(new Work { Id = 2, Title = "Test 2", UserId = "1", Score = 90, CreatedDate = DateTime.Now.AddDays(-40) });

            _db.Works.Add(new Work { Id = 3, Title = "Test 1", UserId = "2", Score = 95, CreatedDate = DateTime.Now.AddDays(-30) });
            _db.Works.Add(new Work { Id = 4, Title = "Test 2", UserId = "2", Score = 85, CreatedDate = DateTime.Now.AddDays(-40) });

            _db.SaveChanges();

            return Created();
        }
    }
}
