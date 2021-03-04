using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GameOfLife.Console.Test
{
    [TestClass]
    public class GameTests
    {

        [TestMethod]
        public void CanCreateNewGame()
        {
            var game = new Game();

            Assert.IsNotNull(game);
        }

        [TestMethod]
        public void CanCreateGridWithSetValues()
        {
            var game = new Game();

            var grid = game.CreateGrid(2, 3);

            Assert.AreEqual(2, grid.GetLength(0));
            Assert.AreEqual(3, grid.GetLength(1));
        }
        
        [TestMethod]
        public void CanCreateCell()
        {
            var cell = new Cell();

            Assert.IsNotNull(cell);
        }
        
        [TestMethod]
        public void CanCreateNewCellWithDeadStatus()
        {
            var cell = new Cell();

            var status = cell.Status;

            Assert.IsFalse(status);
        }

        [TestMethod]
        public void CanCreateNewCellWithAliveStatus()
        {
            var cell = new Cell();

            cell.Status = true;

            var status = cell.Status;

            Assert.IsTrue(status);
        }

        [TestMethod]
        public void WhenCellSelectedInGridThenStatusBecomesTrue()
        {

            var game = new Game();
            var grid = game.CreateGrid(2,3);
            var updatedGrid = Game.SetCell(grid, 0, 0);

            var expectedGrid = new bool[2,3] { { true, false, false },{ false, false, false } };

            CollectionAssert.AreEqual(expectedGrid, updatedGrid);
        }

        [TestMethod]
        public void WhenCellSelectIsOutOfRangeThenReturnGridUnchanged()
        {

            var game = new Game();
            var grid = game.CreateGrid(2, 3);

            Assert.ThrowsException<Exception>(() => Game.SetCell(grid, -1, 5));
        }

        [TestMethod]
        public void CheckStatusOfBeforeCellInRow()
        {

            var game = new Game();
            var grid = game.CreateGrid(3, 3);

            var initialGrid = Game.SetCell(grid, 0, 1);

            var updatedGrid = Game.CheckBeforeCellInRow(initialGrid);

            var expectedValue = 


            CollectionAssert.AreEqual(expectedGrid, updatedGrid);
        }

        
    }
}
