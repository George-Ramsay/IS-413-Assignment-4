namespace Assignment_4;

public class GameTools
{
    // Prints the current state of the game board
    public void PrintBoard(char[,] board);

    // Handles user input and ensures a valid, unoccupied position is selected
    public int GetValidatedMove(char[,] board, char currentPlayer);

    // Applies a validated move to the game board
    public void ApplyMove(char[,] board, int position, char playerMark);

    // Checks whether a winning condition has been met
    public bool TryGetWinner(char[,] board, out char winnerMark);

    // Determines whether the board is full
    public bool IsBoardFull(char[,] board);

    // Evaluates the overall game state (in progress, win, or draw)
    public GameStatus GetGameStatus(char[,] board, out char winnerMark);

    // Converts a linear board position (0–8) into row and column indices
    private (int row, int col) ConvertPosition(int position);
}
