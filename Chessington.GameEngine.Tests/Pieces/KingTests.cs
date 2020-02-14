﻿using Chessington.GameEngine.Pieces;
 using FluentAssertions;
 using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class KingTests
    {
        [Test]
        public void WhiteKing_CanMoveOneSquareUp()
        {
            var board = new Board();
            var king = new King(Player.White);
            board.AddPiece(Square.At(4, 0), king);

            var moves = king.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(3, 0));
        }
    }
}