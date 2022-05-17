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
            var action = () =>  _board.Play(Player.O, 0, 0);

            action.Should().Throw<IncorrectTurnException>().WithMessage("X player must be first.");
        }

        [Fact]
        public void XPlayerAlwaysPlayFirst()
        {
            var action = () => _board.Play(Player.X, 0, 0);

            action.Should().NotThrow<IncorrectTurnException>();
        }

        [Fact]
        public void APlayerCanNotPlayTwice2()
        {
            _board.Play(Player.X, 0, 0);
            _board.Play(Player.O, 1, 0);
            var action = () => _board.Play(Player.O, 0, 1);

            action.Should().Throw<IncorrectTurnException>().WithMessage("Incorrect Turn !!, player can not play twice.");
        }

        [Fact]
        public void APlayerCanNotPlayTwice()
        {
            _board.Play(Player.X, 0, 0);
            var action= () => _board.Play(Player.X, 0, 0);

            action.Should().Throw<IncorrectTurnException>().WithMessage("Incorrect Turn !!, player can not play twice.");
        }
        

        [Fact]
        public void AllowPlayersToPlayAlternatively()
        {
            _board.Play(Player.X, 1, 0);
            _board.Play(Player.O, 0, 1);
            var action = () => _board.Play(Player.X, 1, 1);

            action.Should().NotThrow<IncorrectTurnException>();
        }

        [Fact]
        public void APlayerCanNotPlayInAlreadyUsedPosition()
        {
            _board.Play(Player.X,0,0);

            var action = () => _board.Play(Player.O, 0, 0);

            action.Should().Throw<IncorrectPosition>().WithMessage("Can't play in already used position."); ;
        }

        [Fact]
        public void ABoardHasNineFiedlsInA3X3Grid()
        {
            var action = () => _board.Play(Player.X, 4, 0);

            action.Should().Throw<IncorrectPosition>().WithMessage("Can't play in this position, Board is a 3x3 grid."); ;

        }

    }
}