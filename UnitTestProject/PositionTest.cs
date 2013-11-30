using CoolChess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject
{
    
    // This is a test class for PositionTest and is intended
    // to contain all PositionTest Unit Tests
    [TestClass()]
    public class PositionTest
    {


        // A test for Equals
        [TestMethod()]
        public void EqualsTest()
        {
            int n = 1;
            int m = 5;
            Position pos1 = new Position(n, m);
            Position pos2 = new Position(n, m);

            bool expected = true;
            bool actual = pos1.Equals(pos2) && pos2.Equals(pos1);
            Assert.AreEqual(expected, actual);
        }

        // A test for Equals
        [TestMethod()]
        public void NotEqualsTest()
        {
            Position pos1 = new Position(5, 5);
            Position pos2 = new Position(5, 6);
            Position pos3 = new Position(6, 5);
            Position pos4 = new Position(6, 6);

            bool expected = false;
            bool actual = pos1.Equals(pos2) || pos1.Equals(pos3) || pos1.Equals(pos4);
            Assert.AreEqual(expected, actual);
        }

        // A test for GetHashCode
        [TestMethod()]
        public void GetHashCodeTest()
        {
            int n = 1;
            int m = 2;
            Position target = new Position(n, m);
            int expected = m * 10 + 1;
            int actual = target.GetHashCode();
            Assert.AreEqual(expected, actual);
        }

        // A test for ToString
        [TestMethod()]
        public void ToStringTest()
        {
            int n = 1;
            int m = 2;
            Position target = new Position(n, m);
            string expected = "m: 2 n: 1";
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
