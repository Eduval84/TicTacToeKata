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


    }
}