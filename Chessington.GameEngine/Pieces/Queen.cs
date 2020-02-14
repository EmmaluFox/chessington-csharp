﻿using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player, 9) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            return Enumerable.Empty<Square>();
        }
    }
}