using System;
using FluentAssertions;
using Xunit;
using TicTacToeKata;



namespace TestTicTacToeKata
{
    public class TicTacToeKataShould
    {
        private Board Board = new Board();

        [Fact]
        public void OPlayerCanNotPlayFirst()
        {
            var action = () =>  Board.play(Player.O);

            action.Should().Throw<IncorrectTurnException>().WithMessage("X player must be first");
        }

        [Fact]
        public void XPlayerAlwaysPlayFirst()
        {
            var action = () => Board.play(Player.X);

            action.Should().NotThrow<IncorrectTurnException>();
        }

        [Fact]
        public void APlayerCanNotPlayTwice()
        {
            Board.play(Player.X);
            var action= () => Board.play(Player.X);

            action.Should().Throw<IncorrectTurnException>().WithMessage("Incorrect Turn !!, player can not play twice.");
        }

    }
}