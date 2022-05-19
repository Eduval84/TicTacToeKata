using Microsoft.VisualBasic;
using TestTicTacToeKata;

namespace TicTacToeKata;

public class Board
{
    private Player? _lastPlayer;
    private Player? _winner;
    private readonly List<Player> _winningPlayers = new() { Player.X, Player.O };
    private readonly List<WinningCellSet> _winningCellSetList;

    private readonly Dictionary<BoardCells,Player> _boardCells= new ();
    private readonly WinningCellSet _winningTopCellSet = new(new List<BoardCells> { BoardCells.TopLeft, BoardCells.TopMiddle, BoardCells.TopRigth });
    private readonly WinningCellSet _winningMiddleCellSet = new(new List<BoardCells> { BoardCells.MiddleLeft, BoardCells.Middle, BoardCells.MiddleRigth });
    private readonly WinningCellSet _winningDownCellSet = new(new List<BoardCells> { BoardCells.DownLeft, BoardCells.DownMiddle, BoardCells.DownRigth });
    private readonly WinningCellSet _winningFirstColumnsCellSet = new(new List<BoardCells> { BoardCells.TopLeft, BoardCells.MiddleLeft, BoardCells.DownLeft });
    private readonly WinningCellSet _winningMiddleColumnsCellSet = new(new List<BoardCells> { BoardCells.TopMiddle, BoardCells.Middle, BoardCells.DownMiddle });
    private readonly WinningCellSet _winningLastColumnsCellSet = new(new List<BoardCells> { BoardCells.TopRigth, BoardCells.MiddleRigth, BoardCells.DownRigth });
    private readonly WinningCellSet _winningADiagonalColumnsCellSet = new(new List<BoardCells> { BoardCells.TopLeft, BoardCells.Middle, BoardCells.DownRigth });
    private readonly WinningCellSet _winningADiagonalColumnsCellSet2 = new(new List<BoardCells> { BoardCells.TopRigth, BoardCells.Middle, BoardCells.DownLeft });

    private readonly WinningCellSet _playFinishWhenAllCellsAreTaken = new(new() { BoardCells.TopLeft, BoardCells.TopMiddle, BoardCells.TopRigth, BoardCells.MiddleLeft, BoardCells.Middle,BoardCells.MiddleRigth, BoardCells.DownLeft, BoardCells.DownMiddle, BoardCells.DownRigth });

    public Board()
    {
        _winningCellSetList = new() {_winningTopCellSet,_winningMiddleCellSet,_winningDownCellSet, _winningFirstColumnsCellSet, _winningMiddleColumnsCellSet, _winningLastColumnsCellSet, _winningADiagonalColumnsCellSet, _winningADiagonalColumnsCellSet2 };
    }

    public static void Main() { }

    public void Play(Player player, BoardCells boardCells)
    {
        if (AllCellsOfTheBoardCompleted()) throw new GameOver("Game over, the board it is completed.");
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
        if (player == Player.O && _lastPlayer == null) throw new IncorrectTurn("X player must be first.");

        if (player.Equals(_lastPlayer)) throw new IncorrectTurn("Incorrect Turn !!, player can not play twice.");

        _lastPlayer = player;
    }

    public Player GetWinner()
    {
        CheckIfAnyPlayerHasWon();
        return (Player) _winner;
    }

    private void CheckIfAnyPlayerHasWon()
    {
        foreach (var player in from winningCellSet in _winningCellSetList from player in _winningPlayers where CheckIfAPlayerHasWonByCompletingAWinningCellSet(player, winningCellSet.WinningCells) select player)
        {
            _winner = player;
            return;
        }
    }

    private bool CheckIfAPlayerHasWonByCompletingAWinningCellSet(Player player, IEnumerable<BoardCells> winningCellSet) {
        
        return winningCellSet.All(cell => IsCellPlayerByPlayer(cell, player));
    }

    private bool IsCellPlayerByPlayer(BoardCells cell, Player player)
    {
        return _boardCells.ContainsKey(cell) && _boardCells[cell] == player;
    }

    public bool AllCellsOfTheBoardCompleted()
    {
        return _playFinishWhenAllCellsAreTaken.WinningCells.All(cell => _boardCells.ContainsKey(cell));
    }
}