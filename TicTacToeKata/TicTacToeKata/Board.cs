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

    private void CheckPlayerTurn(Player player)
    {
        if (player == Player.O && _lastPlayer == null) throw new IncorrectTurnException("X player must be first.");

        if (player.Equals(_lastPlayer)) throw new IncorrectTurnException("Incorrect Turn !!, player can not play twice.");

        _lastPlayer = player;
    }

    public Player GetWinner()
    {
        return CheckIfAnyPlayerHasWon(new WinningCellSet(new() { BoardCells.TopLeft, BoardCells.TopMiddle, BoardCells.TopRigth }));
    }

    private Player CheckIfAnyPlayerHasWon(WinningCellSet winningCellSet)
    {

        Player? winner = null;
        List<BoardCells> middleWinningCells = new() { BoardCells.MiddleLeft, BoardCells.Middle, BoardCells.MiddleRigth };
        List<BoardCells> downWinningCells = new() { BoardCells.DownLeft, BoardCells.DownMiddle, BoardCells.DownRigth };

        if (CheckIfAPlayerHasWonByCompletingARow(Player.X, winningCellSet.WinningCells))
        {
            return Player.X;
        }

        if (CheckIfAPlayerHasWonByCompletingARow(Player.O, winningCellSet.WinningCells))
        {
            return Player.O;
        }

        if (CheckIfAPlayerHasWonByCompletingARow(Player.X, middleWinningCells))
        {
            return Player.X;
        }

        if (CheckIfAPlayerHasWonByCompletingARow(Player.O, middleWinningCells))
        {
            return Player.O;
        }

        if (CheckIfAPlayerHasWonByCompletingARow(Player.X, downWinningCells))
        {
            return Player.X;
        }

        if (CheckIfAPlayerHasWonByCompletingARow(Player.O, downWinningCells))
        {
            return Player.O;
        }

        return (Player)winner;

    }

    private bool CheckIfAPlayerHasWonByCompletingARow(Player player, IEnumerable<BoardCells> winningRow) {
        
        return winningRow.All(cell => IsCellPlayerByPlayer(cell, player));
    }

    private bool IsCellPlayerByPlayer(BoardCells cell, Player player)
    {
        return _boardCells.ContainsKey(cell) && _boardCells[cell] == player;
    }
}