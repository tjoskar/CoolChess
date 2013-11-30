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
        private players _currentTurn { get; set; }

        public Board(MainWindow mainWindow)
        {
            this._mainWindow = mainWindow;
            this._board = mainWindow.Board;
            this.createNewBorad();
            if (Momento.getInstance().existState())
            {
                this._mainWindow.makeLoadButtoVisible();
            }
        }

        public void createNewBorad()
        {
            this.paintBoard();
            this._blackPlayer = new Player(_cells, players.Black);
            this._whitePlayer = new Player(_cells, players.White);
            this._currentTurn = players.White;
            this._mainWindow.setWhoseTurn(this._currentTurn);
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
            if (this._currentTurn == players.Black)
            {
                if (this._blackPlayer.mouseClick(p))
                {
                    this.swapPlayer();
                }
            }
            else if (this._currentTurn == players.White)
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
            if (this._currentTurn == players.White)
            {
                if (this._blackPlayer.isKingDead())
                {
                    this.gameOver();
                }
                else
                {
                    this._currentTurn = players.Black;
                    this._mainWindow.setWhoseTurn(this._currentTurn);
                }
            }
            else if (this._currentTurn == players.Black)
            {
                if (this._whitePlayer.isKingDead())
                {
                    this.gameOver();
                }
                else
                {
                    this._currentTurn = players.White;
                    this._mainWindow.setWhoseTurn(this._currentTurn);
                }
            }

        }

        private void gameOver()
        {
            this._mainWindow.setGameOver(this._currentTurn);
            this._currentTurn = players.None;
        }

        public void saveGame()
        {
            Momento.getInstance().saveState(this._currentTurn, this._cells);
        }

        public void loadSavedState()
        {
            State state = Momento.getInstance().fetchState();
            IQueryable<CellState> cellSates = Momento.getInstance().fetchCellState(state);

            foreach (CellState cellState in cellSates)
            {
                if (cellState.m >= 0 && cellState.m < 8 && cellState.n >= 0 && cellState.n < 8)
                {
                    switch ((chessmen) cellState.pice)
                    {
                        case chessmen.Bishop:
                            this._cells[(int)cellState.n, (int)cellState.m].setPiece(new Chessman(new Bishop((players) cellState.color)));
                        break;
                        case chessmen.King:
                            this._cells[(int)cellState.n, (int)cellState.m].setPiece(new Chessman(new King((players) cellState.color)));
                        break;
                        case chessmen.Knight:
                            this._cells[(int)cellState.n, (int)cellState.m].setPiece(new Chessman(new Knight((players) cellState.color)));
                        break;
                        case chessmen.Pawn:
                            this._cells[(int)cellState.n, (int)cellState.m].setPiece(new Chessman(new Pawn((players) cellState.color)));
                        break;
                        case chessmen.Queen:
                            this._cells[(int)cellState.n, (int)cellState.m].setPiece(new Chessman(new Queen((players) cellState.color)));
                        break;
                        case chessmen.Rook:
                            this._cells[(int)cellState.n, (int)cellState.m].setPiece(new Chessman(new Rook((players) cellState.color)));
                        break;
                        default:
                        break;
                    }
                }
            }
            this._currentTurn = (players) state.current_turn;
        }
    }
}
