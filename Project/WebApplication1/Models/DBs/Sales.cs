using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models.DBs
{
    //[Table("Sales")]
    public class Sales
    {
        
        [Key]
        public Guid Id { get; set; }
        public Guid IdCar { get; set; }
        public Guid IdClient { get; set; }
        public int TotalPayment { get; set; }
    }
}
