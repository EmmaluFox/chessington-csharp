using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player, 100) { }
        
        
        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square kingLocation = board.FindPiece(this);
            List<Square> availableMoves = new List<Square>();
            /*availableMoves.Add(OneSquareUp(kingLocation));
            availableMoves.Add(OneSquareDown(kingLocation));
            availableMoves.Add(OneSquareRight(kingLocation));
            availableMoves.Add(OneSquareLeft(kingLocation));
            availableMoves.Add(DiagonalUpLeft(kingLocation));
            availableMoves.Add(DiagonalDownLeft(kingLocation));
            availableMoves.Add(DiagonalUpRight(kingLocation));
            availableMoves.Add(DiagonalDownRight(kingLocation));*/

            availableMoves.Add(CreateAvailableSquare(kingLocation, 1, 1));
            availableMoves.Add(CreateAvailableSquare(kingLocation, 1, -1));
            availableMoves.Add(CreateAvailableSquare(kingLocation, -1, 1));
            availableMoves.Add(CreateAvailableSquare(kingLocation, -1, -1));
            availableMoves.Add(CreateAvailableSquare(kingLocation, 0, 1));
            availableMoves.Add(CreateAvailableSquare(kingLocation, 0, -1));
            availableMoves.Add(CreateAvailableSquare(kingLocation, -1, 0));
            availableMoves.Add(CreateAvailableSquare(kingLocation, 1, 0));
            return availableMoves;
        }


        private Square CreateAvailableSquare(Square kingLocation, int rowDirection, int columnDirection)
        {
            Square availableSquare = new Square(kingLocation.Row+rowDirection, kingLocation.Col+columnDirection);
            return availableSquare;

        }
        /*Square OneSquareUp(Square kingLocation)
        {
            Square oneSquareUp = new Square(kingLocation.Row-1, kingLocation.Col);
            return oneSquareUp;
        }
        
        Square OneSquareDown(Square kingLocation)
        {
            Square oneSquareDown = new Square(kingLocation.Row+1, kingLocation.Col);
            return oneSquareDown;
        }
        
        Square OneSquareRight(Square kingLocation)
        {
            Square oneSquareRight = new Square(kingLocation.Row, kingLocation.Col+1);
            return oneSquareRight;
        }
        
        Square OneSquareLeft(Square kingLocation)
        {
            Square oneSquareLeft = new Square(kingLocation.Row, kingLocation.Col-1);
            return oneSquareLeft;
        }
        
        Square DiagonalUpRight(Square kingLocation)
        {
            Square diagonalUpRight = new Square(kingLocation.Row-1, kingLocation.Col+1);
            return diagonalUpRight;
        }
        
        Square DiagonalUpLeft(Square kingLocation)
        {
            Square diagonalUpLeft = new Square(kingLocation.Row-1, kingLocation.Col-1);
            return diagonalUpLeft;
        }
        Square DiagonalDownLeft(Square kingLocation)
        {
            Square diagonalDownLeft = new Square(kingLocation.Row+1, kingLocation.Col-1);
            return diagonalDownLeft;
        }
        
        Square DiagonalDownRight(Square kingLocation)
        {
            Square diagonalDownRight = new Square(kingLocation.Row+1, kingLocation.Col+1);
            return diagonalDownRight;
        }*/
    }
}