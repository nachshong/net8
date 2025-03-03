using System.ComponentModel.DataAnnotations.Schema;

namespace University.Database.Models
{
    public class Work
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Title { get; set; }

        public DateTime CreatedDate { get; set; }

        public int Score { get; set; }
    }
}
