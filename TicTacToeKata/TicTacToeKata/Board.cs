using Microsoft.VisualBasic;

namespace TicTacToeKata;

public class Board
{
    private Player? _lastPlayer;
    private readonly Dictionary<BoardCells,Player> _boardCells= new ();

    public static void Main() { }

    public void Play(Player player, BoardCells boardCells)
    {
        CheckPlayerTurn(player);
        CheckForValidPosition(boardCells, player);
    }

    private void CheckForValidPosition(BoardCells boardCells, Player player)
    {
        if (_boardCells.ContainsKey(boardCells)) throw new IncorrectPosition("Can't play in already used position.");
        _boardCells.Add(boardCells,player);
    }

    public void CheckPlayerTurn(Player player)
    {
        if (player == Player.O && _lastPlayer == null) throw new IncorrectTurnException("X player must be first.");

        if (player.Equals(_lastPlayer)) throw new IncorrectTurnException("Incorrect Turn !!, player can not play twice.");

        _lastPlayer = player;
    }

    public Player GetWinner()
    {
        return CheckIfAnyPlayerHasWon();
    }

    private Player CheckIfAnyPlayerHasWon()
    {

        Player? winner = null;

        if ((_boardCells.ContainsKey(BoardCells.TopLeft) && _boardCells[BoardCells.TopLeft] == Player.X) &&
            (_boardCells.ContainsKey(BoardCells.TopMiddle) && _boardCells[BoardCells.TopMiddle] == Player.X) &&
            _boardCells.ContainsKey(BoardCells.TopRigth) && _boardCells[BoardCells.TopRigth] == Player.X)
        {
            return Player.X;
        }

        if ((_boardCells.ContainsKey(BoardCells.TopLeft) && _boardCells[BoardCells.TopLeft] == Player.O) &&
            (_boardCells.ContainsKey(BoardCells.TopMiddle) && _boardCells[BoardCells.TopMiddle] == Player.O) &&
            _boardCells.ContainsKey(BoardCells.TopRigth) && _boardCells[BoardCells.TopRigth] == Player.O)
        {
            return Player.X;
        }

        if ((_boardCells.ContainsKey(BoardCells.MiddleLeft) && _boardCells[BoardCells.MiddleLeft] == Player.X) &&
            (_boardCells.ContainsKey(BoardCells.Middle) && _boardCells[BoardCells.Middle] == Player.X) &&
            _boardCells.ContainsKey(BoardCells.MiddleRigth) && _boardCells[BoardCells.MiddleRigth] == Player.X)
        {
            return Player.X;
        }

        if ((_boardCells.ContainsKey(BoardCells.MiddleLeft) && _boardCells[BoardCells.MiddleLeft] == Player.O) &&
            (_boardCells.ContainsKey(BoardCells.Middle) && _boardCells[BoardCells.Middle] == Player.O) &&
            _boardCells.ContainsKey(BoardCells.MiddleRigth) && _boardCells[BoardCells.MiddleRigth] == Player.O)
        {
            return Player.O;
        }

        if ((_boardCells.ContainsKey(BoardCells.DownLeft) && _boardCells[BoardCells.DownLeft] == Player.X) &&
            (_boardCells.ContainsKey(BoardCells.DownMiddle) && _boardCells[BoardCells.DownMiddle] == Player.X) &&
            _boardCells.ContainsKey(BoardCells.DownLeft) && _boardCells[BoardCells.DownLeft] == Player.X)
        {
            return Player.X;
        }

        if ((_boardCells.ContainsKey(BoardCells.DownLeft) && _boardCells[BoardCells.DownLeft] == Player.O) &&
            (_boardCells.ContainsKey(BoardCells.DownMiddle) && _boardCells[BoardCells.DownMiddle] == Player.O) &&
            _boardCells.ContainsKey(BoardCells.DownLeft) && _boardCells[BoardCells.DownLeft] == Player.O)
        {
            return Player.O;
        }

        return (Player)winner;

    }

  
}