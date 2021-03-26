namespace GameOfLife.Service.Models
{
    public class SetGridModel
    {
        public bool[,] Grid { get; set; }
        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }
    }
}
