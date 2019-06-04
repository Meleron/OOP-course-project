using OOPWinFroms.Cars;
using OOPWinFroms.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOPWinFroms.Renting
{
    class RentClass
    {
        public int RentId { get; set; }
        public ClientClass CurrentClient { get; set; }
        public CarClass CurrentCar { get; set; }
        public DateTime IssueDate { get; }
        public DateTime ReturnDate { get; }

        public RentClass(int rentId, ClientClass currentClient, CarClass currentCar, DateTime issueDate, DateTime returnDate)
        {
            if(rentId == -1)
            {
                RentService.LastId++;
                RentId = RentService.LastId;
            }
            else
            {
                RentId = rentId;
                RentService.LastId = RentId;
            }
            CurrentClient = currentClient ?? throw new ArgumentNullException("currentClient can't be null!");
            CurrentCar = currentCar ?? throw new ArgumentNullException("currentCar can't be null");
            if (issueDate != null)
                IssueDate = issueDate;
            else
                throw new ArgumentNullException("issueDate can't be null");
            if (returnDate != null)
                ReturnDate = returnDate;
            else
                throw new ArgumentNullException("returnDate can't be null");
            CurrentCar.CarStatus = true;
        }

        public RentClass(ClientClass currentClient, CarClass currentCar, DateTime issueDate, DateTime returnDate) : this(-1, currentClient, currentCar, issueDate, returnDate) { }
        public RentClass(ClientClass currentClient, CarClass currentCar, DateTime returnDate):this(currentClient, currentCar, DateTime.Now, returnDate) { }
        public RentClass(ClientClass currentClient, CarClass currentCar):this(currentClient, currentCar, DateTime.Now, DateTime.Now.AddDays(15)) { }

        /*public void CloseRent()
        {
            CurrentCar.CarStatus = false;
            CurrentClient = null;
            CurrentCar = null;
            if (ReturnDate < DateTime.Now)
                IsExpired = true;
        }*/

        public override string ToString()
        {
            //return string.Format("Client's name: {0}\nCar's id: {1}\nIssue date: {2}\nReturn date: {3}", CurrentClient.FirstName, CurrentCar.CarId, IssueDate, ReturnDate);
            return string.Format($"Client's name: {CurrentClient.FirstName} Car's id: {CurrentCar.CarId} Return date: {ReturnDate}");
        }

    }
}
