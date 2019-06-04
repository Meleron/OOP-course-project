using MySql.Data.MySqlClient;
using OOPWinFroms.Finances;
using OOPWinFroms.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPWinFroms.Database
{
    class SQLTransactions : IRepository<TransactionClass>
    {
        private static SQLTransactions Instance = null;

        private static MySqlConnection SQLConnection { get; set; }

        private SQLTransactions() { }

        public static SQLTransactions GetInstance()
        {
            if (Instance == null)
                Instance = new SQLTransactions();
            return Instance;
        }

        private static MySqlConnection GetConnection()
        {
            if (SQLConnection == null)
            {
                string SQLConnectionProperties = "server=localhost;user=root;database=oopautopark;password=160419";
                SQLConnection = new MySqlConnection(SQLConnectionProperties);
                SQLConnection.Open();
            }
            return SQLConnection;
        }

        public MySqlDataReader GetReader(string query)
        {
            return new MySqlCommand(query, GetConnection()).ExecuteReader();
        }

        private void ExecuteQuery(string query)
        {
            new MySqlCommand(query, GetConnection()).ExecuteNonQuery();
        }

        public void Create(TransactionClass item)
        {
            string query = string.Format($"INSERT INTO oopautopark.transactions (amount, time, clientId) VALUES ({item.Amount}, '{item.Time.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                $"'{item.Client.ClientId}');");
            ExecuteQuery(query);
        }

        public IEnumerable<TransactionClass> GetList()
        {
            string query = "SELECT * FROM transactions";
            MySqlDataReader reader = GetReader(query);
            while (reader.Read())
            {
                yield return new TransactionClass(int.Parse(reader[1].ToString()), ClientService.SearchClientById(int.Parse(reader[3].ToString())), DateTime.Parse(reader[2].ToString()));
            }
            reader.Close();
        }

        public TransactionClass Search(string transactionId)
        {
            string query = "SELECT * FROM transactions WHERE transactionId='" + transactionId + "'";
            TransactionClass transaction = null;
            MySqlDataReader reader = GetReader(query);
            try
            {
                reader.Read();
                transaction = new TransactionClass(int.Parse(reader[1].ToString()), ClientService.SearchClientById(int.Parse(reader[3].ToString())), DateTime.Parse(reader[2].ToString()));
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            finally { reader.Close(); }
            return transaction;
            throw new NotImplementedException();
        }

        public void Remove(string transactionId)
        {
            string query = $"DELETE FROM oopautopark.transactions WHERE (transactionId = '{transactionId}')";
            try { ExecuteQuery(query); }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void Update(TransactionClass item)
        {
            throw new NotImplementedException();
        }
    }
}
