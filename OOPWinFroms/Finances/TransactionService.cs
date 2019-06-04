using OOPWinFroms.Database;
using OOPWinFroms.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOPWinFroms.Finances
{
    static class TransactionService
    {
        public static List<TransactionClass> Transactions { get; } = new List<TransactionClass>();
        public static int TotalAmount { get; set; } = 0;

        public static void NewTransaction(int amount, ClientClass client)
        {
            TransactionClass currentTransaction = new TransactionClass(amount, client);
            Transactions.Add(currentTransaction);
            SQLTransactions.GetInstance().Create(currentTransaction);
            TotalAmount += amount;
        }

        public static void InitializeTransactions()
        {
            foreach(var i in SQLTransactions.GetInstance().GetList())
            {
                Transactions.Add(i);
                TotalAmount += i.Amount;
            }
        }

        public static List<TransactionClass> SearchByUser(ClientClass client)
        {
            List<TransactionClass> temp = new List<TransactionClass>();
            foreach (var i in Transactions)
                if (i.Client.Equals(client))
                    temp.Add(i);
            return temp;
        }
    }
}
