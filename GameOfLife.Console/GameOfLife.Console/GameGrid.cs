using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Console
{
    public class GameGrid
    {

        public int XAxis;
        public int YAxis;

        public GameGrid()
        {
            this.XAxis = 5;
            this.YAxis = 5;
        }

        public GameGrid(int xAxis, int yAxis)
        {
            this.XAxis = xAxis;
            this.YAxis = yAxis;
        }

        public bool[,] CreateGrid(int xAxis, int yAxis)
        {
            return new bool[xAxis, yAxis];
        }

        public bool[,] SetCell(int xAxis, int yAxis, Cell NewCell)
        {
            var grid = CreateGrid(xAxis, yAxis);

            var CellX = NewCell.GetCellXPosition();
            var CellY = NewCell.GetCellYPosition();
            var CellStatus = NewCell.GetCellStatus();

            var GridX = grid.GetLength(0);
            var GridY = grid.GetLength(1);

            for (int column = 0; column < GridX; column++)
            {
                for (int row = 0; row < GridY; row++)
                {
                    if ((CellX == column) && (CellY == row))
                    {
                        grid[column, row] = CellStatus;
                        break;
                    }
                }
            
            }
            
            return grid;        
        }
    }
}