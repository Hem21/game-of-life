using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Newtonsoft.Json;
using WebAppExample.Controllers;
using WebAppExample.Models;
using GameOfLife.Service.Models;

namespace GameOfLife.Console.Test
{
    [TestClass]
    public class BackendControllerTest
    {
        [TestMethod]
        public void WhenFrontEndInputsRowsAndColumnsBackEndReturnsOk()
        {
            //Act
            var controller = new AppController();

            var gridModel = new GridModel() { Row = "1", Column = "2" };

            var actual = controller.CreateGrid(gridModel);
            var okResult = actual as OkObjectResult;

            var gridResult = JsonConvert.DeserializeObject<bool[,]>(okResult.Value.ToString());

            // Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.IsInstanceOfType(gridResult, typeof(bool[,]));
        }

        [TestMethod]
        public void WhenFrontEndInputsRowsAndColumnsBackEndArrayWithCorrectLengths()
        {
            var expected = new bool[2, 3];
            var controller = new AppController();

            var gridModel = new GridModel() { Row = "2", Column = "3" };

            var actual = controller.CreateGrid(gridModel);
            var okResult = actual as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            var gridResult = JsonConvert.DeserializeObject<bool[,]>(okResult.Value.ToString());
       
            Assert.IsNotNull(gridResult);
            CollectionAssert.AreEqual(expected, gridResult);
        }

        [TestMethod]
        public void WhenFrontEndSelectsCellsBackEndReturnsOk()
        {
            var controller = new AppController();

            var gridModel = new GridModel() { Row = "1", Column = "2" };

            var grid = controller.CreateGrid(gridModel);
            var okGrid = grid as OkObjectResult;
            var gridDeserialized = JsonConvert.DeserializeObject<bool[,]>(okGrid.Value.ToString());

            var setGridModel = new SetGridModel() { Grid = gridDeserialized, RowIndex = 0, ColumnIndex = 1 };
            var actual = controller.SetCells(setGridModel);
            var okResult = actual as OkObjectResult;

            var setGridResult = JsonConvert.DeserializeObject<bool[,]>(okResult.Value.ToString());
            // Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.IsInstanceOfType(setGridResult, typeof(bool[,]));
        }

        [TestMethod]
        public void WhenFrontEndSelectsCellsBackEndReturnsTrueCells()
        {
            var expected = new bool[1, 2] { { false, true } };
            var controller = new AppController();

            var gridModel = new GridModel() { Row = "1", Column = "2" };

            var grid = controller.CreateGrid(gridModel);
            var okGrid = grid as OkObjectResult;
            var gridDeserialized = JsonConvert.DeserializeObject<bool[,]>(okGrid.Value.ToString());

            var setGridModel = new SetGridModel() { Grid = gridDeserialized, RowIndex = 0, ColumnIndex = 1 };
            var actual = controller.SetCells(setGridModel);
            var okResult = actual as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            var setGridResult = JsonConvert.DeserializeObject<bool[,]>(okResult.Value.ToString());
            // Assert
            Assert.IsNotNull(setGridResult);
            CollectionAssert.AreEqual(expected, setGridResult);
        }

        [TestMethod]
        public void WhenFrontEndClicksNextButtonBackEndReturnsUpdatedGrid()
        {
            var expected = new bool[2, 2] { { false , false }, { false, false } };
            var controller = new AppController();

            var gridModel = new GridModel() { Row = "2", Column = "2" };

            var grid = controller.CreateGrid(gridModel);
            var okGrid = grid as OkObjectResult;
            var gridDeserialized = JsonConvert.DeserializeObject<bool[,]>(okGrid.Value.ToString());

            var setGridModel = new SetGridModel() { Grid = gridDeserialized, RowIndex = 0, ColumnIndex = 1 };
            var setGrid = controller.SetCells(setGridModel);
            var okSetGrid = setGrid as OkObjectResult;

            var setGridDeserialized = JsonConvert.DeserializeObject<bool[,]>(okSetGrid.Value.ToString());
            var updatedGrid = controller.UpdateGrid(setGridDeserialized);
            var okUpdatedGrid = updatedGrid as OkObjectResult;

            Assert.IsNotNull(okUpdatedGrid);
            Assert.AreEqual(200, okUpdatedGrid.StatusCode);

            var updatedGridResult = JsonConvert.DeserializeObject<bool[,]>(okUpdatedGrid.Value.ToString());
            // Assert
            Assert.IsNotNull(updatedGridResult);
            CollectionAssert.AreEqual(expected, updatedGridResult);
        }



    }
}

