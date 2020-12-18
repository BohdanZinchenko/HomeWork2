using System;
using Library;
namespace Task_2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            BetService BS = new BetService();



            for (int i = 0; i < 10; i++)
            {
                decimal cof = BS.GetOdds();

                {
                    Console.WriteLine($"I`ve bet 100 USD with the odd {Decimal.Round(cof, 2)} and I’ve earned {Decimal.Round(BS.Bet(100), 2)}");
                }
            }
            int times = 0;
            Console.WriteLine("--------------------------------------------------------------");
            while (times < 3)
            {
                decimal cof = BS.GetOdds();
                if (cof > 12)
                {
                    Console.WriteLine($"I`ve bet 100 USD with the odd {Decimal.Round(cof, 2)} and I’ve earned {Decimal.Round(BS.Bet(100), 2)}");
                    times++;
                }
            }
            decimal amount = 10000;
            while (amount <= 150000 || amount <= 0)
            {
                decimal cof = BS.GetOdds();
                if (cof < 5)
                {
                    amount += Decimal.Round(BS.Bet(amount / 2), 2);
                    Console.WriteLine(amount);
                    Console.WriteLine($"I`ve bet 100 USD with the odd {Decimal.Round(cof, 2)} and I’ve earned {Decimal.Round(BS.Bet(100), 2)}");
                }
            }
            Console.WriteLine($"Amount of your acount is {amount}");
            // BetService realised in Library like BetService.cs
        }
    }
}
