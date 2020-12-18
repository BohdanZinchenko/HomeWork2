using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class PaymentServiceException : Exception
    {
        private string _innerData;
        public PaymentServiceException(string innerData) : this("Something went wrong. Try again later...", innerData)
        {
            _innerData = innerData;
        }
        public PaymentServiceException() : base("Payment Service Exception")
        {

        }
        public PaymentServiceException(string message, string innerData) :
            base(message)
        {
            _innerData = innerData;
        }

    }
    class LimitExceededException : PaymentServiceException
    {
        public LimitExceededException() : base("Limit Exceeded Exception")
        {

        }

    }
    class InsufficientFundsException : PaymentServiceException
    {

        public InsufficientFundsException() : base("Insufficient Funds Exception")
        {

        }
    }
}
