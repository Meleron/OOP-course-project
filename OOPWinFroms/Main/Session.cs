using OOPWinFroms.Cars;
using OOPWinFroms.Database;
using System;
using System.Collections.Generic;

namespace OOPWinFroms
{
    class Session
    {

        /*static void Main(string[] args)
        {
            InitializeCars();
            //ClientClass client = ClientService.AddNewClient(new ClientClass(487, 0, "Danik", "+1234567"));
            ClientClass client = Registration.RegisterNewClient();
            MenuService.LaunchMenu(client);
        }*/

        public static void InitializeCars()
        {
            /*   List<string> colors = new List<string> { "Red", "Green", "Blue", "Cyan", "Yellow", "Black", "Silver" };
               List<Types> types = new List<Types> { Types.Hatchback, Types.Pickup, Types.Sedan, Types.Universal };
               Random rnd = new Random();
               for(int i = 0; i< 10 ; i++)
               {
                   try
                   {
                       AutoParkService.AddNewCar(new CarClass(new BodyworkClass(colors[rnd.Next(7)], types[rnd.Next(4)], (float)Math.Round(rnd.NextDouble(), 1)), new EngineClass((float)Math.Round(rnd.NextDouble(), 1), rnd.Next(100, 300)), rnd.Next(10000), i));
                   }
                   catch (Exception)
                   {
                       i--;
                   }
               }*/
            foreach(var i in SQLCars.GetInstance().GetList())
            {
                AutoParkService.AutoPark.Add(i);
            }
        }
    }
}
