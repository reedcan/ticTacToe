using System;

namespace ticTacToe
{

    class Program
    {

        static void Main(string[] args)
        {
            
            bool keepPlaying = true;

            while (keepPlaying)
            {
                string[] spaces = {"1", "2", "3", "4", "5", "6", "7", "8", "9"};
                List<string> listOfSpaces = new List<string>(spaces);

                int turns = -1;

                bool checkWin = false;
                
                drawGrid(listOfSpaces);
                Console.WriteLine("Welcome to Tic Tac Toe! Enter the number (1-9)");
                Console.WriteLine("that indicates the space you would like to mark");

                while (checkWin == false)
                {
                    turns += 1;
                    string currentPlayer = decideCurrentPlayer(turns);
                    Console.WriteLine($"Player {currentPlayer}:");

                    string userChoiceString = Console.ReadLine();
                    int userChoice = int.Parse(userChoiceString);

                    listOfSpaces = updateGrid(listOfSpaces, userChoice, currentPlayer);
                    
                    checkWin = checkForWin(listOfSpaces, currentPlayer);
                }
                if (checkWin == true)
                {
                    Console.WriteLine("Would you like to play again? (y/n): ");
                    string playAgain = Console.ReadLine();

                    if (playAgain == "y")
                    {
                        keepPlaying = true;
                    }
                    else
                    {
                        keepPlaying = false;
                    }
                }


            void drawGrid(List<string> listOfSpaces)
            {
                Console.WriteLine($" {listOfSpaces[0]} | {listOfSpaces[1]} | {listOfSpaces[2]} ");
                Console.WriteLine("---+---+---");
                Console.WriteLine($" {listOfSpaces[3]} | {listOfSpaces[4]} | {listOfSpaces[5]} ");
                Console.WriteLine("---+---+---");
                Console.WriteLine($" {listOfSpaces[6]} | {listOfSpaces[7]} | {listOfSpaces[8]} ");


            }

            List<string> updateGrid(List<string> listOfSpaces, int userChoice, string currentPlayer)
            {
                int indexToChange = userChoice - 1;
                
                listOfSpaces[indexToChange] = currentPlayer;

                drawGrid(listOfSpaces);

                return listOfSpaces;
            }

            bool checkForWin(List<string> listOfSpaces, string currentPlayer)
            {
                if (listOfSpaces[0] == currentPlayer && listOfSpaces [1] == currentPlayer && listOfSpaces[2] == currentPlayer||
                    listOfSpaces[3] == currentPlayer && listOfSpaces [4] == currentPlayer && listOfSpaces[5] == currentPlayer||
                    listOfSpaces[6] == currentPlayer && listOfSpaces [7] == currentPlayer && listOfSpaces[8] == currentPlayer||
                    listOfSpaces[0] == currentPlayer && listOfSpaces [3] == currentPlayer && listOfSpaces[6] == currentPlayer||
                    listOfSpaces[1] == currentPlayer && listOfSpaces [4] == currentPlayer && listOfSpaces[7] == currentPlayer||
                    listOfSpaces[2] == currentPlayer && listOfSpaces [5] == currentPlayer && listOfSpaces[8] == currentPlayer||
                    listOfSpaces[0] == currentPlayer && listOfSpaces [4] == currentPlayer && listOfSpaces[8] == currentPlayer||
                    listOfSpaces[2] == currentPlayer && listOfSpaces [4] == currentPlayer && listOfSpaces[6] == currentPlayer)
                    {
                        Console.WriteLine($"Congratulations! {currentPlayer} has won!");

                        return true;
                    }
                
                else if(turns == 8)
                    {
                        Console.WriteLine("It's a draw!");
                        return true;                        
                    }
                
                else
                    {
                        return false;
                    }
                
            }

            string decideCurrentPlayer(int turns)
            {
                if (turns % 2 == 0)
                {
                    return "X";
                }
                else
                {
                    return "O";
                }
            }

            
            }

            }

        }
}
