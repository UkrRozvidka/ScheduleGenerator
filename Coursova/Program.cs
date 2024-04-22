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

            var tasks = TaskGenerator.Generate(12);
            ShowTasks(tasks);
            
            
            var res = ProbabilisticAlgorithm.Calculate(tasks);

            ShowSchedule(res);
            Console.WriteLine(ProbabilisticAlgorithm.TargetFunction(res));
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