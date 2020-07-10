using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Cell
{
    public class Cell
    {
        public int SoldierAmount { get; set; }
        public Color color { get; set; }
    }
    public enum Color{
        Red,
        Black,
        empty
    }
}
