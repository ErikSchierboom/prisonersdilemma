namespace StudioDonder.PrisonersDilemma.Domain
{
	using System.Diagnostics.Contracts;

    /// <summary>
    /// The fitness of a specific cooperation strategy.
    /// </summary>
	public class CooperationStrategyFitness
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CooperationStrategyFitness"/> class.
        /// </summary>
        /// <param name="cooperationStrategy">The cooperation strategy.</param>
        /// <param name="totalPayoff">The total payoff.</param>
        public CooperationStrategyFitness(CooperationStrategy cooperationStrategy, int totalPayoff)
        {
            Contract.Requires(cooperationStrategy != null);

            this.Strategy = cooperationStrategy;
            this.TotalPayoff = totalPayoff;
        }

        /// <summary>
        /// Gets the strategy.
        /// </summary>
        public CooperationStrategy Strategy { get; private set; }

        /// <summary>
        /// Gets the total payoff.
        /// </summary>
        public int TotalPayoff { get; private set; }
    }
}