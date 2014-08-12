namespace PrisonersDilemma.Domain
{
    using System.Collections.Generic;
    using System.Linq;

    using Validation;

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
            Requires.NotNull(matchup, "matchup");

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
        public CooperationStrategyMatchupSimulationResult Simulate(uint numberOfRounds)
        {
            Requires.That(numberOfRounds > 0, "numberOfRounds", "The number of rounds must be greater than zero.");

            var matchupResults = this.GetMatchupResults(numberOfRounds).ToList();

            return new CooperationStrategyMatchupSimulationResult(this.Matchup, matchupResults);
        }

        /// <summary>
        /// Gets the matchup results.
        /// </summary>
        /// <param name="numberOfRounds"> </param>
        /// <returns>The matchup results.</returns>
        private IEnumerable<CooperationStrategyMatchupResult> GetMatchupResults(uint numberOfRounds)
        {
            Requires.That(numberOfRounds > 0, "numberOfRounds", "The number of rounds must be greater than zero.");
            
            var lastMatchupResult = this.Matchup.Play();
            yield return lastMatchupResult;

            for (var i = 1; i < numberOfRounds; i++)
            {
                lastMatchupResult = this.Matchup.Play(lastMatchupResult);
                yield return lastMatchupResult;
            }
        }
    }
}