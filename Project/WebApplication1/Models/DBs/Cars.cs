using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DBs
{
    public class Car
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }

    }
}