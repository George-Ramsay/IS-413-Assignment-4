// See https://aka.ms/new-console-template for more information

using Assignment_4;
using System;
internal class Program
{
    static void Main(string[] args)
    {
        GameTools gameTools = new GameTools();
        Console.WriteLine("Welcome to Tic-Tac-Toe!");
        char[] playerSymbols = [];
        char[] gameBoard = new char[9];
        Array.Fill(gameBoard, '-');

        while (true)
        {
            Console.WriteLine("Player 1: Would you like to be X or O? ");
            string input = Console.ReadLine().ToUpper();
            char playerSymbol1 = !string.IsNullOrEmpty(input) ? input[0] : 'X';
            

            if (playerSymbol1 != 'X' && playerSymbol1 != 'O')
            {
                Console.WriteLine("Sorry, please pick either X or O.");
            }

            else if (playerSymbol1 == 'X')
            {
                Console.WriteLine("Great! Player 1 is X and Player 2 is O.");
                playerSymbols = ['X', 'O'];
                break;
            }
            else
            {
                Console.WriteLine("Great! Player 1 is O and Player 2 is X.");
                playerSymbols = ['O', 'X'];
                break;
            }
        }
        
        bool isFinished = false;
        int currentPlayer = 1;

        while (!isFinished)
        {
            gameTools.PrintBoard();

            while (true)
            {
                Console.WriteLine($"Player {currentPlayer} {playerSymbols[currentPlayer-1]}, please input a number.");
                string inputValue = Console.ReadLine();
                int boardinput;

                if (!int.TryParse(inputValue, out boardinput))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }

                else if (boardinput > 8 || boardinput < 0)
                {
                    Console.WriteLine("Invalid input. Number out of range.");
                }

                else if (gameTools.GetValidatedMove())
                {
                    Console.WriteLine("Invalid input.");
                }

                else
                    break;

            }

            if (gameTools.TryGetWinner())
            {
                Console.WriteLine($"{currentPlayer} won! Congratulations!");
                break;
            }
            else if (gameTools.IsBoardFull())
            {
                Console.WriteLine("It's a draw! Y'all were just too good.");
                break;
            }

            if (currentPlayer == 1)
            {
                currentPlayer = 2;
            }
            else
            {
                currentPlayer = 1;
            }
        }
    }

    /*/ Initializes and returns an empty 3x3 game board
    private static char[,] CreateEmptyBoard();

    // Displays a numbered reference board (0–8) for user input guidance
    private static void PrintPositionBoard();

    // Determines which player's turn is next
    private static char GetNextPlayer(char currentPlayer);

    // Displays the final outcome of the game (win or draw)
    private static void DisplayGameResult(GameStatus status, char winner);
    */
}
