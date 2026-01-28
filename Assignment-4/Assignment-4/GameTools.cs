namespace Assignment_4;

public class GameTools
{
    private int[] moves = int[9];

    // Prints the current state of the game board
    public void PrintBoard(char[] board)
    {
        for (int i = 0; i < 3; i++)
        {
            Console.Write("\n");
            for (int j = 0; i < 3; i++)
            {
                if (board[i] == 2)
                {
                    Console.Write(board[i]);
                }
                else
                {
                    Console.Write(board[i]);
                    Console.Write("|");
                }

            }
        }
    }
    
    // Handles user input and ensures a valid, unoccupied position is selected
    public bool GetValidatedMove(char[] board, int position)
    {
        return board[position] == '-';
    }
    
    // Applies a validated move to the game board
    public void ApplyMove(char[] board, int position, char playerMark);

    // Checks whether a winning condition has been met
    public bool TryGetWinner(char[] board, out char winnerMark);

    // Determines whether the board is full
    public bool IsBoardFull(char[] board);
    
    // Converts a linear board position (0–8) into row and column indices
   // private (int row, int col) ConvertPosition(int position);
}
