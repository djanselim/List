using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            List<string> listOfGuests = new List<string>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                List<string> command = Console.ReadLine()
                    .Split()
                    .ToList();

                if(command.Count == 3)
                {
                    string name = command[0];
                    if (listOfGuests.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                        continue;
                    }
                    listOfGuests = NameChecker(listOfGuests, name);    
                }
                else if(command.Count == 4)
                {
                    string name = command[0];
                    if (listOfGuests.Contains(name))
                    {
                        listOfGuests = NameChecker(listOfGuests, name);
                        continue;
                    }
                    Console.WriteLine($"{name} is not in the list!");
                }
            }

            PrintNames(listOfGuests);
        }

        private static void PrintNames(List<string> listOfGuests)
        {
            for (int i = 0; i < listOfGuests.Count; i++)
            {
                Console.WriteLine(listOfGuests[i]);
            }
        }

        private static List<string> NameChecker(List<string> listOfGuests, string name)
        {
            if(listOfGuests.Contains(name))
            {
                listOfGuests.Remove(name);
                return listOfGuests;
            }
            listOfGuests.Add(name);
            return listOfGuests;
        }
    }
}
