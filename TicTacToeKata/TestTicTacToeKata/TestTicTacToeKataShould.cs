using System;
using FluentAssertions;
using Xunit;
using TicTacToeKata;



namespace TestTicTacToeKata
{
    public class TicTacToeKataShould
    {
        [Fact]
        public void XPlayerAlwaysPlayFirst()
        {
            var action = () =>new Board().play("O");

            action.Should().Throw<Exception>().WithMessage("X player must be first");
        }

        
    }
}