using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeAndLadderGame
{
    internal class SnakeLadderUC2
    {
        public static void Start()
        {
            //implementing single player start at 0.
            //variables
            int position = 0;
            int playerOne;
            //initialize player
            playerOne = position;
            Console.WriteLine($"player One position is {playerOne}");
            playerOne = RollDie();
            Console.WriteLine($"player One rolls die and get position {playerOne}");
        }
        public static int RollDie()
        {
            //Roll die to produce random number between 1-6
            Random random = new Random();
            int dice = random.Next(1, 7);
            return dice;
        }
        //start of game 
        public static void Board()
        {
            //at the start
            Start();

        }
    }
}
