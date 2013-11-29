using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CoolChess.Checkers
{
    class Rook : ChessmanInterface
    {
        private players _color;

        public Rook(players color)
        {
            this._color = color;
        }

        public void setTemplate(Cell cell)
        {
            cell.piece.ContentTemplate = cell.getTemplate("Rook");
        }

        public players getColor()
        {
            return this._color;
        }

        public List<Position> getAvailableMoves(Position p)
        {
            List<Position> positionList = new List<Position>();
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
