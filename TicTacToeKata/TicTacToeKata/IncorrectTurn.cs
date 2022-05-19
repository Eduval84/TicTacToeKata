namespace TicTacToeKata;

public class IncorrectTurn : Exception
{
    public IncorrectTurn(string message) : base(message)
    {
    }
}
