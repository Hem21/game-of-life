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
            var cell = new Cell
            {
                Status = true
            };

            var status = cell.Status;

            Assert.IsTrue(status);
        }

        [TestMethod]
        public void CreateGridWithLiveCell()
        {

            var game = new Game();
            var grid = game.CreateGrid(2,3);
            var updatedGrid = Game.SetCell(grid, 0, 0);

            var expectedGrid = new bool[2,3] { { true, false, false },{ false, false, false } };

            CollectionAssert.AreEqual(expectedGrid, updatedGrid);
            Assert.ThrowsException<Exception>(() => Game.SetCell(grid, 1000, 5));
        }

        [TestMethod]
        public void WhenCellSelectIsOutOfRangeThenReturnGridUnchanged()
        {

            var game = new Game();
            var grid = game.CreateGrid(2, 3);

            Assert.ThrowsException<Exception>(() => Game.SetCell(grid, 1000, 5));
        }
        /*
                [TestMethod]
                public void WhenCellCreatedWithInvalidStatusThenExceptionIsThrown()
                {
                    //test if exception is thrown with invalid status?
                }

                [TestMethod]
                public void WhenCellIsSelectedThenStatusChangesToAlive()
                {
                    var game = new Game();
                    var grid = game.CreateGrid(2,2);

                    var updatedGrid = game.SetCell(Status.Alive, grid, 0, 1);

                    var alive = new Cell(Status.Alive);
                    var dead = new Cell(Status.Dead);
                    var expectedValue = new Cell[,] { { dead, alive }, { dead, dead } };

                    CollectionAssert.AreEqual(expectedValue, updatedGrid);
                }

                [TestMethod]
                public void WhenCellSelectIsOutOfRangeThenReturnGridUnchanged()
                {
                    //test if exception is thrown with invalid status instead??
                }

                //Any live cell with fewer than two live neighbours dies, as if by underpopulation.
                [TestMethod]
                public void WhenCellHasOneAliveNeighbourInItsRowThenDiesAfterOneIteration()
                {

                    var game = new Game();
                    var grid = game.CreateGrid(2, 3);

                    game.SetCell(Status.Alive, grid, 0, 1);
                    var gameGrid = game.SetCell(Status.Alive, grid, 0, 2);
                    var stayAlive = game.StaysAlive(gameGrid);

                    var alive = new Cell(Status.Alive);
                    var dead = new Cell(Status.Dead);
                    var expectedGrid = new Cell[,] { { dead, dead, dead }, { dead, dead, dead } };

                    CollectionAssert.AreEqual(expectedGrid, stayAlive);


                }
                */
    }
}
