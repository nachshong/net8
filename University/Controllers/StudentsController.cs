using Microsoft.AspNetCore.Mvc;
using University.Data;
using University.Models;

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
        public string Login(string username, string paswword)
        {
            var id = _db.Users.SingleOrDefault(s => s.Username == username && s.Password == paswword)?.Id;
            return id;
        }

        [HttpGet]
        [Route("{userId}/works")]
        public IEnumerable<Work> Works(string userId)
        {
            return _db.Works.Where(s => s.UserId == userId);
        }
    }
}
