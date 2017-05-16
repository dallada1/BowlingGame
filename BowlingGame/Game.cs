using System;

namespace BowlingGame
{
    public class Game
    {
        public Int32 GetScore(Int32[] rolls)
        {
            var score = 0;
            var rollIndex = 0;

            for (var frame = 1; frame < 10; frame++)
            {
                if (IsStrike(rolls[rollIndex]))
                {
                    score += GetPinsToAddForStrike(rolls, rollIndex);
                    rollIndex++;
                }
                else if (IsSpare(rolls[rollIndex], rolls[rollIndex + 1]))
                {
                    score += GetPinsToAddForSpare(rolls, rollIndex);
                    rollIndex += 2;
                }
                else
                {
                    score += GetPinsForFrame(rolls, rollIndex);
                    rollIndex += 2;
                }
            }

            score += GetTenthFramePins(rolls, rollIndex);
           
            return score;
        }

        private static Boolean IsSpare(Int32 firstThrow, Int32 secondThrow)
        {
            return firstThrow + secondThrow == 10 && firstThrow != 10;
        }

        private static Boolean IsStrike(Int32 firstThrow)
        {
            return firstThrow == 10;
        }
        
        private static Int32 GetPinsToAddForStrike(Int32[] rolls, Int32 rollIndex)
        {
            return 10 + rolls[rollIndex + 1] + rolls[rollIndex + 2];
        }

        private static Int32 GetPinsToAddForSpare(Int32[] rolls, Int32 rollIndex)
        {
            return 10 + rolls[rollIndex + 2];
        }

        private static Int32 GetPinsForFrame(Int32[] rolls, Int32 rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1];
        }

        private static Int32 GetTenthFramePins(Int32[] rolls, Int32 rollIndex)
        {
            var tenthFrameScore = 0;

            for (var i = rollIndex; i < rolls.Length; i++)
                tenthFrameScore += rolls[i];

            return tenthFrameScore;
        }
    }

}
