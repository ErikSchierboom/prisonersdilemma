namespace StudioDonder.PrisonersDilemma.Domain
{
    /// <summary>
    /// An evil cooperation strategy that always defects.
    /// </summary>
    public class EvilCooperationStrategy : CooperationStrategy
    {
        private const string StrategyName = "Evil";
        private const string StrategyDescription = "Always defect.";

        /// <summary>
        /// Initializes a new instance of the <see cref="EvilCooperationStrategy"/> class.
        /// </summary>
        public EvilCooperationStrategy()
            : base(StrategyName, StrategyDescription)
        {
        }

        /// <summary>
        /// 	Make a choice.
        /// </summary>
        /// <param name="opponentLastChoice">
        /// The last choice of the opponent.
        /// </param>
        /// <returns>
        /// 	The choice.
        /// </returns>
        public override CooperationChoice Choose(CooperationChoice opponentLastChoice)
        {
            return CooperationChoice.Defect;
        }
    }
}