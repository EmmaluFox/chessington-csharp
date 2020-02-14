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
        
        
        [Test]
        public void AnotherTestScoreCalculator()
        {
            var rook = new Rook(Player.Black);
            var queen = new Queen(Player.Black);
            var pawn2 = new Pawn(Player.Black);
            
            
            var knight = new Knight(Player.White);
            var pawn = new Pawn(Player.White);
            var pawn3 = new Pawn(Player.White);
            
            var board = A.Fake<IBoard>();
            A.CallTo(() => board.CapturedPieces).Returns(new List<Piece> {rook,queen,knight,pawn,pawn2,pawn3});
            var scoreCalculator = new ScoreCalculator(board);

            scoreCalculator.GetWhiteScore().Should().Be(5);
            scoreCalculator.GetBlackScore().Should().Be(15);
        }
    }
}

