namespace Assignment_4;

public class GameTools
{
    private int turns = 0;

    // Prints the current state of the game board
    public void PrintBoard(char[] board)
    {
        for (int i = 0; i < 3; i++)
        {
            Console.Write("\n");
            for (int j = 0; j < 3; j++)
            {
                int index = i * 3 + j;     // converts row/col 
                Console.Write(board[index]);

                if (j < 2) Console.Write("|"); 
            }
            Console.WriteLine();
        }
    }
    
    // Handles user input and ensures a valid, unoccupied position is selected
    public bool GetValidatedMove(char[] board, int position)
    { 
        if (position < 0 || position > 8) return false; 
        return board[position] == '-';
    }
    
    // Applies a validated move to the game board
    public void ApplyMove(char[] board, int position, char playerMark)
    {
        board[position] = playerMark;
        turns++;
    }

    // Checks whether a winning condition has been met
    public bool TryGetWinner(char[] board, out char winnerMark)
    {
        winnerMark = '-';
        if (turns < 5) return false;

        int[][] winOptions = //might break if it dosent compile use the older syntax
        [
            [0, 1, 2],
            [3, 4, 5],
            [6, 7, 8],
            [0, 3, 6],
            [1, 4, 7],
            [2, 5, 8],
            [0, 4, 8],
            [2, 4, 6]
        ];

        foreach (int[] option in winOptions)
        {
            var a = option[0];
            var b = option[1];
            var c = option[2];
            
            if (TripleCheck(board, a, b, c))
            {
                winnerMark = board[a];
                return true;
            }
        }
        return false;
    }
    
    // Checks to see if all player marks in a line match
    private bool TripleCheck(char[] board, int index1, int index2, int index3)
    {
        return (board[index1] != '-' && board[index1] == board[index2] && board[index1] == board[index3]);
    }

    // Determines whether the board is full
    public bool IsBoardFull(char[] board)
    {
        return turns == 9;
    }
}
