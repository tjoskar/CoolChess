using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CoolChess.Checkers;

namespace CoolChess
{
    /*
     * The Game board
     */
    class Board
    {
        private Grid _board;
        private Cell[,] _cells = new Cell[8, 8];
        private Player _blackPlayer;
        private Player _whitePlayer;
        private MainWindow _mainWindow;
        public players currentTurn { get; set; }

        public Board(MainWindow mainWindow)
        {
            this._mainWindow = mainWindow;
            this._board = mainWindow.Board;
            this.createNewBorad();
        }

        public void createNewBorad()
        {
            this.paintBoard();
            this._blackPlayer = new Player(_cells, players.Black);
            this._whitePlayer = new Player(_cells, players.White);
            this.currentTurn = players.White;
            _mainWindow.WhoseTurn = "White";
        }

        /* This will reset the whole game board */
        private void paintBoard()
        {
            for (int m = 0; m < 8; m++)
            {
                for (int n = 0; n < 8; n++)
                {
                    Cell cell = new Cell();
                    if ((m % 2 == 0 && n % 2 == 0) || (m % 2 != 0 && n % 2 != 0))
                    {
                        cell.setBlack();
                    }
                    else
                    {
                        cell.setWhite();
                    }
                    this._cells[m, n] = cell;

                    Grid.SetColumn(cell, n);
                    Grid.SetRow(cell, m);
                    this._board.Children.Add(cell);
                }
            }
        }

        /* 
         * Reset all cells to the default color
         * This will keep all chessmen as they are
         */
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

        public double getCellWidth()
        {
            if (_cells.Length > 0)
            {
                return _cells[0, 0].ActualWidth;
            }
            else
            {
                return .0;
            }
        }

        public double getCellHeight()
        {
            if (_cells.Length > 0)
            {
                return _cells[0, 0].ActualHeight;
            }
            else
            {
                return .0;
            }
        }

        /* Forwrd mouse click to the current player */
        public void mouseClick(Position p)
        {
            if (this.currentTurn == players.Black)
            {
                if (_blackPlayer.mouseClick(p))
                {
                    this.resetBoard();
                    this.currentTurn = players.White;
                    _mainWindow.WhoseTurn = "White";
                }
            }
            else
            {
                if (_whitePlayer.mouseClick(p))
                {
                    this.resetBoard();
                    this.currentTurn = players.Black;
                    _mainWindow.WhoseTurn = "Black";
                }
            }
        }
    }
}
