﻿using System;
 using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player, 1) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> squareList = new List<Square>();
            Square pieceLocation = board.FindPiece(this);
            int startingRow;
            
            if (Player == Player.White)
            {
                startingRow = 6;
                Square twoSpacesForward = TwoSpacesForward(pieceLocation, -2);
                Square oneSpaceForward = OneSpaceForward(pieceLocation, -1);
                Square diagonalLeft = DiagonalLeft(pieceLocation, -1, -1);
                Square diagonalRight = DiagonalRight(pieceLocation, -1, 1);
                AddAvailableSpaces(board, pieceLocation, startingRow, twoSpacesForward, oneSpaceForward, diagonalLeft, diagonalRight, squareList);

            }
            else if (Player == Player.Black)
            {
                startingRow = 1;
                Square twoSpacesForward = TwoSpacesForward(pieceLocation, 2);
                Square oneSpaceForward = OneSpaceForward(pieceLocation, 1);
                Square diagonalLeft = DiagonalLeft(pieceLocation, 1, 1);
                Square diagonalRight = DiagonalRight(pieceLocation, 1, -1);
                AddAvailableSpaces(board, pieceLocation, startingRow, twoSpacesForward, oneSpaceForward, diagonalLeft, diagonalRight, squareList);
            }
            return squareList;
        }

        public void AddAvailableSpaces(Board board, Square pieceLocation, int startingRow, Square twoSpacesForward,
            Square oneSpaceForward, Square diagonalLeft, Square diagonalRight, List<Square >squareList)
        {
            if (OneSpaceForwardAvailable(board, oneSpaceForward) && IsSquareOnBoard(oneSpaceForward))
            {
                squareList.Add(oneSpaceForward);
            }

            if (TwoSpaceForwardAvailable(board, pieceLocation, startingRow, twoSpacesForward, oneSpaceForward) && IsSquareOnBoard(twoSpacesForward))
            {
                squareList.Add(twoSpacesForward);
            }

            if (DiagonalLeftPossible(board, diagonalLeft, this) && IsSquareOnBoard(diagonalLeft))
            {
                squareList.Add(diagonalLeft);
            }

            if (DiagonalRightPossible(board, diagonalRight, this) && IsSquareOnBoard(diagonalRight))
            {
                squareList.Add(diagonalRight);
            }
        }
        
        public bool TwoSpaceForwardAvailable(Board board, Square pieceLocation, int startingRow,
            Square twoSpacesForward, Square oneSpaceForward)
        {
            bool result;
            if (!PieceInStartPosition(pieceLocation, startingRow))
            {
                result = false;
            }
            else
            {
                result = !IsSpaceOccupied(board, twoSpacesForward) && !IsSpaceOccupied(board, oneSpaceForward);
            }

            return result;

        }
        
        public bool OneSpaceForwardAvailable(Board board, Square oneSpaceForward)
        {
            return !IsSpaceOccupied(board, oneSpaceForward);
        } 

        public bool PieceInStartPosition(Square pieceLocation, int startingRow)
        {
            var result = pieceLocation.Row == startingRow;
            return result;
        }
        public Square TwoSpacesForward(Square pieceLocation, int twoSpace)
        { 
            Square secondAvailableSquare = new Square(pieceLocation.Row + twoSpace, pieceLocation.Col);
            return secondAvailableSquare;
        }

        public Square OneSpaceForward(Square pieceLocation, int oneSpace)
        {
            Square availableSquare = new Square(pieceLocation.Row + oneSpace, pieceLocation.Col);
            return availableSquare;
        }

        public Square DiagonalLeft(Square pieceLocation, int rowChange, int diagonalL)
        {
            Square diagonalTakePossibleL = new Square(pieceLocation.Row + rowChange, pieceLocation.Col + diagonalL);
            return diagonalTakePossibleL;
        }
        
        public Square DiagonalRight(Square pieceLocation, int rowChange, int diagonalR)
        {
            Square diagonalTakePossibleL = new Square(pieceLocation.Row + rowChange, pieceLocation.Col + diagonalR);
            return diagonalTakePossibleL;
        }
        
        public bool DiagonalLeftPossible(Board board, Square diagonalLeft, Piece player)
        {
            bool result;
            if (IsSpaceOccupied(board, diagonalLeft) && !IsOccupierFriendly(board, diagonalLeft, player))
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        } 
        public bool DiagonalRightPossible(Board board, Square diagonalRight, Piece player)
        {
            bool result;
            if (IsSpaceOccupied(board, diagonalRight) && !IsOccupierFriendly(board, diagonalRight, player))
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
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
        public bool IsOccupierFriendly(Board board, Square square, Piece pieceLocation)
                 {
                     bool isOccupierFriendly;
                     Piece getPiece = board.GetPiece(square);
                     if (getPiece.Player == pieceLocation.Player)
                     {
                         isOccupierFriendly = true;
                     }
                     else
                     {
                         isOccupierFriendly = false;
                     }
                     return isOccupierFriendly;
                 }

        public bool IsSquareOnBoard(Square square)
        {
            bool result;
            if (square.Row > 0 && square.Row < 7 && square.Col > 0 &&
                square.Col < 7)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}