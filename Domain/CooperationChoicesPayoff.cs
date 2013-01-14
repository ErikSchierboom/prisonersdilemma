namespace StudioDonder.PrisonersDilemma.Domain
{
    using System;

    /// <summary>
    /// Determine the payoff for cooperation choices.
    /// </summary>
    public class CooperationChoicesPayoff : IEquatable<CooperationChoicesPayoff>
    {
        public const int DefaultPayoffForCooperateAndCooperate = 3;
        public const int DefaultPayoffForCooperateAndDefect = 0;
        public const int DefaultPayoffForDefectAndCooperate = 5;
        public const int DefaultPayoffForDefectAndDefect = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="CooperationChoicesPayoff"/> class.
        /// </summary>
        public CooperationChoicesPayoff()
        {
            this.PayoffForCooperateAndCooperate = DefaultPayoffForCooperateAndCooperate;
            this.PayoffForCooperateAndDefect = DefaultPayoffForCooperateAndDefect;
            this.PayoffForDefectAndCooperate = DefaultPayoffForDefectAndCooperate;
            this.PayoffForDefectAndDefect = DefaultPayoffForDefectAndDefect;
        }

        /// <summary>
        /// Gets or sets the payoff for cooperate and cooperate.
        /// </summary>
        public int PayoffForCooperateAndCooperate { get; set; }

        /// <summary>
        /// Gets or sets the payoff for cooperate and defect.
        /// </summary>
        public int PayoffForCooperateAndDefect { get; set; }

        /// <summary>
        /// Gets or sets the payoff for defect and cooperate.
        /// </summary>
        public int PayoffForDefectAndCooperate { get; set; }

        /// <summary>
        /// Gets or sets the payoff for defect and defect.
        /// </summary>
        public int PayoffForDefectAndDefect { get; set; }

        /// <summary>
        /// Calculates the payoff.
        /// </summary>
        /// <param name="cooperationChoice">The cooperation choice.</param>
        /// <param name="otherCooperationChoice">The other cooperation choice.</param>
        /// <returns>The payoff.</returns>
        public int Calculate(CooperationChoice cooperationChoice, CooperationChoice otherCooperationChoice)
        {
            if (cooperationChoice == CooperationChoice.Cooperate)
            {
                return otherCooperationChoice == CooperationChoice.Cooperate
                           ? this.PayoffForCooperateAndCooperate
                           : this.PayoffForCooperateAndDefect;
            }

            return otherCooperationChoice == CooperationChoice.Cooperate
                       ? this.PayoffForDefectAndCooperate
                       : this.PayoffForDefectAndDefect;
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

            return this.Equals(obj as CooperationChoicesPayoff);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return
                this.PayoffForCooperateAndCooperate.GetHashCode() ^
                this.PayoffForCooperateAndDefect.GetHashCode() ^
                this.PayoffForDefectAndCooperate.GetHashCode() ^
                this.PayoffForDefectAndDefect.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified <see cref="CooperationStrategyResult"/> is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="CooperationStrategyResult"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="CooperationStrategyResult"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(CooperationChoicesPayoff other)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return
                this.PayoffForCooperateAndCooperate == other.PayoffForCooperateAndCooperate &&
                this.PayoffForCooperateAndDefect == other.PayoffForCooperateAndDefect &&
                this.PayoffForDefectAndCooperate == other.PayoffForDefectAndCooperate &&
                this.PayoffForDefectAndDefect == other.PayoffForDefectAndDefect;
        }
    }
}