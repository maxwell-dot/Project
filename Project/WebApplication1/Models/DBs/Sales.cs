using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DBs
{
    public class Sale
    {
        [Key]
        public Guid Id { get; set; }
        public Guid IdCar { get; set; }
        public Guid IdClient { get; set; }
        public int TotalPay { get; set; }
    }
}
