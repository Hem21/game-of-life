using WebAppExample.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WebAppExample.Models;
using Newtonsoft.Json;

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

            var gridModel = new GridModel() { Row = "1", Column = "1" };

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
    }
}

