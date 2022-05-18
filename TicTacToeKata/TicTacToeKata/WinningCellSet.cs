namespace TicTacToeKata;

public class WinningCellSet
{
    public WinningCellSet(List<BoardCells> winningCells)
    {
        WinningCells = winningCells;
    }

    public List<BoardCells> WinningCells { get; private set; }
}