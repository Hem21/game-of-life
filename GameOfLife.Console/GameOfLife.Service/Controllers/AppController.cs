using GameOfLife.Console;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAppExample.Models;

namespace WebAppExample.Controllers
{
    [ApiController]
    public class AppController : ControllerBase
    {

       //public IActionResult Index()
       // {
       //     return View();
       // }

        
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

    }
}
