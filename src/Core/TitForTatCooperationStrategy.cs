namespace PrisonersDilemma.Domain
{
    /// <summary>
    /// A cooperation strategy that mimics the opponent's last choice.
    /// </summary>
    public class TitForTatCooperationStrategy : CooperationStrategy
    {
        private const string StrategyName = "Tit for tat";

        private const string StrategyDescription =
            "Mimic the choice last made by the opponent and cooperate by default.";

        /// <summary>
        /// Initializes a new instance of the <see cref="TitForTatCooperationStrategy"/> class.
        /// </summary>
        public TitForTatCooperationStrategy()
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
            if (opponentLastChoice == CooperationChoice.None)
            {
                return CooperationChoice.Cooperate;
            }

            return opponentLastChoice;
        }
    }
}