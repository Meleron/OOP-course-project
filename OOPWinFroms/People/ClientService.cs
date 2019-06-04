using OOPWinFroms.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOPWinFroms.People
{
    static class ClientService
    {
        public static List<ClientClass> Clients { get; } = new List<ClientClass>();

        public static void InitializeClients()
        {
            foreach (ClientClass i in new List<ClientClass>(SQLClients.GetInstance().GetList()))
            {
                AddNewClient(i);
            }
        }

        public static ClientClass AddNewClient(ClientClass clientToAdd)
        {
            if (clientToAdd != null)
                Clients.Add(clientToAdd);
            else
                throw new ArgumentNullException("clientToAdd can't be null!");
            return clientToAdd;
        }

        public static ClientClass SearchClientById(int clientId)
        {
            foreach (var i in Clients)
                if (i.ClientId == clientId)
                    return i;
            return null;
        }

        public static int GetIdByFirstName(string firstName)
        {
            int hash = 0;
            for (int i = 0; i < firstName.Length; i++)
            {
                hash += firstName[i];
            }
            return hash;
        }

        public static List<ClientClass> GetAllClients()
        {
            List<ClientClass> toReturn = new List<ClientClass>();
            foreach(var i in Clients)
                toReturn.Add(i);
            return toReturn;
        }
    }
}
