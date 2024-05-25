using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineProject.Services
{
    class Program
    {
        static void Main(string[] args)
        {
            // ---------- Creating instance of Vending Machine -----------//
            VendingMachine machine = new VendingMachine();
            try
            {
                //-------- Starting Machine -----------//
                machine.StartMachine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
