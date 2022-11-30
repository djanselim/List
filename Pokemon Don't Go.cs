using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Pokemon_Don_t_Go
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();
            int sum = 0;
            int removedInteger = 0;
            while(sequence.Count > 0)
            {
                //5 10  3 5
                int command = int.Parse(Console.ReadLine());
               
                if (command < 0)
                {
                    int lastIndex = sequence[sequence.Count - 1];
                    removedInteger = sequence[0];
                    sequence.RemoveAt(0);
                    sequence.Insert(0, lastIndex);
                    sum += removedInteger;
                }
                else if(command >= sequence.Count)
                {
                    int firstIndex = sequence[0];
                    removedInteger = sequence[sequence.Count - 1];
                    sequence.RemoveAt(sequence.Count - 1);
                    sequence.Insert(sequence.Count, firstIndex);
                    sum += removedInteger;
                }
                else
                {
                    removedInteger = sequence[command];
                    sequence.RemoveAt(command);
                    sum += removedInteger;
                }

                for (int i = 0; i < sequence.Count; i++)
                {
                    if (sequence[i] <= removedInteger)
                    {
                        sequence[i] += removedInteger;
                    }
                    else if (sequence[i] > removedInteger)
                    {
                        sequence[i] -= removedInteger;
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
