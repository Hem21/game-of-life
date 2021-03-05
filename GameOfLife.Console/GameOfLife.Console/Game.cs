using System;

namespace GameOfLife.Console
{
    public class Game
    {

        public bool[,] CreateGrid(int xAxis, int yAxis)
        {
            return new bool[xAxis, yAxis];
        }

        public static bool[,] SetCell(bool[,] grid, int selectRowPosition, int selectColumnPosition)
        {
            var row = selectRowPosition;
            var column = selectColumnPosition;
            if (row < 0 || row > grid.GetLength(0) || column < 0 || column > grid.GetLength(1))
            {
                throw new Exception("Cell selected is not in range");
            }

            grid[row, column] = true;

            return grid;
        }

        public static int CheckRowNeighbors(int rowNumber, int columnNumber, bool[,] grid)
        {
            var sumOfRowNeighbors = 0;

            var rows = grid.GetLength(0);
            var columns = grid.GetLength(1);

            //checking row
            for (var i = 0; i < rows; i++)
            {

                for (var j = 0; j < columns; j++)
                {
                    var isNotRow = i != rowNumber;
                    var isNotColumn = j != columnNumber;
                    if (isNotRow || isNotColumn) continue;
                    if (j == 0)
                    {
                        var valueAfter = grid[i, j + 1];
                        if (valueAfter.Equals(true))
                        {
                            sumOfRowNeighbors += 1;
                        }
                    }
                    else if (j == rows - 1)
                    {
                        var valueBefore = grid[i, j - 1];
                        if (valueBefore.Equals(true))
                        {
                            sumOfRowNeighbors += 1;
                        }
                    }
                    else
                    {
                        var valueBefore = grid[i, j - 1].Equals(true);
                        var valueAfter = grid[i, j + 1].Equals(true);

                        if (valueBefore.Equals(true) && valueAfter.Equals(true))
                        {
                            sumOfRowNeighbors += 2;
                            break;
                        }
                        else if (valueBefore.Equals(true) || valueAfter.Equals(true))
                        {
                            sumOfRowNeighbors += 1;
                            break;
                        }
                        else if (!valueBefore.Equals(true) && !valueAfter.Equals(true))
                        {
                            sumOfRowNeighbors += 0;
                            break;
                        }

                    }
                }
            }

            return sumOfRowNeighbors;
        }

        public static int CheckColumnNeighbors(int columnNumber, bool[,] grid)
        {
            var rows = grid.GetLength(0);
            var columns = grid.GetLength(1);
            var sumOfColumnNeighbors = 0;

            //checking column
            for (var i = 0; i < columns; i++)
            {

                for (var j = 0; j < rows; j++)
                {
                    if (i != columnNumber) continue;
                    if (i == 0)
                    {
                        var valueAfter = grid[i + 1, j];
                        if (valueAfter.Equals(true))
                        {
                            sumOfColumnNeighbors += 1;
                        }
                    }
                    else if (i == columns - 1)
                    {
                        var valueBefore = grid[i - 1, j];
                        if (valueBefore.Equals(true))
                        {
                            sumOfColumnNeighbors += 1;
                        }
                    }
                    else
                    {
                        var valueBefore = grid[i - 1, j].Equals(true);
                        var valueAfter = grid[i + 1, j].Equals(true);

                        if (valueBefore.Equals(true) && valueAfter.Equals(true))
                        {
                            sumOfColumnNeighbors += 2;
                        }
                        else if (valueBefore.Equals(true) || valueAfter.Equals(true))
                        {
                            sumOfColumnNeighbors += 1;
                        }
                        else if (!valueBefore.Equals(true) && !valueAfter.Equals(true))
                        {
                            sumOfColumnNeighbors += 0;
                        }

                    }
                }
            }

            return sumOfColumnNeighbors;
        }

        /*
        public static bool[,] UpdateGrid(bool[,] grid)
        {
            var columns = grid.GetLength(0);
            var rows = grid.GetLength(1);
            var updatedGrid = new bool[columns,rows];

            for (var i = 0; i < columns; i++) 
            {
                for (var j = 0; j < rows; j++)
                {
                    var sumOfNeighbors = CheckRowNeighbors(j, grid);
                    //var sumOfColumnNeighbors = CheckCellColumnNeighbors(i, grid);
                    //var sumOfNeighbors = sumOfRowNeighbors + sumOfColumnNeighbors;
                    if (sumOfNeighbors < 2) 
                    {
                        //create new grid and add new values to it?
                        updatedGrid.SetValue(false, i, j);
                    }
                }
            }

            return updatedGrid;
        }
        
        */
    }
}