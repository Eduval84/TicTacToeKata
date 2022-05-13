namespace TicTacToeKata
{
    public class Board
    {
        private Player SecondPlayer = Player.O;
        private Player LastPlayer= Player.Null;
        public static void Main(){}
        
        public void play(Player player)
        {
            if (player == null) throw new ArgumentNullException("player can not be null");
            
            if (player == SecondPlayer) throw new IncorrectTurnException("X player must be first");

            if (player.Equals(LastPlayer)) throw  new IncorrectTurnException("Incorrect Turn !!, player can not play twice.");
            
            LastPlayer = player;
        }
    }
}
