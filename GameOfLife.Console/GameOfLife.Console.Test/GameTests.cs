using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.Console.Test
{
    [TestClass]
    public class GameTests
    { 
        [TestMethod]
        public void CanCreateGridWithInterchangingValues()
        {
            var xAxis = 25;
            var yAxis = 15;
            var gameGrid = new Game();

            var grid = gameGrid.CreateGrid(25, 15);
           
            Assert.AreEqual(xAxis, grid.GetLength(0));
            Assert.AreEqual(yAxis, grid.GetLength(1));
        }
    }
}
