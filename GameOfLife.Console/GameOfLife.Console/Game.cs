using System;

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
                throw new Exception("Cell selected is not in range");
            }

            grid[row, column] = true;

            return grid;
        }

        public static object CheckBeforeCellInRow(bool[,] grid)
        {
            var row = grid.GetLength(0);
            var column = grid.GetLength(1);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    var value = grid[i, j];
                    var valueBefore = grid[i, j - 1];

                    if (j == column - 1)
                    {
                        if (valueBefore.Equals(true))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static object CheckAfterCellInRow(bool[,] grid)
        {
            var row = grid.GetLength(0);
            var column = grid.GetLength(1);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    var value = grid[i, j];
                    var valueAfter = grid[i, j + 1];

                    if (j == column + 1)
                    {
                        if (valueAfter.Equals(true))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
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





        /*public static bool[,] CheckRow(bool[,] grid)
{
    var row = grid.GetLength(0);
    var column = grid.GetLength(1);
    //checking row
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < column; j++)
        {
            var value = grid[i,j].Equals(true);

            if (j == 0)
            {
                var valueAfter = grid[i, j + 1].Equals(true);
                if (value && valueAfter)
                {
                    grid.SetValue(false, i, j);
                }
            }
            else if (j == column - 1)
            {
                var valueBefore = grid[i, j - 1].Equals(true);
                if (value && valueBefore)
                {
                    grid.SetValue(false, i, j);
                }
            }
            else
            {
                var valueBefore = grid[i, j - 1].Equals(true);
                var valueAfter = grid[i, j + 1].Equals(true);

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