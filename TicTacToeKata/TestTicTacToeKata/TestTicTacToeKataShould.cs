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
        public void ABoardHasNineCellsInA3X3Grid()
        {
            var numBoardCells = Enum.GetValues(typeof(BoardCells)).Length;

            Assert.Equal(9,numBoardCells);

        }

        [Fact]
        public void AGameIsOverWhenAllTopCellsInARowAreTakenByTheSamePlayer()
        {
            _board.Play(Player.X, BoardCells.TopLeft);
            _board.Play(Player.O, BoardCells.DownLeft);
            _board.Play(Player.X, BoardCells.TopMiddle);
            _board.Play(Player.O, BoardCells.DownMiddle);
            _board.Play(Player.X, BoardCells.TopRigth);

            _board.GetWinner().Should().Be(Player.X);
        }

        [Fact]
        public void AGameIsOverWhenAllMidCellsInARowAreTakenByTheSamePlayer()
        {
            _board.Play(Player.X, BoardCells.TopLeft);
            _board.Play(Player.O, BoardCells.MiddleLeft);
            _board.Play(Player.X, BoardCells.TopMiddle);
            _board.Play(Player.O, BoardCells.Middle);
            _board.Play(Player.X, BoardCells.DownLeft);
            _board.Play(Player.O, BoardCells.MiddleRigth);

            _board.GetWinner().Should().Be(Player.O);
        }

        [Fact]
        public void AGameIsOverWhenAllDownCellsInARowAreTakenByTheSamePlayer()
        {
            _board.Play(Player.X, BoardCells.DownLeft);
            _board.Play(Player.O, BoardCells.MiddleLeft);
            _board.Play(Player.X, BoardCells.DownMiddle);
            _board.Play(Player.O, BoardCells.Middle);
            _board.Play(Player.X, BoardCells.DownRigth);
       
            _board.GetWinner().Should().Be(Player.X);
        }

        [Fact]
        public void AGameIsOverWhenAllFirstColumnCellsAreTakenByTheSamePlayer()
        {
            _board.Play(Player.X, BoardCells.TopLeft);
            _board.Play(Player.O, BoardCells.TopMiddle);
            _board.Play(Player.X, BoardCells.MiddleLeft);
            _board.Play(Player.O, BoardCells.Middle);
            _board.Play(Player.X, BoardCells.DownLeft);

            _board.GetWinner().Should().Be(Player.X);
        }

        [Fact]
        public void AGameIsOverWhenAllMiddleColumnCellsAreTakenByTheSamePlayer()
        {
            _board.Play(Player.X, BoardCells.TopLeft);
            _board.Play(Player.O, BoardCells.TopMiddle);
            _board.Play(Player.X, BoardCells.TopRigth);
            _board.Play(Player.O, BoardCells.Middle);
            _board.Play(Player.X, BoardCells.DownLeft);
            _board.Play(Player.O, BoardCells.DownMiddle);

            _board.GetWinner().Should().Be(Player.O);
        }

        [Fact]
        public void AGameIsOverWhenAllLastColumnCellsAreTakenByTheSamePlayer()
        {
            _board.Play(Player.X, BoardCells.TopRigth);
            _board.Play(Player.O, BoardCells.TopMiddle);
            _board.Play(Player.X, BoardCells.MiddleRigth);
            _board.Play(Player.O, BoardCells.Middle);
            _board.Play(Player.X, BoardCells.DownRigth);

            _board.GetWinner().Should().Be(Player.X);
        }

        [Fact]
        public void AGameIsOverWhenAllCellsInADiagonalAreTakenByTheSamePlayer()
        {
            _board.Play(Player.X, BoardCells.TopLeft);
            _board.Play(Player.O, BoardCells.TopMiddle);
            _board.Play(Player.X, BoardCells.Middle);
            _board.Play(Player.O, BoardCells.MiddleLeft);
            _board.Play(Player.X, BoardCells.DownRigth);

            _board.GetWinner().Should().Be(Player.X);
        }

        [Fact]
        public void AGameIsOverWhenAllCellsInADiagonal2AreTakenByTheSamePlayer()
        {
            _board.Play(Player.X, BoardCells.TopRigth);
            _board.Play(Player.O, BoardCells.TopMiddle);
            _board.Play(Player.X, BoardCells.Middle);
            _board.Play(Player.O, BoardCells.MiddleLeft);
            _board.Play(Player.X, BoardCells.DownLeft);

            _board.GetWinner().Should().Be(Player.X);
        }

    }
}