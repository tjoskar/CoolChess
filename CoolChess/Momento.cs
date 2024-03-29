﻿using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolChess
{
    /*
     * Don't be misled by that name. It is not a design pattern.
     * This class is used to communicate with the database
     */
    public class Momento
    {
        private StateLINQDataContext db;
        private static Momento instance = null;     // It should only exist one instace of this class
        private static int stateID = 0;
        private static int cellStateID = 0;

        private Momento()
        {
            db = new StateLINQDataContext();
        }

        public static Momento getInstance()
        {
            if (instance == null)
            {
                instance = new Momento();
            }
            return instance;
        }

        public void saveState(playerColor currentTurn, Cell[,] cells)
        {
            this.db.ExecuteCommand("TRUNCATE TABLE State");     // May seem harsh but we are only interested to save one row 
            State s = new State() {
                current_turn = (int)currentTurn,
                Id = ++stateID
            };
            this.db.States.InsertOnSubmit(s);
            this.db.SubmitChanges();

            var state = this.fetchState();
            if (state == null)
            {
                return;
            }

            this.saveCells(state, cells);
        }

        private void saveCells(State state, Cell[,] cells)
        {
            this.db.ExecuteCommand("TRUNCATE TABLE CellState");
            Cell cell;
            for (int m = 0; m < 8; m++)
            {
                for (int n = 0; n < 8; n++)
                {
                    cell = cells[m, n];
                    if (cell.hasPiece()) {
                        this.db.CellStates.InsertOnSubmit(
                            new CellState() {
                                Id = ++cellStateID,
                                color = (int)cell.getPiece().getColor(),
                                m = m,
                                n = n,
                                state_id = state.Id,
                                pice = (int)cell.getPiece().getType()
                            }
                        );
                        this.db.SubmitChanges();
                    }
                }
            }
        }

        public State fetchState()
        {
            State s = (
                from st in this.db.States
                select st
            ).FirstOrDefault();
            if (s != null)
            {
                stateID = s.Id;
                cellStateID = 64 * s.Id;
            }
            return s;
        }

        public IQueryable<CellState> fetchCellState(State state)
        {
            return (
                from c in this.db.CellStates
                where c.state_id == state.Id
                select c
            );
        }

        public bool existState()
        {
            return (this.fetchState() != null);
        }
    }
}
