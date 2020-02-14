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
            // Should add up the value of all of the pieces that white has taken.
            return _board.CapturedPieces.Sum(piece => piece.CaptureValue);
        }

        public int GetBlackScore()
        {
            // Should add up the value of all of the pieces that black has taken.
            return 0;
        }
    }
}s