using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using FantasticBits.src;
using FantasticBits.src.Model.Entities;

namespace FantasticBits
{

    /**
     * Grab Snaffles and try to throw them through the opponent's goal!
     * Move towards a Snaffle and use your team id to determine where you need to throw it.
     **/
    class Program
    {
        static void Main(string[] args) {



            // game loop
            while (true) {

                var gameState = ParseCurrentGameStateInput();

                for (int i = 0; i < 2; i++) {

                    // Write an action using Console.WriteLine()
                    // To debug: Console.Error.WriteLine("Debug messages...");


                    // Edit this line to indicate the action for each wizard (0 ≤ thrust ≤ 150, 0 ≤ power ≤ 500)
                    // i.e.: "MOVE x y thrust" or "THROW x y power"
                    Console.WriteLine("MOVE 8000 3750 100");
                }
            }
        }

        public static GameState ParseCurrentGameStateInput() {
            string[] inputs;
            int myTeamId = int.Parse(Console.ReadLine()); // if 0 you need to score on the right of the map, if 1 you need to score on the left
            inputs = Console.ReadLine().Split(' ');
            int myScore = int.Parse(inputs[0]);
            int myMagic = int.Parse(inputs[1]);
            inputs = Console.ReadLine().Split(' ');
            int opponentScore = int.Parse(inputs[0]);
            int opponentMagic = int.Parse(inputs[1]);
            int entities = int.Parse(Console.ReadLine()); // number of entities still in game

            var gameState = new GameState(myScore, opponentScore, myMagic, opponentMagic, entities);

            for (int i = 0; i < entities; i++) {
                inputs = Console.ReadLine().Split(' ');
                int entityId = int.Parse(inputs[0]); // entity identifier
                string entityType = inputs[1]; // "WIZARD", "OPPONENT_WIZARD" or "SNAFFLE" (or "BLUDGER" after first league)
                int x = int.Parse(inputs[2]); // position
                int y = int.Parse(inputs[3]); // position
                int vx = int.Parse(inputs[4]); // velocity
                int vy = int.Parse(inputs[5]); // velocity
                int state = int.Parse(inputs[6]); // 1 if the wizard is holding a Snaffle, 0 otherwise

                if (entityType == "WIZARD") {
                    var wizard = new Wizard(entityId, x, y, 400/*wizards are radius 400 according to game definition*/, vx, vy, state, entityType);
                    gameState.Wizards.Add(wizard);
                }
                else if (entityType == "OPPONENT_WIZARD") {
                    var wizard = new Wizard(entityId, x, y, 400/*wizards are radius 400 according to game definition*/, vx, vy, state, entityType);
                    gameState.OpponentWizards.Add(wizard);
                }
                else if (entityType == "SNAFFLE") {
                    var snaffle = new Snaffle(entityId, x, y, 150/*snaffled are radius 400 according to game definition*/, vx, vy, state);
                    gameState.Snaffles.Add(snaffle);
                }
                else if (entityType == "BLUDGER") {
                    var bludger = new Bludger(entityId, x, y, 0/*unknown, snaffles not unlocked until next level*/, vx, vy, state);
                    gameState.Bludgers.Add(bludger);
                }
            }

            return gameState;


        }
    }
}