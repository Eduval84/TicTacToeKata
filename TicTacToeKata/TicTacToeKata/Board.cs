namespace TicTacToeKata;

public class Board
{
    private Player LastPlayer= Player.Null;
    private readonly String [,] BoardCoordinates = new String[3,3];

    public static void Main(){}
        
    public void play(Player player, int X, int Y)
    {
        if (player == Player.O && LastPlayer == Player.Null) throw new IncorrectTurnException("X player must be first");

        if (player.Equals(LastPlayer)) throw  new IncorrectTurnException("Incorrect Turn !!, player can not play twice.");
            
        LastPlayer = player;

        if (!string.IsNullOrEmpty(BoardCoordinates[X, Y])) throw new IncorrectPosition("Can't play in already used position !!!");

        BoardCoordinates[X, Y] = player.ToString();

    }
}