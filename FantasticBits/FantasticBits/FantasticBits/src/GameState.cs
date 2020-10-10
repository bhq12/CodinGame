using FantasticBits.src.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasticBits.src
{
    public class GameState
    {
        // if 0 you need to score on the right of the map, if 1 you need to score on the left
        public int TeamId { get; set; }
        
        public int Score { get; set; }

        public int OpponentScore { get; set; }

        public int Magic { get; set; }

        // number of entities still in game
        public int EntityCount { get; set; }

        public int OpponentMagic { get; set; }

        public List<Wizard> Wizards { get; set; }

        public List<Wizard> OpponentWizards { get; set; }

        public List<Snaffle> Snaffles { get; set; }

        public List<Bludger> Bludgers{ get; set; }

        public GameState(int teamId, int score, int opponentScore, int magic, int opponentMagic, int entityCount) {
            TeamId = teamId;
            Score = score;
            OpponentScore = opponentScore;

            Magic = magic;
            OpponentMagic = opponentMagic;

            EntityCount = entityCount;

            Wizards = new List<Wizard>();
            OpponentWizards = new List<Wizard>();
            Snaffles = new List<Snaffle>();
            Bludgers = new List<Bludger>();
        }
    }
}
