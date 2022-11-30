using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Course_Planning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> shedule = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command;

            while((command = Console.ReadLine()) != "course start")
            {
                List<string> cmdArgs = command
                    .Split(":", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                string cmdType = cmdArgs[0];

                if (cmdType == "Add")
                {
                    string lessonTitle = cmdArgs[1];
                    if (shedule.Contains(lessonTitle))
                    {
                        continue;
                    }
                    AddLesson(ref shedule, lessonTitle);
                }
                else if (cmdType == "Insert")
                {
                    string lessonTitle = cmdArgs[1];
                    int index = int.Parse(cmdArgs[2]);
                    if (shedule.Contains(lessonTitle))
                    {
                        continue;
                    }
                    InsertLesson(ref shedule, lessonTitle, index);
                }
                else if (cmdType == "Remove")
                {
                    string lessonTitle = cmdArgs[1];
                    if (!shedule.Contains(lessonTitle))
                    {
                        continue;
                    }
                    if (shedule.Contains($"{lessonTitle}-Exercise"))
                    {
                        shedule.Remove(lessonTitle);
                        shedule.Remove($"{lessonTitle}-Exercise");
                    }
                    else
                    {
                        shedule.Remove(lessonTitle);
                    }
                }
                else if (cmdType == "Swap")
                {
                    string firstLesson = cmdArgs[1];
                    string secondLesson = cmdArgs[2];
                    if(!shedule.Contains(firstLesson) && shedule.Contains(secondLesson))
                    {
                        continue;
                    }
                    SwapingShedule(ref shedule, firstLesson, secondLesson);
                }
                else if (cmdType == "Exercise")
                {
                    string lessonTitle = cmdArgs[1];
                    if (shedule.Contains(lessonTitle) && shedule.Contains($"{lessonTitle}-Exercise"))
                    {
                        continue;
                    }
                    ExerciseShedule(ref shedule, lessonTitle);
                }
            }
            PrintList(shedule.Distinct().ToList());
        }
        
        private static void AddLesson(ref List<string> shedule, string lessonTitle)
        {
            shedule.Add(lessonTitle);
        }


        private static void InsertLesson(ref List<string> shedule, string lessonTitle, int index)
        {
            shedule.Insert(index, lessonTitle);
        }

        private static void ExerciseShedule(ref List<string> shedule, string lessonTitle)
        {
            if (shedule.Contains(lessonTitle) && !shedule.Contains($"{lessonTitle}-Exercise"))
            {
                int lessonIndex = shedule.FindIndex(x => x == lessonTitle);
                shedule.Insert(lessonIndex + 1, $"{lessonTitle}-Exercise");
            }
            else if(!shedule.Contains(lessonTitle) && !shedule.Contains($"{lessonTitle}-Exercise"))
            {
                shedule.Add(lessonTitle);
                shedule.Add($"{lessonTitle}-Exercise");
            }
        }

        private static void SwapingShedule(ref List<string> shedule, string firstLesson, string secondLesson)
        {
            string firstLessonExercise = $"{firstLesson}-Exercise";
            string secondLessonExercise = $"{secondLesson}-Exercise";

            int firstLessonIndex = shedule.FindIndex(x => x == firstLesson);
            int secondLessonIndex = shedule.FindIndex(x => x == secondLesson);

            shedule.RemoveAt(secondLessonIndex);
            shedule.Insert(secondLessonIndex, firstLesson);

            shedule.RemoveAt(firstLessonIndex);
            shedule.Insert(firstLessonIndex, secondLesson);

            if (shedule.Contains(firstLessonExercise))
            {
                shedule.Remove(firstLessonExercise);
                shedule.Insert(secondLessonIndex + 1, firstLessonExercise);
            }
            if (shedule.Contains(secondLessonExercise))
            {
                shedule.Remove(secondLessonExercise);
                shedule.Insert(firstLessonIndex + 1, secondLessonExercise);
            }
        }

        private static void PrintList(List<string> shedule)
        {
            for (int i = 0; i < shedule.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{shedule[i]}");
            }
        }
    }
}
