using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Console
{
    public class Game
    {

        public Grid[,] CreateGrid(int xAxis, int yAxis)
        { 
            return new Grid[xAxis, yAxis];
        }

        public void DisplayGrid(Grid[,] grid)
        {

            var row = grid.GetLength(0);
            var column = grid.GetLength(1);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    System.Console.Write(string.Format("{0} ", grid[i, j]));
                }
                System.Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }


        public bool SetCell(Status setAlive, Grid[,] grid)
        {

            System.Console.WriteLine("Enter row and column number (e.g 3,4) to select live cell");

            string PlayerInput = System.Console.ReadLine();
            string[] Parts = PlayerInput.Split(',');
            if (Parts.Length != 2) { return false; }
            int.TryParse(Parts[0], out int row);
            int.TryParse(Parts[1], out int column);

            if (row < 1 || row > grid.GetLength(0) || column < 1 || column > grid.GetLength(1)) {
                return false;
            }

            grid[row - 1, column - 1] = new Grid(setAlive);
            return true;
        }

        public void SetGrid()
        {

            System.Console.WriteLine("Enter row length and column number (e.g 3,4) to create grid");

            string PlayerInput = System.Console.ReadLine();
            string[] Parts = PlayerInput.Split(',');
            int.TryParse(Parts[0], out int row);
            int.TryParse(Parts[1], out int column);
            Status setAlive = Status.Alive;

            var grid = CreateGrid(row, column);

            bool newCell = true;

            while (newCell) {
                DisplayGrid(grid);
                newCell = SetCell(setAlive, grid);
                if (!newCell) {
                    return;
                }
            }
        }

    }
}