using System;
using Library;
namespace Task_1._5
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("John Doe", "Betman", "john777@gmail.com", "TheP@$$w0rd", "USD");
            string Truepas = "TheP@$$w0rd";
            string FalsePas = "FalsePAs";
            player.IsPaswwordValid(Truepas);
            player.IsPaswwordValid(FalsePas);
            player.Deposit(100, "USD");
            player.Withdraw(50, "EUR");
            try
            {
                player.Withdraw(1000, "USD");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                Player player1 = new Player("John Doe", "Betman", "john777@gmail.com", "TheP@$$w0rd", "PLN");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Player realised in Player.cs
        }
    }
}
