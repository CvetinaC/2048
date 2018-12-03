using System;
using _2048.Models;
using _2048.BisnessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;


namespace Tests
{
    [TestClass]
    public class MatrixTest
    {
        [TestMethod]
        public void InitializeMatrix()
        {
            var matrix = FillMatrix.list(Logic.InitializeMatrix());
            //Assert
            Assert.AreEqual(2, matrix.Count(x => x != 0));
            Assert.AreNotEqual(2, matrix.Count(x => x == 4));
        }

        [TestMethod]
        public void MoveUpTest()
        {
            int[,] myMatrix =
            {
                { 0, 2, 0, 2 },
                { 0, 0, 0, 0 },
                { 0, 2, 0, 0 },
                { 4, 0, 0, 0 }
            };
            int[,] actualMatrix = { { 4, 4, 0, 2 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
            int[,] result = Logic.MoveUp(myMatrix);

            CollectionAssert.AreEqual(result, actualMatrix);

        }


        [TestMethod]
        public void MoveDownTest()
        {
            int[,] myMatrix = { { 2, 2, 4, 4 }, { 0, 4, 2, 0 }, { 2, 0, 0, 0 }, { 0, 0, 2, 0 } };
            int[,] actualMatrix = { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 2, 4, 0 }, { 4, 4, 4, 4 } };
            int[,] result = _2048.BisnessLogic.Logic.MoveDown(myMatrix);

            CollectionAssert.AreEqual(result, actualMatrix);

        }

    }
}
