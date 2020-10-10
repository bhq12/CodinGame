using System;
using System.Collections.Generic;
using System.Text;

namespace FantasticBits.src.Model.Entities
{
    public class Wizard : GameEntity
    {
        public bool IsOpponent { get; set; }

        public Wizard(int id, int x, int y, int radius, int xVelocity, int yVelocity, int state, string entityType): base(id, x, y, radius, xVelocity, yVelocity, state) {
            IsOpponent = true;
            if (entityType == "OPPONENT_WIZARD") {
                IsOpponent = true;
            }
        }
    }
}
