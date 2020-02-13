﻿using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> squareList = new List<Square>();
            Square pieceLocation = board.FindPiece(this);
            int whiteOrBlack = 0;
            if (Player == Player.White)
            {
                whiteOrBlack = -1;
            } else if (Player == Player.Black)
            {
                whiteOrBlack = 1;
            }
            
            Square availableSquare = new Square(pieceLocation.Row+whiteOrBlack, pieceLocation.Col);
            squareList.Add(availableSquare);
            return squareList;
        }
    }
}