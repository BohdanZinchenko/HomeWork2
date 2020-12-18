using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class BettingPlatformEmulator
    {
        private List<Player> players;
        private Player ActivePlayer;
        private Account Account;
        private decimal _amount;
        private BetService Betservice;
        private PaymentService PaymentServ;
        public BettingPlatformEmulator()
        {
            Account = new Account();
            players = new List<Player>();
            _amount = 0;
            Betservice = new BetService();
            PaymentServ = new PaymentService();
        }
        public void Start()
        {
            int chouse;

            if (ActivePlayer == null)
            {
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Stop");
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out chouse) && chouse >= 1 && chouse <= 3)
                    {
                        break;
                    }
                    {
                        Console.WriteLine("Chose the right option from 1 to 3 pls ");
                    }
                }
            }
            else
            {
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. GetOdds");
                Console.WriteLine("4. Bet");
                Console.WriteLine("5. Logout");
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out chouse) && chouse >= 1 && chouse <= 5)
                    {
                        break;
                    }
                    {
                        Console.WriteLine("Chose the right option from 1 to 5 pls ");
                    }
                }
            }

            if (ActivePlayer == null)
            {
                switch (chouse)
                {
                    case 1:
                        Register();
                        break;
                    case 2:
                        Login();
                        break;
                    case 3:
                        Exit();
                        break;
                }
            }
            else
            {
                switch (chouse)
                {
                    case 1:
                        Deposit();
                        break;
                    case 2:
                        Withdraw();
                        break;
                    case 3:
                        GetOdds();
                        break;
                    case 4:
                        Bet();
                        break;
                    case 5:
                        Logout();
                        break;
                }
            }

        }
        public void Exit()
        {
            return;
        }
        public void Register()
        {
            
                string Fname;
                string Lname;
                string login;
                string password;
                string currency;
                Console.Write("Enter your name , please  ");
                Fname = Console.ReadLine();
                Console.Write("Enter your Last name , please  ");
                Lname = Console.ReadLine();
                Console.Write("Enter your Login , please  ");
                login = Console.ReadLine();
                Console.Write("Enter your Password , please  ");
                password = Console.ReadLine();
                while (true)
                {
                    Console.Write("( Chose one of this Currency: USD, EUR, UAH )  Currency , please  ");
                    currency = Console.ReadLine();
                    if (currency == "USD" || currency == "EUR" || currency == "UAH")
                    {
                        break;
                    }
                }
                Player player = new Player(Fname, Lname, login, password, currency);
                players.Add(player);
            
            
            Start();
        }
        public void Login()
        {
            string login;
            string password;
            Console.Write("Enter your Login , please  ");
            login = Console.ReadLine();
            Console.Write("Enter your Password , please  ");
            password = Console.ReadLine();
            ActivePlayer = players.Find(x => x.Login(password, login));
            if (ActivePlayer != null)
            {
                Console.WriteLine("Logined");
            }
            else
            {
                Console.WriteLine("False login");
            }
            Start();
        }

        
       
        
        public void Logout()
        {
            ActivePlayer = null;
            Start();
        }
        public void Deposit()
        {
            try
            {
                if (ActivePlayer == null)
                {
                    Console.WriteLine("No active player you are not logined");
                    Start();
                }
                else
                {

                    decimal amount;
                    string Currency;
                    Console.Write("Pls input the amount = ");
                    while (!Decimal.TryParse(Console.ReadLine(), out amount))
                    {
                        Console.WriteLine("incorect amout");
                    }
                    Console.Write("Pls input the Currency = ");
                    Currency = Console.ReadLine();
                    while (true)
                    {
                        try
                        {
                            PaymentServ.StartDeposit(amount, Currency);
                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Please, try to make a transaction with lower amount");
                            Start();
                            return;

                        }
                    }
                    if (Currency == "USD")
                    {
                        _amount = _amount + amount;
                        ActivePlayer.Deposit(amount, Currency);
                    }
                    else if (Currency == "EUR")
                    {
                        double value;
                        value = double.Parse(_amount.ToString()) + (double.Parse(amount.ToString()) * 1.19);
                        _amount = Decimal.Parse(value.ToString("#.##"));
                        ActivePlayer.Deposit(amount, Currency);
                    }
                    else if (Currency == "UAH")
                    {
                        double value;
                        value = double.Parse(_amount.ToString()) + (double.Parse(amount.ToString()) / 28.36);
                        _amount = Decimal.Parse(value.ToString("#.##"));
                        ActivePlayer.Deposit(amount, Currency);
                    }
                    else
                    {
                        Console.WriteLine("Incorect Currency");
                    }
                }
            }
            catch (PaymentServiceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Start();
        }

        
        public void Withdraw()
        {
            try
            {
                decimal amount;
                string Currency;
                Console.Write("Pls input the amount = ");
                while (!Decimal.TryParse(Console.ReadLine(), out amount))
                {
                    Console.WriteLine("incorect amout");
                }
                Console.Write("Pls input the Currency = ");
                Currency = Console.ReadLine();
                while (true)
                {
                    try
                    {
                        PaymentServ.StartWithdrawal(amount, Currency);
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Please, try to make a transaction with lower amount or change the payment method");
                        Console.Write("Pls input the amount = ");
                        Start();
                        return;
                    }
                }


                if (Currency == "USD" && amount < _amount)
                {
                    try
                    {
                        _amount = _amount - amount;
                        ActivePlayer.Withdraw(amount, Currency);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (Currency == "EUR" && double.Parse(amount.ToString()) * 1.19 < double.Parse(_amount.ToString()))
                {
                    try
                    {
                        var value = double.Parse(_amount.ToString()) - (double.Parse(amount.ToString()) * 1.19);
                        _amount = Decimal.Parse(value.ToString("#.##"));
                        ActivePlayer.Withdraw(amount, Currency);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (Currency == "UAH" && double.Parse(amount.ToString()) < double.Parse(_amount.ToString()) * 28.36)
                {
                    try
                    {
                        var value = double.Parse(_amount.ToString()) - (double.Parse(amount.ToString()) / 28.36);
                        _amount = Decimal.Parse(value.ToString("#.##"));
                        ActivePlayer.Withdraw(amount, Currency);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("There is some problem on the platform side.Please try it later");
                }
            }
            catch(PaymentServiceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Start();
        }
        public void GetOdds()
        {
            
            Console.WriteLine($" Current cof is  {Betservice.GetOdds()}");
            Start();
        }
        public void Bet()
        {
            decimal amount;
            string currency;
            Console.Write("Pls input the amount = ");
            try
            {
                while (!Decimal.TryParse(Console.ReadLine(), out amount))
                {
                    Console.WriteLine("incorect amout");
                }
                Console.Write("Currency ");
                currency  = Console.ReadLine();
                ActivePlayer.Withdraw(amount, currency);
                amount = Betservice.Bet(amount);
                ActivePlayer.Deposit(amount, currency);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Start();


        }

    }
}
