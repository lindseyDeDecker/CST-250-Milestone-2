using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperClasses
{
    public class Cell
    {
        public bool IsVisited { get; set; }
        public bool IsBomb { get; set; }
        public int AdjacentBombs { get; set; }
        public bool IsFlag { get; set; }

        public Cell()
        {
            IsBomb = false;
            IsVisited = false;
            AdjacentBombs = 0;
            IsFlag = false;
        }

        
    }
}
