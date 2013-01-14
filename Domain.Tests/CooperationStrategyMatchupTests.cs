namespace StudioDonder.PrisonersDilemma.Domain.Tests
{
    using System;

    using Xunit;

    /// <summary>
    /// Tests for the <see cref="CooperationStrategyMatchup"/> class.
    /// </summary>
    public class CooperationStrategyMatchupTests
    {
        /// <summary>
        /// Test that calling the constructor with a <c>null</c> strategy A
        /// will throw an exception.
        /// </summary>
        [Fact]
        public void ConstructorWithNullStrategyAThrowsArgumentNullException()
        {
            // Arrange
            CooperationStrategy nullStrategyA = null;
            var strategyB = new EvilCooperationStrategy();
            var cooperationChoicePayoff = new CooperationChoicesPayoff();

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new CooperationStrategyMatchup(nullStrategyA, strategyB, cooperationChoicePayoff));
        }

        /// <summary>
        /// Test that calling the constructor with a <c>null</c> strategy B
        /// will throw an exception.
        /// </summary>
        [Fact]
        public void ConstructorWithNullStrategyBThrowsArgumentNullException()
        {
            // Arrange
            var strategyA = new NaiveCooperationStrategy();
            CooperationStrategy nullStrategyB = null;
            var cooperationChoicePayoff = new CooperationChoicesPayoff();

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new CooperationStrategyMatchup(strategyA, nullStrategyB, cooperationChoicePayoff));
        }

        /// <summary>
        /// Test that calling the constructor with a <c>null</c> <see cref="CooperationChoicesPayoff"/>
        /// will throw an exception.
        /// </summary>
        [Fact]
        public void ConstructorWithNullCooperationChoicePayoffThrowsArgumentNullException()
        {
            // Arrange
            var strategyA = new NaiveCooperationStrategy();
            var strategyB = new EvilCooperationStrategy();
            CooperationChoicesPayoff cooperationChoicesPayoff = null;

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new CooperationStrategyMatchup(strategyA, strategyB, cooperationChoicesPayoff));
        }

        /// <summary>
        /// Test that calling the StrategyA property returns the strategy A parameter
        /// supplied to the constructor.
        /// </summary>
        [Fact]
        public void StrategyAReturnsStrategyASuppliedToConstructor()
        {
            // Arrange
            var strategyA = new NaiveCooperationStrategy();
            var strategyB = new EvilCooperationStrategy();
            var cooperationChoicePayoff = new CooperationChoicesPayoff();

            // Act
            var cooperationStrategyMatchup = new CooperationStrategyMatchup(strategyA, strategyB, cooperationChoicePayoff);

            // Assert
            Assert.Equal(strategyA, cooperationStrategyMatchup.StrategyA);
        }

        /// <summary>
        /// Test that calling the StrategyB property returns the strategy B parameter
        /// supplied to the constructor.
        /// </summary>
        [Fact]
        public void StrategyBReturnsStrategyBSuppliedToConstructor()
        {
            // Arrange
            var strategyA = new NaiveCooperationStrategy();
            var strategyB = new EvilCooperationStrategy();
            var cooperationChoicePayoff = new CooperationChoicesPayoff();

            // Act
            var cooperationStrategyMatchup = new CooperationStrategyMatchup(strategyA, strategyB, cooperationChoicePayoff);

            // Assert
            Assert.Equal(strategyB, cooperationStrategyMatchup.StrategyB);
        }

        /// <summary>
        /// Test that calling the CooperationChoicesPayoff property returns the 
        /// <see cref="CooperationChoicesPayoff"/> parameter supplied to the constructor.
        /// </summary>
        [Fact]
        public void CooperationChoicePayoffsReturnsCooperationChoicePayoffsSuppliedToConstructor()
        {
            // Arrange
            var strategyA = new NaiveCooperationStrategy();
            var strategyB = new EvilCooperationStrategy();
            var cooperationChoicePayoff = new CooperationChoicesPayoff();

            // Act
            var cooperationStrategyMatchup = new CooperationStrategyMatchup(strategyA, strategyB, cooperationChoicePayoff);

            // Assert
            Assert.Equal(cooperationChoicePayoff, cooperationStrategyMatchup.CooperationChoicesPayoff);
        }

        /// <summary>
        /// Test that calling the Play method returns the correct cooperation strategy matchup for strategy A.
        /// </summary>
        [Fact]
        public void PlayReturnsCorrectCooperationStrategyMatchupResultForStrategyA()
        {
            // Arrange
            var strategyA = new NaiveCooperationStrategy();
            var strategyB = new EvilCooperationStrategy();
            var cooperationChoicePayoff = new CooperationChoicesPayoff();
            var cooperationStrategyMatchup = new CooperationStrategyMatchup(strategyA, strategyB, cooperationChoicePayoff);

            // Act
            var cooperationStrategyMatchupResult = cooperationStrategyMatchup.Play();

            // Assert
            var correctCooperationStrategyResultForStrategyA = new CooperationStrategyResult
                                                                   {
                                                                       Strategy = strategyA,
                                                                       ChoiceMade = CooperationChoice.Cooperate,
                                                                       Payoff = CooperationChoicesPayoff.DefaultPayoffForCooperateAndDefect,
                                                                   };
            Assert.Equal(correctCooperationStrategyResultForStrategyA, cooperationStrategyMatchupResult.StrategyAResult);
        }

        /// <summary>
        /// Test that calling the Play method returns the correct cooperation strategy matchup for strategy B.
        /// </summary>
        [Fact]
        public void PlayReturnsCorrectCooperationStrategyMatchupResultForStrategyB()
        {
            // Arrange
            var strategyA = new NaiveCooperationStrategy();
            var strategyB = new EvilCooperationStrategy();
            var cooperationChoicePayoff = new CooperationChoicesPayoff();
            var cooperationStrategyMatchup = new CooperationStrategyMatchup(strategyA, strategyB, cooperationChoicePayoff);

            // Act
            var cooperationStrategyMatchupResult = cooperationStrategyMatchup.Play();

            // Assert
            var correctCooperationStrategyResultForStrategyB = new CooperationStrategyResult
                                                                   {
                                                                       Strategy = strategyB,
                                                                       ChoiceMade = CooperationChoice.Defect,
                                                                       Payoff = CooperationChoicesPayoff.DefaultPayoffForDefectAndCooperate,
                                                                   };
            Assert.Equal(correctCooperationStrategyResultForStrategyB, cooperationStrategyMatchupResult.StrategyBResult);
        }

        /// <summary>
        /// Test that calling the Play method with a last matchup result specified
        /// returns the correct cooperation strategy matchup result for strategy A.
        /// </summary>
        [Fact]
        public void PlayWithLastMatchupResultReturnsCorrectCooperationStrategyMatchupResultForStrategyA()
        {
            // Arrange
            var strategyA = new TitForTatCooperationStrategy();
            var strategyB = new TitForTatCooperationStrategy();
            var cooperationChoicePayoff = new CooperationChoicesPayoff();
            var cooperationStrategyMatchup = new CooperationStrategyMatchup(strategyA, strategyB, cooperationChoicePayoff);
            var lastMatchupResult = new CooperationStrategyMatchupResult(
                new CooperationStrategyResult
                    {
                        Strategy = strategyA,
                        ChoiceMade = CooperationChoice.Cooperate,
                        Payoff =
                            cooperationChoicePayoff.Calculate(
                                CooperationChoice.Cooperate, CooperationChoice.Defect),
                    },
                new CooperationStrategyResult
                    {
                        Strategy = strategyB,
                        ChoiceMade = CooperationChoice.Defect,
                        Payoff =
                            cooperationChoicePayoff.Calculate(
                                CooperationChoice.Cooperate, CooperationChoice.Defect),
                    });

            // Act
            var cooperationStrategyMatchupResult = cooperationStrategyMatchup.Play(lastMatchupResult);

            // Assert
            var correctCooperationStrategyResultForStrategyA = new CooperationStrategyResult
                                                                   {
                                                                       Strategy = strategyA,
                                                                       ChoiceMade = CooperationChoice.Defect,
                                                                       Payoff = CooperationChoicesPayoff.DefaultPayoffForDefectAndCooperate,
                                                                   };
            Assert.Equal(correctCooperationStrategyResultForStrategyA, cooperationStrategyMatchupResult.StrategyAResult);
        }

        /// <summary>
        /// Test that calling the Play method with a last matchup result specified
        /// returns the correct cooperation strategy matchup result for strategy B.
        /// </summary>
        [Fact]
        public void PlayWithLastMatchupResultReturnsCorrectCooperationStrategyMatchupResultForStrategyB()
        {
            // Arrange
            var strategyA = new TitForTatCooperationStrategy();
            var strategyB = new TitForTatCooperationStrategy();
            var cooperationChoicePayoff = new CooperationChoicesPayoff();
            var cooperationStrategyMatchup = new CooperationStrategyMatchup(strategyA, strategyB, cooperationChoicePayoff);
            var lastMatchupResult = new CooperationStrategyMatchupResult(
                new CooperationStrategyResult
                    {
                        Strategy = strategyA,
                        ChoiceMade = CooperationChoice.Cooperate,
                        Payoff =
                            cooperationChoicePayoff.Calculate(
                                CooperationChoice.Cooperate, CooperationChoice.Cooperate),
                    },
                new CooperationStrategyResult
                    {
                        Strategy = strategyB,
                        ChoiceMade = CooperationChoice.Cooperate,
                        Payoff =
                            cooperationChoicePayoff.Calculate(
                                CooperationChoice.Cooperate, CooperationChoice.Cooperate),
                    });

            // Act
            var cooperationStrategyMatchupResult = cooperationStrategyMatchup.Play(lastMatchupResult);

            // Assert
            var correctCooperationStrategyResultForStrategyB = new CooperationStrategyResult
                                                                   {
                                                                       Strategy = strategyB,
                                                                       ChoiceMade = CooperationChoice.Cooperate,
                                                                       Payoff = CooperationChoicesPayoff.DefaultPayoffForCooperateAndCooperate
                                                                   };
            Assert.Equal(correctCooperationStrategyResultForStrategyB, cooperationStrategyMatchupResult.StrategyBResult);
        }

        /// <summary>
        /// Test that calling the Play method with a <c>null</c> last matchup result
        /// will throw an exception.
        /// </summary>
        [Fact]
        public void PlayWithNullLastMatchupResultThrowsArgumentNullException()
        {
            // Arrange
            var strategyA = new TitForTatCooperationStrategy();
            var strategyB = new TitForTatCooperationStrategy();
            var cooperationChoicePayoff = new CooperationChoicesPayoff();
            var cooperationStrategyMatchup = new CooperationStrategyMatchup(strategyA, strategyB, cooperationChoicePayoff);
            CooperationStrategyMatchupResult nullLastMatchupResult = null;

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => cooperationStrategyMatchup.Play(nullLastMatchupResult));
        }

        /// <summary>
        /// Test that calling the Equals method with the strategy A not equal will return <c>false</c>.
        /// </summary>
        [Fact]
        public void EqualsWithUnequalStrategyAReturnsFalse()
        {
            // Arrange
            var strategyB = new EvilCooperationStrategy();
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();
            var cooperationStrategyMatchup = new CooperationStrategyMatchup(new NaiveCooperationStrategy(), strategyB, cooperationChoicesPayoff);
            var unequalCooperationStrategyMatchup = new CooperationStrategyMatchup(new EvilCooperationStrategy(), strategyB, cooperationChoicesPayoff);

            // Act
            var objectsAreEqual = cooperationStrategyMatchup.Equals(unequalCooperationStrategyMatchup);

            // Assert
            Assert.False(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with the strategy B not equal will return <c>false</c>.
        /// </summary>
        [Fact]
        public void EqualsWithUnequalStrategyBReturnsFalse()
        {
            // Arrange
            var strategyA = new EvilCooperationStrategy();
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();
            var cooperationStrategyMatchup = new CooperationStrategyMatchup(strategyA, new NaiveCooperationStrategy(), cooperationChoicesPayoff);
            var unequalCooperationStrategyMatchup = new CooperationStrategyMatchup(strategyA, new EvilCooperationStrategy(), cooperationChoicesPayoff);

            // Act
            var objectsAreEqual = cooperationStrategyMatchup.Equals(unequalCooperationStrategyMatchup);

            // Assert
            Assert.False(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with the cooperation choices payoff not equal will return <c>false</c>.
        /// </summary>
        [Fact]
        public void EqualsWithUnequalCooperationChoicesPayoffReturnsFalse()
        {
            // Arrange
            var strategyA = new NaiveCooperationStrategy();
            var strategyB = new EvilCooperationStrategy();
            var cooperationStrategyMatchup = new CooperationStrategyMatchup(strategyA, strategyB, new CooperationChoicesPayoff());
            var unequalCooperationStrategyMatchup = new CooperationStrategyMatchup(strategyA, strategyB, new CooperationChoicesPayoff { PayoffForCooperateAndCooperate = 20 });

            // Act
            var objectsAreEqual = cooperationStrategyMatchup.Equals(unequalCooperationStrategyMatchup);

            // Assert
            Assert.False(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method on two new <see cref="CooperationStrategyMatchup"/>
        /// instances will return <c>true</c>.
        /// </summary>
        [Fact]
        public void EqualsWithUnchangedNewCooperationStrategyMatchupInstancesReturnsTrue()
        {
            // Arrange
            var cooperationStrategyMatchup = new CooperationStrategyMatchup(
                new NaiveCooperationStrategy(), new EvilCooperationStrategy(), new CooperationChoicesPayoff());
            var otherCooperationStrategyMatchup = new CooperationStrategyMatchup(
                new NaiveCooperationStrategy(), new EvilCooperationStrategy(), new CooperationChoicesPayoff());

            // Act
            var objectsAreEqual = cooperationStrategyMatchup.Equals(otherCooperationStrategyMatchup);

            // Assert
            Assert.True(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method on two new <see cref="CooperationStrategyMatchup"/>
        /// instances with flipped strategies return <c>true</c>.
        /// </summary>
        [Fact]
        public void EqualsWithFlippedStrategiesCooperationStrategyMatchupInstancesReturnsTrue()
        {
            // Arrange
            var cooperationStrategyMatchup = new CooperationStrategyMatchup(
                new NaiveCooperationStrategy(), new EvilCooperationStrategy(), new CooperationChoicesPayoff());
            var otherCooperationStrategyMatchup = new CooperationStrategyMatchup(
                new EvilCooperationStrategy(), new NaiveCooperationStrategy(), new CooperationChoicesPayoff());

            // Act
            var objectsAreEqual = cooperationStrategyMatchup.Equals(otherCooperationStrategyMatchup);

            // Assert
            Assert.True(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method on two new <see cref="CooperationStrategyMatchup"/>
        /// instances with flipped strategies return <c>true</c>.
        /// </summary>
        [Fact]
        public void EqualsWithFlippedStrategiesObjectInstancesReturnsTrue()
        {
            // Arrange
            var cooperationStrategyMatchup = new CooperationStrategyMatchup(
                new NaiveCooperationStrategy(), new EvilCooperationStrategy(), new CooperationChoicesPayoff());
            var otherCooperationStrategyMatchup = new CooperationStrategyMatchup(
                new EvilCooperationStrategy(), new NaiveCooperationStrategy(), new CooperationChoicesPayoff());

            // Act
            var objectsAreEqual = cooperationStrategyMatchup.Equals((object)otherCooperationStrategyMatchup);

            // Assert
            Assert.True(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with a <see cref="CooperationStrategyMatchup"/>
        /// that is actually the same instance will return <c>true</c>.
        /// </summary>
        [Fact]
        public void EqualsWithSameCooperationChoicesPayoffInstanceReturnsTrue()
        {
            // Arrange
            var cooperationStrategyMatchup = new CooperationStrategyMatchup(
                new NaiveCooperationStrategy(), new EvilCooperationStrategy(), new CooperationChoicesPayoff());

            // Act
            var objectsAreEqual = cooperationStrategyMatchup.Equals(cooperationStrategyMatchup);

            // Assert
            Assert.True(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with a <see cref="System.Object"/>
        /// that is actually the same instance will return <c>true</c>.
        /// </summary>
        [Fact]
        public void EqualsWithSameObjectInstanceReturnsTrue()
        {
            // Arrange
            var cooperationStrategyMatchup = new CooperationStrategyMatchup(
                new NaiveCooperationStrategy(), new EvilCooperationStrategy(), new CooperationChoicesPayoff());

            // Act
            var objectsAreEqual = cooperationStrategyMatchup.Equals((object)cooperationStrategyMatchup);

            // Assert
            Assert.True(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with a <c>null</c> <see cref="CooperationStrategyMatchup"/>
        /// will return <c>false</c>.
        /// </summary>
        [Fact]
        public void EqualsWithNullCooperationChoicesPayoffReturnsFalse()
        {
            // Arrange
            var cooperationStrategyMatchup = new CooperationStrategyMatchup(
                new NaiveCooperationStrategy(), new EvilCooperationStrategy(), new CooperationChoicesPayoff());
            CooperationStrategyMatchup comparisonCooperationStrategyMatchup = null;

            // Act
            var objectsAreEqual = cooperationStrategyMatchup.Equals(comparisonCooperationStrategyMatchup);

            // Assert
            Assert.False(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with a <c>null</c> <see cref="System.Object"/>
        /// will return <c>false</c>.
        /// </summary>
        [Fact]
        public void EqualsWithNullObjectReturnsFalse()
        {
            // Arrange
            var cooperationStrategyMatchup = new CooperationStrategyMatchup(
                new NaiveCooperationStrategy(), new EvilCooperationStrategy(), new CooperationChoicesPayoff());
            CooperationStrategyMatchup comparisonCooperationStrategyMatchup = null;

            // Act
            var objectsAreEqual = cooperationStrategyMatchup.Equals((object)comparisonCooperationStrategyMatchup);

            // Assert
            Assert.False(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the GetHashCode method on two <see cref="CooperationStrategyResult"/>
        /// instances that refer to the same cooperation strategy but a different cooperation choice
        /// will return equal hash codes.
        /// </summary>
        [Fact]
        public void GetHashCodeWithEqualValuesReturnsEqualHashCodes()
        {
            // Arrange
            var cooperationStrategyMatchup = new CooperationStrategyMatchup(
                new NaiveCooperationStrategy(), new EvilCooperationStrategy(), new CooperationChoicesPayoff());
            var otherCooperationStrategyMatchup = new CooperationStrategyMatchup(
                new NaiveCooperationStrategy(), new EvilCooperationStrategy(), new CooperationChoicesPayoff());

            // Act
            var hashCode = cooperationStrategyMatchup.GetHashCode();
            var otherHashCode = otherCooperationStrategyMatchup.GetHashCode();

            // Assert
            Assert.Equal(hashCode, otherHashCode);
        }

        /// <summary>
        /// Test that calling the GetHashCode method on two <see cref="CooperationStrategyResult"/>
        /// instances that have different strategy A instances will return different hash codes.
        /// </summary>
        [Fact]
        public void GetHashCodeWithDifferentStrategyAReturnsDifferentHashCodes()
        {
            // Arrange
            var cooperationStrategyMatchup = new CooperationStrategyMatchup(
                new NaiveCooperationStrategy(), new EvilCooperationStrategy(), new CooperationChoicesPayoff());
            var otherCooperationStrategyMatchup = new CooperationStrategyMatchup(
                new EvilCooperationStrategy(), new EvilCooperationStrategy(), new CooperationChoicesPayoff());

            // Act
            var hashCode = cooperationStrategyMatchup.GetHashCode();
            var otherHashCode = otherCooperationStrategyMatchup.GetHashCode();

            // Assert
            Assert.NotEqual(hashCode, otherHashCode);
        }

        /// <summary>
        /// Test that calling the GetHashCode method on two <see cref="CooperationStrategyResult"/>
        /// instances that have different strategy B instances will return different hash codes.
        /// </summary>
        [Fact]
        public void GetHashCodeWithDifferentStrategyBReturnsDifferentHashCodes()
        {
            // Arrange
            var cooperationStrategyMatchup = new CooperationStrategyMatchup(
                new NaiveCooperationStrategy(), new EvilCooperationStrategy(), new CooperationChoicesPayoff());
            var otherCooperationStrategyMatchup = new CooperationStrategyMatchup(
                new NaiveCooperationStrategy(), new TitForTatCooperationStrategy(), new CooperationChoicesPayoff());

            // Act
            var hashCode = cooperationStrategyMatchup.GetHashCode();
            var otherHashCode = otherCooperationStrategyMatchup.GetHashCode();

            // Assert
            Assert.NotEqual(hashCode, otherHashCode);
        }

        /// <summary>
        /// Test that calling the GetHashCode method on two <see cref="CooperationStrategyResult"/>
        /// instances that have different cooperation choices payoff instances will return different hash codes.
        /// </summary>
        [Fact]
        public void GetHashCodeWithDifferentCooperationChoicesPayoffReturnsDifferentHashCodes()
        {
            // Arrange
            var cooperationStrategyMatchup = new CooperationStrategyMatchup(
                new NaiveCooperationStrategy(), new EvilCooperationStrategy(), new CooperationChoicesPayoff());
            var otherCooperationStrategyMatchup = new CooperationStrategyMatchup(
                new NaiveCooperationStrategy(), new EvilCooperationStrategy(), new CooperationChoicesPayoff { PayoffForCooperateAndCooperate = 20 });

            // Act
            var hashCode = cooperationStrategyMatchup.GetHashCode();
            var otherHashCode = otherCooperationStrategyMatchup.GetHashCode();

            // Assert
            Assert.NotEqual(hashCode, otherHashCode);
        }

        /// <summary>
        /// Test that calling the GetHashCode method on two <see cref="CooperationStrategyResult"/>
        /// instances that have different the same strategies only flipped will return the same hash codes.
        /// </summary>
        [Fact]
        public void GetHashCodeWithFlippedStrategiesReturnsSameHashCodes()
        {
            // Arrange
            var cooperationStrategyMatchup = new CooperationStrategyMatchup(
                new NaiveCooperationStrategy(), new EvilCooperationStrategy(), new CooperationChoicesPayoff());
            var otherCooperationStrategyMatchup = new CooperationStrategyMatchup(
                new EvilCooperationStrategy(), new NaiveCooperationStrategy(), new CooperationChoicesPayoff());

            // Act
            var hashCode = cooperationStrategyMatchup.GetHashCode();
            var otherHashCode = otherCooperationStrategyMatchup.GetHashCode();

            // Assert
            Assert.Equal(hashCode, otherHashCode);
        }
    }
}