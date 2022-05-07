using Port.Domain.Provider;
using Moq;
using Xunit;
using System.Threading.Tasks;
using Port.Domain.Models;
using Port.Controller;
using Port.Domain.Data;

namespace Port.Tests
{
    public class BehaviourTestFunction
    {
        private Mock<IShipDataProvider> _shipDataProvider;
        private readonly Mock<ShipDataContext> _context;
        public BehaviourTestFunction()
        {
            _context=new Mock<ShipDataContext>();
            _shipDataProvider = new Mock<IShipDataProvider>(_context);
        }

        [Fact]
        [Trait("BehaviourTest", "Behaviour")]
        public async Task UnitTestAddShip()
        {
             var studio = new Ship
            {
                Name="Ship0",
                Width=3,
                Length=5,
                Code="FTDS-8347-A5"
            };
          var studioResponse=await _shipDataProvider.Object.AddShipAsync(studio);
          Assert.NotNull(studioResponse);
        }

     

    }
}