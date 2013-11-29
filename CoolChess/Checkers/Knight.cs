using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolChess.Checkers
{
    class Knight : ChessmanInterface
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

        public List<Position> getAvailableMoves(Position p)
        {
            List<Position> positionList = new List<Position>();
            // Up, Left
            if (p.m - 2 >= 0 && p.n - 1 >= 0)
            {
                positionList.Add(new Position(p.n - 1, p.m - 2));
            }
            // Up, Right
            if (p.m - 2 >= 0 && p.n + 1 < 8)
            {
                positionList.Add(new Position(p.n + 1, p.m - 2));
            }
            // Right, Up
            if (p.m - 1 >= 0 && p.n + 2 < 8)
            {
                positionList.Add(new Position(p.n + 2, p.m - 1));
            }
            // Right, Down
            if (p.m + 1 < 8 && p.n + 2 < 8)
            {
                positionList.Add(new Position(p.n + 2, p.m + 1));
            }
            // Down, Right
            if (p.m + 2 < 8 && p.n + 1 < 8)
            {
                positionList.Add(new Position(p.n + 1, p.m + 2));
            }
            // Down, Left
            if (p.m + 2 < 8 && p.n - 1 >= 0)
            {
                positionList.Add(new Position(p.n - 1, p.m + 2));
            }
            // Left, Down
            if (p.m + 1 < 8 && p.n - 2 >= 0)
            {
                positionList.Add(new Position(p.n - 2, p.m + 1));
            }
            // Left, Up
            if (p.m - 1 >= 0 && p.n - 2 >= 0)
            {
                positionList.Add(new Position(p.n - 2, p.m - 1));
            }

            return positionList;
        }
    }
}
