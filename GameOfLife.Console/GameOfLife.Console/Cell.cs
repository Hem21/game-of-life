using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Console
{
    public class Cell
    {
        int XPosition;
        int YPosition;
        bool CellStatus;



        public Cell(int xPosition, int yPosition, bool cellStatus)
        {
            this.XPosition = xPosition;
            this.YPosition = yPosition;
            this.CellStatus = cellStatus;

        }

        public int GetCellXPosition()
        {
            return XPosition;
        }

        public int GetCellYPosition()
        {
            return YPosition;
        }

        public bool GetCellStatus()
        {
            return CellStatus;
        }

    }
}
