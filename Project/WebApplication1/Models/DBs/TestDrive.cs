using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DBs
{
    public class TestDrive
    {
        [Key]
        public Guid Id { get; set; }
        public Guid IdCar { get; set; }
        public string IdClient { get; set; }
        public bool Booked { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
