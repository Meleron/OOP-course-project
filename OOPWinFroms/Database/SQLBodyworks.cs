using MySql.Data.MySqlClient;
using OOPWinFroms.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPWinFroms.Database
{
    class SQLBodyworks : IRepository<BodyworkClass>
    {

        private static SQLBodyworks Instance = null;

        private static MySqlConnection SQLConnection { get; set; }

        private SQLBodyworks() { }

        public static SQLBodyworks GetInstance()
        {
            if (Instance == null)
                Instance = new SQLBodyworks();
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

        public void Create(BodyworkClass item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BodyworkClass> GetList()
        {
            throw new NotImplementedException();
        }

        public BodyworkClass Search(string serialNumber)
        {
            string query = "SELECT * FROM bodyworks WHERE serialNumber='" + serialNumber + "'";
            BodyworkClass bodywork = null;
            MySqlDataReader reader = GetReader(query);
            try
            {
                reader.Read();
                bodywork = new BodyworkClass(int.Parse(reader[0].ToString()), reader[1].ToString(), (Types)int.Parse(reader[2].ToString()), float.Parse(reader[3].ToString()));
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            finally { reader.Close(); }
            return bodywork;
            throw new NotImplementedException();
        }

        public void Update(BodyworkClass item)
        {
            throw new NotImplementedException();
        }
    }
}
