using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Console
{
    public class Game
    {

        public bool[,] CreateGrid(int xAxis, int yAxis)
        {
            return new bool[xAxis, yAxis];
        }

        public static bool[,] SetCell(bool[,] grid, int selectRowPosition, int selectColumn)
        {
            int row = selectRowPosition;
            int column = selectColumn;
            if (row < 0 || row > grid.GetLength(0) || column < 0 || column > grid.GetLength(1))
            {
                throw new Exception("Cell ...");
            }

            grid[row, column] = true;

            return grid;
        }
/*
        public Cell[,] StaysAlive(Cell[,] grid)
        {
            var row = grid.GetLength(0);
            var column = grid.GetLength(1);
            //checking row
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    var firstValue = grid[i,j].Equals(Status.Alive);
                    var secondValue = grid[i, j + 1].Equals(Status.Alive);
                    if (firstValue && secondValue)
                    {
                        grid.SetValue(Status.Dead, i, j);
                    }
                }
            }

            return grid;
        }
*/
    }
}