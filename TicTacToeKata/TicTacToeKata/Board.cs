namespace TicTacToeKata;

public class Board
{
    private Player _lastPlayer= Player.Null;
    private readonly string [,] _boardCoordinates = new String[3,3];

    public static void Main(){}
        
    public void Play(Player player, int X, int Y)
    {
        if (player == Player.O && _lastPlayer == Player.Null) throw new IncorrectTurnException("X player must be first");

        if (player.Equals(_lastPlayer)) throw  new IncorrectTurnException("Incorrect Turn !!, player can not play twice.");
            
        _lastPlayer = player;

        if (!string.IsNullOrEmpty(_boardCoordinates[X, Y])) throw new IncorrectPosition("Can't play in already used position !!!");

        _boardCoordinates[X, Y] = player.ToString();

    }
}