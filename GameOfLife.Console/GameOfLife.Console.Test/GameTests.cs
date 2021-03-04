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
            var grid = game.CreateGrid(2, 3);
            var updatedGrid = Game.SetCell(grid, 0, 0);

            var expectedGrid = new bool[2, 3] { { true, false, false }, { false, false, false } };

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
        public void CheckNumberOfNeighboursIsOneInRow()
        {

            var game = new Game();
            var grid = game.CreateGrid(1, 3);
            var updatedGrid = Game.SetCell(grid, 0, 2);

            var actualValue = Game.CheckRowNeighbours(updatedGrid);

            var expectedValue = 1;

            Assert.AreEqual(expectedValue, actualValue);

        }

        [TestMethod]
        public void CheckNumberOfNeighboursIsTwoInRow()
        {

            var game = new Game();
            var grid = game.CreateGrid(1, 3);
            Game.SetCell(grid, 0, 0);
                        
            var updatedGrid = Game.SetCell(grid, 0, 2);
                              
            var actualValue = Game.CheckRowNeighbours(updatedGrid);

            var expectedValue = 2;

            Assert.AreEqual(expectedValue, actualValue);

        }

        [TestMethod]
        public void CheckNumberOfNeighboursInColumn()
        {

            var game = new Game();
            var grid = game.CreateGrid(3, 3);
            Game.SetCell(grid, 1, 2);

            var updatedGrid = Game.SetCell(grid, 0, 2);

            var actualValue = Game.CheckColumnNeighbours(updatedGrid);

            var expectedValue = 1;

            Assert.AreEqual(expectedValue, actualValue);
        }
    }

        
}
