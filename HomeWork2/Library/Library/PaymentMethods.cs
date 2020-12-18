using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    
    public abstract class PaymentMethodBase
    {
        public string Name;
        public decimal _amount;
        public abstract void StartDeposit(decimal amount, string currency);
        public abstract void StartWithdrawal(decimal amount, string currency);
    }

    public interface ISupportDeposit
    {
        public void StartDeposit(decimal amount, string currency);
    }
    public interface ISupportWithdrawal
    {
        public void StartWithdrawal(decimal amount, string currency);

    }
    public class CreditCard : PaymentMethodBase, ISupportDeposit, ISupportWithdrawal
    {
        private string _typeCard;
        string _cardNumber;
        string _expiryDate;
        string _cvv;
        

        public CreditCard()
        {
            Name = "CreditCard";
            _amount = 0;
        }
        public override void StartDeposit(decimal amount, string currency)
        {


            while (true)
            {
                Console.Write("Chose cart type (Visa, Mastercard)  ");
                _typeCard = Console.ReadLine();
                if (_typeCard == "Visa")
                {
                    Console.WriteLine("Pls Enter card number ");
                    Console.Write("4");
                    _cardNumber = "4" + Console.ReadLine();
                    if (_cardNumber.Length != 16)
                    {
                        Console.WriteLine("Error Card number, must be 16 symbols");
                    }
                    else
                    {
                        break;
                    }
                }
                else if (_typeCard == "Mastercard")
                {
                    Console.WriteLine("Pls Enter card number ");
                    Console.Write("5");
                    _cardNumber = "5" + Console.ReadLine();
                    if (_cardNumber.Length != 16)
                    {
                        Console.WriteLine("Error Card number, must be 16 symbols");
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Error type card");
                    return;


                }
            }
            bool flagExpireDate = true;
            while (flagExpireDate)
            {
                Console.Write("Input Experation date (xx/xx)");
                _expiryDate = Console.ReadLine();
                var num1 = 0;
                var num2 = 0;
                char[] arg = _expiryDate.ToCharArray();
                for (int i = 0; i < arg.Length; i++)
                {
                    if (arg[i] == '/')
                    {
                        string[] elem = _expiryDate.Split('/');
                        if (int.TryParse(elem[0], out num1) && int.TryParse(elem[1], out num2))
                        {
                            if (num1 > 0 && num1 <= 31 && num2 > 0 && num2 <= 12)
                            {
                                flagExpireDate = false;
                            }

                        }

                    }

                }
                if (flagExpireDate == true)
                {
                    Console.WriteLine("Incorect input try again");
                    return;
                }
            }
            while (true)
            {
                int x;
                Console.WriteLine("input CVV ");
                _cvv = Console.ReadLine();
                if (_cvv.Length == 3 && int.TryParse(_cvv, out x))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorect input try again");
                    return;
                }

            }
           
        }
        public override void StartWithdrawal(decimal amount, string currency)
        {
            string TypeCard;
            string CardNumber;
            while (true)
            {
                Console.Write("Chose cart type (Visa, Mastercard)  ");
                TypeCard = Console.ReadLine();
                if (TypeCard == "Visa")
                {
                    Console.WriteLine("Pls Enter card number ");
                    Console.Write("4");
                    CardNumber = "4" + Console.ReadLine();
                    if (CardNumber.Length != 16)
                    {
                        Console.WriteLine("Error Card number, must be 16 symbols");
                    }
                    else
                    {
                        break;
                    }
                }
                else if (TypeCard == "Mastercard")
                {
                    Console.WriteLine("Pls Enter card number ");
                    Console.Write("5");
                    CardNumber = "5" + Console.ReadLine();
                    if (CardNumber.Length != 16)
                    {
                        Console.WriteLine("Error Card number, must be 16 symbols");
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Error type card");
                }
            }
        }


    }
    public abstract class Bank : PaymentMethodBase, ISupportDeposit, ISupportWithdrawal
    {
        public string[] AvailableCards;
        private string _login;
        private string _password;
        public Bank()
        {
        }
        public override void StartDeposit(decimal amount, string currency)
        {
            Console.WriteLine($"Welcome, dear client to the online bank {Name}");
            Console.Write($"Please, enter your login ");
            _login = Console.ReadLine();
            Console.Write($"Please, enter your password ");
            _password = Console.ReadLine();
            Console.WriteLine($"Hello Mr/Mis {_login}. Pick a card to proceed the transaction ");
            for (int i = 0; i < AvailableCards.Length; i++)
            {
                Console.WriteLine($"{i}. {AvailableCards[i]}");

            }
            int Cardindex;
            while (!int.TryParse(Console.ReadLine(), out Cardindex)) { Console.WriteLine("Eror index card");return; }
            Console.WriteLine($"You’ve withdraw {amount} {currency} from your {AvailableCards[Cardindex]} card successfully");

            

        }
        public override void StartWithdrawal(decimal amount, string currency)
        {
            Console.WriteLine($"Welcome, dear client to the online bank {Name}");
            Console.Write($"Please, enter your login ");
            _login = Console.ReadLine();
            Console.Write($"Please, enter your password ");
            _password = Console.ReadLine();
            Console.WriteLine($"Hello Mr/Mis {_login}. Pick a card to proceed the transaction ");
            for (int i = 0; i < AvailableCards.Length; i++)
            {
                Console.WriteLine($"{i}. {AvailableCards[i]}");

            }
            int Cardindex;
            while (!int.TryParse(Console.ReadLine(), out Cardindex) && Cardindex <= AvailableCards.Length) { Console.WriteLine("Eror index card");return ; }
            Console.WriteLine($"You’ve deposit  {amount} {currency} from your {AvailableCards[Cardindex]} card successfully ");
        }
    }

    public class Privet48 : Bank
    {
        public Privet48()
        {
            Name = "Privet48";
            AvailableCards = new string[2] { "Gold", "Platinum" };
            _amount = 0;
        }

    }
    public class Stereobank : Bank
    {
        public Stereobank()
        {
            Name = "Stereobank";
            AvailableCards = new string[3] { "Black", "White", "Iron" };
            _amount = 0;
        }
    }
    public class GiftVoucher : PaymentMethodBase, ISupportDeposit
    {
        private bool usage = true;
        public GiftVoucher()
        {
            Name = "GiftVoucher";
            _amount = 0;
        }

        public override void StartDeposit(decimal amount, string currency)
        {
            try
            {
                if (usage == false)
                {
                    throw new PaymentServiceException();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            if (amount == 500 || amount == 100 || amount == 1000)
            {
                string code;
                int x;
                while (true)
                {
                    Console.Write("Input 10x number of sertificate ");
                    code = Console.ReadLine();

                    if (code.Length != 10)
                    {
                        Console.WriteLine("Code must have integer 10 symbols ");
                        return;
                    }
                    else
                    {
                        if (int.TryParse(code, out x))
                        {
                            usage = false;
                            break;
                            
                        }
                    }
                }

            }
            else
            {
                Console.WriteLine("Need to chose a right amount , it can be 100, 500 , 1000 ");
            }
        }

        public override void StartWithdrawal(decimal amount, string currency)
        {
            throw new NotImplementedException();
        }
    }
}
