using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThingsAreAboutToGetDicey
{
    public static class DiceJudge
    {
        /// <summary>
        /// Returns the highest score for a grouping of five numbers 1-8 based on the rules established in Software Engineer Test.pdf.
        /// </summary>
        /// <param name="values">A group of 5 integers, each ranging from 1-8 inclusive</param>
        /// <returns>The highest score resulting</returns>
        public static int GetHighScore(params int[] values)
        {
            //Let's take a closer look at the rules to see what we need to implement:
            /*

            We are only concerned about the highest score, so evaluating the following:

            Ones through Eights
            ThreeOfAKind & FourOfAKind 
            === These will always be less than or equal to Chance ===
            === LargeStraight qualifies as NoneOfAKind, which scores the same. We will only check for the latter, as it is a simpler evaluation ===

            So we need to check for:
            
            
            AllOfAKind – Return 50 if all of the dice are the same
            NoneOfAKind – Return 40 if there are no duplicate dice

            Return the following only if they are greater than Chance (which has a max of 40):
            FullHouse – Return 25 if there are two duplicate dice of one value and three duplicate dice of a different value
            SmallStraight – Scores 30 if there are 4 or more dice in a sequence, otherwise scores 0

            Chance – Scores the sum of all dice
             */
            var distinctSet = values.Distinct().OrderBy(d => d);
            if (distinctSet.Count() == 1)
            {
                //AllOfAKind - we can't possibly beat 50.
                return 50;
            }
            if (distinctSet.Count() == 5)
            {
                //We have NoneOfAKind - we can't do better than 40
                return 40;
            }
            int chance = values.Sum();
            if (distinctSet.Count() == 2 && (values.Count(v => v == distinctSet.First()) & 2) == 2)
            {
                //Of two distinct values, we check if the count of either is 2 or 3
                return chance > 25 ? chance : 25;
            }
            if (distinctSet.Count() == 4 && distinctSet.First() + 3 == distinctSet.Last())
            {
                //I am making the assumption that we do *not* respect the order of the rolls in this case
                //chance could be higher if someone rolls 5,6,7,7,8 or a similar result.
                return chance > 30 ? chance : 30;
            }
            return chance;
        }

    }
}
