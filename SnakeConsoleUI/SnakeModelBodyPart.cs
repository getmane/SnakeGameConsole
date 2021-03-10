using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeConsoleUI
{
    public class SnakeModelBodyPart
    {
        public string Fragment { get; set; } = " ";

        public int X { get; set; } = 1;

        public int Y { get; set; } = 1;

        public ConsoleKey Direction { get; set; } = ConsoleKey.RightArrow;

        public int prevX { get; set; } = 1;

        public int prevY { get; set; } = 1;

    }
}
