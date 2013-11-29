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

        public List<Position> getAvailableMoves(Position p)
        {
            List<Position> positionList = new List<Position>();
            // Up
            if (p.m - 1 >= 0)
            {
                positionList.Add(new Position(p.n, p.m - 1));
            }
            // Right
            if (p.n + 1 < 8)
            {
                positionList.Add(new Position(p.n + 1, p.m));
            }
            // Down
            if (p.m + 1 < 8)
            {
                positionList.Add(new Position(p.n, p.m + 1));
            }
            // Left
            if (p.n - 1 >= 0)
            {
                positionList.Add(new Position(p.n - 1, p.m));
            }
            return positionList;
        }
    }
}
