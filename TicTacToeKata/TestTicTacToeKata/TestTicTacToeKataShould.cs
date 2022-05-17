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
            var action = () =>  _board.Play(Player.O, BoardCells.TopLeft);

            action.Should().Throw<IncorrectTurnException>().WithMessage("X player must be first.");
        }

        [Fact]
        public void XPlayerAlwaysPlayFirst()
        {
            var action = () => _board.Play(Player.X, BoardCells.TopMiddle);

            action.Should().NotThrow<IncorrectTurnException>();
        }

        [Fact]
        public void APlayerCanNotPlayTwice()
        {
            _board.Play(Player.X, BoardCells.TopRigth);
            _board.Play(Player.O, BoardCells.MiddleLeft);
            var action = () => _board.Play(Player.O, BoardCells.Middle);

            action.Should().Throw<IncorrectTurnException>().WithMessage("Incorrect Turn !!, player can not play twice.");
        }
        
        [Fact]
        public void AllowPlayersToPlayAlternatively()
        {
            _board.Play(Player.X, BoardCells.MiddleRigth);
            _board.Play(Player.O, BoardCells.DownLeft);
            var action = () => _board.Play(Player.X, BoardCells.DownMiddle);

            action.Should().NotThrow<IncorrectTurnException>();
        }

        [Fact]
        public void APlayerCanNotPlayInAlreadyUsedPosition()
        {
            _board.Play(Player.X, BoardCells.DownRigth);

            var action = () => _board.Play(Player.O, BoardCells.DownRigth);

            action.Should().Throw<IncorrectPosition>().WithMessage("Can't play in already used position."); ;
        }

        [Fact]
        public void ABoardHasNineFiedlsInA3X3Grid()
        {
            var numBoardCells = Enum.GetValues(typeof(BoardCells)).Length;

            Assert.Equal(9,numBoardCells);

        }

        [Fact]
        public void AGameIsOverWhenAllFieldsInARowAreRTakenByAPlayer()
        {
            _board.Play(Player.X, BoardCells.TopLeft);
            _board.Play(Player.O, BoardCells.DownLeft);
            _board.Play(Player.X, BoardCells.TopMiddle);
            _board.Play(Player.O, BoardCells.DownMiddle);

            var action = () => _board.Play(Player.O, BoardCells.TopRigth);

            var winner = Console.ReadLine();
            Assert.Equal("Player x win the game, a Row just completed.",winner);
        }

    }
}