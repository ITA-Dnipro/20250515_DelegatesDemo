using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20250515_DelegatesDemo
{
    public class IterationEventArgs: EventArgs
    {
        public int IterationNumber { get; }

        public IterationEventArgs(int iterationNumber)
        {
            IterationNumber = iterationNumber;
        }
    }
}
