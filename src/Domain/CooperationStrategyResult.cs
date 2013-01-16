namespace StudioDonder.PrisonersDilemma.Domain
{
    using System;

    /// <summary>
    /// A cooperation strategy's result.
    /// </summary>
    public class CooperationStrategyResult : IEquatable<CooperationStrategyResult>
    {
        /// <summary>
        /// Gets or sets the strategy.
        /// </summary>
        public CooperationStrategy Strategy { get; set; }

        /// <summary>
        /// Gets or sets the cooperation choice made.
        /// </summary>
        public CooperationChoice ChoiceMade { get; set; }

        /// <summary>
        /// Gets or sets the payoff of the choice made.
        /// </summary>
        public int Payoff { get; set; }

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

            return this.Equals(obj as CooperationStrategyResult);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            if (this.Strategy == null)
            {
                return this.ChoiceMade.GetHashCode() ^ this.Payoff.GetHashCode();
            }

            return this.Strategy.GetHashCode() ^ this.ChoiceMade.GetHashCode() ^ this.Payoff.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified <see cref="CooperationStrategyResult"/> is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="CooperationStrategyResult"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="CooperationStrategyResult"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(CooperationStrategyResult other)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return ReferenceEquals(this.Strategy, other.Strategy) &&
                   this.ChoiceMade == other.ChoiceMade &&
                   this.Payoff == other.Payoff;
        }
    }
}