using NUnit.Framework;

namespace VendingMachineProject.Services
{
    [TestFixture]
    public class VendingMachineTests
    {

        //----------------- testStartMachineFunction ------------//

        //---------- creating required instances ---------//
        private VendingMachine machine;
        private StringWriter writer;
        private StringReader reader;

        //---------- Setting up instances -----------//
        [SetUp]
        public void setUp()
        {
            machine = new VendingMachine();
            writer = new StringWriter();
            Console.SetOut(writer);
        }

        //------------ Resetting instances and restoring the system to its original state -------//
        [TearDown]
        public void tearDown()
        {
            writer.Dispose();
            if (reader != null)
            {
                reader.Dispose();
            }
            //Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }
        //------------ testing option three selection --------------//
        [Test]
        public void startTest_option3()
        {
            reader = new StringReader("3\n");
            Console.SetIn(reader);

            machine.StartMachine();

            string output = writer.ToString();

            //Assert.That(output.Contains("You have 0kr in moneyPool."), Is.True, "The output is incorrect");
            if (!output.Contains("You have 0kr in moneyPool."))
            {
                throw new Exception("Output is wrong!");
            }
        }
    }

}