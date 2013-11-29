using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolChess.Checkers
{
    class Queen : ChessmanInterface
    {
        private players _color;

        public Queen(players color)
        {
            this._color = color;
        }
        
        public void setTemplate(Cell cell)
        {
            cell.piece.ContentTemplate = cell.getTemplate("Queen");
        }

        public players getColor()
        {
            return this._color;
        }

        public List<Position> getAvailableMoves(Position p)
        {
            List<Position> positionList = new List<Position>();
            // Diagonal 
            // Right Down
            for (int m = p.m + 1, n = p.n + 1; m < 8 && n < 8; m++, n++)
            {
                positionList.Add(new Position(n, m));
            }
            // Left Down
            for (int m = p.m + 1, n = p.n - 1; m < 8 && n >= 0; m++, n--)
            {
                positionList.Add(new Position(n, m));
            }
            // Left Up
            for (int m = p.m - 1, n = p.n - 1; m >= 0 && n >= 0; m--, n--)
            {
                positionList.Add(new Position(n, m));
            }
            // Right Up
            for (int m = p.m - 1, n = p.n + 1; m >= 0 && n < 8; m--, n++)
            {
                positionList.Add(new Position(n, m));
            }

            // Vertically
            // Down
            for (int m = p.m + 1; m < 8; m++)
            {
                positionList.Add(new Position(p.n, m));
            }
            // Up
            for (int m = p.m - 1; m >= 0; m--)
            {
                positionList.Add(new Position(p.n, m));
            }

            // Horizontal
            // Right
            for (int n = p.n + 1; n < 8; n++)
            {
               positionList.Add(new Position(n, p.m));
            }
            // Left
            for (int n = p.n - 1; n >= 0; n--)
            {
                positionList.Add(new Position(n, p.m));
            }

            return positionList;
        }
    }
}
