using System;

namespace GameOfLife.Console
{
    class Program
    {
        static void Main(string[] args)
        { 
            Game game = new Game();

            //game.SetGrid();

            var grid = game.CreateGrid(2,3);

            game.StaysAlive(grid);

           


        }
    }
}
