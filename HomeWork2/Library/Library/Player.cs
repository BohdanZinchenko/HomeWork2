using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class Player
    {
        private static int _invidual = 100000;
        public readonly int _id;
        private string _firstName;
        private string _lastName;
        private string _email { get; set; }
        private string _password;
        Account Account;


        public Player(string firstName, string lastName, string email, string password, string Currency)
        {
            _id = genid();
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _password = password;
            Account = new Account(Currency);
        }
        public string getEmail()
        {
            return _email;
        }
        private int genid()
        {
            _invidual++;
            return _invidual;
        }
        public bool IsPaswwordValid(string password)
        {
            if (password == _password)
            {
                Console.WriteLine($"Login with login {_email} and password {password} is {true}");
                return true;

            }
            else
            {
                Console.WriteLine($"Login with login {_email} and password {password} is {false}");
                return false;
            }
        }
        public bool Login(string password, string login)
        {
            if (password == _password && login == _email)
            {
                return true;
            }
            return false;
        }
        public void Deposit(decimal amount, string Currency)
        {
            Account.Deposit(amount, Currency);
        }
        public void Withdraw(decimal amount, string Currency)
        {
            Account.Withdraw(amount, Currency);
        }
    }
}
