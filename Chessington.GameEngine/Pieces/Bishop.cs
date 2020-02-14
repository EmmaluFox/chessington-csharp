﻿using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player, 3) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            return Enumerable.Empty<Square>();
        }
    }
}