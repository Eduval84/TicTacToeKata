namespace TicTacToeKata;

public class IncorrectPosition : Exception
{
    public IncorrectPosition(string message) : base(message)
    {
    }
}