using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeAndLadderGame
{
    internal class SnakeLadderUC7
    {
        public static int PlayGame(int playerPosition, int turn)
        {
            int checkwin; //for checking win
            int position; // position generated randomly
            while (playerPosition != WIN_POSITION) //loop until PlayerOne or PlayerTwo reaches win position
            {
                //check for win condition
                checkwin = CheckWin(playerPosition);
                if (checkwin == 1 && turn == 1) //player One has reached exact 100th position
                {
                    Console.WriteLine($"player One wins!!");// display win message
                    break; //End the game
                }
                if (checkwin == 1 && turn == 0) //player Two has reached exact 100th position
                {
                    Console.WriteLine($"player Two wins!!");// display win message
                    break; //End the game
                }
                if (checkwin == 2) // player reaches over hundred than do No play
                {
                    position = 0;
                }
                else // else continue game
                {
                    position = RollDie();
                }

                // No play condition
                if (position == 0)
                {
                    Console.WriteLine("its a no play");
                    playerPosition += position;// player get no play then remain at same place
                }

                //snake condition
                if (playerPosition == 0 && position < 0) //when player is at start  
                {
                    Console.WriteLine("its a snake bite @ 0");
                    playerPosition = 0; //if player gets snake bite, player remain at same place
                }
                if (playerPosition > 0 && position < 0)
                {
                    Console.WriteLine("its a snake bite");
                    playerPosition += position; //if player is at position less than 6 and gets snake bite
                    if (playerPosition < 0)
                    {
                        //if player position is below 0
                        playerPosition = 0;
                    }
                }

                //ladder condition
                if (position > 0)
                {
                    Console.WriteLine("its a ladder"); //player moves forward
                    playerPosition += position;
                }
                if (playerPosition > WIN_POSITION)//player position is greater than 100
                {
                    playerPosition -= position; // do no play
                }
                if (turn == 1) // player One's turn is over so break the loop
                {
                    Console.WriteLine($"Player One rolls die and gets position {playerPosition}");
                    break;
                }
                if (turn == 0) // player Two's turn is over break the loop
                {
                    Console.WriteLine($"Player Two rolls die and get position {playerPosition}");
                    break;
                }
            }
            return playerPosition; // return player's position
        }

        //constants
        const int WIN_POSITION = 100; //winning position
        const int START_POSITION = 0; // starting position

        public static void Start()
        {
            //implementing single player start at 0.
            //variables
            int player; // record new position of both players
            int playerOne = START_POSITION, playerTwo = START_POSITION;    //initialize players
            Console.WriteLine($"player One position is {playerOne}"); //player 1 -initial position is 0
            Console.WriteLine($"player Two position is {playerTwo}"); //player 2 -initial position is 0
            //Now to make turn for player one and player two creating an infinite loop
            int turn = 1; //to run true condition
            while (true) //infinte condition
            {
                if (turn == 1) // for player One's turn
                {
                    Console.WriteLine(" PLAYER ONE TURN");
                    player = PlayGame(playerOne, turn); //passing player One's position and recording back new position 
                    turn = 0; //switch to player two
                    if (player > playerOne) //checking for ladder if true play again
                    {
                        turn = 1;
                    }
                    playerOne = player; // recording player One's position
                }
                if (playerOne == WIN_POSITION) // checking win condition before giving turn to player two
                {
                    Console.WriteLine("~~~~~~~~PLAYER ONE WINS~~~~~~~");
                    break; // player one wins the game
                }
                if (turn == 0)
                {
                    //playerTwo Turn
                    Console.WriteLine(" PLAYER TWO TURN");
                    player = PlayGame(playerTwo, turn);//passing player Two's position and recording back new position
                    turn = 1; //switch back to player One
                    if (player > playerTwo) //checking for ladder if true play again
                    {
                        turn = 0;
                    }
                    playerTwo = player; // recording player Two's position
                }
                if (playerTwo == WIN_POSITION) //checking for win condition before giving turn to player One
                {
                    Console.WriteLine("~~~~~~~~PLAYER TWO WINS~~~~~~~");
                    break; //player 2 wins the game
                }
            }
        }

        public static int CheckWin(int playerOne)
        {
            if (playerOne == WIN_POSITION) //check for 100th position
                return 1;
            if (playerOne > WIN_POSITION) //check for over 100th position
                return 2;
            else // continue game
                return 0;
        }

        public static int RollDie()
        {
            Random random = new Random();
            int diceThrown = 0;
            int dice, check;
            dice = random.Next(1, 7);
            diceThrown++; //Count number of times dice thrown
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

        //START OF GAME 
        public static  void Board()
        {
            int diceThrown = 0;
            //at the start
            Start();
            //Display dice thrown
            Console.WriteLine($"Number of Times Dice Thrown: {diceThrown}");
        }


    }
}