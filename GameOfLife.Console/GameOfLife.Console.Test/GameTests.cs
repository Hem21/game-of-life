using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.Console.Test
{
    [TestClass]
    public class GameTests
    { 
        [TestMethod]
        public void CanCreateGameGridWithInterchangingValues()
        {
            var xAxis = 25;
            var yAxis = 15;
            var gameGrid = new Game();

            var grid = gameGrid.CreateGrid(25, 15);
           
            Assert.AreEqual(xAxis, grid.GetLength(0));
            Assert.AreEqual(yAxis, grid.GetLength(1));
        }

        [TestMethod]
        public void CanCreateNewGrid()
        {
            var grid = new Grid();

            Assert.IsNotNull(grid);
        }

        [TestMethod]
        public void CanCreateNewGridWithDeadStatus()
        {

            var status = Status.Dead;
            var grid = new Grid(status);

            //Assert.Equals(Status.Dead, );
        }
    }
}
