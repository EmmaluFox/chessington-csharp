using System.Linq;

namespace Chessington.GameEngine
{
    public class ScoreCalculator
    {
        private IBoard _board;

        public ScoreCalculator(IBoard board)
        {
            _board = board;
        }
        
        public int GetWhiteScore()
        {
            int whiteScore = 0;// Should add up the value of all of the pieces that white has taken.
            foreach (var piece in _board.CapturedPieces)
            {
                if (piece.Player == Player.White)
                {
                   whiteScore += piece.CaptureValue; 
                }
            }

            return whiteScore;

            //return _board.CapturedPieces.Sum(piece => piece.CaptureValue);
        }
        public int GetBlackScore()
        {
            // Should add up the value of all of the pieces that black has taken.
            int blackScore = 0;// Should add up the value of all of the pieces that white has taken.
            foreach (var piece in _board.CapturedPieces)
            {
                if (piece.Player == Player.Black)
                {
                    blackScore += piece.CaptureValue; 
                }
            }

            return blackScore;
        }
    }
}