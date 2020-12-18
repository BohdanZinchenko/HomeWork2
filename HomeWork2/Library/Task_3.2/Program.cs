using System;
using Library;
namespace Task_3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            PaymentService ps = new PaymentService();
            ps.StartDeposit(15,"USD");
            ps.StartWithdrawal(15,"USD");
            // PaymentSercvice class created in Library like PaymentService.cs
        }
    }
}
