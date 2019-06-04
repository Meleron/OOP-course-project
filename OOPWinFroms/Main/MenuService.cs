using OOPWinFroms.Cars;
using OOPWinFroms.Finances;
using OOPWinFroms.People;
using OOPWinFroms.Renting;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOPWinFroms.Main
{
    //This class is not used
    static class MenuService
    {
        public static void LaunchMenu(ClientClass client)
        {
            bool stopflag = false;
            Console.WriteLine($"Welcome, {client.FirstName}!");
            while (true)
            {
                if(client.Status == 0)
                    Console.WriteLine("\nChoose option:\n1 - exit\n2 - rent a car\n3 - return rented car");
                else
                    Console.WriteLine("\nChoose option:\n1 - exit\n2 - rent a car\n3 - return rented car\n4 - print all cars\n5 - print all rents\n6 - print transactions history");
                ConsoleKeyInfo UserInput = Console.ReadKey();
                Console.Clear();
                Console.WriteLine();
                if (char.IsDigit(UserInput.KeyChar))
                {
                    switch (int.Parse(UserInput.KeyChar.ToString()))
                    {
                        case 1:
                            {
                                stopflag = true;
                                break;
                                
                            }
                        case 2:
                            {
                                RentCar(client);
                                break;
                                
                            }
                        case 3:
                            {
                                ReturnCar(client);
                                break;
                            }
                        case 4:
                            {
                                if (client.Status != 1)
                                    goto default;
                                Console.WriteLine("All cars in autopark:\n");
                                AutoParkService.PrintAllCars();
                                EndCase();
                                break;
                            }
                        case 5:
                            {
                                if (client.Status != 1)
                                    goto default;
                                Console.WriteLine("All current rents:\n");
                                RentService.PrintAllRents();
                                EndCase();
                                break;
                            }
                        case 6:
                            {
                                if (client.Status != 1)
                                    goto default;
                                Console.WriteLine($"Current income: {TransactionService.TotalAmount}\n");
                                Console.WriteLine("Transactions history:\n");
                                //TransactionService.PrintTransactionsHistory();
                                EndCase();
                                break;
                            }
                        default:
                            {
                                Console.Clear();
                                Console.WriteLine("Wrong input!");
                                break;
                            }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wrong input!");
                }
                if (stopflag)
                    break;
            }
            Console.Clear();
            Console.WriteLine("All rents:\n");
            RentService.PrintAllRents();
            Console.WriteLine("\n\nAll transactions:\n");
            //TransactionService.PrintAllTransactions();
            Console.ReadKey();
            return;
        }

        public static bool UserInputInt(out int result)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out result))
                return true;
            return false;
        }

        private static void RentCar(ClientClass client)
        {
            Console.Clear();
            //AutoParkService.PrintAvailableCars();
            CarClass chosenCar = AutoParkService.ChooseCar();
            Console.Clear();
            if (chosenCar != null)
            {
                RentService.AddNewRent(new RentClass(client, chosenCar));
                Console.WriteLine("Car with id '{0}' was successfully rented.", chosenCar.CarId);
            }
            else
            {
                Console.WriteLine("Id not found!");
            }
        }

        private static void EndCase()
        {
            Console.Write("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        private static void ReturnCar(ClientClass client)
        {
            Console.Clear();
            List<RentClass> rentsOfClient = RentService.GetRentsOfClient(client);
            if (rentsOfClient.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("You have no rents");
                return;
            }

            foreach (var i in RentService.GetRentsOfClient(client))
            {
                Console.WriteLine("\nCar id: " + i.CurrentCar.CarId);
                Console.WriteLine("Car type: " + i.CurrentCar.Bodywork.Type);
                Console.WriteLine("Car color: " + i.CurrentCar.Bodywork.Color);
            }
            Console.Write("\nChoose car's id you want to return: ");
            if (UserInputInt(out int chosenCarId))
            {
                Console.Clear();
                CarClass tempCar = AutoParkService.SearchCarById(chosenCarId);
                if (tempCar != null && tempCar.CurrentClient == client)
                {
                    RentService.RemoveRent(RentService.GetRentByCarId(chosenCarId));
                    Console.WriteLine($"Car with id '{chosenCarId}' was successfully returned");
                    return;
                }
            }
            Console.Clear();
            Console.WriteLine("Id not found!");
        }
    }
}
