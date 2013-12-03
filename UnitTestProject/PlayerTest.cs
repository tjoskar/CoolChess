using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoolChess.Checkers;
using CoolChess;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void TestGameOver()
        {
            Cell[,] cells = new Cell[8, 8];

            for (int m = 0; m < 8; m++)
            {
                for (int n = 0; n < 8; n++)
                {
                    cells[m, n] = new Cell(cellColor.None);
                }
            }

            Player blackPlayer = new Player(cells, playerColor.Black);
            Player whitePlayer = new Player(cells, playerColor.White);

            Assert.IsFalse(blackPlayer.isKingDead());
            Assert.IsFalse(whitePlayer.isKingDead());

            whitePlayer.movePice(cells[7, 4], cells[0, 4]);
            Assert.IsTrue(blackPlayer.isKingDead());
            Assert.IsFalse(whitePlayer.isKingDead());
        }
    }
}
