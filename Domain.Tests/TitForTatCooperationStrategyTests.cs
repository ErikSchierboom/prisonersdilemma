namespace StudioDonder.PrisonersDilemma.Domain.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests for the <see cref="TitForTatCooperationStrategy"/> class.
    /// </summary>
    [TestClass]
    public class TitForTatCooperationStrategyTests : CooperationStrategyTestsBase
    {
        /// <summary>
        /// Test that the Choose method will always return <see cref="CooperationChoice.Defect"/>
        /// when the last choice by the opponent is <see cref="CooperationChoice.Cooperate"/>.
        /// </summary>
        [TestMethod]
        public void Choose_WithLastChoiceByOpponentIsCooperate_ReturnsCooperate()
        {
            // Arrange
            var strategy = new TitForTatCooperationStrategy();

            // Act
            var choice = strategy.Choose(CooperationChoice.Cooperate);

            // Assert
            Assert.AreEqual(CooperationChoice.Cooperate, choice);
        }

        /// <summary>
        /// Test that the Choose method will always return <see cref="CooperationChoice.Defect"/>
        /// when the last choice by the opponent is <see cref="CooperationChoice.Defect"/>.
        /// </summary>
        [TestMethod]
        public void Choose_WithLastChoiceByOpponentIsDefect_ReturnsDefect()
        {
            // Arrange
            var strategy = new TitForTatCooperationStrategy();

            // Act
            var choice = strategy.Choose(CooperationChoice.Defect);

            // Assert
            Assert.AreEqual(CooperationChoice.Defect, choice);
        }

        /// <summary>
        /// Test that the Choose method will always return <see cref="CooperationChoice.Defect"/>
        /// when the last choice by the opponent is <see cref="CooperationChoice.None"/>.
        /// </summary>
        [TestMethod]
        public void Choose_WithLastChoiceByOpponentIsNone_ReturnsCooperate()
        {
            // Arrange
            var strategy = new TitForTatCooperationStrategy();

            // Act
            var choice = strategy.Choose(CooperationChoice.None);

            // Assert
            Assert.AreEqual(CooperationChoice.Cooperate, choice);
        }

        /// <summary>
        /// The create different strategy.
        /// </summary>
        /// <returns>
        /// The strategy.
        /// </returns>
        protected override CooperationStrategy CreateDifferentStrategy()
        {
            return new EvilCooperationStrategy();
        }

        /// <summary>
        /// The create strategy.
        /// </summary>
        /// <returns>
        /// The strategy.
        /// </returns>
        protected override CooperationStrategy CreateStrategy()
        {
            return new TitForTatCooperationStrategy();
        }

        /// <summary>
        /// Gets the correct name.
        /// </summary>
        /// <returns>
        /// The name.
        /// </returns>
        protected override string GetCorrectName()
        {
            return "Tit for tat";
        }

        /// <summary>
        /// Gets the correct description.
        /// </summary>
        /// <returns>
        /// The description.
        /// </returns>
        protected override string GetCorrectDescription()
        {
            return "Mimic the choice last made by the opponent and cooperate by default.";
        }
    }
}