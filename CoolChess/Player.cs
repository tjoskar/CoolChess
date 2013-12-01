using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CoolChess.Checkers;
using System.Diagnostics;

namespace CoolChess
{
    public class Player
    {
        private Cell[,] _cells;
        private players _color;
        private Position _selected = null;
        private List<List<Position>> _availableMoves = new List<List<Position>>();
        private List<List<Position>> _captureMoves = new List<List<Position>>();

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
            Cell cell = this._cells[p.m, p.n]; // Selected cell
            if (cell.hasPiece() && cell.hasColor(this._color)) // The cell contain a chessman of our own
            {
                // If the user select a new chessman we must reset the bord to its default color
                if (this._selected != null)
                {
                    this.resetBoard();
                }

                this._selected = p;
                cell.setSelected();
                // Available moves and capture moves are the same for all chessmen except pawn
                this._availableMoves = cell.getPiece().getAvailableMoves(p);
                this._captureMoves = cell.getPiece().getCaptureMoves(p);
                foreach (List<Position> posList in this._availableMoves)
                {
                    foreach (Position pos in posList)
                    {
                        Cell c = this._cells[pos.m, pos.n];
                        if (c.hasPiece())
                        {
                            // We can not go any further if the cell already has a piece. 
                            break;
                        }
                        c.setAvailable();
                    }
                }

                foreach (List<Position> posList in this._captureMoves)
                {
                    foreach (Position pos in posList)
                    {
                        Cell c = this._cells[pos.m, pos.n];
                        if (c.hasPiece())
                        {
                            if (!c.hasColor(this._color)) // No friendly fire
                            {
                                c.setTarget();
                            }
                            // We can not go any further so lets break.
                            break;
                        }
                    }
                }
            }
            else if (this._selected != null)
            {
                // Should we move?
                // Check if the current cell is within range
                foreach (List<Position> posList in this._availableMoves)
                {
                    foreach (Position pos in posList)
                    {
                        if (this._cells[pos.m, pos.n].hasPiece())
                        {
                            // We can not move to a cell that already has a piece.
                            // However, we may be able to capture this piece but that is a later problem.
                            break;
                        }
                        if (pos.m == p.m && pos.n == p.n)
                        {
                            // Alright, let's move
                            movePice(this._cells[this._selected.m, this._selected.n], cell);    // Move the pice
                            this._selected = null;                                              // Remove any trace
                            return true;                                                        // And return true, ie. we have made our move
                        }
                    }
                }

                foreach (List<Position> posList in this._captureMoves)
                {
                    foreach (Position pos in posList)
                    {
                        // The clicked cell is the same as 'pos' and the cell as a pice and it is not one of ours.. Let's capture it.
                        if (pos.m == p.m && pos.n == p.n && this._cells[pos.m, pos.n].hasPiece() && !this._cells[pos.m, pos.n].hasColor(this._color))
                        {
                            movePice(this._cells[this._selected.m, this._selected.n], cell);    // Move the pice
                            this._selected = null;                                              // Remove any trace
                            return true;                                                        // And return true, ie. we have made our move
                        }
                        else if (pos.m == p.m && pos.n == p.n || this._cells[pos.m, pos.n].hasPiece())
                        {
                            break;
                        }
                    }
                }
            }
            return false;
        }

        public void movePice(Cell from, Cell to)
        {
            to.setPiece(from.getPiece());
            from.removePiece();
        }

        public bool isKingDead()
        {
            foreach (Cell cell in this._cells)
            {
                if (cell.hasPiece() && cell.hasColor(this._color) && cell.getPiece().getType() == chessmen.King)
                {
                    return false;
                }
            }
            return true;
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
