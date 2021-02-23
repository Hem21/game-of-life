using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Console
{
    public class GameGrid
    {

        public int Width;
        public int Height;

        public GameGrid()
        {
            this.Width = 5;
            this.Height = 5;
        }

        public GameGrid(int gridWidth, int gridHeight)
        {
            this.Width = gridWidth;
            this.Height = gridHeight;
        }

        public int getWidth()
        {
            return Width;
        }

        public int getHeight()
        {
            return Height;
        }
       

    }
}
