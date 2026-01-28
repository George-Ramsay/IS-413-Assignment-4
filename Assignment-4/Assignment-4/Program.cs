// See https://aka.ms/new-console-template for more information

internal class Program
{
    static void Main(string[] args);

    // Initializes and returns an empty 3x3 game board
    private static char[,] CreateEmptyBoard();

    // Displays a numbered reference board (0–8) for user input guidance
    private static void PrintPositionBoard();

    // Determines which player's turn is next
    private static char GetNextPlayer(char currentPlayer);

    // Displays the final outcome of the game (win or draw)
    private static void DisplayGameResult(GameStatus status, char winner);
}
