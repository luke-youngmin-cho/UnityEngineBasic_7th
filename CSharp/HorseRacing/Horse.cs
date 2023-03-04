using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRacing
{
    internal class Horse
    {
        public string Name;
        public string IsFinished;
        public int TotalDistance;

        public void Run(int distance)
        {
            TotalDistance += distance;
        }
    }
}
