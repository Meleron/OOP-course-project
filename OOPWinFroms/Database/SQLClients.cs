using OOPWinFroms.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace OOPWinFroms.Database
{
    class SQLClients : IRepository<ClientClass>
    {

        private static SQLClients Instance = null;

        private static MySqlConnection SQLConnection { get; set; }

        private SQLClients() { }

        public static SQLClients GetInstance()
        {
            if (Instance == null)
                Instance = new SQLClients();
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

        private MySqlDataReader GetReader(string query)
        {
            return new MySqlCommand(query, GetConnection()).ExecuteReader();
        }

        private void ExecuteQuery(string query)
        {
            new MySqlCommand(query, GetConnection()).ExecuteNonQuery();
        }

        public IEnumerable<ClientClass> GetList()
        {
            string query = "SELECT * FROM clients";
            MySqlDataReader reader = GetReader(query);
            while (reader.Read())
            {
                yield return new ClientClass(int.Parse(reader[0].ToString()), int.Parse(reader[1].ToString()), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString());
            }
            reader.Close();
        }

        public ClientClass Search(string firstName)
        {
            string query = "SELECT * FROM clients WHERE firstName='" + firstName + "'";
            ClientClass client = null;
            MySqlDataReader reader = GetReader(query);
            try
            {
                reader.Read();
                client = new ClientClass(int.Parse(reader[0].ToString()), int.Parse(reader[1].ToString()), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString());
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            finally { reader.Close(); }
            return client;
        }

        public string GetPassword(string firstName)
        {
            string password = "";
            string query = "SELECT password FROM clients WHERE firstName='" + firstName + "'";
            try
            {
                MySqlDataReader reader = GetReader(query);
                reader.Read();
                password = reader[0].ToString();
                reader.Close();
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            return password;
        }

        public void Create(ClientClass item)
        {
            throw new NotImplementedException("'Create' from SQLClients.cs is not implemented");
        }

        public void Update(ClientClass item)
        {
            string query = string.Format($"UPDATE oopautopark.clients SET status = '{item.Status}', firstname = '{item.FirstName}', secondName = '{item.SecondName}', " +
                $"patronymic = '{item.Patronymic}', address = '{item.Address}', phoneNumber = '{item.PhoneNumber}' WHERE (clientId = {item.ClientId})");
            ExecuteQuery(query);
        }

        public void AddClient(ClientClass item, string password)
        {
            string query = string.Format($"INSERT INTO oopautopark.clients (status, firstName, secondName, patronymic, address, phoneNumber, password)" +
                $" VALUES ('{item.Status}', '{item.FirstName}', '{item.SecondName}', '{item.Patronymic}', '{item.Address}', '{item.PhoneNumber}', '{password}');");
            ExecuteQuery(query);
        }

    }
}
