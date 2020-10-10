using System;
using System.Collections.Generic;
using System.Text;

namespace FantasticBits.src.Model.Entities
{
    public class Snaffle : GameEntity
    {
        public Snaffle(int id, int x, int y, int radius, int xVelocity, int yVelocity, int state) : base(id, x, y, radius, xVelocity, yVelocity, state) { 
        }
    }
}
