using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolChess.Checkers
{
    public class Pawn : ChessmanInterface
    {
        private players _color;

        public Pawn() {}
        
        public Pawn(players color)
        {
            this._color = color;
        }

        public void setTemplate(Cell cell)
        {
            cell.piece.ContentTemplate = cell.getTemplate("Pawn");
        }

        public players getColor()
        {
            return this._color;
        }

        public List<List<Position>> getAvailableMoves(Position p)
        {
            List<List<Position>> positionList = new List<List<Position>>();
            List<Position> t = new List<Position>();
            if (this._color == players.Black)
            {
                if (p.m == 1) // Start potiition
                {
                    t.Add(new Position(p.n, p.m + 1));
                    t.Add(new Position(p.n, p.m + 2));
                }
                else if (p.m + 1 < 8)
                {
                    t.Add(new Position(p.n, p.m + 1));
                }
            }
            else
            {
                if (p.m == 6) // Start potiition
                {
                    t.Add(new Position(p.n, p.m - 1));
                    t.Add(new Position(p.n, p.m - 2));
                }
                else if (p.m + 1 < 8)
                {
                    t.Add(new Position(p.n, p.m - 1));
                }
            }
            positionList.Add(t);
            return positionList;
        }

        public List<List<Position>> getCaptureMoves(Position p)
        {
            List<List<Position>> positionList = new List<List<Position>>();
            List<Position> t = new List<Position>();
            if (this._color == players.Black)
            {
                if (p.n + 1 < 8 && p.m + 1 < 8)
                {
                    t.Add(new Position(p.n + 1, p.m + 1));
                }
                add(positionList, t);
                t = new List<Position>();
                if (p.n - 1 >= 0 && p.m + 1 < 8)
                {
                    t.Add(new Position(p.n - 1, p.m + 1));
                }
                add(positionList, t);
            }
            else
            {
                if (p.n + 1 < 8 && p.m - 1 >= 0)
                {
                    t.Add(new Position(p.n + 1, p.m - 1));
                }
                add(positionList, t);
                t = new List<Position>();
                if (p.n - 1 >= 0 && p.m - 1 >= 0)
                {
                    t.Add(new Position(p.n - 1, p.m - 1));
                }
                add(positionList, t);
            }
            return positionList;
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
            return chessmen.Pawn;
        }
    }
}
