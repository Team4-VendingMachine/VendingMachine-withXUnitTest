namespace VendingMachineProject.Models
{
    public class ps4gameTest : IproductTests
    {
        [Fact]
        public void Examine_test2_ShouldReturnString()
        {
            var product = new PlayStation4Game(5, "God of War", 349, "Action-adventure game", "Action", 7);
            var result = product.Use();
            Assert.Equal("You can Enjoy the virtual fight and do not try it with others.", result);
        }

        void IproductTests.Examine_test_ShouldReturnString()
        {
            throw new NotImplementedException();
        }
    }
}