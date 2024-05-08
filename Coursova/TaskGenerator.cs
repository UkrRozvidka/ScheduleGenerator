using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Coursova
{
    public static class TaskGenerator
    {
        public static List<Task> Generate(int n, double durationMin = 1, double durationMax = 10, double weightMin = 1, double weightMax = 10, int roundIndex = 0)
        {
            var random = new Random(123);
            var result  = new List<Task>();

            for (int i = 0; i < n; i++)
            {
                var duration = random.NextDouble() * (durationMax - durationMin) + durationMin;
                var weight = random.NextDouble() * (weightMax - weightMin) + weightMin;
                duration = Math.Round(duration, roundIndex);
                weight = Math.Round(weight, roundIndex);
                result.Add(new Task(duration, weight));
            }

            return result;
        }
    }
}
