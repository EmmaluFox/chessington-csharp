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
            int startingRow;
            
            if (Player == Player.White)
            {
                startingRow = 6;
                Square twoSpacesForward = TwoSpacesForward(squareList, pieceLocation, -2);
                Square oneSpaceForward = OneSpaceForward(squareList, pieceLocation, -1);
                if (!IsSpaceOccupied(board, oneSpaceForward))
                {
                    squareList.Add(oneSpaceForward);
                }

                if (PieceInStartPosition(board, pieceLocation, startingRow))
                {
                    if (!IsSpaceOccupied(board, twoSpacesForward) && !IsSpaceOccupied(board, oneSpaceForward))
                    {
                        squareList.Add(twoSpacesForward);
                    }
                }

            }
            else if (Player == Player.Black)
            {
                startingRow = 1;
                Square twoSpacesForward = TwoSpacesForward(squareList, pieceLocation, 2);
                Square oneSpaceForward = OneSpaceForward(squareList, pieceLocation, 1);
                if (!IsSpaceOccupied(board, oneSpaceForward))
                {
                    squareList.Add(oneSpaceForward);
                }

                if (PieceInStartPosition(board, pieceLocation, startingRow))
                {
                    if (!IsSpaceOccupied(board, twoSpacesForward) && !IsSpaceOccupied(board, oneSpaceForward))
                    {
                        squareList.Add(twoSpacesForward);
                    }
                }
            }
            return squareList;
        }

        public bool PieceInStartPosition(Board board, Square pieceLocation, int startingRow)
        {
            var result = pieceLocation.Row == startingRow;
            return result;
        }
        public Square TwoSpacesForward(List<Square> squareList, Square pieceLocation, int twoSpace)
        { 
            Square secondAvailableSquare = new Square(pieceLocation.Row + twoSpace, pieceLocation.Col);
            return secondAvailableSquare;
        }

        public Square OneSpaceForward(List<Square> squareList, Square pieceLocation, int oneSpace)
        {
            Square availableSquare = new Square(pieceLocation.Row + oneSpace, pieceLocation.Col);
            return availableSquare;
        }

        public bool IsSpaceOccupied(Board board, Square square)
        {
            bool spaceOccupied;
            Piece getPiece = board.GetPiece(square);
            if (getPiece == null)
            {
                spaceOccupied = false;
            }
            else
            {
                spaceOccupied = true;
            }
            return spaceOccupied;
        }
        
    }
}