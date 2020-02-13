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
            int OneSpace = 0;
            int TwoSpaces = 0;
            if (Player == Player.White)
            {
                if (pieceLocation.Row == 7)
                {
                    TwoSpaces = -2;
                    Square secondAvailableSquare = new Square(pieceLocation.Row+TwoSpaces , pieceLocation.Col);
                    squareList.Add(secondAvailableSquare);
                }
                OneSpace = -1;
            } else if (Player == Player.Black)
            {
                if (pieceLocation.Row == 1)
                {
                    TwoSpaces = 2;
                    Square secondAvailableSquare = new Square(pieceLocation.Row+TwoSpaces , pieceLocation.Col);
                    squareList.Add(secondAvailableSquare);
                }
                OneSpace = 1;
            }
            
            Square availableSquare = new Square(pieceLocation.Row+OneSpace, pieceLocation.Col);
            squareList.Add(availableSquare);
            
            return squareList;
        }
    }
}