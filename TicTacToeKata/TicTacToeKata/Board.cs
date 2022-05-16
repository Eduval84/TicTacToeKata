using Microsoft.VisualBasic;

namespace TicTacToeKata
{
    public class Board
    {
        private Player LastPlayer= Player.Null;
        public static void Main(){}
        
        public void play(Player player)
        {
            if (player == Player.O && LastPlayer == Player.Null) throw new IncorrectTurnException("X player must be first");

            if (player.Equals(LastPlayer)) throw  new IncorrectTurnException("Incorrect Turn !!, player can not play twice.");
            
            LastPlayer = player;
        }
    }
}
