namespace TestTicTacToeKata;

public class GameOver: Exception
{
    public GameOver(string message) : base(message)
    {
    }
}