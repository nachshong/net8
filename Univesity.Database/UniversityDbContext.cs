using Microsoft.EntityFrameworkCore;
using University.Database.Models;

namespace University.Data
{
    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Work> Works { get; set; }
    
    }
}
