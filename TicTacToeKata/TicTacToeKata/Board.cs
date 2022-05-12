namespace TicTacToeKata
{
    public class Board
    {
        private string SecondPlayer = "O";
        private string LastPlayer;
        public static void Main(){}
        
        public void play(string player)
        {
            if (player == null) throw new ArgumentNullException("player can not be null");
            
            if (player.ToUpper() == SecondPlayer) throw new IncorrectTurnException("X player must be first");

            if (player.ToUpper().Equals(LastPlayer)) throw  new IncorrectTurnException("Incorrect Turn !!, player can not play twice.");
            
            LastPlayer = player;
        }
    }
}
