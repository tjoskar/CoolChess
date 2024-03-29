﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolChess.Checkers
{
    public class Queen : ChessmanInterface
    {
        private playerColor _color;

        public Queen(playerColor color)
        {
            this._color = color;
        }
        
        public void setTemplate(Cell cell)
        {
            cell.piece.ContentTemplate = cell.getTemplate("Queen");
        }

        public playerColor getColor()
        {
            return this._color;
        }

        public List<List<Position>> getAvailableMoves(Position p)
        {
            List<List<Position>> positionList = new List<List<Position>>();
            List<Position> t = new List<Position>();
            // Diagonal 
            // Right Down
            for (int m = p.m + 1, n = p.n + 1; m < 8 && n < 8; m++, n++)
            {
                t.Add(new Position(n, m));
            }
            add(positionList, t);

            // Left Down
            t = new List<Position>();
            for (int m = p.m + 1, n = p.n - 1; m < 8 && n >= 0; m++, n--)
            {
                t.Add(new Position(n, m));
            }
            add(positionList, t);

            // Left Up
            t = new List<Position>();
            for (int m = p.m - 1, n = p.n - 1; m >= 0 && n >= 0; m--, n--)
            {
                t.Add(new Position(n, m));
            }
            add(positionList, t);

            // Right Up
            t = new List<Position>();
            for (int m = p.m - 1, n = p.n + 1; m >= 0 && n < 8; m--, n++)
            {
                t.Add(new Position(n, m));
            }
            add(positionList, t);

            // Vertically
            // Down
            t = new List<Position>();
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
            return chessmen.Queen;
        }
    }
}
