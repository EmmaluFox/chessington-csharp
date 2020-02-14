using System;
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
        string _winner = "";
        string _runnerUp = "";
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


        public void PrintScoreUpdate()
        {
            WhoIsWinning();
            Console.WriteLine(WinningByHowMuch());
            
        }
        public void WhoIsWinning()
        {
            //who is winning code
            if (GetBlackScore() > GetWhiteScore())
            {
                _winner = "Black";
                _runnerUp = "White";

            } else if (GetWhiteScore() > GetBlackScore())
            {
                _winner = "White";
                _runnerUp = "Black";
            } else if (GetBlackScore() == GetWhiteScore())
            {
                _winner = "Neither player";
            }
        }

        public int GetDifferenceInScores()
        {
            int balance = 0;
            if (_winner == "Black")
            {
                balance = GetBlackScore() - GetWhiteScore();
            } else if (_winner == "White")
            {
                balance = GetWhiteScore() - GetBlackScore();
            }
            return balance;
        }

        public string WinningByHowMuch()
        {
            int balance = GetDifferenceInScores();
            string message = "";
            if (balance < 3 && balance > 0)
            {
                message = $@"{_winner} is in the lead, but it's very close!";
            } else if (balance > 2 && balance < 6)
            {
                message = $@"{_winner} has taken a slight lead! Come on {_runnerUp}!";
            } else if (balance > 5 && balance < 10)
            {
                message = $@"{_winner} is winning!";
            } else if (balance > 9)
            {
                message = $@"{_winner} is way ahead of {_runnerUp}!";
            } else if (balance == 0)
            {
                message = "Its neck and neck!";
            }
            return message;
        }
        
    }
}