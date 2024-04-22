using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursova
{
    public class Task
    {
        public double Duration { get; set; }
        public double Weight { get; set; }

        public Task(double duration, double weight)
        {
            Duration = duration;
            Weight = weight;
        }
    }
}
