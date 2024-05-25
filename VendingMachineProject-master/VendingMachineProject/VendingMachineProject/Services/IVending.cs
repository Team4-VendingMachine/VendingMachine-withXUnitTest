using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineProject.Services
{
    // -----------------Console based Interface of Vending Machine ------------//
    public interface IVending
    {
        void displayMenu();
        void selectItem();
        void insertMoney();
        void checkBalance();
        double returnChange();
    }

    // -----------------Console based Input Reading Interface of Vending Machine ------------//
   /* public interface inputReader
    {
        string readLine();
    }

    // -----------------Input Reading class for inputReader Interface ------------//
    public class optionReader: inputReader
    {
        public string readLine()
        {
            return Console.ReadLine();
        }
    }*/
}
