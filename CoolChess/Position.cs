using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoolChess
{
    /*
     * m n -->
     * |
     * v
    */
    public class Position
    {
        public int m { get; set; }
        public int n { get; set; }
        public Position(int n, int m)
        {
            this.m = m;
            this.n = n;
        }
    }
}
