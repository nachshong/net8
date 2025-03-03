using Microsoft.AspNetCore.Mvc;
using University.Data;

namespace University.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Authorize : ControllerBase
    {
        private UniversityDbContext _db;

        public Authorize(UniversityDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public IActionResult Login(string username, string paswword)
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
    }
}
