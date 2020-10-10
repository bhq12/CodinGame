using System;
using System.Collections.Generic;
using System.Text;

namespace FantasticBits
{
    public class Coordinate
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Coordinate(int x, int y) {
            X = x;
            Y = y;
        }
    }
}
