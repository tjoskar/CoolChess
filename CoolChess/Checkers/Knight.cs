using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolChess.Checkers
{
    public class Knight : ChessmanInterface
    {
        private players _color;

        public Knight(players color)
        {
            this._color = color;
        }

        public void setTemplate(Cell cell)
        {
            cell.piece.ContentTemplate = cell.getTemplate("Knight");
        }

        public players getColor()
        {
            return this._color;
        }

        public List<List<Position>> getAvailableMoves(Position p)
        {
            List<List<Position>> positionList = new List<List<Position>>();
            List<Position> t = new List<Position>();
            // Up, Left
            if (p.m - 2 >= 0 && p.n - 1 >= 0)
            {
                t.Add(new Position(p.n - 1, p.m - 2));
            }
            add(positionList, t);
            
            // Up, Right
            t = new List<Position>();
            if (p.m - 2 >= 0 && p.n + 1 < 8)
            {
                t.Add(new Position(p.n + 1, p.m - 2));
            }
            add(positionList, t);

            // Right, Up
            t = new List<Position>();
            if (p.m - 1 >= 0 && p.n + 2 < 8)
            {
                t.Add(new Position(p.n + 2, p.m - 1));
            }
            add(positionList, t);

            // Right, Down
            t = new List<Position>();
            if (p.m + 1 < 8 && p.n + 2 < 8)
            {
                t.Add(new Position(p.n + 2, p.m + 1));
            }
            add(positionList, t);

            // Down, Right
            t = new List<Position>();
            if (p.m + 2 < 8 && p.n + 1 < 8)
            {
                t.Add(new Position(p.n + 1, p.m + 2));
            }
            add(positionList, t);

            // Down, Left
            t = new List<Position>();
            if (p.m + 2 < 8 && p.n - 1 >= 0)
            {
                t.Add(new Position(p.n - 1, p.m + 2));
            }
            add(positionList, t);

            // Left, Down
            t = new List<Position>();
            if (p.m + 1 < 8 && p.n - 2 >= 0)
            {
                t.Add(new Position(p.n - 2, p.m + 1));
            }
            add(positionList, t);

            // Left, Up
            t = new List<Position>();
            if (p.m - 1 >= 0 && p.n - 2 >= 0)
            {
                t.Add(new Position(p.n - 2, p.m - 1));
            }
            add(positionList, t);

            return positionList;
        }

        public List<List<Position>> getCaptureMoves(Position p)
        {
            return getAvailableMoves(p);
        }

        private void add(List<List<Position>> listlist, List<Position> list)
        {
            if (list.Count() > 0)
            {
                listlist.Add(list);
            }
        }

        public chessmen getType()
        {
            return chessmen.Knight;
        }
    }
}
