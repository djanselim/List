using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<string> command = Console.ReadLine().Split().ToList();

            while (command[0] != "end")
            {
                string cmdType = command[0];

                if(cmdType == "Delete")
                {
                    int number = int.Parse(command[1]);
                    numbers.RemoveAll(x => x == number);
                }
                else if(cmdType == "Insert")
                {
                    int number = int.Parse(command[1]);
                    int index = int.Parse(command[2]);
                    numbers.Insert(index, number);
                }

                command = Console.ReadLine().Split().ToList();
            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
