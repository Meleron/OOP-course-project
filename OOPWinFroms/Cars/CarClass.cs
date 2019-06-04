using OOPWinFroms.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOPWinFroms.Cars
{
    class CarClass
    {
        public int CarId { get; }
        public BodyworkClass Bodywork { get; }
        public EngineClass Engine { get; }
        public ClientClass CurrentClient { get; set; }
        public int Kilometrage { get; }
        public int Cost { get; }
        public bool CarStatus { get; set; }
        public static List<int> CarIdAll { get; } = new List<int>();

        public CarClass(int carId, BodyworkClass bodywork, EngineClass engine, ClientClass currentClient, int kilometrage, int cost, int carStatus)
        {
            Bodywork = bodywork ?? throw new ArgumentNullException("Bodywork can't be null!");
            Engine = engine ?? throw new ArgumentNullException("Engine can't be null!");
            CurrentClient = currentClient;
            if (kilometrage < 0)
                throw new Exception("Kilometrage can't be less than zero!");
            Kilometrage = kilometrage;
            if (cost < 0)
                throw new Exception("Cost can't be less than zero!");
            Cost = cost;
            if (carId < 0)
                throw new Exception("carId can't be less than zero!");
            //if (CarIdAll.Contains(carId))
            //    throw new Exception("carId is not unique!");
            CarId = carId;
            CarIdAll.Add(carId);
            if (carStatus != 0 && carStatus != 1)
                throw new Exception("carStatus can't be represented as bool!");
            CarStatus = Convert.ToBoolean(carStatus);
        }

        public CarClass(BodyworkClass bodywork, EngineClass engine, ClientClass currentClient, int kilometrage, int cost, int carId) : this(carId, bodywork, engine, currentClient, kilometrage, cost, 0) { }
        public CarClass(BodyworkClass bodywork, EngineClass engine, int kilometrage, int cost, int carId) : this(bodywork, engine, null, kilometrage, cost, carId) { }
        public CarClass(BodyworkClass bodywork, EngineClass engine, int kilometrage, int carId) : this(bodywork, engine, null, kilometrage, ((int)(engine.MaxSpeed * 50 + engine.Quality * 10000 + bodywork.Quality * 10000)) / 2, carId) { }

        public override string ToString()
        {
            //return string.Format("\n[\nBodywork = \"{0}\", \nEngine = \"{1}\"\n, \nCurrentClient = \"{2}\", \nCost = \"{3}\", \nCarId = \"{4}\", \nCarStatus = \"{5}\"]\n", Bodywork, Engine, CurrentClient.ToString() ?? "", Cost, CarId, CarStatus);
            //return string.Format("Id:{0}\nType:{1}\nColor:{2}\nMaxSpeed:{3}\nCost:{4}\nIsRented:{5}", CarId, Bodywork.Type, Bodywork.Color, Engine.MaxSpeed, Cost, CarStatus);
            return string.Format($"Type: {Bodywork.Type}, Cost: {Cost}, MaxSpeed: {Engine.MaxSpeed}, Color: {Bodywork.Color}");
        }
    }
}
