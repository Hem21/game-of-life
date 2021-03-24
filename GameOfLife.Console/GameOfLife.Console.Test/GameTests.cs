using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
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
            var cell = new Cell
            {
                Status = true
            };

            var status = cell.Status;

            Assert.IsTrue(status);
        }

        [TestMethod]
        public void WhenCellSelectedInGridThenStatusBecomesTrue()
        {

            var game = new Game();
            var grid = game.CreateGrid(2, 3);
            var updatedGrid = Game.SetCell(grid, 0, 0);

            var expectedGrid = new[,] { { true, false, false }, { false, false, false } };

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
        public void WhenCellHasNoRowNeighborsThenZeroReturned()
        {
            var game = new Game();
            var grid = game.CreateGrid(1, 3);
            var setGrid = Game.SetCell(grid, 0, 2);
            var actualValue = Game.CheckRowNeighbors(0, 2, setGrid);

            var expectedValue = 0;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void WhenCellHasOneRowNeighborsThenOneReturned()
        {
            var game = new Game();
            var grid = game.CreateGrid(1, 3);
            Game.SetCell(grid, 0, 0);
            var setGrid = Game.SetCell(grid, 0, 1);
            var actualValue = Game.CheckRowNeighbors(0, 1, setGrid);

            var expectedValue = 1;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void WhenCellHasTwoRowNeighborsThenTwoReturned()
        {
            var game = new Game();
            var grid = game.CreateGrid(1, 3);
            Game.SetCell(grid, 0, 0);
            Game.SetCell(grid, 0, 1);
            var setGrid = Game.SetCell(grid, 0, 2);
            var actualValue = Game.CheckRowNeighbors(0, 1, setGrid);

            var expectedValue = 2;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void WhenCellHasNoColumnNeighborsThenZeroReturned()
        {
            var game = new Game();
            var grid = game.CreateGrid(3, 3);
            var setGrid = Game.SetCell(grid, 1, 1);
            var aboveBelow = Game.CheckColumnAboveAndBelowNeighbors(1, 1, setGrid);
            var diagonal = Game.CheckColumnDiagonalNeighbors(1, 1, setGrid);
            var actualValue = aboveBelow + diagonal;

            var expectedValue = 0;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void WhenCellHasOneColumnNeighborsThenOneReturned()
        {
            var game = new Game();
            var grid = game.CreateGrid(3, 3);
            Game.SetCell(grid, 2, 2);
            var setGrid = Game.SetCell(grid, 1, 1);
            var aboveBelow = Game.CheckColumnAboveAndBelowNeighbors(1, 1, setGrid);
            var diagonal = Game.CheckColumnDiagonalNeighbors(1, 1, setGrid);
            var actualValue = aboveBelow + diagonal;

            var expectedValue = 1;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void WhenCellHasTwoColumnNeighborsThenTwoReturned()
        {
            var game = new Game();
            var grid = game.CreateGrid(3, 3);
            Game.SetCell(grid, 0, 0);
            Game.SetCell(grid, 2, 2);
            var setGrid = Game.SetCell(grid, 1, 1);
            var aboveBelow = Game.CheckColumnAboveAndBelowNeighbors(1, 1, setGrid);
            var diagonal = Game.CheckColumnDiagonalNeighbors(1, 1, setGrid);
            var actualValue = aboveBelow + diagonal;

            var expectedValue = 2;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void WhenCellHasThreeColumnNeighborsThenThreeReturned()
        {
            var game = new Game();
            var grid = game.CreateGrid(3, 3);
            Game.SetCell(grid, 0, 0);
            Game.SetCell(grid, 2, 1);
            Game.SetCell(grid, 2, 2);
            var setGrid = Game.SetCell(grid, 1, 1);
            var aboveBelow = Game.CheckColumnAboveAndBelowNeighbors(1, 1, setGrid);
            var diagonal = Game.CheckColumnDiagonalNeighbors(1, 1, setGrid);
            var actualValue = aboveBelow + diagonal;

            var expectedValue = 3;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void WhenCellHasFourColumnNeighborsThenFourReturned()
        {
            var game = new Game();
            var grid = game.CreateGrid(3, 3);
            Game.SetCell(grid, 0, 0);
            Game.SetCell(grid, 0, 1);
            Game.SetCell(grid, 2, 1);
            Game.SetCell(grid, 2, 2);
            var setGrid = Game.SetCell(grid, 1, 1);
            var aboveBelow = Game.CheckColumnAboveAndBelowNeighbors(1, 1, setGrid);
            var diagonal = Game.CheckColumnDiagonalNeighbors(1, 1, setGrid);
            var actualValue = aboveBelow + diagonal;

            var expectedValue = 4;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void WhenCellHasFiveColumnNeighborsThenFiveReturned()
        {
            var game = new Game();
            var grid = game.CreateGrid(3, 3);
            Game.SetCell(grid, 0, 0);
            Game.SetCell(grid, 0, 1);
            Game.SetCell(grid, 0, 2);
            Game.SetCell(grid, 2, 1);
            Game.SetCell(grid, 2, 2);
            var setGrid = Game.SetCell(grid, 1, 1);
            var aboveBelow = Game.CheckColumnAboveAndBelowNeighbors(1, 1, setGrid);
            var diagonal = Game.CheckColumnDiagonalNeighbors(1, 1, setGrid);
            var actualValue = aboveBelow + diagonal;

            var expectedValue = 5;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void WhenCellHasSixColumnNeighborsThenSixReturned()
        {
            var game = new Game();
            var grid = game.CreateGrid(3, 3);
            Game.SetCell(grid, 0, 0);
            Game.SetCell(grid, 0, 1);
            Game.SetCell(grid, 0, 2);
            Game.SetCell(grid, 2, 0);
            Game.SetCell(grid, 2, 1);
            Game.SetCell(grid, 2, 2);
            var setGrid = Game.SetCell(grid, 1, 1);
            var aboveBelow = Game.CheckColumnAboveAndBelowNeighbors(1, 1, setGrid);
            var diagonal = Game.CheckColumnDiagonalNeighbors(1, 1, setGrid);
            var actualValue = aboveBelow + diagonal;

            var expectedValue = 6;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void WhenCellHasSevenNeighborsThenSevenReturned()
        {
            var game = new Game();
            var grid = game.CreateGrid(3, 3);
            Game.SetCell(grid, 0, 0);
            Game.SetCell(grid, 0, 1);
            Game.SetCell(grid, 0, 2);
            Game.SetCell(grid, 2, 0);
            Game.SetCell(grid, 2, 1);
            Game.SetCell(grid, 2, 2);
            Game.SetCell(grid, 1, 0);
            var setGrid = Game.SetCell(grid, 1, 1);
            var aboveBelow = Game.CheckColumnAboveAndBelowNeighbors(1, 1, setGrid);
            var diagonal = Game.CheckColumnDiagonalNeighbors(1, 1, setGrid);
            var rowNeighbors = Game.CheckRowNeighbors(1, 1, setGrid);
            var actualValue = aboveBelow + diagonal + rowNeighbors;

            var expectedValue = 7;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void WhenCellHasEightNeighborsThenEightReturned()
        {
            var game = new Game();
            var grid = game.CreateGrid(3, 3);
            Game.SetCell(grid, 0, 0);
            Game.SetCell(grid, 0, 1);
            Game.SetCell(grid, 0, 2);
            Game.SetCell(grid, 2, 0);
            Game.SetCell(grid, 2, 1);
            Game.SetCell(grid, 2, 2);
            Game.SetCell(grid, 1, 0);
            Game.SetCell(grid, 1, 2);
            var setGrid = Game.SetCell(grid, 1, 1);
            var aboveBelow = Game.CheckColumnAboveAndBelowNeighbors(1, 1, setGrid);
            var diagonal = Game.CheckColumnDiagonalNeighbors(1, 1, setGrid);
            var rowNeighbors = Game.CheckRowNeighbors(1, 1, setGrid);
            var actualValue = aboveBelow + diagonal + rowNeighbors;

            var expectedValue = 8;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void WhenLiveCellHasNoAliveNeighborsThenDies()
        {
            var game = new Game();
            var grid = game.CreateGrid(3, 3);
            Game.SetCell(grid, 0, 1);
            var setGrid = Game.SetCell(grid, 2, 2);
            var actualGrid = Game.UpdateGrid(setGrid);

            var expectedGrid = new[,] { { false, false, false }, { false, false, false }, { false, false, false } };

            CollectionAssert.AreEqual(expectedGrid, actualGrid);
        }

        [TestMethod]
        public void WhenLiveCellHasOneAliveNeighborsThenDies()
        {
            var game = new Game();
            var grid = game.CreateGrid(3, 3);
            Game.SetCell(grid, 0, 1);
            var setGrid = Game.SetCell(grid, 1, 1);
            var actualGrid = Game.UpdateGrid(setGrid);

            var expectedGrid = new[,] {{false, false, false}, {false, false, false}, {false, false, false}};

            CollectionAssert.AreEqual(expectedGrid, actualGrid);
        }

        [TestMethod]
        public void WhenLiveCellHasTwoAliveNeighborsThenLives()
        {
            var game = new Game();
            var grid = game.CreateGrid(3, 3);
            Game.SetCell(grid, 0, 1);
            Game.SetCell(grid, 0, 2);
            var setGrid = Game.SetCell(grid, 1, 1);
            var actualGrid = Game.UpdateGrid(setGrid);

            var expectedGrid = new[,] { { false, true, true }, { false, true, true }, { false, false, false } };

            CollectionAssert.AreEqual(expectedGrid, actualGrid);
        }

        [TestMethod]
        public void WhenLiveCellHasThreeAliveNeighborsThenLives()
        {
            var game = new Game();
            var grid = game.CreateGrid(3, 3);
            Game.SetCell(grid, 0, 1);
            Game.SetCell(grid, 0, 2);
            Game.SetCell(grid, 1, 2);
            var setGrid = Game.SetCell(grid, 1, 1);
            var actualGrid = Game.UpdateGrid(setGrid);

            var expectedGrid = new[,] { { false, true, true }, { false, true, true }, { false, false, false } };

            CollectionAssert.AreEqual(expectedGrid, actualGrid);
        }

        [TestMethod]
        public void WhenLiveCellHasFourAliveNeighborsThenDies()
        {
            var game = new Game();
            var grid = game.CreateGrid(3, 3);
            Game.SetCell(grid, 0, 1);
            Game.SetCell(grid, 0, 2);
            Game.SetCell(grid, 1, 2);
            Game.SetCell(grid, 2, 1);
            var setGrid = Game.SetCell(grid, 1, 1);
            var actualGrid = Game.UpdateGrid(setGrid);

            var expectedGrid = new[,] { { false, true, true }, { true, false, false }, { false, true, true } };

            CollectionAssert.AreEqual(expectedGrid, actualGrid);
        }

        [TestMethod]
        public void WhenDeadCellHasThreeAliveNeighborsThenBecomesAlive()
        {
            var game = new Game();
            var grid = game.CreateGrid(3, 3);
            Game.SetCell(grid, 0, 1);
            Game.SetCell(grid, 1, 0);
            var setGrid = Game.SetCell(grid, 2, 1);
            var actualGrid = Game.UpdateGrid(setGrid);

            var expectedGrid = new[,] { { false, false, false }, { true, true, false }, { false, false, false } };

            CollectionAssert.AreEqual(expectedGrid, actualGrid);
        }


    }


}
