using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20250515_DelegatesDemo
{
    public static class Common
    {
        public static int Sqr(this int n)
        { 
            return n * n;
        }
    }
}
