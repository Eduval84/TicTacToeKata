using System;
using FluentAssertions;
using Xunit;
using TicTacToeKata;



namespace TestTicTacToeKata
{
    public class TicTacToeKataShould
    {
        private readonly Board _board;
        

        public TicTacToeKataShould()
        {
            _board= new Board();
        }

        [Fact]
        public void OPlayerCanNotPlayFirst()
        {
            var action = () =>  _board.play(Player.O);

            action.Should().Throw<IncorrectTurnException>().WithMessage("X player must be first");
        }

        [Fact]
        public void XPlayerAlwaysPlayFirst()
        {
            var action = () => _board.play(Player.X);

            action.Should().NotThrow<IncorrectTurnException>();
        }

        [Fact]
        public void APlayerCanNotPlayTwice()
        {
            _board.play(Player.X);
            var action= () => _board.play(Player.X);

            action.Should().Throw<IncorrectTurnException>().WithMessage("Incorrect Turn !!, player can not play twice.");
        }

        [Fact]
        public void AllowPlayersToPlayAlternatively()
        {
            _board.play(Player.X);
            _board.play(Player.O);
            var action = () => _board.play(Player.X);

            action.Should().NotThrow<IncorrectTurnException>();
        }

    }
}