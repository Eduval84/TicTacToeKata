using System;
using FluentAssertions;
using Xunit;
using TicTacToeKata;



namespace TestTicTacToeKata
{
    public class TicTacToeKataShould
    {
        [Fact]
        public void OPlayerCanNotPlayFirst()
        {
            var action = () =>new Board().play("O");

            action.Should().Throw<IncorrectTurnException>().WithMessage("X player must be first");
        }

        [Fact]
        public void XPlayerAlwaysPlayFirst()
        {
            var action = () => new Board().play("X");

            action.Should().NotThrow<IncorrectTurnException>();
        }

        [Fact]
        public void APlayerCanNotPlayTwice()
        {
            Board board = new Board();
            board.play("X");
            var action= () => board.play("X");

            action.Should().Throw<IncorrectTurnException>().WithMessage("Incorrect Turn !!, player can not play twice.");
        }

    }
}