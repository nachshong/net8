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
            _db.Works.RemoveRange(_db.Works.ToArray());
            _db.Users.RemoveRange(_db.Users.ToArray());

            _db.Users.AddRange(
                new User { Id = "1", Username = "user1", Password = "1234" },
                new User { Id = "2", Username = "user2", Password = "1234" }
            );

            _db.Works.AddRange(
                new Work { Title = "Test 1", UserId = "1", Score = 100, CreatedDate = DateTime.Now.AddDays(-30) },
                new Work { Title = "Test 2", UserId = "1", Score = 90, CreatedDate = DateTime.Now.AddDays(-40) },
                new Work { Title = "Test 1", UserId = "2", Score = 95, CreatedDate = DateTime.Now.AddDays(-30) },
                new Work { Title = "Test 2", UserId = "2", Score = 85, CreatedDate = DateTime.Now.AddDays(-40) }
            );

            _db.SaveChanges();

            return Created();
        }
    }
}
