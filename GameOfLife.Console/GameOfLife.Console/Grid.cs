using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Console
{
    public enum Status { Dead = 0, Alive }

    public struct Grid
    {
        public Status SetAlive { get; }

        public Grid(Status setAlive)
        {
            this.SetAlive = setAlive;
        }

        public override string ToString()
        { 
            switch (SetAlive)
            {
                case Status.Dead:
                    return "D";
                case Status.Alive:
                    return "A";
                default:
                    throw new Exception("Inavlid State");
            }
        }


    }
}
