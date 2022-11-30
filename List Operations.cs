using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string cmdType = cmdArgs[0];
                if (cmdType == "Add")
                {
                    int num = int.Parse(cmdArgs[1]);
                    numbers = AddNumbers(numbers, num);
                }
                else if (cmdType == "Insert")
                {
                    int num = int.Parse(cmdArgs[1]);
                    int index = int.Parse(cmdArgs[2]);
                    if (index >= numbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers = InsertNumbers(numbers, num, index);
                    }
                }
                else if (cmdType == "Remove")
                {
                    int index = int.Parse(cmdArgs[1]);
                    if (index >= numbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers = RemoveNumbers(numbers, index);
                    }
                }
                else if (cmdType == "Shift")
                {
                    string shiftType = cmdArgs[1];
                    int count = int.Parse(cmdArgs[2]);
                    numbers = ShiftingNumbers(numbers, shiftType, count);
                }
            }

            Console.WriteLine(String.Join(" ", numbers));
        }

        private static List<int> AddNumbers(List<int> numbers, int num)
        {
            numbers.Add(num);
            return numbers;
        }


        private static List<int> InsertNumbers(List<int> numbers, int num, int index)
        {
            numbers.Insert(index, num);
            return numbers;
        }


        private static List<int> RemoveNumbers(List<int> numbers, int index)
        {
            numbers.RemoveAt(index);
            return numbers;
        }

        private static List<int> ShiftingNumbers(List<int> numbers, string shiftType, int count)
        {
            if (shiftType == "left")
            {
                for (int i = 0; i < count; i++)
                {
                    int firstItem = numbers[0];
                    numbers.RemoveAt(0);
                    numbers.Insert(numbers.Count, firstItem);
                }
                return numbers;
            }
            for (int i = 0; i < count; i++)
            {
                int lastItem = numbers[numbers.Count - 1];
                numbers.RemoveAt(numbers.Count - 1);
                numbers.Insert(0, lastItem);
            }
            return numbers;
        }
    }
}
