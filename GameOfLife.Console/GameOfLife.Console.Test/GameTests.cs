using Microsoft.VisualStudio.TestTools.UnitTesting;

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

            var status = Status.Dead;
            var cell = new Cell(status);

            Assert.AreEqual("D", cell.ToString());
        }

        [TestMethod]
        public void CanCreateNewCellWithAliveStatus()
        {

            var status = Status.Alive;
            var cell = new Cell(status);

            Assert.AreEqual("A", cell.ToString());
        }

        [TestMethod]
        public void WhenCellCreatedWithInvalidStatusThenExceptionIsThrown()
        {
            //test if exception is thrown with invalid status?
        }

        //Any live cell with fewer than two live neighbours dies, as if by underpopulation.
        [TestMethod]
        public void WhenCellHasTwoAliveNeighboursInItsRowThenStaysAliveAfterOneIteration()
        {
            var game = new Game();
            var alive = new Cell(Status.Alive);
            var dead = new Cell(Status.Dead);

            var grid = new Cell[,] { { alive, alive, alive }, { dead, dead, dead } };

            var stayAlive = game.StaysAlive(grid);

            var expectedValue = new Cell[,] { { dead, alive, dead }, { dead, dead, dead } };

            CollectionAssert.AreEqual(expectedValue, stayAlive);


        }
    }
}
