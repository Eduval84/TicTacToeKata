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
        return CheckIfAnyPlayerHasWon();
    }

    private Player CheckIfAnyPlayerHasWon()
    {

        Player? winner = null;
        var winningTopCellSet = new WinningCellSet(new() { BoardCells.TopLeft, BoardCells.TopMiddle, BoardCells.TopRigth });
        var winningMiddleCellSet = new WinningCellSet(new() { BoardCells.MiddleLeft, BoardCells.Middle, BoardCells.MiddleRigth });
        var winningDownCellSet = new WinningCellSet(new() { BoardCells.DownLeft, BoardCells.DownMiddle, BoardCells.DownRigth });

        List<WinningCellSet> winningCellSetList = new() {winningTopCellSet,winningMiddleCellSet,winningDownCellSet};
        List<Player> winningPlayers = new() {Player.X, Player.O};

        foreach (var player in from winningCellSet in winningCellSetList from player in winningPlayers where CheckIfAPlayerHasWonByCompletingAWinningCellSet(player, winningCellSet.WinningCells) select player)
        {
            return player;
        }

        return (Player)winner;

    }

    private bool CheckIfAPlayerHasWonByCompletingAWinningCellSet(Player player, IEnumerable<BoardCells> winningCellSet) {
        
        return winningCellSet.All(cell => IsCellPlayerByPlayer(cell, player));
    }

    private bool IsCellPlayerByPlayer(BoardCells cell, Player player)
    {
        return _boardCells.ContainsKey(cell) && _boardCells[cell] == player;
    }
}