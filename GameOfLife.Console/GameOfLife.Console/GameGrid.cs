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

        public int GetXAxis()
        {
            return XAxis;
        }

        public int GetYAxis()
        {
            return YAxis;
        }

        public bool[,] CreateGrid(int xAxis, int yAxis)
        {
            return new bool[xAxis, yAxis];
        }

        public bool[,] SetGrid(int xAxis, int yAxis, Cell NewCell)
        {
            var grid = CreateGrid(xAxis, yAxis);

            var CellX = NewCell.GetCellXPosition();
            var CellY = NewCell.GetCellYPosition();
            var CellStatus = NewCell.GetCellStatus();

            var GridX = grid.GetLength(0);
            var GridY = grid.GetLength(1);

            for (int i = 0; i < GridX; i++)
            {
                for (int j = 0; j < GridY; j++)
                {
                    if ((CellX == i) && (CellY == j))
                    {
                        grid[i, j] = CellStatus;
                        break;
                    }
                }
            
            }
            
            return grid;        
        }
    }
}