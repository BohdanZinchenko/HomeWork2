using System;
using Library;
namespace BettingPlatformEmulatorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            BettingPlatformEmulator Platform = new BettingPlatformEmulator();
            Platform.Start();
        }
    }
}
