using System;
using System.Linq;

namespace SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            var schedule = Console.ReadLine().Split(", ").ToList();

            while (true)
            {
                var commands = Console.ReadLine();

                if (commands == "course start")
                {
                    break;
                }

                var input = commands.Split(":");

                if (input[0] == "Add")
                {
                    var lesson = input[1];

                    if (!schedule.Contains(lesson))
                    {
                        schedule.Add(lesson);
                    }
                }
                else if (input[0] == "Insert")
                {
                    var lessonTitle = input[1];
                    int index = int.Parse(input[2]);

                    if (index >= 0 && index < schedule.Count)
                    {
                        if (!schedule.Contains(lessonTitle))
                        {
                            schedule.Insert(index, lessonTitle);
                        }

                    }
                }
                else if (input[0] == "Remove")
                {
                    var lessonToRemove = input[1];

                    if (schedule.Contains(lessonToRemove))
                    {
                        schedule.Remove(lessonToRemove);

                        if (schedule.Contains(lessonToRemove + "-Exercise"))
                        {
                            schedule.Remove(lessonToRemove + "-Exercise");
                        }
                    }
                }
                else if (input[0] == "Swap")
                {
                    var lessonTitleOne = input[1];
                    var lessonTitleTwo = input[2];
                    int indexOfOne = schedule.IndexOf(lessonTitleOne);
                    int indexOfTwo = schedule.IndexOf(lessonTitleTwo);

                    if (schedule.Contains(lessonTitleOne) && schedule.Contains(lessonTitleTwo))
                    {
                        schedule.Remove(lessonTitleOne);
                        schedule.Remove(lessonTitleTwo);
                        schedule.Insert(indexOfOne, lessonTitleTwo);
                        schedule.Insert(indexOfTwo, lessonTitleOne);

                        if (schedule.Contains(lessonTitleOne + "-Exercise"))
                        {
                            schedule.Remove(lessonTitleOne + "-Exercise");
                            indexOfOne = schedule.IndexOf(lessonTitleOne);
                            schedule.Insert(indexOfOne + 1, lessonTitleOne + "-Exercise");
                        }
                        else if (schedule.Contains(lessonTitleTwo + "-Exercise"))
                        {
                            schedule.Remove(lessonTitleTwo + "-Exercise");
                            indexOfTwo = schedule.IndexOf(lessonTitleTwo);
                            schedule.Insert(indexOfTwo + 1, lessonTitleTwo + "-Exercise");
                        }
                    }
                }
                else if (input[0] == "Exercise")
                {
                    var lessonTitle = input[1];
                    var index = schedule.IndexOf(lessonTitle);

                    if (schedule.Contains(lessonTitle))
                    {

                        if (!schedule.Contains(lessonTitle + "-Exercise"))
                        {
                            schedule.Insert(index + 1, lessonTitle + "-Exercise");
                        }

                    }
                    else
                    {
                        schedule.Add(lessonTitle);
                        schedule.Add(lessonTitle + "-Exercise");
                    }
                }

            }

            for (int i = 0; i < schedule.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{schedule[i]}");
            }
        }
    }
}
