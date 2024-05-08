using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursova
{
    class Program
    {
        static void Main(string[] args)
        {

            var tasks = TaskGenerator.Generate(10);
            //List<Task> tasks = new List<Task>() {
            //            new Task(5, 1),
            //            new Task(8, 3),
            //            new Task(2, 3),
            //            new Task(4, 1),
            //            new Task(3, 4),
            //            new Task(7, 3),
            //            new Task(8, 5),
            //            new Task(5, 2),
            //            new Task(6, 3),
            //            new Task(1, 2),
            //            new Task(3, 2),
            //            new Task(2, 1)
            //        };
            ShowTasks(tasks);
            
            
            var resP = ProbabilisticAlgorithm.Calculate(tasks, 100000);

            ShowSchedule(resP);
            Console.WriteLine(ProbabilisticAlgorithm.TargetFunction(resP));

            Console.WriteLine();
            Console.WriteLine();

            var resG = GreedyAlgorithm.Calculate(tasks);

            ShowSchedule(resG);
            Console.WriteLine(ProbabilisticAlgorithm.TargetFunction(resG));
        }

        static void ShowSchedule(List<List<Tuple<Task, Task>>> schedule)
        {
            foreach (var m in schedule)
            {
                foreach(var t in m)
                {
                    Console.Write($"[({t.Item1.Duration} , {t.Item1.Weight}); ({t.Item2.Duration} , {t.Item2.Weight})]   ");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        static void ShowTasks(List<Task> tasks)
        {
            foreach (var task in tasks) 
            {
                Console.Write($"({task.Duration}, {task.Weight}); ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}