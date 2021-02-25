using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.Console.Test
{
    [TestClass]
    public class GameGridTests
    {
        [TestMethod]
        public void CanCreateGrid()
        {
            var grid = new GameGrid();

            Assert.AreEqual(5, grid.XAxis);
            Assert.AreEqual(5, grid.YAxis);
        }

        [TestMethod]
        public void CanCreateGridWithInterchangingValues()
        {
            var xAxis = 25;
            var yAxis = 15;
            var grid = new GameGrid(xAxis, yAxis);
           

            Assert.AreEqual(xAxis, grid.XAxis);
            Assert.AreEqual(yAxis, grid.YAxis);
        }

        [TestMethod]
        public void WhenHeightAndWidthInputtedAnArrayListOfLengthHeightWithArraysOfLengthWidthCreated()
        {
            var grid = new GameGrid(2, 3);

            bool[,] newGrid = grid.CreateGrid(grid.XAxis, grid.YAxis);

            bool[,] expectedGrid = { { false, false, false }, { false, false, false } };

            CollectionAssert.AreEqual(newGrid, expectedGrid);
        }

        [TestMethod]
        public void WhenWidthAndHeightAreGivenCellIsCreated()
        {
            var cell = new Cell(1, 2, false);

            Assert.IsNotNull(cell);
        }

        [TestMethod]
        public void WhenCellIsCreatedThenLiveCellIsAddedToGridAndTrueReturned()
        {
            var grid = new GameGrid(2, 3);

            var NewCell = new Cell(1, 1, true);

            bool[,] initialGrid = grid.SetCell(grid.XAxis, grid.YAxis, NewCell);

            bool expectedValue = true;

            Assert.AreEqual(initialGrid[1,1], expectedValue);
        }

    }
}
