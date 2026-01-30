// See https://aka.ms/new-console-template for more information

using Assignment_4;
using System;
internal class Program
{
    static void Main(string[] args)
    {
        // Setup
        GameTools gameTools = new GameTools();
        Console.WriteLine("Welcome to Tic-Tac-Toe!");
        Console.WriteLine();
        char[] playerSymbols = [];
        char[] gameBoard = new char[9];
        Array.Fill(gameBoard, '-');

        // Player setup
        while (true)
        {
            Console.WriteLine("Player 1: Would you like to be X or O?");
            string input = Console.ReadLine().ToUpper();
            char playerSymbol1 = !string.IsNullOrEmpty(input) ? input[0] : 'X';
            

            if (playerSymbol1 != 'X' && playerSymbol1 != 'O')
            {
                Console.WriteLine("Sorry, please pick either X or O.");
            }

            else if (playerSymbol1 == 'X')
            {
                Console.WriteLine("Great! Player 1 is X and Player 2 is O.");
                Console.WriteLine();
                playerSymbols = ['X', 'O'];
                break;
            }
            else
            {
                Console.WriteLine("Great! Player 1 is O and Player 2 is X.");
                Console.WriteLine();
                playerSymbols = ['O', 'X'];
                break;
            }
        }
        
        bool isFinished = false;
        int currentPlayer = 1;

        // Main game loop
        while (!isFinished)
        {
            Console.WriteLine("Reference positions:");
            PrintPositionBoard();
            gameTools.PrintBoard(gameBoard);

            int boardinput;

            while (true)
            {
                Console.WriteLine($"Player {currentPlayer} ({playerSymbols[currentPlayer-1]}), please input a number (0-8):");
                string inputValue = Console.ReadLine();

                if (!int.TryParse(inputValue, out boardinput))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }

                else if (boardinput > 8 || boardinput < 0)
                {
                    Console.WriteLine("Invalid input. Number out of range (0-8).");
                }

                else if (!gameTools.GetValidatedMove(gameBoard, boardinput))
                {
                    Console.WriteLine("Invalid input. That position is already taken.");
                }

                else
                    break;

            }

            gameTools.ApplyMove(gameBoard, boardinput, playerSymbols[currentPlayer - 1]);

            Console.WriteLine();
            gameTools.PrintBoard(gameBoard);

            // Game results
            if (gameTools.TryGetWinner(gameBoard, out var winnerMark))
            {
                Console.WriteLine();
                Console.WriteLine($"{winnerMark} won! Congratulations!");
                Console.WriteLine("Press any Key to exit...");
                Console.ReadKey();
                break;
            }
            else if (gameTools.IsBoardFull(gameBoard))
            {
                Console.WriteLine();
                Console.WriteLine("It's a draw! Y'all were just too good.");
                Console.WriteLine("Press any Key to exit...");
                Console.ReadKey();
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

    private static char[,] CreateEmptyBoard()
    {
        var board = new char[3, 3];

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = '-';
            }
        }

        return board;
    }

    private static void PrintPositionBoard()
    {
        Console.WriteLine();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int index = i * 3 + j;
                Console.Write(index);

                if (j < 2) Console.Write(" | ");
            }
            Console.WriteLine();
            if (i < 2) Console.WriteLine("--+---+--");
        }
        Console.WriteLine();
    }
}
