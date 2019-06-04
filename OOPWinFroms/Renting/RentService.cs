using OOPWinFroms.Database;
using OOPWinFroms.Finances;
using OOPWinFroms.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOPWinFroms.Renting
{
    static class RentService
    {
        public static List<RentClass> Rent { get; } = new List<RentClass>();
        public static int LastId { get; set; }

        static RentService()
        {
            LastId = 0;
        }

        public static void AddNewRent(RentClass rentToAdd)
        {
            if (rentToAdd != null)
            {
                rentToAdd.CurrentCar.CarStatus = true;
                rentToAdd.CurrentCar.CurrentClient = rentToAdd.CurrentClient;
                SQLCars.GetInstance().Update(rentToAdd.CurrentCar);
                SQLRents.GetInstance().Create(rentToAdd);
                Rent.Add(rentToAdd);
                TransactionService.NewTransaction(rentToAdd.CurrentCar.Cost, rentToAdd.CurrentClient);
            }
            else
                throw new ArgumentNullException("rentToAdd can't be null!");
        }

        public static void InitializeRents()
        {
            foreach(var i in SQLRents.GetInstance().GetList())
            {
                Rent.Add(i);
            }
        }

        public static List<RentClass> GetRentsOfClient(ClientClass client)
        {
            //Console.WriteLine(Rent.Count);
            List<RentClass> temp = new List<RentClass>();
            foreach (var i in Rent)
            {
                if (i.CurrentClient.Equals(client))
                    temp.Add(i);
            }
            return temp;
        }

        public static void RemoveRent(RentClass rent)
        {
            rent.CurrentCar.CarStatus = false;
            rent.CurrentCar.CurrentClient = null;
            SQLCars.GetInstance().Update(rent.CurrentCar);
            SQLRents.GetInstance().Remove(rent.RentId.ToString());
            Rent.Remove(rent);
        }

        public static RentClass GetRentByCarId(int carId)
        {
            foreach (var i in Rent)
            {
                if (i.CurrentCar.CarId == carId)
                    return i;
            }
            return null;
        }

        public static void PrintAllRents()
        {
            if (Rent.Count == 0)
            {
                Console.WriteLine("-List is empty-");
                return;
            }
            foreach (var i in Rent)
            {
                Console.WriteLine("\n" + i);
            }
        }
    }
}
