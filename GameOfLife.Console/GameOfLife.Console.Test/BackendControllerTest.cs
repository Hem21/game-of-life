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
        public void WhenFrontEndSelectscelssBackEndReturnsTrueCells()
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
    }
}

