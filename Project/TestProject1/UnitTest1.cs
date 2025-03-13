using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Controllers;
using WebApplication1.Data;
using WebApplication1.Repositories;

namespace TestProject1
{
    public class UnitTest1 : IClassFixture<DependecyFixture>
    {
        private ServiceProvider _serviceProvider;

        public UnitTest1(DependecyFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }

        [Fact]
        public async Task WhenClientNotFound()
        {
            using var dbContext = _serviceProvider.GetService<ApplicationDbContext>();
            var repository = new DealerShipRepository(dbContext);
            var salesController = new SalesController(repository);
            var deleteClientResult = await salesController.DeleteClient(Guid.Empty);
            Assert.IsType<NotFoundResult>(deleteClientResult);
        }
    }
}