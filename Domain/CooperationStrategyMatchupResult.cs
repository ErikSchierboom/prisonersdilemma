namespace StudioDonder.PrisonersDilemma.Domain
{
    using System.Diagnostics.Contracts;

    /// <summary>
    /// The result of a cooperation strategy matchup.
    /// </summary>
    public class CooperationStrategyMatchupResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CooperationStrategyMatchupResult"/> class.
        /// </summary>
        /// <param name="strategyAResult">The result for strategy A.</param>
        /// <param name="strategyBResult">The result for strategy B.</param>
        public CooperationStrategyMatchupResult(
            CooperationStrategyResult strategyAResult, CooperationStrategyResult strategyBResult)
        {
            Contract.Requires(strategyAResult != null);
            Contract.Requires(strategyBResult != null);

            this.StrategyAResult = strategyAResult;
            this.StrategyBResult = strategyBResult;
        }

        /// <summary>
        /// Gets the result for strategy A.
        /// </summary>
        public CooperationStrategyResult StrategyAResult { get; private set; }

        /// <summary>
        /// Gets the result for strategy B.
        /// </summary>
        public CooperationStrategyResult StrategyBResult { get; private set; }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.StrategyAResult != null);
            Contract.Invariant(this.StrategyBResult != null);
        }
    }
}