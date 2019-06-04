using OOPWinFroms.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOPWinFroms.Main
{
    static class Registration
    {
        public static ClientClass RegisterNewClient()
        {
            ClientClass toReturn = null;
            bool isDefault = false;
            int clientId, status = 0;
            string firstName, secondName, patronymic, address, phoneNumber;
            Console.WriteLine("Hello! To continue working you need to sign up first:");
            while (true)
            {
                firstName = InputWithRangeCheck("first name (required)", 3, 20);
                if (firstName == "super")
                {
                    status = 1;
                    Console.Clear();
                    Console.WriteLine("Status set to admin");
                    continue;
                }
                if (firstName == "def")
                {
                    isDefault = true;
                    Console.Clear();
                    Console.WriteLine("Now you need to enter your first name only");
                    continue;
                }
                clientId = GetHashCode(firstName);
                if (ClientClass.ClientIdAll.Contains(clientId))
                {
                    Console.Clear();
                    Console.WriteLine("This name is unavailable");
                    continue;
                }
                break;
            }
            if (!isDefault)
            {
                secondName = InputWithRangeCheck("second name (can be empty)", 0, 20);
                patronymic = InputWithRangeCheck("patronymic (can be empty)", 0, 20);
                address = InputWithRangeCheck("address (can be empty)", 0, 50);
                phoneNumber = InputWithRangeCheck("phone number (required)", 3, 20);
                toReturn =  new ClientClass(clientId, status, firstName, secondName, patronymic, address, phoneNumber);
            }
            else
                toReturn = new ClientClass(clientId, status, firstName, "", "", "", "+1234567");
            Console.Clear();
            Console.WriteLine("Now you are the following user:\n");
            Console.WriteLine(toReturn);
            Console.WriteLine("\nPress any key to coninue...");
            Console.ReadKey();
            Console.Clear();
            return toReturn;
        }

        private static string InputWithRangeCheck(string subject, int a, int b)
        {
            string input;
            while (true)
            {
                Console.Write($"\nEnter your {subject}: ");
                input = Console.ReadLine();
                Console.Clear();
                if (input.Length < a || input.Length > b)
                {
                    Console.WriteLine($"String's length should be in range [{a} .. {b}]");
                    continue;
                }
                Console.WriteLine();
                break;
            }
            return input;
        }

        public static int GetHashCode(string input)
        {
            int toReturn = 0;
            for (int i = 0; i < input.Length; i++)
            {
                toReturn += input[i];
            }
            return toReturn;
        }
    }
}
