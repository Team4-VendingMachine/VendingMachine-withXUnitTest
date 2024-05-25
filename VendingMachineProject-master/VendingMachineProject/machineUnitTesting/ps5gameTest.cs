namespace VendingMachineProject.Models
{
    public class ps5gameTest : IproductTests
    {

        [Fact]
        public void Examine_test3_ShouldReturnString()
        {
            var product = new PlayStation5Game(3, "Demon's Souls", 899, "Face the challenges of Demon's Souls and emerge victorious.", "Horror", 2);
            var result = product.Use();
            Assert.Equal("You can Experience a real horror game.", result);
        }


        void IproductTests.Examine_test_ShouldReturnString()
        {
            throw new NotImplementedException();
        }
    }
}