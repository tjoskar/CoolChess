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
        private Cell[,] _cells = new Cell[8, 8];
        private Player _blackPlayer;
        private Player _whitePlayer;
        private MainWindow _mainWindow;                 // Reference to main window which acts as a bridge to the GUI                        
        private playerColor _currentTurn { get; set; }

        public Board(MainWindow mainWindow)
        {
            this._mainWindow = mainWindow;
            this.createNewBorad();

            // Show loading button if there exist a saved game
            if (Momento.getInstance().existState())
            {
                this._mainWindow.makeLoadButtonVisible();
            }
        }

        public void createNewBorad()
        {
            this.paintBoard();                                          // Create new cells and paint them black and white
            this._blackPlayer = new Player(_cells, playerColor.Black);      // We need a new black player
            this._whitePlayer = new Player(_cells, playerColor.White);      // And a white one
            this._currentTurn = playerColor.White;                          // White player always start
            this._mainWindow.setWhoseTurn(this._currentTurn);           // Tell the user
            this._mainWindow.hideGameOver();                            // Hide the "Game Over" label until one of the player wins
        }

        /* This will reset the whole game board */
        private void paintBoard()
        {
            for (int m = 0; m < 8; m++)
            {
                for (int n = 0; n < 8; n++)
                {
                    Cell cell;
                    if ((m % 2 == 0 && n % 2 == 0) || (m % 2 != 0 && n % 2 != 0))
                    {
                        cell = new Cell(cellColor.Black);
                    }
                    else
                    {
                        cell = new Cell(cellColor.White);
                    }
                    this._cells[m, n] = cell;

                    Grid.SetColumn(cell, n);
                    Grid.SetRow(cell, m);
                    this._mainWindow.Board.Children.Add(cell);
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
            if (this._cells.Length > 0)
            {
                return this._cells[0, 0].ActualWidth;
            }
            else
            {
                return .0;
            }
        }

        public double getCellHeight()
        {
            if (this._cells.Length > 0)
            {
                return this._cells[0, 0].ActualHeight;
            }
            else
            {
                return .0;
            }
        }

        /* Forwrd mouse click to the current player */
        public void mouseClick(Position p)
        {
            if (this._currentTurn == playerColor.Black)
            {
                if (this._blackPlayer.mouseClick(p))
                {
                    this.swapPlayer();
                }
            }
            else if (this._currentTurn == playerColor.White)
            {
                if (this._whitePlayer.mouseClick(p))
                {
                    this.swapPlayer();
                }
            }
        }

        private void swapPlayer()
        {
            this.resetBoard();
            if (this._currentTurn == playerColor.White)
            {
                if (this._blackPlayer.isKingDead())
                {
                    this.gameOver();
                }
                else
                {
                    this._currentTurn = playerColor.Black;
                    this._mainWindow.setWhoseTurn(this._currentTurn);
                }
            }
            else if (this._currentTurn == playerColor.Black)
            {
                if (this._whitePlayer.isKingDead())
                {
                    this.gameOver();
                }
                else
                {
                    this._currentTurn = playerColor.White;
                    this._mainWindow.setWhoseTurn(this._currentTurn);
                }
            }

        }

        private void gameOver()
        {
            this._mainWindow.setGameOver(this._currentTurn);
            this._currentTurn = playerColor.None;
        }

        public void saveGame()
        {
            Momento.getInstance().saveState(this._currentTurn, this._cells);
        }

        public void loadSavedState()
        {
            State state = Momento.getInstance().fetchState();
            IQueryable<CellState> cellSates = Momento.getInstance().fetchCellState(state);

            // Reset the board color
            this.paintBoard();

            // We only save cells that have game pieces
            // Go through all saved cells and place the game pieces in their real position 
            foreach (CellState cellState in cellSates)
            {
                if (cellState.m >= 0 && cellState.m < 8 && cellState.n >= 0 && cellState.n < 8)
                {
                    switch ((chessmen)cellState.pice)
                    {
                        case chessmen.Bishop:
                            this._cells[(int)cellState.m, (int)cellState.n].setPiece(new Chessman(new Bishop((playerColor)cellState.color)));
                            break;
                        case chessmen.King:
                            this._cells[(int)cellState.m, (int)cellState.n].setPiece(new Chessman(new King((playerColor)cellState.color)));
                            break;
                        case chessmen.Knight:
                            this._cells[(int)cellState.m, (int)cellState.n].setPiece(new Chessman(new Knight((playerColor)cellState.color)));
                            break;
                        case chessmen.Pawn:
                            this._cells[(int)cellState.m, (int)cellState.n].setPiece(new Chessman(new Pawn((playerColor)cellState.color)));
                            break;
                        case chessmen.Queen:
                            this._cells[(int)cellState.m, (int)cellState.n].setPiece(new Chessman(new Queen((playerColor)cellState.color)));
                            break;
                        case chessmen.Rook:
                            this._cells[(int)cellState.m, (int)cellState.n].setPiece(new Chessman(new Rook((playerColor)cellState.color)));
                            break;
                        default:
                            break;
                    }
                }
            }
            this._currentTurn = (playerColor)state.current_turn;
            this._mainWindow.setWhoseTurn(this._currentTurn);
            this._mainWindow.hideGameOver();
        }
    }
}
