using MySql.Data.MySqlClient;
using OOPWinFroms.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPWinFroms.Database
{
    class SQLEngines : IRepository<EngineClass>
    {

        private static SQLEngines Instance = null;

        private static MySqlConnection SQLConnection { get; set; }

        private SQLEngines() { }

        public static SQLEngines GetInstance()
        {
            if (Instance == null)
                Instance = new SQLEngines();
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

        public void Create(EngineClass item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EngineClass> GetList()
        {
            throw new NotImplementedException();
        }

        public EngineClass Search(string serialNumber)
        {
            string query = "SELECT * FROM engines WHERE serialNumber='" + serialNumber + "'";
            EngineClass engine = null;
            MySqlDataReader reader = GetReader(query);
            try
            {
                reader.Read();
                engine = new EngineClass(int.Parse(reader[0].ToString()), float.Parse(reader[1].ToString()), float.Parse(reader[2].ToString()));
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            finally { reader.Close(); }
            return engine;
        }

        public void Update(EngineClass item)
        {
            throw new NotImplementedException();
        }
    }
}
