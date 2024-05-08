using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursova
{
    public  static class GreedyAlgorithm
    {
        public static List<List<Tuple<Task, Task>>> Calculate(List<Task> tasks)
        {
            var sortedTasks = tasks.OrderBy(x => x.Duration).ToList();

            var tuples = new List<Tuple<Task, Task>>();
            for (int i = 0; i < sortedTasks.Count; i+=2)
            {
                tuples.Add(new Tuple<Task, Task>(sortedTasks[i+1], sortedTasks[i]));
            }
            var sortedTuples = tuples.OrderBy(x => x.Item1.Weight + x.Item2.Weight).ToList();

            var res = new List<List<Tuple<Task, Task>>>();
            res.Add(new List<Tuple<Task, Task>>());
            res.Add(new List<Tuple<Task, Task>>());

            foreach (var tuple in sortedTuples) 
            {
                if (res[0].Count > res[1].Count)
                    res[1].Add(tuple);
                else
                    res[0].Add(tuple);
            }

            return res;
        }
    }
}
