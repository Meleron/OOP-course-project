using System;
using System.Collections.Generic;
using System.Text;

namespace OOPWinFroms.Cars
{
    static class AutoParkService
    {
        public static List<CarClass> AutoPark { get; } = new List<CarClass>();

        public static CarClass SearchCarById(int carId)
        {
            foreach (var i in AutoPark)
                if (i.CarId == carId)
                    return i;
            return null;
        }

        public static void AddNewCar(CarClass newCar)
        {
            if (newCar != null)
                AutoPark.Add(newCar);
            else
                throw new ArgumentNullException("newCar can't bew null!");
        }

        public static void RemoveCar(CarClass carToRemove)
        {
            if (carToRemove != null)
                AutoPark.Remove(carToRemove);
            else
                throw new ArgumentNullException("carToRemove can't be null!");
        }

        public static CarClass ChooseCar()
        {
            Console.Write("\nSelect car by typing it's id: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int value))
            {
                if (SearchCarById(value) == null || SearchCarById(value).CarStatus == true)
                {
                    //Console.WriteLine("Id not found!");
                    return null;
                }
                else
                    return SearchCarById(value);
            }
            else
            {
                Console.WriteLine("Wrong input!");
                return null;
            }
        }

        public static bool IsExists(int carId)
        {
            foreach (var i in AutoPark)
            {
                if (i.CarId == carId)
                    return true;
            }
            return false;
        }

        public static List<CarClass> GetAvailableCars()
        {
            List<CarClass> toReturn = new List<CarClass>();
            if (!IsListEmpty())
            {
                foreach (var i in AutoPark)
                {
                    if (!i.CarStatus)
                        toReturn.Add(i);
                }
            }
            return toReturn;
        }

        public static List<CarClass> GetAllCars()
        {
            List<CarClass> toReturn = new List<CarClass>();
            foreach (var i in AutoPark)
                toReturn.Add(i);
            return toReturn;
        }

        public static void PrintAllCars()
        {
            if (!IsListEmpty())
                foreach (var i in AutoPark)
                {
                    Console.WriteLine("\n" + i);
                }
        }

        private static bool IsListEmpty()
        {
            if (AutoPark.Count == 0)
            {
                Console.WriteLine("-List is empty-");
                return true;
            }
            return false;
        }
    }
}
