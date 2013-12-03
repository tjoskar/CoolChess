using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoolChess.Checkers;
using CoolChess;
using System.Collections.Generic;

namespace UnitTestProject
{

    /*
     * Test that all Chessmans can move correct 
     */

    [TestClass]
    public class TestAvailableMoves
    {
        [TestMethod]
        public void TestMoveQueen()
        {
            // Arrange
            Chessman queen = new Chessman(new Queen(playerColor.Black));
            Position position = new Position(4, 4);
            List<Position> expected = new List<Position> {
                (new Position(4, 0)), (new Position(4, 1)), (new Position(4, 2)), (new Position(4, 3)), (new Position(4, 5)), (new Position(4, 6)), (new Position(4, 7)),
                (new Position(0, 4)), (new Position(1, 4)), (new Position(2, 4)), (new Position(3, 4)), (new Position(5, 4)), (new Position(6, 4)), (new Position(7, 4)),
                (new Position(0, 0)), (new Position(1, 1)), (new Position(2, 2)), (new Position(3, 3)), (new Position(5, 5)), (new Position(6, 6)), (new Position(7, 7)),
                (new Position(1, 7)), (new Position(2, 6)), (new Position(3, 5)), (new Position(5, 3)), (new Position(6, 2)), (new Position(7, 1))
            };

            // Act
            List<List<Position>> actual = queen.getAvailableMoves(position);

            // Assert
            Assert.IsTrue(comparerLists(expected, actual));
        }

        [TestMethod]
        public void TestMoveBishop()
        {
            // Arrange
            Chessman bishop = new Chessman(new Bishop(playerColor.Black));
            Position position = new Position(4, 4);
            List<Position> expected = new List<Position> {
                (new Position(0, 0)), (new Position(1, 1)), (new Position(2, 2)), (new Position(3, 3)), (new Position(5, 5)), (new Position(6, 6)), (new Position(7, 7)),
                (new Position(1, 7)), (new Position(2, 6)), (new Position(3, 5)), (new Position(5, 3)), (new Position(6, 2)), (new Position(7, 1))
            };

            // Act
            List<List<Position>> actual = bishop.getAvailableMoves(position);

            // Assert
            Assert.IsTrue(comparerLists(expected, actual));
        }

        [TestMethod]
        public void TestMoveKing()
        {
            // Arrange
            Chessman king = new Chessman(new King(playerColor.Black));
            Position position = new Position(4, 4);
            List<Position> expected = new List<Position> {
                (new Position(position.n,     position.m - 1)),
                (new Position(position.n + 1, position.m - 1)),
                (new Position(position.n + 1, position.m)),
                (new Position(position.n + 1, position.m + 1)),
                (new Position(position.n,     position.m + 1)),
                (new Position(position.n - 1, position.m + 1)),
                (new Position(position.n - 1, position.m)),
                (new Position(position.n - 1, position.m - 1))
            };

            // Act
            List<List<Position>> actual = king.getAvailableMoves(position);

            // Assert
            Assert.IsTrue(comparerLists(expected, actual));
        }

        [TestMethod]
        public void TestMoveKnight()
        {
            // Arrange
            Chessman knight = new Chessman(new Knight(playerColor.Black));
            Position position = new Position(4, 4);
            List<Position> expected = new List<Position> {
                (new Position(3, 2)),
                (new Position(5, 2)),
                (new Position(6, 3)),
                (new Position(6, 5)),
                (new Position(5, 6)),
                (new Position(3, 6)),
                (new Position(2, 5)),
                (new Position(2, 3))
            };

            // Act
            List<List<Position>> actual = knight.getAvailableMoves(position);

            // Assert
            Assert.IsTrue(comparerLists(expected, actual));
        }

        [TestMethod]
        public void TestMoveRook()
        {
            // Arrange
            Chessman rook = new Chessman(new Rook(playerColor.Black));
            Position position = new Position(4, 4);
            List<Position> expected = new List<Position> {
                (new Position(4, 0)), (new Position(4, 1)), (new Position(4, 2)), (new Position(4, 3)), (new Position(4, 5)), (new Position(4, 6)), (new Position(4, 7)),
                (new Position(0, 4)), (new Position(1, 4)), (new Position(2, 4)), (new Position(3, 4)), (new Position(5, 4)), (new Position(6, 4)), (new Position(7, 4))
            };

            // Act
            List<List<Position>> actual = rook.getAvailableMoves(position);

            // Assert
            Assert.IsTrue(comparerLists(expected, actual));
        }

        [TestMethod]
        public void TestMovePawn()
        {
            // Arrange
            Chessman pawn = new Chessman(new Pawn(playerColor.Black));
            Position position = new Position(4, 4);
            List<Position> expected = new List<Position> { (new Position(position.n, position.m + 1)) };

            // Act
            List<List<Position>> actual = pawn.getAvailableMoves(position);

            // Assert
            Assert.IsTrue(comparerLists(expected, actual));
        }

        [TestMethod]
        public void TestMoveStartPawn()
        {
            // Arrange
            Chessman pawn = new Chessman(new Pawn(playerColor.White));
            Position position = new Position(0, 6);
            List<Position> expected = new List<Position> { (new Position(position.n, position.m - 1)), (new Position(position.n, position.m - 2)) };

            // Act
            List<List<Position>> actual = pawn.getAvailableMoves(position);

            // Assert
            Assert.IsTrue(comparerLists(expected, actual));
        }

        private bool comparerLists(List<Position> expected, List<List<Position>> actual)
        {
            int expectedSize = expected.Count;
            int actualSize = 0;
            foreach (List<Position> list in actual)
            {
                foreach (Position actualPosition in list)
                {
                    actualSize++;
                    bool found = false;
                    foreach (Position expectedPosition in expected)
                    {
                        if (actualPosition.Equals(expectedPosition))
                        {
                            found = true;
                            expected.Remove(expectedPosition);
                            break;
                        }
                    }
                    if (!found)
                    {
                        return false;
                    }
                }
            }

            if (actualSize == expectedSize)
            {
                return true;
            }
            return false;
        }
    }
}
