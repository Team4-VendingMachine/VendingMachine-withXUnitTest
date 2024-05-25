
namespace VendingMachineProject.Models
{
    public class productTests : IproductTests
    {
        [Fact]
        public void Examine_test1_ShouldReturnString()
        {
            var product = new NintendoSwitchGame(8, "Animal Crossing: New Horizons", 399, "Life simulation game", "Family", 18);
            var result = product.Use();
            Assert.Equal("Enjoy playing together with family.", result);
        }
        void IproductTests.Examine_test_ShouldReturnString()
        {
            throw new NotImplementedException();
        }
    }
}
