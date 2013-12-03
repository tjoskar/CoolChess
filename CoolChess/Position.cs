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

        public override bool Equals(Object obj)
        {
            Position pos = obj as Position;
            return Equals(pos);
        }

        public bool Equals(Position pos)
        {
            if (pos == null)
            {
                return false;
            }
            else
            {
                return this.m.Equals(pos.m) && this.n.Equals(pos.n);
            }
        }

        public override int GetHashCode()
        {
            return this.m*10 + this.n;
        }

        public override string ToString()
        {
            return "m: " + this.m.ToString() + " n: " + this.n.ToString();
        }
    }
}
