using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Console
{
    public class Game
    {

        public Cell[,] CreateGrid(int xAxis, int yAxis)
        {
            return new Cell[xAxis, yAxis];
        }

        public void DisplayGrid(Cell[,] grid)
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


        public bool SetCell(Status setAlive, Cell[,] grid)
        {

            System.Console.WriteLine("Enter row and column number (e.g 3,4) to select live cell");

            string PlayerInput = System.Console.ReadLine();
            string[] Parts = PlayerInput.Split(',');
            if (Parts.Length != 2) { return false; }
            int.TryParse(Parts[0], out int row);
            int.TryParse(Parts[1], out int column);

            if (row < 0 || row > grid.GetLength(0) || column < 0 || column > grid.GetLength(1))
            {
                return false;
            }

            grid[row, column] = new Cell(setAlive);
            return true;
        }

        public Cell[,] SetGridSize()
        {
            System.Console.WriteLine("Enter row length and column number (e.g 3,4) to create grid");

            string PlayerInput = System.Console.ReadLine();
            string[] Parts = PlayerInput.Split(',');
            int.TryParse(Parts[0], out int row);
            int.TryParse(Parts[1], out int column);

            var grid = CreateGrid(row, column);

            return grid;
        }

        public void SetGrid()
        {

            var newGrid = SetGridSize();
            Status setAlive = Status.Alive;

            bool @continue = true;
            while (@continue)
            {
                DisplayGrid(newGrid);

                System.Console.Write("Write 'Start' if you want to start the game or 'Add' if you want to continue adding cells >");
                string playerInput = System.Console.ReadLine();

                if (playerInput.Equals("Start"))
                {
                    return;
                }
                else if (playerInput.Equals("Add"))
                {
                    @continue = SetCell(setAlive, newGrid);
                }
                else
                {
                    throw new Exception("This command doesn't exist, try again");
                }
            }

        }

        public Cell[,] StaysAlive(Cell[,] grid)
        {

            //checking row
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j].Equals("A") && (grid[i + 1, j].Equals("A")))
                    {
                        grid.SetValue("D", i);
                    }
                }
            }

            return grid;
        }

    }
}