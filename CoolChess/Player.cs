using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CoolChess.Checkers;

namespace CoolChess
{
    class Player
    {
        private Cell[,] _cells;
        private players _color;
        private Position _selected = null;
        private List<List<Position>> _availableMovs = new List<List<Position>>();

        public Player(Cell[,] cells, players color)
        {
            this._cells = cells;
            this._color = color;

            int basePos = 0;
            if (this._color == players.White)
            {
                basePos = 7; // The pieces should be placed at the bottom
            }

            this._cells[basePos, 0].setPiece(new Chessman(new Rook(color)));
            this._cells[basePos, 1].setPiece(new Chessman(new Knight(color)));
            this._cells[basePos, 2].setPiece(new Chessman(new Bishop(color)));
            this._cells[basePos, 3].setPiece(new Chessman(new Queen(color)));
            this._cells[basePos, 4].setPiece(new Chessman(new King(color)));
            this._cells[basePos, 5].setPiece(new Chessman(new Bishop(color)));
            this._cells[basePos, 6].setPiece(new Chessman(new Knight(color)));
            this._cells[basePos, 7].setPiece(new Chessman(new Rook(color)));
             
            for (int i = 0; i < 8; i++)
            {
                this._cells[Math.Abs(basePos - 1), i].setPiece(new Chessman(new Pawn(color)));
            }

        }

        public bool mouseClick(Position p)
        {
            System.Diagnostics.Debug.WriteLine("Player mouseClick");
            Cell cell = this._cells[p.m, p.n];
            if (cell.hasPiece() && cell.hasColor(this._color)) // The cell contain a chessman of our own
            {
                if (this._selected != null) // The user selected a new chessman
                {
                    this.resetBoard();
                }

                this._selected = p;
                cell.setSelected();
                this._availableMovs = cell.getPiece().getAvailableMoves(p);
                foreach (Position pos in this._availableMovs)
                {
                    Cell c = this._cells[pos.m, pos.n];
                    if (c.hasPiece())
                    {
                        if (!c.hasColor(this._color)) // No friendly fire
                        {
                            c.setTarget();
                        }
                    }
                    else  // The cell is avaiable
                    {
                        c.setAvailable();
                    }
                }
            }
            else if (this._selected != null)
            {
                // Should we move?
                // Check if the current cell is within range
                foreach (Position pos in this._availableMovs)
                {
                    if (pos.m == p.m && pos.n == p.n)
                    {
                        System.Diagnostics.Debug.WriteLine("Movie it");
                        cell.setPiece(this._cells[this._selected.m, this._selected.n].getPiece());
                        this._cells[this._selected.m, this._selected.n].removePiece();
                        this._selected = null;
                        return true;
                    }
                }
            }
            return false;
        }

        private void resetBoard()
        {
            for (int m = 0; m < 8; m++)
            {
                for (int n = 0; n < 8; n++)
                {
                    this._cells[m, n].restore();
                }
            }
        }
    }
}
