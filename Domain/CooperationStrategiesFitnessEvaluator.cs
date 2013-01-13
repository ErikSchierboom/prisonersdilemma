namespace StudioDonder.PrisonersDilemma.Domain
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;

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
			Contract.Requires(cooperationStrategyRepository != null);

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
			Contract.Requires(this.CooperationStrategies != null);
			Contract.Requires(this.CooperationChoicesPayoff != null);
			Contract.Requires(this.NumberOfRounds > 0);

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
			Contract.Requires(this.CooperationStrategies != null);
            Contract.Requires(this.CooperationChoicesPayoff != null);
            Contract.Ensures(Contract.Result<IEnumerable<CooperationStrategyMatchup>>() != null);

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
            Contract.Requires(cooperationStrategy != null);
            Contract.Requires(simulationResults != null);

            return
                simulationResults
                    .Where(simulationResult => simulationResult.Matchup.StrategyA == cooperationStrategy)
                    .Sum(simulationResult => simulationResult.PayoffForStrategyA) +
                simulationResults
                    .Where(simulationResult => simulationResult.Matchup.StrategyB == cooperationStrategy)
                    .Sum(simulationResult => simulationResult.PayoffForStrategyB);
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.CooperationChoicesPayoff != null);
            Contract.Invariant(this.CooperationStrategies != null);
			Contract.Invariant(this.NumberOfRounds > 0);
        }
    }
}