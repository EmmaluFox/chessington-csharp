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
            int oneSpace = 0;

            int startingRow;


            if (Player == Player.White)
            {
                startingRow = 7;
                CanMoveTwoSpaces(squareList, pieceLocation, startingRow, -2);
                CanMoveOneSpace(squareList, pieceLocation, -1);
            }
            else if (Player == Player.Black)
            {
                startingRow = 1;
                CanMoveTwoSpaces(squareList, pieceLocation, startingRow, 2);
                CanMoveOneSpace(squareList, pieceLocation, 1);
            }
            return squareList;
        }

        public void CanMoveTwoSpaces(List<Square> squareList, Square pieceLocation, int startingRow, int twoSpace)
        {
            if (pieceLocation.Row == startingRow)
            {
                Square secondAvailableSquare = new Square(pieceLocation.Row + twoSpace, pieceLocation.Col);
                squareList.Add(secondAvailableSquare);
            }
        }

        public void CanMoveOneSpace(List<Square> squareList, Square pieceLocation, int oneSpace)
        {
            Square availableSquare = new Square(pieceLocation.Row + oneSpace, pieceLocation.Col);
            squareList.Add(availableSquare);
        }
    }
}