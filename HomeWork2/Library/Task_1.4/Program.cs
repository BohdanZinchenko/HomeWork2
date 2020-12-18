using System;
using Library;
namespace Task_1._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Account[] accounts = new Account[10000];
            for (int i = 0; i < 10000; i++)
            {
                accounts[i] = new Account("UAH");
            }

            GetSortedAccountsByQuickSort(accounts, 0, accounts.Length - 1);
            Console.WriteLine("First Ten Accounts are : ");
            for (var i = 0; i <= 10; i++)
            {
                Console.WriteLine(accounts[i]._id);
            }
            Console.WriteLine("Last Ten Accounts are : ");
            for (var i = accounts.Length - 10; i < accounts.Length ; i++)
            {
                Console.WriteLine(accounts[i]._id);
            }
            
        }
        static void GetSortedAccountsByQuickSort(Account[] accounts, int start, int end)
        {
            if (start < end)
            {
                int pivot = partition(accounts, start, end);

                if (pivot > 1)
                {
                    GetSortedAccountsByQuickSort(accounts, start, pivot - 1);
                }
                if (pivot + 1 < end)
                {
                    GetSortedAccountsByQuickSort(accounts, pivot + 1, end);
                }
            }

        }
        static int partition(Account[] accounts, int start, int end)
        {
            var pivot = accounts[start];
            while (true)
            {

                while (accounts[start]._id < pivot._id)
                {
                    start++;
                }

                while (accounts[end]._id > pivot._id)
                {
                    end--;
                }

                if (start < end)
                {
                    if (accounts[start]._id == accounts[end]._id) return end;

                    var temp = accounts[start];
                    accounts[start] = accounts[end];
                    accounts[end] = temp;


                }
                else
                {
                    return end;
                }
            }
        }

    }
}
