using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class PaymentService : ISupportDeposit, ISupportWithdrawal
    {
        private PaymentMethodBase[] AvailablePaymentMethod;
        
        public PaymentService()
        {
            AvailablePaymentMethod = new PaymentMethodBase[4] { new CreditCard(), new Privet48(), new Stereobank(), new GiftVoucher() };
        }
        public void StartDeposit(decimal amount, string currency)
        {
            for (int i = 0; i < AvailablePaymentMethod.Length; i++)
            { 
                    Console.WriteLine($"{i+1}. {AvailablePaymentMethod[i].Name}");   
            }

            int variant;
            
            if (int.TryParse(Console.ReadLine(), out variant) && variant > 0 && variant < 5)
            {
             
                switch(variant)
                {
                    case 1:
                        try
                        {
                            if (currency == "USD" && AvailablePaymentMethod[0]._amount + amount * 28 > 3000) throw new InsufficientFundsException();
                            else if (currency == "UAH" && AvailablePaymentMethod[0]._amount + amount > 3000) throw new InsufficientFundsException();
                            else if (currency == "EUR" && AvailablePaymentMethod[0]._amount + amount * 32 > 3000) throw new InsufficientFundsException();
                            else if (currency == "USD") AvailablePaymentMethod[0]._amount +=amount * 28;
                            else if (currency == "EUR") AvailablePaymentMethod[0]._amount +=amount *32;
                            else if (currency == "UAH") AvailablePaymentMethod[0]._amount += amount;
                        }
                        catch(LimitExceededException ex)
                        {
                            
                            
                            throw;
                        }
                        catch (InsufficientFundsException ex)
                        {
                            
                            
                            throw;
                        }

                        AvailablePaymentMethod[0].StartDeposit(amount, currency);
                        break;
                    case 2:
                        try
                        {
                            if (currency == "USD" && AvailablePaymentMethod[1]._amount + amount * 28 > 10000) throw new InsufficientFundsException();
                            else if (currency == "UAH" && AvailablePaymentMethod[1]._amount + amount > 10000) throw new InsufficientFundsException();
                            else if (currency == "EUR" && AvailablePaymentMethod[1]._amount + amount * 32 > 10000) throw new InsufficientFundsException();
                            else if (currency == "USD") AvailablePaymentMethod[1]._amount += amount * 28;
                            else if (currency == "EUR") AvailablePaymentMethod[1]._amount += amount * 32;
                            else if (currency == "UAH") AvailablePaymentMethod[1]._amount += amount;
                            
                            
                        }
                        catch (LimitExceededException ex)
                        {

                            throw;
                        }
                        catch (InsufficientFundsException ex)
                        {
                            
                            throw;
                        }
                        AvailablePaymentMethod[1].StartDeposit(amount, currency);
                        break;
                    case 3:
                        try
                        {
                            if (currency == "USD" && AvailablePaymentMethod[2]._amount + amount * 28 > 3000) throw new InsufficientFundsException();
                            else if (currency == "UAH" && AvailablePaymentMethod[2]._amount + amount > 3000) throw new InsufficientFundsException();
                            else if (currency == "EUR" && AvailablePaymentMethod[2]._amount + amount * 32 > 3000) throw new InsufficientFundsException();
                            else if (currency == "USD") AvailablePaymentMethod[2]._amount += amount / 28;
                            else if (currency == "EUR") AvailablePaymentMethod[2]._amount += amount / 32;
                            else if (currency == "UAH") AvailablePaymentMethod[2]._amount += amount;
                            else if (currency == "UAH" && amount > 3000) throw new LimitExceededException();
                            else if (currency == "EUR" && amount*33 > 3000) throw new LimitExceededException();
                            else if (currency == "USD" && amount*28 > 3000) throw new LimitExceededException();
                        }
                        catch (LimitExceededException ex)
                        {
                            
                           
                            throw;
                        }
                        catch (InsufficientFundsException ex)
                        {
                           
                            throw;
                        }
                        AvailablePaymentMethod[2].StartDeposit(amount, currency);
                        break;
                    case 4:
                        try
                        {
                            AvailablePaymentMethod[3].StartDeposit(amount, currency);
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                        
                        break;
                }
            }
            else
            {
                Console.WriteLine("Error instuction ");
                
            }
        }
        

        public void StartWithdrawal(decimal amount, string currency)
        {
            for (int i = 0; i < AvailablePaymentMethod.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {AvailablePaymentMethod[i].Name}");
            }

            int variant;

            if (int.TryParse(Console.ReadLine(), out variant) && variant > 0 && variant <4 )
            {

                switch (variant)
                {
                    case 1:
                        AvailablePaymentMethod[0].StartWithdrawal(amount, currency);
                        break;
                    case 2:
                        AvailablePaymentMethod[1].StartWithdrawal(amount, currency);
                        break;
                    case 3:
                        AvailablePaymentMethod[3].StartWithdrawal(amount, currency);
                        break;
                   
                }
            }
            else
            {
                Console.WriteLine("Error instuction ");
                

            }
        }
    }
}
