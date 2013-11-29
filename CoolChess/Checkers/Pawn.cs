using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolChess.Checkers
{
    class Pawn : ChessmanInterface
    {
        private players _color;

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

        public List<Position> getAvailableMoves(Position p)
        {
            List<Position> positionList = new List<Position>();
            if (this._color == players.Black)
            {
                if (p.m + 1 < 8)
                {
                    positionList.Add(new Position(p.n, p.m + 1));
                }
            }
            else
            {
                if (p.m - 1 > 0)
                {
                    positionList.Add(new Position(p.n, p.m - 1));
                }
            }
            return positionList;
        }
    }
}
