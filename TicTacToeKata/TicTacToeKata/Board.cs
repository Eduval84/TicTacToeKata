namespace TicTacToeKata
{
    public class Board
    {
        public static void Main(){}
        
        public void play(string player)
        {
            if (player == null) throw new ArgumentNullException("player can not be null");

            if (player.ToUpper() == "O") throw new Exception("X player must be first");

        }
    }
}
