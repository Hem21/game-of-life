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

            Assert.AreEqual(5, grid.Width);
            Assert.AreEqual(5, grid.Height);
        }

        [TestMethod]
        public void CanCreateGridWithInterchangingValues()
        {
            var gridWidth = 25;
            var gridHeight = 15;
            var grid = new GameGrid(gridWidth, gridHeight);
           

            Assert.AreEqual(gridWidth, grid.Width);
            Assert.AreEqual(gridHeight, grid.Height);
        }



    }
}
