namespace StudioDonder.PrisonersDilemma.Domain
{
    using Validation;

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
            Requires.NotNull(strategyAResult, "strategyAResult");
            Requires.NotNull(strategyBResult, "strategyBResult");

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
    }
}