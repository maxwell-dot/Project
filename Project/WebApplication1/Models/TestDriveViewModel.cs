using WebApplication1.Models.DBs;

namespace WebApplication1.Models
{
    public class TestDriveViewModel
    {
        public IEnumerable<Clients> Clients { get; set; }
        public IEnumerable<Car> Cars{ get; set; }
        public string SelectedCar { get; set; }

    }
}
