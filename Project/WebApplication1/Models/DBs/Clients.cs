using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DBs
{
    public class Clients
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
