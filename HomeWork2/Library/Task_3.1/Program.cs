using System;
using Library;
namespace Task_3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            CreditCard creditCard = new CreditCard();
            creditCard.StartDeposit(50,"USD");
            Privet48 privet = new Privet48();
            privet.StartDeposit(50, "USD");
            Stereobank stereo = new Stereobank();
            stereo.StartWithdrawal(50, "USD");
            GiftVoucher gift = new GiftVoucher();
            gift.StartDeposit(50m, "USD");
            gift.StartDeposit(500m, "USD");
            gift.StartDeposit(100m, "USD");

            //Class PaynmentMethods realised in Library like  PaynmentMethods.cs
        }
    }
    
}
