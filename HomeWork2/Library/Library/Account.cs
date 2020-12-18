using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    
    public class Account
    {
        private static int _invidual = 100000;
        public readonly int _id;
        private string _currency;
        private decimal _amount;

        public Account()
        {
            Random rn = new Random();
            _id = genid();
            _currency = "USD";
            _amount = 0;


        }

        public Account(string Currency)
        {

            if (Currency == "UAH" || Currency == "EUR" || Currency == "USD")
            {
                _id = genid();
                this._currency = Currency;
                _amount = 0;

            }
            else
            {
                throw new NotSupportedException();
            }

        }
        private int genid()
        {
            _invidual++;
            return _invidual;
        }
        public void PrintInfo()
        {
            Console.WriteLine($"ID Account = {_id} with Currency {_currency} has {GetBalance(_currency)}  ");
        }
        public void Deposit(decimal amount, string Currency)
        {
            if (_currency == Currency)
            {
                _amount = _amount + amount;
            }
            else if (Currency == "UAH" && _currency == "USD")
            {
                double value;
                value = double.Parse(_amount.ToString()) + (double.Parse(amount.ToString()) / 28.36);
                _amount = Decimal.Parse(value.ToString("#.##"));

            }
            else if (Currency == "EUR" && _currency == "USD")
            {
                double value;
                value = double.Parse(_amount.ToString()) + (double.Parse(amount.ToString()) * 1.19);
                _amount = Decimal.Parse(value.ToString("#.##"));
            }
            else if (Currency == "USD" && _currency == "UAH")
            {
                double value;
                value = double.Parse(_amount.ToString()) + (double.Parse(amount.ToString()) * 28.36);
                _amount = Decimal.Parse(value.ToString("#.##"));
            }
            else if (Currency == "EUR" && _currency == "UAH")
            {
                double value;
                value = double.Parse(_amount.ToString()) + (double.Parse(amount.ToString()) * 33.63);
                _amount = Decimal.Parse(value.ToString("#.##"));
            }
            else if (Currency == "USD" && _currency == "EUR")
            {
                double value;
                value = double.Parse(_amount.ToString()) + (double.Parse(amount.ToString()) / 1.19);
                _amount = Decimal.Parse(value.ToString("#.##"));
            }
            else if (Currency == "UAH" && _currency == "EUR")
            {
                double value;
                value = double.Parse(_amount.ToString()) + (double.Parse(amount.ToString()) / 33.63);
                _amount = Decimal.Parse(value.ToString("#.##"));
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        public void Withdraw(decimal amount, string Currency)
        {
            if (_currency == Currency)
            {
                if (amount > _amount)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    _amount = _amount - amount;
                }



            }
            else if (Currency == "UAH" && _currency == "USD")
            {
                double value;


                value = double.Parse(_amount.ToString()) - (double.Parse(amount.ToString()) / 28.36);
                if (value < 0)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    _amount = Decimal.Parse(value.ToString("#.##"));
                }

            }
            else if (Currency == "EUR" && _currency == "USD")
            {
                double value;
                value = double.Parse(_amount.ToString()) - (double.Parse(amount.ToString()) * 1.19);
                if (value < 0)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    _amount = Decimal.Parse(value.ToString("#.##"));
                }
            }
            else if (Currency == "USD" && _currency == "UAH")
            {
                double value;
                value = double.Parse(_amount.ToString()) - (double.Parse(amount.ToString()) * 28.36);
                if (value < 0)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    _amount = Decimal.Parse(value.ToString("#.##"));
                }
            }
            else if (Currency == "EUR" && _currency == "UAH")
            {
                double value;
                value = double.Parse(_amount.ToString()) - (double.Parse(amount.ToString()) * 33.63);
                if (value < 0)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    _amount = Decimal.Parse(value.ToString("#.##"));
                }
            }
            else if (Currency == "USD" && _currency == "EUR")
            {
                double value;
                value = double.Parse(_amount.ToString()) - (double.Parse(amount.ToString()) / 1.19);
                if (value < 0)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    _amount = Decimal.Parse(value.ToString("#.##"));
                }
            }
            else if (Currency == "UAH" && _currency == "EUR")
            {
                double value;
                value = double.Parse(_amount.ToString()) - (double.Parse(amount.ToString()) / 33.63);
                if (value < 0)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    _amount = Decimal.Parse(value.ToString("#.##"));
                }
            }
        }
        decimal GetBalance(string Currency)
        {
            if (_currency == Currency)
            {
                return _amount;
            }
            else if (Currency == "UAH" && _currency == "USD")
            {
                double value;
                value = double.Parse(_amount.ToString()) / 28.36;
                return _amount = Decimal.Parse(value.ToString("#.##"));

            }
            else if (Currency == "EUR" && _currency == "USD")
            {
                double value;
                value = double.Parse(_amount.ToString()) * 1.19;
                return _amount = Decimal.Parse(value.ToString("#.##"));
            }
            else if (Currency == "USD" && _currency == "UAH")
            {
                double value;
                value = double.Parse(_amount.ToString()) * 28.36;
                return _amount = Decimal.Parse(value.ToString("#.##"));
            }
            else if (Currency == "EUR" && _currency == "UAH")
            {
                double value;
                value = double.Parse(_amount.ToString()) * 33.63;
                return _amount = Decimal.Parse(value.ToString("#.##"));
            }
            else if (Currency == "USD" && _currency == "EUR")
            {
                double value;
                value = double.Parse(_amount.ToString()) / 1.19;
                return _amount = Decimal.Parse(value.ToString("#.##"));
            }
            else if (Currency == "UAH" && _currency == "EUR")
            {
                double value;
                value = double.Parse(_amount.ToString()) / 33.63;
                return _amount = Decimal.Parse(value.ToString("#.##"));
            }
            else
            {
                throw new NotSupportedException();
            }

        }
    }
}
