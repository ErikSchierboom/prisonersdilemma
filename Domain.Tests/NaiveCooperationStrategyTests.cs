namespace StudioDonder.PrisonersDilemma.Domain.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests for the <see cref="NaiveCooperationStrategy"/> class.
    /// </summary>
    [TestClass]
    public class NaiveCooperationStrategyTests : CooperationStrategyTestsBase
    {
        /// <summary>
        /// Test that the Choose method will always return <see cref="CooperationChoice.Cooperate"/>
        /// when the last choice by the opponent is <see cref="CooperationChoice.None"/>.
        /// </summary>
        [TestMethod]
        public void Choose_WithLastChoiceByOpponentIsNone_ReturnsCooperate()
        {
            // Arrange
            var strategy = new NaiveCooperationStrategy();

            // Act
            var choice = strategy.Choose(CooperationChoice.None);

            // Assert
            Assert.AreEqual(CooperationChoice.Cooperate, choice);
        }

        /// <summary>
        /// Test that the Choose method will always return <see cref="CooperationChoice.Cooperate"/>
        /// when the last choice by the opponent is <see cref="CooperationChoice.Cooperate"/>.
        /// </summary>
        [TestMethod]
        public void Choose_WithLastChoiceByOpponentIsCooperate_ReturnsCooperate()
        {
            // Arrange
            var strategy = new NaiveCooperationStrategy();

            // Act
            var choice = strategy.Choose(CooperationChoice.Cooperate);

            // Assert
            Assert.AreEqual(CooperationChoice.Cooperate, choice);
        }

        /// <summary>
        /// Test that the Choose method will always return <see cref="CooperationChoice.Cooperate"/>
        /// when the last choice by the opponent is <see cref="CooperationChoice.Defect"/>.
        /// </summary>
        [TestMethod]
        public void Choose_WithLastChoiceByOpponentIsDefect_ReturnsCooperate()
        {
            // Arrange
            var strategy = new NaiveCooperationStrategy();

            // Act
            var choice = strategy.Choose(CooperationChoice.Defect);

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
            return new TitForTatCooperationStrategy();
        }

        /// <summary>
        /// The create strategy.
        /// </summary>
        /// <returns>
        /// The strategy.
        /// </returns>
        protected override CooperationStrategy CreateStrategy()
        {
            return new NaiveCooperationStrategy();
        }

        /// <summary>
        /// Gets the correct name.
        /// </summary>
        /// <returns>
        /// The name.
        /// </returns>
        protected override string GetCorrectName()
        {
            return "Naive";
        }

        /// <summary>
        /// Gets the correct description.
        /// </summary>
        /// <returns>
        /// The description.
        /// </returns>
        protected override string GetCorrectDescription()
        {
            return "Always cooperate.";
        }
    }
}