namespace PrisonersDilemma.Domain
{
    using System;

    using Validation;

    /// <summary>
    /// This class described a matchup between cooperation strategies.
    /// </summary>
    public class CooperationStrategyMatchup : IEquatable<CooperationStrategyMatchup>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CooperationStrategyMatchup"/> class.
        /// </summary>
        /// <param name="strategyA">Strategy A.</param>
        /// <param name="strategyB">Strategy B.</param>
        /// <param name="cooperationChoicesPayoff">The cooperation choice payoffs.</param>
        public CooperationStrategyMatchup(
            CooperationStrategy strategyA,
            CooperationStrategy strategyB,
            CooperationChoicesPayoff cooperationChoicesPayoff)
        {
            Requires.NotNull(strategyA, "strategyA");
            Requires.NotNull(strategyB, "strategyB");
            Requires.NotNull(cooperationChoicesPayoff, "cooperationChoicesPayoff");

            this.StrategyA = strategyA;
            this.StrategyB = strategyB;
            this.CooperationChoicesPayoff = cooperationChoicesPayoff;
        }

        /// <summary>
        /// Gets strategy A.
        /// </summary>
        public CooperationStrategy StrategyA { get; private set; }

        /// <summary>
        /// Gets strategy B.
        /// </summary>
        public CooperationStrategy StrategyB { get; private set; }

        /// <summary>
        /// Gets the cooperation choice payoffs.
        /// </summary>
        public CooperationChoicesPayoff CooperationChoicesPayoff { get; private set; }

        /// <summary>
        /// Plays this matchup.
        /// </summary>
        /// <returns>The matchup result.</returns>
        public CooperationStrategyMatchupResult Play()
        {
            return this.CreateCooperationStrategyMatchupResult(this.StrategyA.Choose(CooperationChoice.None), this.StrategyB.Choose(CooperationChoice.None));
        }

        /// <summary>
        /// Plays this matchup.
        /// </summary>
        /// <param name="lastMatchupResult">The last matchup result.</param>
        /// <returns>
        /// The matchup result.
        /// </returns>
        public CooperationStrategyMatchupResult Play(CooperationStrategyMatchupResult lastMatchupResult)
        {
            Requires.NotNull(lastMatchupResult, "lastMatchupResult");

            return this.CreateCooperationStrategyMatchupResult(
                this.StrategyA.Choose(lastMatchupResult.StrategyBResult.ChoiceMade),
                this.StrategyB.Choose(lastMatchupResult.StrategyAResult.ChoiceMade));
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return this.Equals(obj as CooperationStrategyMatchup);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return this.StrategyA.GetHashCode() ^ this.StrategyB.GetHashCode() ^
                   this.CooperationChoicesPayoff.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified <see cref="CooperationStrategyMatchup"/> is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="CooperationStrategyMatchup"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="CooperationStrategyMatchup"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(CooperationStrategyMatchup other)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.StrategiesEqualOrFlipped(other) && this.CooperationChoicesPayoff.Equals(other.CooperationChoicesPayoff);
        }

        /// <summary>
        /// Check if the strategies are equal or flipped.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>
        ///   <c>true</c>, if the strategies are equal or flipped; otherwise, <c>false</c>.
        /// </returns>
        private bool StrategiesEqualOrFlipped(CooperationStrategyMatchup other)
        {
            Requires.NotNull(other, "other");

            return
                (this.StrategyA.Equals(other.StrategyA) && this.StrategyB.Equals(other.StrategyB)) ||
                (this.StrategyA.Equals(other.StrategyB) && this.StrategyB.Equals(other.StrategyA));
        }

        /// <summary>
        /// Create the cooperation strategy matchup result.
        /// </summary>
        /// <param name="cooperationChoiceA">Cooperation choice A.</param>
        /// <param name="cooperationChoiceB">Cooperation choice B.</param>
        /// <returns>The matchup result.</returns>
        private CooperationStrategyMatchupResult CreateCooperationStrategyMatchupResult(
            CooperationChoice cooperationChoiceA, CooperationChoice cooperationChoiceB)
        {
            var strategyAResult = new CooperationStrategyResult
                {
                    Strategy = this.StrategyA,
                    ChoiceMade = cooperationChoiceA,
                    Payoff = this.CooperationChoicesPayoff.Calculate(cooperationChoiceA, cooperationChoiceB),
                };

            var strategyBResult = new CooperationStrategyResult
                {
                    Strategy = this.StrategyB,
                    ChoiceMade = cooperationChoiceB,
                    Payoff = this.CooperationChoicesPayoff.Calculate(cooperationChoiceB, cooperationChoiceA),
                };

            return new CooperationStrategyMatchupResult(strategyAResult, strategyBResult);
        }
    }
}