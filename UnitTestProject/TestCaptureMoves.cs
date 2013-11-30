using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoolChess.Checkers;
using CoolChess;
using System.Collections.Generic;

namespace UnitTestProject
{

    /*
     * Test that all Chessmans can capture correct 
     */

    [TestClass]
    public class TestCaptureMoves
    {
        [TestMethod]
        public void TestCaptureQueen()
        {
            // Arrange
            Chessman queen = new Chessman(new Queen(players.Black));
            Position position = new Position(4, 4);
            List<Position> expected = new List<Position> {
                (new Position(4, 0)), (new Position(4, 1)), (new Position(4, 2)), (new Position(4, 3)), (new Position(4, 5)), (new Position(4, 6)), (new Position(4, 7)),
                (new Position(0, 4)), (new Position(1, 4)), (new Position(2, 4)), (new Position(3, 4)), (new Position(5, 4)), (new Position(6, 4)), (new Position(7, 4)),
                (new Position(0, 0)), (new Position(1, 1)), (new Position(2, 2)), (new Position(3, 3)), (new Position(5, 5)), (new Position(6, 6)), (new Position(7, 7)),
                (new Position(1, 7)), (new Position(2, 6)), (new Position(3, 5)), (new Position(5, 3)), (new Position(6, 2)), (new Position(7, 1))
            };

            // Act
            List<List<Position>> actual = queen.getCaptureMoves(position);

            // Assert
            Assert.IsTrue(comparerLists(expected, actual));
        }

        [TestMethod]
        public void TestCaptureBishop()
        {
            // Arrange
            Chessman bishop = new Chessman(new Bishop(players.Black));
            Position position = new Position(4, 4);
            List<Position> expected = new List<Position> {
                (new Position(0, 0)), (new Position(1, 1)), (new Position(2, 2)), (new Position(3, 3)), (new Position(5, 5)), (new Position(6, 6)), (new Position(7, 7)),
                (new Position(1, 7)), (new Position(2, 6)), (new Position(3, 5)), (new Position(5, 3)), (new Position(6, 2)), (new Position(7, 1))
            };

            // Act
            List<List<Position>> actual = bishop.getCaptureMoves(position);

            // Assert
            Assert.IsTrue(comparerLists(expected, actual));
        }

        [TestMethod]
        public void TestCaptureKing()
        {
            // Arrange
            Chessman king = new Chessman(new King(players.Black));
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
            List<List<Position>> actual = king.getCaptureMoves(position);

            // Assert
            Assert.IsTrue(comparerLists(expected, actual));
        }

        [TestMethod]
        public void TestCaptureKnight()
        {
            // Arrange
            Chessman knight = new Chessman(new Knight(players.Black));
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
            List<List<Position>> actual = knight.getCaptureMoves(position);

            // Assert
            Assert.IsTrue(comparerLists(expected, actual));
        }

        [TestMethod]
        public void TestCaptureRook()
        {
            // Arrange
            Chessman rook = new Chessman(new Rook(players.Black));
            Position position = new Position(4, 4);
            List<Position> expected = new List<Position> {
                (new Position(4, 0)), (new Position(4, 1)), (new Position(4, 2)), (new Position(4, 3)), (new Position(4, 5)), (new Position(4, 6)), (new Position(4, 7)),
                (new Position(0, 4)), (new Position(1, 4)), (new Position(2, 4)), (new Position(3, 4)), (new Position(5, 4)), (new Position(6, 4)), (new Position(7, 4))
            };

            // Act
            List<List<Position>> actual = rook.getCaptureMoves(position);

            // Assert
            Assert.IsTrue(comparerLists(expected, actual));
        }

        [TestMethod]
        public void TestCapturePawn()
        {
            // Arrange
            Chessman pawn = new Chessman(new Pawn(players.Black));
            Position position = new Position(4, 4);
            List<Position> expected = new List<Position> {
                (new Position(position.n + 1, position.m + 1)),
                (new Position(position.n - 1, position.m + 1))
            };

            // Act
            List<List<Position>> actual = pawn.getCaptureMoves(position);

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
