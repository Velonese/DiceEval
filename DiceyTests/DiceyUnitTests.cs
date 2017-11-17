using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThingsAreAboutToGetDicey;

namespace DiceyTests
{
    [TestClass]
    public class DiceyUnitTests
    {

        [TestMethod]
        public void AllOfAKindAwards50()
        {
            Assert.AreEqual(50, DiceJudge.GetHighScore(1, 1, 1, 1, 1));
        }

        [TestMethod]
        public void NoneOfAKindAwards40()
        {
            Assert.AreEqual(40, DiceJudge.GetHighScore(1, 8, 2, 7, 4));
        }

        [TestMethod]
        public void FullHouseAwards25()
        {
            Assert.AreEqual(25, DiceJudge.GetHighScore(5, 5, 5, 4, 4));
        }

        [TestMethod]
        public void FullHouseDoesNotAwardFourOfAKind()
        {
            Assert.AreEqual(8, DiceJudge.GetHighScore(4, 1, 1, 1, 1));
        }

        [TestMethod]
        public void FullHouseAwardsChanceIfHigher()
        {
            Assert.AreEqual(27, DiceJudge.GetHighScore(5, 5, 5, 6, 6));
        }

        [TestMethod]
        public void SmallStraightAwards30()
        {
            Assert.AreEqual(30, DiceJudge.GetHighScore(1, 2, 3, 1, 4));
        }
        [TestMethod]
        public void SmallStraightAwardsChanceIfHigher()
        {
            Assert.AreEqual(33, DiceJudge.GetHighScore(5, 6, 7, 7, 8));
        }
        [TestMethod]
        public void ChanceAwardedIfNothingElse()
        {
            Assert.AreEqual(35, DiceJudge.GetHighScore(6, 7, 7, 7, 8));
        }
    }
}
