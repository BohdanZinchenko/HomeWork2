using System;
using Library;
namespace Task_4._2
{
    class Program
    {
        static void Main(string[] args)
        {

            PaymentService PS = new PaymentService();
            PS.StartDeposit(3500, "USD");
            PS.StartDeposit(5000, "UAH");
            PS.StartDeposit(5000, "USD");

            // PaymentServiceException.cs is in Library 
        }

    }
    
    
}
