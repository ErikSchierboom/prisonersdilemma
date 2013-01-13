namespace StudioDonder.PrisonersDilemma.Domain
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;

    /// <summary>
    /// A simulation of a cooperation strategy matchup.
    /// </summary>
    public class CooperationStrategyMatchupSimulation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CooperationStrategyMatchupSimulation"/> class.
        /// </summary>
        /// <param name="matchup">The matchup.</param>
        public CooperationStrategyMatchupSimulation(CooperationStrategyMatchup matchup)
        {
            Contract.Requires(matchup != null);

            this.Matchup = matchup;
        }

        /// <summary>
        /// Gets the matchup.
        /// </summary>
        public CooperationStrategyMatchup Matchup { get; private set; }

        /// <summary>
        /// Simulates the specified number of rounds.
        /// </summary>
        /// <param name="numberOfRounds">The number of rounds.</param>
        /// <returns>The simulation result.</returns>
        public CooperationStrategyMatchupSimulationResult Simulate(int numberOfRounds)
        {
            Contract.Requires(numberOfRounds > 0);

            var matchupResults = this.GetMatchupResults(numberOfRounds).ToList();

            return new CooperationStrategyMatchupSimulationResult(this.Matchup, matchupResults);
        }

        /// <summary>
        /// Gets the matchup results.
        /// </summary>
        /// <param name="numberOfRounds"> </param>
        /// <returns>The matchup results.</returns>
        private IEnumerable<CooperationStrategyMatchupResult> GetMatchupResults(int numberOfRounds)
        {
            Contract.Requires(numberOfRounds > 0);

            var results = new List<CooperationStrategyMatchupResult>();

            var lastMatchupResult = this.Matchup.Play();
            results.Add(lastMatchupResult);

            for (var i = 1; i < numberOfRounds; i++)
            {
                lastMatchupResult = this.Matchup.Play(lastMatchupResult);
                results.Add(lastMatchupResult);
            }

            return results;
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.Matchup != null);
        }
    }
}