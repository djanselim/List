using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int maxCapacity = int.Parse(Console.ReadLine());

            List<string> input = Console.ReadLine()
                .Split()
                .ToList();

            while (input[0] != "end")
            {
                if (input[0] != "Add")
                {
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        int incomingPeople = int.Parse(input[0]);
                        int peopleInOneWagon = incomingPeople + wagons[i];
                        if (peopleInOneWagon <= maxCapacity)
                        {
                            wagons[i] = peopleInOneWagon;
                            break;
                        }
                    }
                }
                else
                {
                    int newWagon = int.Parse(input[1]);
                    wagons.Add(newWagon);
                }
                input = Console.ReadLine()
                .Split()
                .ToList();
            }

            Console.WriteLine(String.Join(" ", wagons));

        }
    }
}
