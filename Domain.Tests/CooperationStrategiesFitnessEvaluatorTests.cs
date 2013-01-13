namespace StudioDonder.PrisonersDilemma.Domain.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using StudioDonder.PrisonersDilemma.Domain.Tests.Helpers;

    /// <summary>
    /// Tests for the <see cref="CooperationStrategiesFitnessEvaluator"/> class.
    /// </summary>
    [TestClass]
    public class CooperationStrategiesFitnessEvaluatorTests
    {
    	private const int DefaultNumberOfRounds = 10;

    	/// <summary>
		/// Test that calling the default constructor will use the default cooperation choices payoff.
		/// </summary>
		[TestMethod]
		public void DefaultConstructor_UsesDefaultCooperationChoicesPayoff_ThrowsException()
		{
			// Arrange
			var defaultCooperationChoicesPayoff = new CooperationChoicesPayoff();

			// Act
			var cooperationStrategiesFitnessEvaluator = new CooperationStrategiesFitnessEvaluator();

			// Assert
			Assert.AreEqual(defaultCooperationChoicesPayoff, cooperationStrategiesFitnessEvaluator.CooperationChoicesPayoff);
		}

		/// <summary>
		/// Test that calling the default constructor will use the default number of rounds.
		/// </summary>
		[TestMethod]
		public void DefaultConstructor_UsesDefaultNumberOfRounds_ThrowsException()
		{
			// Arrange

			// Act
			var cooperationStrategiesFitnessEvaluator = new CooperationStrategiesFitnessEvaluator();

			// Assert
			Assert.AreEqual(DefaultNumberOfRounds, cooperationStrategiesFitnessEvaluator.NumberOfRounds);
		}

		/// <summary>
		/// Test that calling the default constructor will use all strategies by default.
		/// </summary>
		[TestMethod]
		public void DefaultConstructor_UsesAllStrategiesByDefault_ThrowsException()
		{
			// Arrange
			var cooperationStrategyRepository = new CooperationStrategyRepository();

			// Act
			var cooperationStrategiesFitnessEvaluator = new CooperationStrategiesFitnessEvaluator();

			// Assert
			Assert.IsTrue(cooperationStrategiesFitnessEvaluator.CooperationStrategies.SequenceEqual(cooperationStrategyRepository.GetAll()));
		}

		/// <summary>
		/// Test that calling the constructor with a <c>null </c>cooperation strategies repository will throw an exception.
		/// </summary>
		[TestMethod, ExpectException]
		public void Constructor_WithNullCooperationStrategiesRepository_ThrowsException()
		{
			// Arrange
			CooperationStrategyRepository nullCooperationStrategyRepository = null;

			// Act
			new CooperationStrategiesFitnessEvaluator(nullCooperationStrategyRepository);

			// Assert
		}

		/// <summary>
		/// Test that calling the constructor with a cooperation strategies repository sets the cooperation strategies
		/// to the value returned by repository.
		/// </summary>
		[TestMethod]
		public void Constructor_WithCooperationStrategiesRepository_SetsCooperationStrategiesToValueReturnedByRepository()
		{
			// Arrange
			var cooperationStrategyRepository = new CooperationStrategyRepository();

			// Act
			var cooperationStrategiesFitnessEvaluator = new CooperationStrategiesFitnessEvaluator(cooperationStrategyRepository);

			// Assert
			Assert.IsTrue(cooperationStrategiesFitnessEvaluator.CooperationStrategies.SequenceEqual(cooperationStrategyRepository.GetAll()));
		}

		/// <summary>
		/// Test that setting the CooperationChoicesPayoff to <c>null</c> will throw an exception.
		/// </summary>
		[TestMethod, ExpectException]
		public void CooperationChoicesPayoff_SetToNull_ThrowsException()
		{
			// Arrange
			var cooperationStrategyFitness = new CooperationStrategiesFitnessEvaluator();

			// Act
			cooperationStrategyFitness.CooperationChoicesPayoff = null;

			// Assert
		}

		/// <summary>
		/// Test that setting the CooperationStrategies to <c>null</c> will throw an exception.
		/// </summary>
		[TestMethod, ExpectException]
		public void CooperationStrategies_SetToNull_ThrowsException()
		{
			// Arrange
			var cooperationStrategyFitness = new CooperationStrategiesFitnessEvaluator();

			// Act
			cooperationStrategyFitness.CooperationStrategies = null;

			// Assert
		}

		/// <summary>
		/// Test that setting the NumberOfRounds to zero will throw an exception.
		/// </summary>
		[TestMethod, ExpectException]
		public void NumberOfRounds_SetToZero_ThrowsException()
		{
			// Arrange
			var cooperationStrategyFitness = new CooperationStrategiesFitnessEvaluator();

			// Act
			cooperationStrategyFitness.NumberOfRounds = 0;

			// Assert
		}

		/// <summary>
		/// Test that setting the NumberOfRounds to a negative number will throw an exception.
		/// </summary>
		[TestMethod, ExpectException]
		public void NumberOfRounds_SetToNegativeNumber_ThrowsException()
		{
			// Arrange
			var cooperationStrategyFitness = new CooperationStrategiesFitnessEvaluator();

			// Act
			cooperationStrategyFitness.NumberOfRounds = -1;

			// Assert
		}

		/// <summary>
		/// Test that calling the Evaluate method with a no cooperation strategies will not throw an exception.
		/// </summary>
		[TestMethod]
		public void Evaluate_WithEmptyCooperationStrategies_DoesNotThrowException()
		{
			// Arranged
			var cooperationStrategiesFitnessEvaluator = new CooperationStrategiesFitnessEvaluator
				{
					CooperationStrategies = new HashSet<CooperationStrategy>()
				};

			// Act
			var fitnesses = cooperationStrategiesFitnessEvaluator.Evaluate();

			// Assert
			Assert.AreEqual(0, fitnesses.Count);
		}
		
        /// <summary>
        /// Test that calling the Evaluate method with a <c>null</c> cooperation strategy
        /// will ignore that cooperation strategy.
        /// </summary>
        [TestMethod]
        public void Evaluate_WithNullCooperationStrategy_IgnoresNullCooperationStrategyException()
        {
            // Arranged
        	var cooperationStrategiesFitnessEvaluator = new CooperationStrategiesFitnessEvaluator
        		{
        			CooperationStrategies = new HashSet<CooperationStrategy>
        				{
        					new NaiveCooperationStrategy(),
        					null,
        				}
        		};
            

            // Act
            var fitnesses = cooperationStrategiesFitnessEvaluator.Evaluate();

            // Assert
            Assert.AreEqual(1, fitnesses.Count);
        }

        /// <summary>
        /// Test that the Evaluate method returns a cooperation strategy fitness
        /// for each strategy.
        /// </summary>
        [TestMethod]
        public void Evaluate_ReturnsCooperationStrategyFitnessForEachStrategy()
        {
            // Arrange
        	var cooperationStrategiesFitnessEvaluator = new CooperationStrategiesFitnessEvaluator();

            // Act
            var fitnesses = cooperationStrategiesFitnessEvaluator.Evaluate();

            // Assert
			Assert.IsTrue(cooperationStrategiesFitnessEvaluator.CooperationStrategies.All(strategy => fitnesses.Any(fitness => fitness.Strategy == strategy)));
        }

        /// <summary>
        /// Test that the Evaluate method returns only one cooperation strategy fitness
        /// for each strategy.
        /// </summary>
        [TestMethod]
        public void Evaluate_ReturnsOneCooperationStrategyFitnessForEachStrategy()
        {
            // Arrange
        	var cooperationStrategiesFitnessEvaluator = new CooperationStrategiesFitnessEvaluator();

            // Act
            var fitnesses = cooperationStrategiesFitnessEvaluator.Evaluate();

            // Assert
			Assert.AreEqual(cooperationStrategiesFitnessEvaluator.CooperationStrategies.Count(), fitnesses.Count);
        }

        /// <summary>
        /// Test that the Evaluate method returns the cooperation strategy fitnesses
        /// in order of input for the strategies.
        /// </summary>
        [TestMethod]
        public void Evaluate_ReturnsCooperationStrategyFitnessesInOrderOfInput()
        {
            // Arrange
        	var cooperationStrategiesFitnessEvaluator = new CooperationStrategiesFitnessEvaluator();

            // Act
            var fitnesses = cooperationStrategiesFitnessEvaluator.Evaluate();

            // Assert
			Assert.AreEqual(cooperationStrategiesFitnessEvaluator.CooperationStrategies.First(), fitnesses[0].Strategy);
			Assert.AreEqual(cooperationStrategiesFitnessEvaluator.CooperationStrategies.Skip(1).First(), fitnesses[1].Strategy);
			Assert.AreEqual(cooperationStrategiesFitnessEvaluator.CooperationStrategies.Skip(2).First(), fitnesses[2].Strategy);
        }

        /// <summary>
        /// Test that the Evaluate method returns the correct total payoff for each strategy.
        /// </summary>
        [TestMethod]
        public void Evaluate_ReturnsCorrectTotalPayoffForEachStrategy()
        {
            // Arrange
        	var cooperationStrategiesFitnessEvaluator = new CooperationStrategiesFitnessEvaluator()
        		{
					NumberOfRounds = 3,
        		};

            // Act
            var fitnesses = cooperationStrategiesFitnessEvaluator.Evaluate();

            // Assert
            Assert.AreEqual(27, fitnesses[0].TotalPayoff);
            Assert.AreEqual(28, fitnesses[1].TotalPayoff);
            Assert.AreEqual(29, fitnesses[2].TotalPayoff);
        }
	}
}