using OOPWinFroms.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOPWinFroms.Finances
{
    class TransactionClass
    {
        public int Amount { get; }
        public DateTime Time { get; }
        public ClientClass Client { get; }

        public TransactionClass(int amount, ClientClass user, DateTime time)
        {
            Amount = amount;
            Time = time;
            Client = user ?? throw new ArgumentNullException("User can't be null");
        }

        public TransactionClass(int amount, ClientClass user) : this(amount, user, DateTime.Now) { }

        public override string ToString()
        {
            return string.Format($"Amount: {Amount}, Time: {Time}, Client's id: {Client.ClientId}");
        }
    }
}
