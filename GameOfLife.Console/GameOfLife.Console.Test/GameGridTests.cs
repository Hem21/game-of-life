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
        public void CanCreateGridWithDefaultValues()
        {
            var x = 25;
            var y = 15;
            var grid = new GameGrid(x, y);
           

            Assert.AreEqual(x, grid.Width);
            Assert.AreEqual(y, grid.Height);
        }



    }
}
