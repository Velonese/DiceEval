# Things Are About To Get Dicey

## Considerations

Based on the rules given in the document, we are only concerned about the highest score, so evaluating the following:

**Ones** through **Eights**

**ThreeOfAKind** & **FourOfAKind **
   
**These will always be less than or equal to Chance**

**LargeStraight** qualifies as **NoneOfAKind**, which scores the same. We will only check for the latter, as it is a simpler evaluation


So we need check only for the following:
            
**AllOfAKind** – Return 50 if all of the dice are the same

**NoneOfAKind** – Return 40 if there are no duplicate dice

Return the following only if they are greater than Chance (which has a max of possible score of 40):

**FullHouse** – Return 25 if there are two duplicate dice of one value and three duplicate dice of a different value

**SmallStraight** – Scores 30 if there are 4 or more dice in a sequence, otherwise scores 0

**Chance** – Scores the sum of all dice

## Development

Unit Tests were devised for the project, and then expanded to reach full coverage once code was complete.

## Assumptions & Alternatives

One small assumption is that the order of the dice is unimportant, so 3,2,4,1,4 still qualifies as a SmallStraight despite being out of order.

A larger assumption is that we are writing this code without considering that it will likely change. I am betting that whoever designed the results would be interested to realize that many of the conditions can never possibly be hit. In order to respond in a more agile way, I would write an class that could implement rules dynamically, so they could be updated individually, or added/removed from the system without big overhead or understanding of the more procedural code. Here's an example of that implementation:

```c#
    class DiceJudger
    {
        public static IDiceRule[] DefaultRules => new IDiceRule[]{
            CountRule.Instance, ChanceRule.Instance, KindRule.Instance, StraightRule.Instance
        };
        public DiceJudger() : this(DefaultRules) { }
        public DiceJudger(IDiceRule[] rules)
        {
            Rules = rules;
        }
        private IDiceRule[] Rules { get; set; }
        public int GetHighScore(params int[] rolls)
        {
            return GetAllScores(rolls).Max();
        }

        public IEnumerable<int> GetAllScores(params int[] rolls)
        {
            return Rules.SelectMany(rule => rule.EvaluateRoll(rolls));
        }
    }
```


Thanks for the coding project, it was fun!
