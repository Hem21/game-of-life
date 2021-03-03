using System;

namespace GameOfLife.Console
{
    public enum Status { Dead = 0, Alive }

    public struct Cell
    {
        public Status SetAlive { get; }

        public Cell(Status setAlive)
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
                    throw new ArgumentException("Invalid State");
            }
        }
    }
}
