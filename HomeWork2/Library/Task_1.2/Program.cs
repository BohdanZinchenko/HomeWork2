using System;
using Library;
namespace Task_1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            SortAc sort = new SortAc();
            Account[] accounts = new Account[10000];
            for (int i = 0; i < 10000; i++)
            {
                accounts[i] = new Account("UAH");
            }
            accounts = sort.GetSortedAccounts(accounts);
            Console.WriteLine("First Ten Accounts are : ");
            for (var i = 0; i <= 10; i++)
            {
                Console.WriteLine(accounts[i]._id);
            }
            Console.WriteLine("Last Ten Accounts are : ");
            for (var i = accounts.Length - 10; i < accounts.Length; i++)
            {
                Console.WriteLine(accounts[i]._id);
            }
            
        }

    }
    public class SortAc
    {
        static private void Swap(ref Account e1, ref Account e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }
        public Account[] GetSortedAccounts(Account[] accounts)
        {

            var len = accounts.Length;
            for (var i = 1; i < len; i++)
            {
                for (var j = 0; j < len - 1; j++)
                {
                    if (accounts[j]._id > accounts[j + 1]._id)
                    {
                        Swap(ref accounts[j], ref accounts[j + 1]);
                    }
                }
            }
            return accounts;
        }
        public void GetAccount(int id, Account[] accounts)
        {
            int i = 0;
            int left = 0;
            int right = accounts.Length - 1;
            while (left <= right)
            {
                i++;
                var middle = (left + right) / 2;
                if (id == accounts[middle]._id)
                {
                    Console.WriteLine($"{id} was found at index {middle} by {i} tries ");
                    break;
                }
                else if (id < accounts[middle]._id)
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }
            Console.WriteLine($"There is no account {id} in the list");
            Account ac = new Account();

        }
    }
}
