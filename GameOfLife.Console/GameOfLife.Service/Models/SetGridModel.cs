using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameOfLife.Service.Models
{
    public class SetGridModel
    {
        public List<List<bool>> Grid { get; set; }
        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }
    }
}
