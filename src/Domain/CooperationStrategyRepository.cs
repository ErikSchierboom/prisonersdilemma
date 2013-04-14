namespace StudioDonder.PrisonersDilemma.Domain
{
    using System.Collections.Generic;

    /// <summary>
    /// Repository dealing with cooperation strategies.
    /// </summary>
    public class CooperationStrategyRepository
    {
        private readonly IEnumerable<CooperationStrategy> cooperationStrategies;

        /// <summary>
        /// Initializes a new instance of the <see cref="CooperationStrategyRepository"/> class.
        /// </summary>
        public CooperationStrategyRepository()
        {
            this.cooperationStrategies = new HashSet<CooperationStrategy>
                {
                    new NaiveCooperationStrategy(),
                    new EvilCooperationStrategy(),
                    new TitForTatCooperationStrategy(),
                };
        }

        /// <summary>
        /// Gets all strategies.
        /// </summary>
        /// <returns>
        /// The strategies.
        /// </returns>
        public IEnumerable<CooperationStrategy> GetAll()
        {
            return this.cooperationStrategies;
        }
    }
}