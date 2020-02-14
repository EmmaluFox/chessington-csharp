﻿using System.Linq;
 using Chessington.GameEngine.Pieces;
 using FluentAssertions;
 using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class KingTests
    {
        [Test]
        public  void WhiteKing_CanMoveAnyDirection()
        {
            var board = new Board();
            var king = new King(Player.White);
            board.AddPiece(Square.At(3,3), king);
            var moves = king.GetAvailableMoves(board).ToList();

            moves.Should().BeEquivalentTo(Square.At(2, 2), 
                Square.At(2, 3), 
                Square.At(2, 4),
                Square.At(3, 2),
                Square.At(3, 4),
                Square.At(4, 2),
                Square.At(4, 3),
                Square.At(4, 4));
        }

        [Test]
        public  void BlackKing_CanMoveAnyDirection()
        {
            var board = new Board();
            var king = new King(Player.Black);
            board.AddPiece(Square.At(3,3), king);
            var moves = king.GetAvailableMoves(board).ToList();

            moves.Should().BeEquivalentTo(Square.At(2, 2), 
                Square.At(2, 3), 
                Square.At(2, 4),
                Square.At(3, 2),
                Square.At(3, 4),
                Square.At(4, 2),
                Square.At(4, 3),
                Square.At(4, 4));
        }

        
    }
}