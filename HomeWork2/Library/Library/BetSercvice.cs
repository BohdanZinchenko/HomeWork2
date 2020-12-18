using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class BetService
    {
        private decimal Odd;
        Random rn = new Random();

        public BetService()
        {

            Odd = Decimal.Parse((rn.NextDouble() * (25.0 - 1.0) + 1.0).ToString());

        }

        public decimal GetOdds()
        {
            Odd = Decimal.Parse((rn.NextDouble() * (25.0 - 1.0) + 1.0).ToString());
            return Odd;
        }
        private bool IsWon()
        {
            int chance;

            chance = rn.Next(1, 100);
            if (chance >= Odd * 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public decimal Bet(decimal Bet)
        {
            if (IsWon())
            {
                Console.WriteLine($"You won {Decimal.Round(Bet * Odd, 2)}");
                return Decimal.Round(Bet * Odd,2);
            }
            else
            {
                Console.WriteLine($"You lose");
                return 0;
            }
        }
    }
}
