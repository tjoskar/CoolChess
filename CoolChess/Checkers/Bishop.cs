using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolChess.Checkers
{
    class Bishop : ChessmanInterface
    {
        private players _color;

        public Bishop(players color)
        {
            this._color = color;
        }

        public void setTemplate(Cell cell)
        {
            cell.piece.ContentTemplate = cell.getTemplate("Bishop");
        }

        public players getColor()
        {
            return this._color;
        }

        public List<List<Position>> getAvailableMoves(Position p)
        {
            List<List<Position>> positionList = new List<List<Position>>();
            List<Position> t = new List<Position>();
            // Diagonal 
            // Right Down
            for (int m = p.m + 1, n = p.n + 1; m < 8 && n < 8; m++, n++)
            {
                t.Add(new Position(n, m));
            }
            positionList.Add(t);
            t.Clear();
            // Left Down
            for (int m = p.m + 1, n = p.n - 1; m < 8 && n >= 0; m++, n--)
            {
                t.Add(new Position(n, m));
            }
            positionList.Add(t);
            t.Clear();
            // Left Up
            for (int m = p.m - 1, n = p.n - 1; m >= 0 && n >= 0; m--, n--)
            {
                t.Add(new Position(n, m));
            }
            positionList.Add(t);
            t.Clear();
            // Right Up
            for (int m = p.m - 1, n = p.n + 1; m >= 0 && n < 8; m--, n++)
            {
                t.Add(new Position(n, m));
            }
            positionList.Add(t);
            return positionList;
        }
    }
}
