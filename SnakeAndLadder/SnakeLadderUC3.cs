using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeAndLadderGame
{
    internal class SnakeLadderUC3
    {

        public static  void Start()
        {
            //implementing single player start at 0.
            //variables
            int position;
            int playerOne = 3;    //initialize player
            Console.WriteLine($"player One position is {playerOne}");
            position = RollDie();
            // No play condition
            if (position == 0)
            {
                Console.WriteLine("its a no play");
                playerOne += position;// player get no play then remain at same place
            }

            //snake condition
            if (playerOne == 0 && position < 0) //when player is at start  
            {
                Console.WriteLine("its a snake bite @ 0");
                playerOne = 0; //if player gets snake bite, player remain at same place
            }
            if (playerOne > 0 && position < 0)
            {
                Console.WriteLine("its a snake bite");
                playerOne += position; //if player is at position less than 6 and gets snake bite
                if (playerOne < 0)
                {
                    //if player position is below 0
                    playerOne = 0;
                }
            }

            //ladder condition
            if (position > 0)
            {
                Console.WriteLine("its a ladder");
                playerOne += position;
            }

            Console.WriteLine($"player One rolls die and get position {playerOne}");
        }

        
        public static  int RollDie()
        {
            Random random = new Random();
            int dice, check;
            dice = random.Next(1, 7);
            Console.WriteLine($"Dice = {dice}");
            check = CheckPlay();
            //Roll die to produce random number between 1-6
            if (check == 1)
                return -dice; //snake bite
            if (check == 2)
                return dice; //ladder
            else
                return 0; // No play
        }

        public static int CheckPlay()
        {
            Random random = new Random();
            //generate Check play using random
            int check = random.Next(1, 4);
            return check;
        }
        //start of game 
        public static void Board()
        {
            //at the start
            Start();

        }
    }
}
