using System;
using System.Collections.Generic;
using System.Text;

namespace FantasticBits
{
    public class GameEntity
    {
        public int Id { get; set; }
        
        public Coordinate Location { get; set; }


        public int Radius { get; set; }

        public int XVelocity { get; set; }

        public int YVelocity { get; set; }

        public int State { get; set; }

        public GameEntity(int id, int x, int y, int radius, int xVelocity, int yVelocity, int state) {
            Id = id;
            Location = new Coordinate(x, y);
            Radius = radius;
            XVelocity = xVelocity;
            YVelocity = yVelocity;
            State = state;
        }
    }
}
