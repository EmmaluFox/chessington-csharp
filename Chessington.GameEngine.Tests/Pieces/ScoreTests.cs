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
        
        [Test]
        
        public void TestWhoIsWinning()
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
            scoreCalculator.WhoIsWinning().Should().Be("Black is in the lead!");
        }
        
        [Test]
        public void TestScoreBalance()
        {
            //Black 18
            var rook = new Rook(Player.Black); //5
            var queen = new Queen(Player.Black); //9
            var pawn2 = new Pawn(Player.Black); //1
            var bishop = new Bishop(Player.Black); //3
            
            //White 13
            var knight = new Knight(Player.White); //3
            var queen2 = new Queen(Player.White); //9
            var pawn3 = new Pawn(Player.White); //1
            
            var board = A.Fake<IBoard>();
            A.CallTo(() => board.CapturedPieces).Returns(new List<Piece> {rook,queen,knight,queen2,pawn2,pawn3,bishop});
            
            
            var scoreCalculator = new ScoreCalculator(board);
            scoreCalculator.WhoIsWinning().Should().Be("Black has taken a slight lead!");
        }
    }
}
 
