namespace StudioDonder.PrisonersDilemma.Domain
{
    using System.Collections.Generic;
    using System.Linq;

    using Validation;

    /// <summary>
    /// Evaluate a set of cooperation strategies for their relative fitness.
    /// </summary>
    public class CooperationStrategiesFitnessEvaluator
    {
    	private const int DefaultNumberOfRounds = 10;

		/// <summary>
		/// Initializes a new instance of the <see cref="CooperationStrategiesFitnessEvaluator"/> class.
		/// </summary>
    	public CooperationStrategiesFitnessEvaluator() : this(new CooperationStrategyRepository())
    	{
    	}

		/// <summary>
		/// Initializes a new instance of the <see cref="CooperationStrategiesFitnessEvaluator"/> class.
		/// </summary>
		/// <param name="cooperationStrategyRepository">The cooperation strategy repository.</param>
        public CooperationStrategiesFitnessEvaluator(CooperationStrategyRepository cooperationStrategyRepository)
        {
			Requires.NotNull(cooperationStrategyRepository, "cooperationStrategyRepository");

            this.CooperationChoicesPayoff = new CooperationChoicesPayoff();
        	this.NumberOfRounds = DefaultNumberOfRounds;
			this.CooperationStrategies = cooperationStrategyRepository.GetAll();
        }

		/// <summary>
		/// Gets or sets the cooperation strategies.
		/// </summary>
    	public IEnumerable<CooperationStrategy> CooperationStrategies { get; set; }

        /// <summary>
        /// Gets the cooperation choices payoff.
        /// </summary>
        public CooperationChoicesPayoff CooperationChoicesPayoff { get; set; }

		/// <summary>
		/// Gets or sets the number of rounds.
		/// </summary>
		public int NumberOfRounds { get; set; }

		/// <summary>
		/// Evaluates the specified cooperation strategies.
		/// </summary>
		/// <returns>
		/// The fitnesses.
		/// </returns>
        public IList<CooperationStrategyFitness> Evaluate()
        {
            Verify.Operation(this.CooperationStrategies != null, "CooperationStrategies must not be null.");
            Verify.Operation(this.CooperationChoicesPayoff != null, "CooperationChoicesPayoff must not be null.");
            Verify.Operation(this.NumberOfRounds > 0, "NumberOfRounds must be greater than zero.");

			var fitnesses = new List<CooperationStrategyFitness>(this.CooperationStrategies.Count());
            var simulationResults = new List<CooperationStrategyMatchupSimulationResult>();

            foreach (var matchup in this.GetMatchups())
            {
                if (matchup == null)
                {
                    continue;
                }

                var simulation = new CooperationStrategyMatchupSimulation(matchup);
				simulationResults.Add(simulation.Simulate(this.NumberOfRounds));
            }

			foreach (var cooperationStrategy in this.CooperationStrategies)
            {
                if (cooperationStrategy == null)
                {
                    continue;
                }

                var totalPayoff = CalculateTotalPayoff(cooperationStrategy, simulationResults);
                fitnesses.Add(new CooperationStrategyFitness(cooperationStrategy, totalPayoff));
            }

            return fitnesses;
        }

        /// <summary>
        /// Gets the strategy matchups.
        /// </summary>
        /// <returns>The matchups.</returns>
        private IEnumerable<CooperationStrategyMatchup> GetMatchups()
        {
            Verify.Operation(this.CooperationStrategies != null, "CooperationStrategies must not be null.");
            Verify.Operation(this.CooperationChoicesPayoff != null, "CooperationChoicesPayoff must not be null.");

            var strategyMatchups = new HashSet<CooperationStrategyMatchup>();

			foreach (var cooperationStrategy in this.CooperationStrategies)
            {
                if (cooperationStrategy == null)
                {
                    continue;
                }

				foreach (var otherCooperationStrategy in this.CooperationStrategies)
                {
                    if (otherCooperationStrategy == null)
                    {
                        continue;
                    }

                    strategyMatchups.Add(new CooperationStrategyMatchup(cooperationStrategy, otherCooperationStrategy, this.CooperationChoicesPayoff));
                }
            }

            return strategyMatchups;
        }

        /// <summary>
        /// Calculates the total payoff.
        /// </summary>
        /// <param name="cooperationStrategy">The cooperation strategy.</param>
        /// <param name="simulationResults">The simulation results.</param>
        /// <returns>The payoff.</returns>
        private static int CalculateTotalPayoff(CooperationStrategy cooperationStrategy, List<CooperationStrategyMatchupSimulationResult> simulationResults)
        {
            Requires.NotNull(cooperationStrategy, "cooperationStrategy");
            Requires.NotNull(simulationResults, "simulationResults");

            return
                simulationResults
                    .Where(simulationResult => simulationResult.Matchup.StrategyA == cooperationStrategy)
                    .Sum(simulationResult => simulationResult.PayoffForStrategyA) +
                simulationResults
                    .Where(simulationResult => simulationResult.Matchup.StrategyB == cooperationStrategy)
                    .Sum(simulationResult => simulationResult.PayoffForStrategyB);
        }
    }
}