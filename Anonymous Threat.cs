using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Anonymous_Threat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> data = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string command;

            while((command = Console.ReadLine()) != "3:1")
            {
                List<string> cmdArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                string cmdType = cmdArgs[0];

                if(cmdType == "merge")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);
                    if(startIndex >= data.Count)
                    {
                        startIndex = data.Count - 1;
                    }
                    else if(endIndex >= data.Count)
                    {
                        endIndex = data.Count;
                    }
                    MergingData(ref data, startIndex, endIndex);
                }
            }

            Console.WriteLine(String.Join(" ", data));
        }
                                        
        private static void MergingData(ref List<string> data, int startIndex, int endIndex)
        {
            string mergedData = string.Empty;
            for (int i = startIndex; i <= endIndex; i++)
            {
                mergedData += data[0];
                data.RemoveAt(0);
            }
            data.Insert(0, mergedData);
        }
    }
}
