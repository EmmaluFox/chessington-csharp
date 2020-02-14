﻿using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player, 5) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            return Enumerable.Empty<Square>();
        }
    }
}