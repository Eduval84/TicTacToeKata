namespace TicTacToeKata
{
    public class IncorrectTurnException : Exception
    {
        public IncorrectTurnException(string message) : base(message)
        {
        }
    }
}