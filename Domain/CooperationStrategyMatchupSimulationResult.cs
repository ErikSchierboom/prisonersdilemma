namespace StudioDonder.PrisonersDilemma.Domain
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;

    /// <summary>
    /// The result of a cooperation strategy matchup simulation.
    /// </summary>
    public class CooperationStrategyMatchupSimulationResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CooperationStrategyMatchupSimulationResult"/> class.
        /// </summary>
        /// <param name="matchup">The cooperation strategy matchup.</param>
        /// <param name="matchupResults">The matchup results.</param>
        public CooperationStrategyMatchupSimulationResult(
            CooperationStrategyMatchup matchup, IList<CooperationStrategyMatchupResult> matchupResults)
        {
            Contract.Requires(matchup != null);
            Contract.Requires(matchupResults != null);

            this.Matchup = matchup;
            this.MatchupResults = matchupResults;
        }

        /// <summary>
        /// Gets the matchup.
        /// </summary>
        public CooperationStrategyMatchup Matchup { get; private set; }

        /// <summary>
        /// Gets the matchup results.
        /// </summary>
        public IList<CooperationStrategyMatchupResult> MatchupResults { get; private set; }

        /// <summary>
        /// Gets the number of rounds.
        /// </summary>
        public int NumberOfRounds
        {
            get
            {
                return this.MatchupResults.Count;
            }
        }

        /// <summary>
        /// Gets the payoff for strategy A.
        /// </summary>
        public int PayoffForStrategyA
        {
            get
            {
                return this.MatchupResults.Sum(matchupResult => matchupResult.StrategyAResult.Payoff);
            }
        }

        /// <summary>
        /// Gets the payoff for strategy B.
        /// </summary>
        public int PayoffForStrategyB
        {
            get
            {
                return this.MatchupResults.Sum(matchupResult => matchupResult.StrategyBResult.Payoff);
            }
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.Matchup != null);
            Contract.Invariant(this.MatchupResults != null);
        }
    }
}