using System;
using System.Collections.Generic;
using System.Text;

namespace OOPWinFroms.People
{
    public class ClientClass
    {
        public static List<int> ClientIdAll { get; } = new List<int>();
        public int ClientId { get; }
        public int Status { get; set; }
        public string FirstName { get; }
        public string SecondName { get; }
        public string Patronymic { get; }
        public string Address { get; }
        public string PhoneNumber { get; }

        public ClientClass(int clientId, int status, string firstName, string secondName, string patronymic, string address, string phoneNumber)
        {
            try
            {
                if (clientId < 0)
                    throw new Exception("Client's id can't be less than zero!");
                //if (ClientIdAll.Contains(clientId))
                //    throw new Exception("clientId is not unique!");
                ClientId = clientId;
                ClientIdAll.Add(clientId);
                if (status < 0 || status > 2)
                    throw new Exception("Incorrect status! (status should be in range [0 .. 2])");
                Status = status;
                if (firstName.Length < 3 || firstName.Length > 20)
                    throw new Exception("Incorrect string length! (firstname's length should be in range [3 .. 20])");
                FirstName = firstName;
                if (secondName.Length > 20)
                    throw new Exception("Incorrect string length! (secondName's length should 20 or less)");
                SecondName = secondName;
                if (patronymic.Length > 20)
                    throw new Exception("Incorrect string length! (patronymic's length should 20 or less)");
                Patronymic = patronymic;
                if (address.Length > 50)
                    throw new Exception("Incorrect string length! (address's length should 50 or less)");
                Address = address;
                if (phoneNumber.Length < 3 || phoneNumber.Length > 20)
                    throw new Exception("Incorrect string length! (phoneNumber's length should be in range [3 .. 20])");
                PhoneNumber = phoneNumber;
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException("Parameters can't be empty!", ex);
            }
        }

        public ClientClass(int clientId, int status, string firstName, string phoneNumber) : this(clientId, status, firstName, "", "", "", phoneNumber) { }

        public ClientClass(string firstName, string phoneNumber) :this(ClientService.GetIdByFirstName(firstName), 0, firstName, phoneNumber) { }

        public ClientClass(int status, string firstName, string secondName, string patronymic, string address, string phoneNumber) : this(0, status, firstName, secondName, patronymic, address, phoneNumber) { }

        public override string ToString()
        {
            //return string.Format("\n[\nClientId = \"{0}\", \nStatus = \"{1}\", \nFirstName = \"{2}\", \nSecondName = \"{3}\", \nPatronymic = \"{4}\", \nAddress = \"{5}\", \nPhoneNumber = \"{6}\"\n]\n"
            //    , ClientId, Status, FirstName, SecondName, Patronymic, Address, PhoneNumber);
            //return string.Format($"ClientId = {ClientId}\nStatus = {(Status == 0 ? "User" : Status == 1 ? "Admin" : "Undefined")}\nFirstName = {FirstName}\nSecondName = {SecondName}" +
            //    $"\nPatronymic = {Patronymic}\nAddress = {Address}\nPhoneNumber = {PhoneNumber}");
            Console.WriteLine($"First name: {FirstName},\nStatus: {Status}");
            return string.Format($"ClientId = {ClientId}, Status = {(Status == 0 ? "User" : Status == 1 ? "Admin" : Status == 2 ? "Banned" : "Undefined")}, FirstName = {FirstName}");
        }
        public override bool Equals(object obj)
        {
            if (obj is ClientClass toCompare)
            {
                if (ClientId != toCompare.ClientId || Status != toCompare.Status || FirstName != toCompare.FirstName || SecondName != toCompare.SecondName || Patronymic != toCompare.Patronymic
                    || Address != toCompare.Address || PhoneNumber != toCompare.PhoneNumber)
                    return false;
                return true;
            }
            return false;
        }
    }
}
