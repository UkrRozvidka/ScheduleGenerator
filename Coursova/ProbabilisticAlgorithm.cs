using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursova
{
    public static class ProbabilisticAlgorithm
    {

        private static List<List<Task>> SplitInTwoGroup(List<Task> tasks)
        {
            var res = new List<List<Task>>() { new List<Task>(), new List<Task>() };
            Random rnd = new Random();
            var shuffledList = tasks.OrderBy(x => rnd.Next()).ToList();

            res[rnd.Next(0, 1)].AddRange(shuffledList.GetRange(0, 2));

            for (int i = 2; i < tasks.Count; i += 2)
            {
                double probabiliti = ((double)i - res[0].Count) / (double)i;

                res[rnd.NextDouble() < probabiliti ? 0 : 1].AddRange(shuffledList.GetRange(i, 2));
            }
            return res;
        }

        private static List<Tuple<Task, Task>> SplitInPairs(List<Task> tasks)
        {
            Random random = new Random();

            var sortedTasks = tasks.OrderBy(x => x.Duration).ToList();
            var res = new List<Tuple<Task, Task>>();

            while (sortedTasks.Count > 1)
            {
                int element1Index, element2Index;
                do
                {
                    element1Index = random.Next(sortedTasks.Count);
                    element2Index = random.Next(sortedTasks.Count);
                }
                while (element1Index == element2Index);


                double probability = 1.0 /  Math.Pow(Math.Abs(element2Index - element1Index), 3);

                if (random.NextDouble() <= probability)
                {

                    if (sortedTasks[element1Index].Duration >= sortedTasks[element2Index].Duration)
                    {
                        res.Add(new Tuple<Task, Task>(sortedTasks[element1Index], sortedTasks[element2Index]));
                    }
                    else
                    {
                        res.Add(new Tuple<Task, Task>(sortedTasks[element2Index], sortedTasks[element1Index]));
                    }

                    sortedTasks.RemoveAt(element1Index);

                    if (element1Index < element2Index)
                        sortedTasks.RemoveAt(element2Index - 1);
                    else
                        sortedTasks.RemoveAt(element2Index);
                }
            }

            return res;
        }

        private static List<Tuple<Task, Task>> MakeSchedule(List<Tuple<Task, Task>> taskTuples)
        {
            return taskTuples.OrderBy(t => t.Item1.Duration / (t.Item1.Weight + t.Item2.Weight)).ToList();
        }

        public static double TargetFunction(List<List<Tuple<Task, Task>>> schedule)
        {
            double res = 0;
            int count = 0;
            foreach(var m in schedule)
            {
                double totalTime = 0;
                foreach(var t in m)
                {
                    res += (t.Item1.Duration + totalTime) * t.Item1.Weight;
                    res += (t.Item2.Duration + totalTime) * t.Item2.Weight;
                    totalTime += t.Item1.Duration;
                    count += 2;
                }
            }
            return res / count;
        }

        private static  List<List<Tuple<Task, Task>>> MakeSchedule(List<Task> tasks)
        {
            var res = new List<List<Tuple<Task, Task>>>();
            var splitedTask = SplitInTwoGroup(tasks);
            foreach(var m in splitedTask) 
            { 
               res.Add(MakeSchedule(SplitInPairs(m)));
            }
            return res;
        }

        public static List<List<Tuple<Task, Task>>> Calculate(List<Task> tasks, int n = 100000) 
        {
            List<List<Tuple<Task, Task>>> bestSchedule = new();
            double bestScheduleValue = double.MaxValue;

            for (int i = 0; i < n; i++)
            {
                var schedule = MakeSchedule(tasks);
                var ScheduleValue = TargetFunction(schedule);

                if(ScheduleValue < bestScheduleValue)
                {
                    bestSchedule = schedule;
                    bestScheduleValue = ScheduleValue;
                }
            }

            return bestSchedule;
        }
    }
}
