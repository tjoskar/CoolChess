using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolChess.Checkers
{
    class King : ChessmanInterface
    {
        private players _color;

        public King(players color)
        {
            this._color = color;
        }

        public void setTemplate(Cell cell)
        {
            cell.piece.ContentTemplate = cell.getTemplate("King");
        }

        public players getColor()
        {
            return this._color;
        }

        public List<List<Position>> getAvailableMoves(Position p)
        {
            List<List<Position>> positionList = new List<List<Position>>();
            List<Position> t = new List<Position>();
            // Up
            if (p.m - 1 >= 0)
            {
                t.Add(new Position(p.n, p.m - 1));
            }

            // Right
            if (p.n + 1 < 8)
            {
                t.Add(new Position(p.n + 1, p.m));
            }

            // Down
            if (p.m + 1 < 8)
            {
                t.Add(new Position(p.n, p.m + 1));
            }

            // Left
            if (p.n - 1 >= 0)
            {
                t.Add(new Position(p.n - 1, p.m));
            }
            positionList.Add(t);

            return positionList;
        }

        public List<List<Position>> getCaptureMoves(Position p)
        {
            return getAvailableMoves(p);
        }
    }
}
