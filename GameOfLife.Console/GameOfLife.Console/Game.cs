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

        public static int CheckRowNeighbours(bool[,] grid)
        {
            var row = grid.GetLength(0);
            var column = grid.GetLength(1);
            int SumOfRowNeighbours = 0;
            

            //checking row
            for (int i = 0; i < row; i++)
            {

                for (int j = 0; j < column; j++)
                {

                    if (j == 0)
                    {
                        var valueAfter = grid[i, j + 1];
                        if (valueAfter.Equals(true))
                        {
                            SumOfRowNeighbours += 1;
                        }
                    }
                    else if (j == column - 1)
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

                        if (valueBefore.Equals(true) && !valueAfter.Equals(true))
                        {
                            SumOfRowNeighbours += 1;
                        }
                        else if (!valueBefore.Equals(true) && valueAfter.Equals(true))
                        {
                            SumOfRowNeighbours += 1;
                        }
                        else if (valueBefore.Equals(true) && valueAfter.Equals(true))
                        {
                            SumOfRowNeighbours += 1;
                        }

                    }
                }
            }

            return SumOfRowNeighbours;
        }

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


        public static object CheckCellsAndUpgrade(bool [,] grid)
        {
            var row = grid.GetLength(0);
            var column = grid.GetLength(1);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    var value = grid[i, j];
                    var valueBefore = grid[i, j - 1];
                    var valueAfter = grid[i, j + 1];

                    if (value == valueBefore == true || 
                        value == valueAfter == true)
                    {
                        grid.SetValue(false, i, j);

                    }
                    else if (value == valueBefore == true &&
                             value == valueAfter == true)
                    {
                        grid.SetValue(true, i, j);
                    }
                }
            }

            return grid;

        }





 
        /*
public static bool[,] CheckColumn(bool[,] grid)
{
   var row = grid.GetLength(0);
   var column = grid.GetLength(1);

   //checking columns
   for (int i = 0; i < row; i++)
   {
       for (int j = 0; j < column; j++)
       {
           var value = grid[i, j].Equals(true);

           if (i == 0 || i == row - 1)
           {
               if (value)
               {
                   grid.SetValue(false, i, j);
               }
           }
           else
           {
               var valueBefore = grid[i - 1, j].Equals(true);
               var valueAfter = grid[i + 1, j].Equals(true);

               if (value && valueBefore && valueAfter)
               {
                   grid.SetValue(true, i, j);
               }
               else if (value && (!valueBefore && !valueAfter))
               {
                   grid.SetValue(false, i, j);
               }
               else if (value && (valueBefore || valueAfter))
               {
                   grid.SetValue(false, i, j);
               }
           }
       }
   }

   return grid;
}
*/
    }
}