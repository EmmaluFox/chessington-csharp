﻿using System;
 using System.Collections.Generic;
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
                AddAvailableSpaces(board, pieceLocation, startingRow, twoSpacesForward, oneSpaceForward, squareList);

            }
            else if (Player == Player.Black)
            {
                startingRow = 1;
                Square twoSpacesForward = TwoSpacesForward(squareList, pieceLocation, 2);
                Square oneSpaceForward = OneSpaceForward(squareList, pieceLocation, 1);
                AddAvailableSpaces(board, pieceLocation, startingRow, twoSpacesForward, oneSpaceForward, squareList);
            }
            return squareList;
        }

        public void AddAvailableSpaces(Board board, Square pieceLocation, int startingRow, Square twoSpacesForward,
            Square oneSpaceForward, List<Square >squareList)
        {
            if (OneSpaceForwardAvailable(board, pieceLocation, oneSpaceForward))
            {
                squareList.Add(oneSpaceForward);
            }

            if (TwoSpaceForwardAvailable(board, pieceLocation, startingRow, twoSpacesForward, oneSpaceForward))
            {
                squareList.Add(twoSpacesForward);
            }
        }
        
        public bool TwoSpaceForwardAvailable(Board board, Square pieceLocation, int startingRow,
            Square twoSpacesForward, Square oneSpaceForward)
        {
            bool result;
            if (!PieceInStartPosition(board, pieceLocation, startingRow))
            {
                result = false;
            }
            else
            {
                result = !IsSpaceOccupied(board, twoSpacesForward) && !IsSpaceOccupied(board, oneSpaceForward);
            }

            return result;

        }
        
        public bool OneSpaceForwardAvailable(Board board, Square pieceLocation, Square oneSpaceForward)
        {
            return !IsSpaceOccupied(board, oneSpaceForward);
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