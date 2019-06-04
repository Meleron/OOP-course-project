using MySql.Data.MySqlClient;
using OOPWinFroms.Cars;
using OOPWinFroms.People;
using OOPWinFroms.Renting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPWinFroms.Database
{
    class SQLRents : IRepository<RentClass>
    {
        private static SQLRents Instance = null;

        private static MySqlConnection SQLConnection { get; set; }

        private SQLRents() { }

        public static SQLRents GetInstance()
        {
            if (Instance == null)
                Instance = new SQLRents();
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

        public void Create(RentClass item)
        {
            string query = string.Format($"INSERT INTO oopautopark.rents (currentClientId, currentCarId, issueDate, returnDate) VALUES({item.CurrentClient.ClientId}, " +
                $"'{item.CurrentCar.CarId}', '{item.IssueDate.ToString("yyyy-MM-dd HH:mm:ss")}', '{item.ReturnDate.ToString("yyyy-MM-dd HH:mm:ss")}')");
            ExecuteQuery(query);
        }

        public IEnumerable<RentClass> GetList()
        {
            string query = "SELECT * FROM rents";
            MySqlDataReader reader = GetReader(query);
            while (reader.Read())
            {
                yield return new RentClass(int.Parse(reader[0].ToString()), ClientService.SearchClientById(int.Parse(reader[1].ToString())), AutoParkService.SearchCarById(int.Parse(reader[2].ToString())), DateTime.Parse(reader[3].ToString()), DateTime.Parse(reader[4].ToString()));
            }
            reader.Close();
        }

        public RentClass Search(string rentId)
        {
            string query = "SELECT * FROM rents WHERE rentId='" + rentId + "'";
            RentClass rent = null;
            MySqlDataReader reader = GetReader(query);
            try
            {
                reader.Read();
                rent = new RentClass(int.Parse(reader[0].ToString()), ClientService.SearchClientById(int.Parse(reader[1].ToString())), AutoParkService.SearchCarById(int.Parse(reader[2].ToString())), DateTime.Parse(reader[3].ToString()), DateTime.Parse(reader[4].ToString()));
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            finally { reader.Close(); }
            return rent;
            throw new NotImplementedException();
        }

        public void Remove(string rentId)
        {
            string query = $"DELETE FROM oopautopark.rents WHERE (rentId = '{rentId}')";
            try { ExecuteQuery(query); }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void Update(RentClass item)
        {
            throw new NotImplementedException();
        }
    }
}
