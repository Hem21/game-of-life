﻿using System;

namespace GameOfLife.Console
{
    public class Game
    {

        public bool[,] CreateGrid(int xAxis, int yAxis)
        {
            if (xAxis < 0 || yAxis < 0)
            {
                throw new Exception("Invalid grid inputs");
            }

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

            var cell = grid[row, column];

            if (cell == false)
            {
                cell = true;
            }
            else
            {
                cell = false;
            }

            grid[row, column] = cell;

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
                    else if (j == columns - 1)
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

        public static int CheckColumnAboveAndBelowNeighbors(int rowNumber, int columnNumber, bool[,] grid)
        {
            var rows = grid.GetLength(0);
            var columns = grid.GetLength(1);
            var sumOfColumnNeighbors = 0;

            //checking column
            for (var i = 0; i < columns; i++)
            {

                for (var j = 0; j < rows; j++)
                {
                    var isNotRow = i != rowNumber;
                    var isNotColumn = j != columnNumber;
                    if (isNotRow || isNotColumn) continue;
                    if (i == 0)
                    {
                        var valueBelow = grid[i + 1, j];
                        if (valueBelow.Equals(true))
                        {
                            sumOfColumnNeighbors += 1;
                        }
                    }
                    else if (i == columns - 1)
                    {
                        var valueAbove = grid[i - 1, j];
                        if (valueAbove.Equals(true))
                        {
                            sumOfColumnNeighbors += 1;
                        }
                    }
                    else
                    {
                        var valueAbove = grid[i - 1, j].Equals(true);
                        var valueBelow = grid[i + 1, j].Equals(true);

                        if (valueAbove.Equals(true) && valueBelow.Equals(true))
                        {
                            sumOfColumnNeighbors += 2;
                        }
                        else if (valueAbove.Equals(true) || valueBelow.Equals(true))
                        {
                            sumOfColumnNeighbors += 1;
                        }
                        else if (!valueAbove.Equals(true) && !valueBelow.Equals(true))
                        {
                            sumOfColumnNeighbors += 0;
                        }

                    }
                }
            }

            return sumOfColumnNeighbors;
        }

        public static int CheckColumnDiagonalNeighbors(int rowNumber, int columnNumber, bool[,] grid)
        {
            var rows = grid.GetLength(0);
            var columns = grid.GetLength(1);
            var sumOfColumnNeighbors = 0;

            //checking column
            for (var i = 0; i < columns; i++)
            {

                for (var j = 0; j < rows; j++)
                {
                    var isNotRow = i != rowNumber;
                    var isNotColumn = j != columnNumber;
                    if (isNotRow || isNotColumn) continue;
                    if (i == 0)
                    {
                        if (j == 0)
                        {
                            var valueDiagBelowAfter = grid[i + 1, j + 1];
                            if (valueDiagBelowAfter.Equals(true))
                            {
                                sumOfColumnNeighbors += 1;
                            }
                        }
                        else if (j == rows - 1)
                        {
                            var valueDiagBelowBefore = grid[i + 1, j - 1];
                            if (valueDiagBelowBefore.Equals(true))
                            {
                                sumOfColumnNeighbors += 1;
                            }
                        }
                        else
                        {
                            var valueDiagBelowBefore = grid[i + 1, j - 1].Equals(true);
                            var valueDiagBelowAfter = grid[i + 1, j + 1].Equals(true);
                            if (valueDiagBelowAfter && valueDiagBelowBefore)
                            {
                                sumOfColumnNeighbors += 2;
                            }
                            else if (valueDiagBelowBefore || valueDiagBelowAfter)
                            {
                                sumOfColumnNeighbors += 1;
                            }
                            else
                            {
                                sumOfColumnNeighbors += 0;
                            }
                        }
                    }
                    else if (i == (columns - 1))
                    {
                        if (j == 0)
                        {
                            var valueDiagAboveAfter = grid[i - 1, j + 1];
                            if (valueDiagAboveAfter.Equals(true))
                            {
                                sumOfColumnNeighbors += 1;
                            }
                        }
                        else if (j == rows - 1)
                        {
                            var valueDiagAboveBefore = grid[i - 1, j - 1];
                            if (valueDiagAboveBefore.Equals(true))
                            {
                                sumOfColumnNeighbors += 1;
                            }
                        }
                        else
                        {
                            var valueDiagAboveBefore = grid[i - 1, j - 1].Equals(true);
                            var valueDiagAboveAfter = grid[i - 1, j + 1].Equals(true);
                            if (valueDiagAboveBefore && valueDiagAboveAfter)
                            {
                                sumOfColumnNeighbors += 2;
                            }
                            else if (valueDiagAboveBefore || valueDiagAboveAfter)
                            {
                                sumOfColumnNeighbors += 1;
                            }
                            else
                            {
                                sumOfColumnNeighbors += 0;
                            }
                        }
                    }
                    else
                    {
                        if (j == 0)
                        {
                            var valueDiagAboveAfter = grid[i - 1, j + 1].Equals(true);
                            var valueDiagBelowAfter = grid[i + 1, j + 1].Equals(true);
                            if (valueDiagAboveAfter.Equals(true) && valueDiagBelowAfter)
                            {
                                sumOfColumnNeighbors += 2;
                            }
                            else if (valueDiagBelowAfter || valueDiagAboveAfter)
                            {
                                sumOfColumnNeighbors += 1;
                            }
                            else
                            {
                                sumOfColumnNeighbors += 0;
                            }
                        }
                        else if (j == rows - 1)
                        {
                            var valueDiagAboveBefore = grid[i - 1, j - 1].Equals(true);
                            var valueDiagBelowBefore = grid[i + 1, j - 1].Equals(true);
                            if (valueDiagAboveBefore && valueDiagBelowBefore)
                            {
                                sumOfColumnNeighbors += 2;
                            }
                            else if (valueDiagAboveBefore || valueDiagBelowBefore)
                            {
                                sumOfColumnNeighbors += 1;
                            }
                            else
                            {
                                sumOfColumnNeighbors += 0;
                            }
                        }
                        else
                        {

                            var valueDiagBelowBefore = grid[i + 1, j - 1].Equals(true);
                            var valueDiagBelowAfter = grid[i + 1, j + 1].Equals(true);
                            var valueDiagAboveBefore = grid[i - 1, j - 1].Equals(true);
                            var valueDiagAboveAfter = grid[i - 1, j + 1].Equals(true);

                            if (valueDiagBelowBefore && valueDiagBelowAfter && valueDiagAboveBefore &&
                                valueDiagAboveAfter)
                            {
                                sumOfColumnNeighbors += 4;
                            }
                            else if ((valueDiagBelowBefore && valueDiagBelowAfter && valueDiagAboveBefore) ||
                                     (valueDiagBelowBefore && valueDiagBelowAfter && valueDiagAboveAfter) ||
                                     (valueDiagBelowBefore && valueDiagAboveAfter && valueDiagAboveBefore) ||
                                     (valueDiagAboveBefore && valueDiagBelowAfter && valueDiagAboveAfter))
                            {
                                sumOfColumnNeighbors += 3;
                            }
                            else if ((valueDiagBelowBefore && valueDiagBelowAfter) ||
                                     (valueDiagBelowBefore && valueDiagAboveBefore) ||
                                     (valueDiagBelowBefore && valueDiagAboveAfter) ||
                                     (valueDiagBelowAfter && valueDiagAboveBefore) ||
                                     (valueDiagBelowAfter && valueDiagAboveAfter) ||
                                     (valueDiagAboveBefore && valueDiagAboveAfter))
                            {
                                sumOfColumnNeighbors += 2;
                            }
                            else if (valueDiagBelowBefore || valueDiagBelowAfter || valueDiagAboveBefore ||
                                     valueDiagAboveAfter)
                            {
                                sumOfColumnNeighbors += 1;
                            }
                            else
                            {
                                sumOfColumnNeighbors += 0;
                            }
                        }
                    }
                }
            }

            return sumOfColumnNeighbors;
        }

        public static bool[,] UpdateGrid(bool[,] grid)
        {
            var columns = grid.GetLength(0);
            var rows = grid.GetLength(1);
            var updatedGrid = new bool[columns, rows];

            for (var i = 0; i < columns; i++)
            {
                for (var j = 0; j < rows; j++)
                {
                    var sumOfRowNeighbors = CheckRowNeighbors(i, j, grid);
                    var sumOfColumnNeighbors = CheckColumnAboveAndBelowNeighbors(i, j, grid);
                    var sumOfDiagonalNeighbors = CheckColumnDiagonalNeighbors(i, j, grid);
                    var sumOfNeighbors = sumOfRowNeighbors + sumOfColumnNeighbors + sumOfDiagonalNeighbors;

                    var cellStatus = grid.GetValue(i, j);

                    if (cellStatus.Equals(true))
                    {
                        if (sumOfNeighbors < 2)
                        {
                            updatedGrid.SetValue(false, i, j);
                        }
                        else if (sumOfNeighbors <= 3)
                        {
                            updatedGrid.SetValue(true, i, j);
                        }
                        else
                        {
                            updatedGrid.SetValue(false, i, j);
                        }
                    }
                    else
                    {
                        if (sumOfNeighbors == 3)
                        {
                            updatedGrid.SetValue(true, i, j);
                        }
                        else
                        {
                            updatedGrid.SetValue(false, i, j);
                        }
                    }
                }
            }

            return updatedGrid;
        }
    }
}