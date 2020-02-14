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

        public string WhoIsWinning()
        {
            string whoIsWinning = "";
            //who is winning code
            if (GetBlackScore() > GetWhiteScore())
            {
                whoIsWinning = "Black is in the lead!";
            } else if (GetWhiteScore() > GetBlackScore())
            {
                whoIsWinning = "White is in the lead!";
            } else if (GetBlackScore() == GetWhiteScore())
            {
                whoIsWinning = "It's neck and neck!";
            }
            return whoIsWinning;
        }
        
    }
}