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
        [HttpPost ("creategrid")]
        public IActionResult CreateGrid([FromBody]GridModel gridModel)
        {
            var row = int.Parse(gridModel.Row);
            var column = int.Parse(gridModel.Column);

            var game = new Game();
            var grid = game.CreateGrid(row, column);
            var jsonGrid = JsonConvert.SerializeObject(grid);
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
        public IActionResult UpdateGrid([FromBody]bool[,] grid)
        {
            var updatedGrid = Game.UpdateGrid(grid);
            return Ok(updatedGrid);
            //var jsonGrid = JsonConvert.SerializeObject(updatedGrid);
            //return new OkObjectResult(jsonGrid);
        }
    }
}
