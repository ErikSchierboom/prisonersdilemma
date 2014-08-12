namespace PrisonersDilemma.Domain
{
    /// <summary>
    /// A naive cooperation strategy that always cooperates.
    /// </summary>
    public class NaiveCooperationStrategy : CooperationStrategy
    {
        private const string StrategyName = "Naive";
        private const string StrategyDescription = "Always cooperate.";

        /// <summary>
        /// Initializes a new instance of the <see cref="NaiveCooperationStrategy"/> class.
        /// </summary>
        public NaiveCooperationStrategy()
            : base(StrategyName, StrategyDescription)
        {
        }

        /// <summary>
        /// Make a choice.
        /// </summary>
        /// <param name="opponentLastChoice">The last choice of the opponent.</param>
        /// <returns>
        /// The choice.
        /// </returns>
        public override CooperationChoice Choose(CooperationChoice opponentLastChoice)
        {
            return CooperationChoice.Cooperate;
        }
    }
}