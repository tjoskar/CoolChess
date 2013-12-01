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
    public class Rook : ChessmanInterface
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

        public List<List<Position>> getAvailableMoves(Position p)
        {
            List<List<Position>> positionList = new List<List<Position>>();
            List<Position> t = new List<Position>();
            // Vertically
            // Down
            for (int m = p.m + 1; m < 8; m++)
            {
                t.Add(new Position(p.n, m));
            }
            add(positionList, t);

            // Up
            t = new List<Position>();
            for (int m = p.m - 1; m >= 0; m--)
            {
                t.Add(new Position(p.n, m));
            }
            add(positionList, t);

            // Horizontal
            // Right
            t = new List<Position>();
            for (int n = p.n + 1; n < 8; n++)
            {
                t.Add(new Position(n, p.m));
            }
            add(positionList, t);

            // Left
            t = new List<Position>();
            for (int n = p.n - 1; n >= 0; n--)
            {
                t.Add(new Position(n, p.m));
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
            return chessmen.Rook;
        }
    }
}
