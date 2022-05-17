namespace TicTacToeKata;

public class Board
{
    private object? _lastPlayer;
    private readonly HashSet<BoardCells> _boardCells= new ();

    public static void Main() { }

    public void Play(Player player, BoardCells boardCells)
    {
        CheckPlayerTurn(player);
        CheckForValidPosition(boardCells, player);
        CheckIfAnyPlayerHasWon();
    }

    private void CheckIfAnyPlayerHasWon()
    {
    }

    private void CheckForValidPosition(BoardCells boardCells, Player player)
    {
        if (_boardCells.Contains(boardCells)) throw new IncorrectPosition("Can't play in already used position.");
        _boardCells.Add(boardCells);
    }

    public void CheckPlayerTurn(Player player)
    {
        if (player == Player.O && _lastPlayer == null) throw new IncorrectTurnException("X player must be first.");

        if (player.Equals(_lastPlayer)) throw new IncorrectTurnException("Incorrect Turn !!, player can not play twice.");

        _lastPlayer = player;
    }
}