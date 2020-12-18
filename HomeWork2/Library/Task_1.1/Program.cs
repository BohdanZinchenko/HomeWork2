using System;
using Library;
namespace Task_1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            
                Account ac = new Account();
                Account ac1 = new Account("UAH");
                Account ac2 = new Account("EUR");
                ac2.Deposit(10, "EUR");
                ac2.Withdraw(3, "UAH");
                ac1.Deposit(121, "UAH");
                try
                {
                    ac.Withdraw(5, "USD");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                try
                {
                    Account ac3 = new Account("PLN");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                ac.PrintInfo();
                ac1.PrintInfo();
                ac2.PrintInfo();
                Console.ReadKey();
            //Account realised in Library Like Account.cs
        }
    }
}
