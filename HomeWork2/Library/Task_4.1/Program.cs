using System;
using Library;
namespace Task_4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                throw new LimitExceededException();
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine(ex.Message);
                
            }
            catch (LimitExceededException ex)
            {
                Console.WriteLine(ex.Message);

            }
            catch (PaymentServiceException ex)
            {
                Console.WriteLine(ex.Message);
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
            finally
            {
                Console.WriteLine("Handled exceptions");
                Console.WriteLine(" InsufficientFundsException ");
                Console.WriteLine(" LimitExceededException ");
                Console.WriteLine(" PaymentServiceException ");
                Console.WriteLine(" Exception ");
            }

           
           
        }
    }
    class PaymentServiceException : Exception
    {
        private string _innerData;
        public PaymentServiceException(string innerData) : this("Payment Service Exception",innerData)
        {
            _innerData = innerData;
        }
        public PaymentServiceException() : base("Payment Service Exception")
        {
            
        }
        public PaymentServiceException(string message, string innerData):
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
    class InsufficientFundsException: PaymentServiceException
    {
        
        public InsufficientFundsException() : base("Insufficient Funds Exception")
        {
            
        }
    }



}