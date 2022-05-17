using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace TicTacToeKata;

public class Board
{
    private Player _lastPlayer = Player.Null;
    private readonly string[,] _boardCoordinates = new string[3, 3];

    public static void Main() { }

    public void Play(Player player, Coordinates coordinates)
    {
        CheckPlayerTurn(player);
        CheckForValidPosition(coordinates.X, coordinates.Y, player);
        CheckIfAnyPlayerHasWon();
    }

    private void CheckIfAnyPlayerHasWon()
    {
        //entidad propia fila
        //entidad propia columna
        //coleccion de celdas??
    }

    private void CheckForValidPosition(int x, int y, Player player)
    {
        if (x > 2 || y > 2) throw new IncorrectPosition("Can't play in this position, Board is a 3x3 grid.");
        if (!string.IsNullOrEmpty(_boardCoordinates[x, y])) throw new IncorrectPosition("Can't play in already used position.");
        _boardCoordinates[x, y] = player.ToString();
    }

    public void CheckPlayerTurn(Player player)
    {
        if (player == Player.O && _lastPlayer == Player.Null) throw new IncorrectTurnException("X player must be first.");

        if (player.Equals(_lastPlayer)) throw new IncorrectTurnException("Incorrect Turn !!, player can not play twice.");

        _lastPlayer = player;
    }
}