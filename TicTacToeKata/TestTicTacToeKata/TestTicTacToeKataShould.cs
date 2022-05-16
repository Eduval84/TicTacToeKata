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
            var action = () =>  _board.play(Player.O, 0, 0);

            action.Should().Throw<IncorrectTurnException>().WithMessage("X player must be first");
        }

        [Fact]
        public void XPlayerAlwaysPlayFirst()
        {
            var action = () => _board.play(Player.X, 0, 0);

            action.Should().NotThrow<IncorrectTurnException>();
        }

        [Fact]
        public void APlayerCanNotPlayTwice2()
        {
            _board.play(Player.X, 0, 0);
            _board.play(Player.O, 0, 0);
            var action = () => _board.play(Player.O, 0, 0);

            action.Should().Throw<IncorrectTurnException>().WithMessage("Incorrect Turn !!, player can not play twice.");
        }

        [Fact]
        public void APlayerCanNotPlayTwice()
        {
            _board.play(Player.X, 0, 0);
            var action= () => _board.play(Player.X, 0, 0);

            action.Should().Throw<IncorrectTurnException>().WithMessage("Incorrect Turn !!, player can not play twice.");
        }
        

        [Fact]
        public void AllowPlayersToPlayAlternatively()
        {
            _board.play(Player.X, 0, 0);
            _board.play(Player.O, 0, 0);
            var action = () => _board.play(Player.X, 0, 0);

            action.Should().NotThrow<IncorrectTurnException>();
        }

        [Fact]
        public void APlayerCanNotPlayInAlreadyUsedPosition()
        {
            _board.play(Player.X,0,0);

            var action = () => _board.play(Player.X, 0, 0);

            action.Should().Throw<IncorrectPosition>().WithMessage("Can't play in already used position !!!"); ;
        }

    }
}