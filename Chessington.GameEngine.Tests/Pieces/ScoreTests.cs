using System.Collections.Generic;
using Chessington.GameEngine.Pieces;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class ScoreTests
    {
        [Test]
        public void TestScoreCalculator()
        {
            var rook = new Rook(Player.White);
            var board = A.Fake<IBoard>();
            A.CallTo(() => board.CapturedPieces).Returns(new List<Piece> {rook});
            var scoreCalculator = new ScoreCalculator(board);

            scoreCalculator.GetWhiteScore().Should().Be(5);
        }
    }
}

