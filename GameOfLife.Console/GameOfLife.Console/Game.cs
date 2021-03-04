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
            int row = selectRowPosition;
            int column = selectColumnPosition;
            if (row < 0 || row > grid.GetLength(0) || column < 0 || column > grid.GetLength(1))
            {
                throw new Exception("Cell selected is not in range");
            }

            grid[row, column] = true;

            return grid;
        }

        public static int CheckCellRowNeighbours(int rowNumber, bool[,] grid)
        {
            int SumOfRowNeighbours = 0;

            var numOfColumns = grid.GetLength(0);
            var rowLength = grid.GetLength(1);

            //checking row
            for (int i = 0; i < numOfColumns; i++)
            {

                for (int j = 0; j < rowLength; j++)
                {
                    if (j == rowNumber)
                    {

                        if (j == 0)
                        {
                            var valueAfter = grid[i, j + 1];
                            if (valueAfter.Equals(true))
                            {
                                SumOfRowNeighbours += 1;
                            }
                        }
                        else if (j == rowLength - 1)
                        {
                            var valueBefore = grid[i, j - 1];
                            if (valueBefore.Equals(true))
                            {
                                SumOfRowNeighbours += 1;
                            }
                        }
                        else
                        {
                            var valueBefore = grid[i, j - 1].Equals(true);
                            var valueAfter = grid[i, j + 1].Equals(true);

                            if (valueBefore.Equals(true) && valueAfter.Equals(true))
                            {
                                SumOfRowNeighbours += 2;
                                break;
                            }
                            else if (valueBefore.Equals(true) || valueAfter.Equals(true))
                            {
                                SumOfRowNeighbours += 1;
                                break;
                            }
                            else if (!valueBefore.Equals(true) && !valueAfter.Equals(true))
                            {
                                SumOfRowNeighbours += 0;
                                break;
                            }

                        }
                    }
                }
            }

            return SumOfRowNeighbours;
        }

        public static bool[,] UpdateGrid(bool[,] grid)
        {
            int sumOfNeighbours = 0;
            for (int i = 0; i < grid.GetLength(0); i++) 
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    sumOfNeighbours = CheckCellRowNeighbours(j, grid);
                    if (sumOfNeighbours < 2) 
                    {
                        grid.SetValue(false, i, j);
                    }
                }
            }

            return grid;
        }

        /*
        public static int CheckColumnNeighbours(bool[,] grid)
        {
            var row = grid.GetLength(0);
            var column = grid.GetLength(1);
            int SumOfColumnNeighbours = 0;

            //checking column
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {

                    if (i == 0)
                    {
                        var valueAfter = grid[i + 1, j];
                        if (valueAfter.Equals(true))
                        {
                            SumOfColumnNeighbours += 1;
                            break;
                        }
                    }
                    else if (i == row - 1)
                    {
                        var valueBefore = grid[i - 1, j];
                        if (valueBefore.Equals(true))
                        {
                            SumOfColumnNeighbours += 1;
                            break;
                        }
                    }
                    else
                    {
                        var valueBefore = grid[i - 1, j].Equals(true);
                        var valueAfter = grid[i + 1, j].Equals(true);

                        if (valueBefore.Equals(true))
                        {
                            SumOfColumnNeighbours += 1;
                        }
                        else if (valueAfter.Equals(true))
                        {
                            SumOfColumnNeighbours += 1;
                        }

                    }
                }
            }

            return SumOfColumnNeighbours;
        }
        */
    }
}