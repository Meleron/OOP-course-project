using MySql.Data.MySqlClient;
using OOPWinFroms.Cars;
using OOPWinFroms.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPWinFroms.Database
{
    class SQLCars : IRepository<CarClass>
    {

        private static SQLCars Instance = null;

        private static MySqlConnection SQLConnection { get; set; }

        private SQLCars(){}

        public static SQLCars GetInstance()
        {
            if (Instance == null)
                Instance = new SQLCars();
            return Instance;
        }

        private static MySqlConnection GetConnection()
        {
            if(SQLConnection == null)
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

        public void Create(CarClass item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarClass> GetList()
        {
            string query = "SELECT * FROM cars";
            MySqlDataReader reader = GetReader(query);
            while (reader.Read())
            {
                int carId = int.Parse(reader[0].ToString());
                BodyworkClass bodywork = SQLBodyworks.GetInstance().Search(reader[1].ToString());
                EngineClass engine = SQLEngines.GetInstance().Search(reader[2].ToString());
                ClientClass client = ClientService.SearchClientById(int.Parse(reader[3].ToString()));
                int kilometrage = int.Parse(reader[4].ToString());
                int cost = int.Parse(reader[5].ToString());
                int carStatus = int.Parse(reader[6].ToString());
                yield return new CarClass(carId, bodywork, engine, client, kilometrage, cost, carStatus);
            }
            reader.Close();
        }

        public CarClass Search(string carId)
        {
            string query = "SELECT * FROM cars WHERE carId='" + carId + "'";
            CarClass car = null;
            MySqlDataReader reader = GetReader(query);
            try
            {
                reader.Read();
                BodyworkClass bodywork = SQLBodyworks.GetInstance().Search(reader[1].ToString());
                EngineClass engine = SQLEngines.GetInstance().Search(reader[2].ToString());
                ClientClass client = ClientService.SearchClientById(int.Parse(reader[3].ToString()));
                int kilometrage = int.Parse(reader[4].ToString());
                int cost = int.Parse(reader[5].ToString());
                int carStatus = int.Parse(reader[6].ToString());
                car = new CarClass(int.Parse(carId), bodywork, engine, client, kilometrage, cost, carStatus);
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            finally { reader.Close(); }
            return car;
        }

        public void Update(CarClass item)
        {
            string query = string.Format($"UPDATE oopautopark.cars SET bodyworkSN = '{item.Bodywork.SerialNumber}', engineSN = '{item.Engine.SerialNumber}', " +
                $"clientId = '{(item.CurrentClient == null ? 0 : item.CurrentClient.ClientId)}', kilometrage = '{item.Kilometrage}', cost = '{item.Cost}', carStatus = '{(item.CarStatus ? 1 : 0)}' " +
                $"WHERE(carId = '{item.CarId}')");
            ExecuteQuery(query);
        }
    }
}
