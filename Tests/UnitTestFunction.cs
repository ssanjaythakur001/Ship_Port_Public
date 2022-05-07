using Port.Domain.Provider;
using Moq;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Port.Domain.Models;
using Port.Controller;
using Port.Domain.Data;

namespace Port.Tests
{
    public class TestFunction
    {
        private IShipDataProvider _shipDataProvider;
        private Mock<ShipController> _mockShipCOntroller;
        private readonly Mock<ShipDataContext> _context;
        public TestFunction()
        {
            _context=new Mock<ShipDataContext>();
            _shipDataProvider = new ShipDataProvider(_context.Object);
            _mockShipCOntroller=new Mock<ShipController>(_shipDataProvider);
        }

        [Fact]
        [Trait("UnitTest", "Unit")]
        public async Task UnitTestAddShip()
        {
             var studio = new Ship
            {
                Name="TestShip",
                Width=3,
                Length=5,
                Code="ASDR-8347-A5"
            };
          var studioResponse=await _mockShipCOntroller.Object.Post(studio);
          Assert.NotNull(studioResponse);
        }

     

    }
}