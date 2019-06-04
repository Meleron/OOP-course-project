using OOPWinFroms.Cars;
using OOPWinFroms.Database;
using OOPWinFroms.Finances;
using OOPWinFroms.Forms;
using OOPWinFroms.People;
using OOPWinFroms.Renting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPWinFroms
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //ClientClass client = ClientService.AddNewClient(new ClientClass(487, 0, "Danik", "+1234567"));
            Session.InitializeCars();
            ClientService.InitializeClients();
            RentService.InitializeRents();
            TransactionService.InitializeTransactions();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            List<CarClass> cars = AutoParkService.AutoPark;
            /*foreach (var i in cars)
            {
                Console.WriteLine($"bodyworkSN = {i.Bodywork.SerialNumber}, engineSN = {i.Engine.SerialNumber}" +
                    $", kilometrage = {i.Kilometrage}, cost = {i.Cost}" +
                    $", carStatus = {i.CarStatus}");
            }*/
            Console.WriteLine(SQLEngines.GetInstance().Search("24887"));
            Console.WriteLine(SQLBodyworks.GetInstance().Search("11414"));
            Console.WriteLine(SQLRents.GetInstance().Search("1"));
            //Console.WriteLine(SQLCars.GetInstance().Search("5"));
            //Application.Run(new WorkForm(client));
            //Console.WriteLine(SQLClients.GetInstance().Search("Danik"));

            Application.Run(new LoginForm());
        }
    }
}
