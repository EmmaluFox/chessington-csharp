﻿﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        //Constructors
        protected Piece(Player player)
        {
            Player = player;
        }

        public Player Player { get; private set; }
        
        //Methods
        public abstract IEnumerable<Square> GetAvailableMoves(Board board);
       

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
        }
    }
}