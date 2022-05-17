namespace TicTacToeKata;

public class Board
{
    private Player _lastPlayer= Player.Null;
    private readonly string [,] _boardCoordinates = new string[3,3];

    public static void Main(){}
        
    public void Play(Player player, int x, int y)
    {
        CheckPlayerTurn(player);

        CheckForValidPosition(x, y, player);
    }

    private void CheckForValidPosition(int x, int y, Player player)
    {
        if (!string.IsNullOrEmpty(_boardCoordinates[x, y])) throw new IncorrectPosition("Can't play in already used position !!!");

        _boardCoordinates[x, y] = player.ToString();
    }

    private void CheckPlayerTurn(Player player)
    {
        if (player == Player.O && _lastPlayer == Player.Null) throw new IncorrectTurnException("X player must be first");

        if (player.Equals(_lastPlayer)) throw new IncorrectTurnException("Incorrect Turn !!, player can not play twice.");

        _lastPlayer = player;
    }
}