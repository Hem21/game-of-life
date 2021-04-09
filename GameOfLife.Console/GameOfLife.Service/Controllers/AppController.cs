using GameOfLife.Console;
using GameOfLife.Service.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAppExample.Models;

namespace WebAppExample.Controllers
{
    [ApiController]
    public class AppController : ControllerBase
    {
        [HttpPost("creategrid")]
        public IActionResult CreateGrid([FromBody] GridModel gridModel)
        {

            int row;
            int column;

            int rowParsed;
            int columnParsed;

            if (int.TryParse(gridModel.Row, out row))
            {
                rowParsed = row;
            }
            else
            {
                throw new System.Exception("Invalid row number entered");
            }

            if (int.TryParse(gridModel.Column, out column))
            {
                columnParsed = column;
            }
            else
            {
                throw new System.Exception("Invalid column number entered");
            }


            var game = new Game();
            var grid = game.CreateGrid(rowParsed, columnParsed);
            var jsonGrid = JsonConvert.SerializeObject(grid);
            return new OkObjectResult(jsonGrid);
        }

        [HttpPost("getstartgrid")]
        public IActionResult GetStartGrid([FromBody] StartGridModel startGridModel)
        {
            var gridName = startGridModel.gridName;
            var startGrid = Game.GetStartGrid(gridName);
            var jsonGrid = JsonConvert.SerializeObject(startGrid);
            return new OkObjectResult(jsonGrid);
        }

        [HttpPost("setcells")]
        public IActionResult SetCells([FromBody] SetGridModel setGridModel)
        {
            var rowPosition = setGridModel.RowIndex;
            var columnPosition = setGridModel.ColumnIndex;
            var grid = setGridModel.Grid;

            var setGrid = Game.SetCell(grid, rowPosition, columnPosition);
            var jsonGrid = JsonConvert.SerializeObject(setGrid);
            return new OkObjectResult(jsonGrid);
        }

        [HttpPost("updategrid")]
        public IActionResult UpdateGrid([FromBody] bool[,] grid)
        {
            var updatedGrid = Game.UpdateGrid(grid);
            return Ok(updatedGrid);
            //var jsonGrid = JsonConvert.SerializeObject(updatedGrid);
            //return new OkObjectResult(jsonGrid);
        }

        [HttpPost("getweathergrid")]
        public IActionResult GetWeatherGrid([FromBody] WeatherGridModel weatherGridModel)
        {
            var gridWeather = weatherGridModel.gridWeatherStatus;
            var weatherGrid = Game.GetWeatherGrid(gridWeather);
            var jsonGrid = JsonConvert.SerializeObject(weatherGrid);
            return new OkObjectResult(jsonGrid);
        }

    }
}
