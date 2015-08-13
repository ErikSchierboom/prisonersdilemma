namespace PrisonersDilemma.Domain.Tests
{
    using Xunit;

    /// <summary>
    /// Tests for the <see cref="CooperationStrategyResult"/> class.
    /// </summary>
    public class CooperationStrategyResultTests
    {
        /// <summary>
        /// Test that calling the Equals method with the choice made
        /// not equal will return <c>false</c>.
        /// </summary>
        [Fact]
        public void EqualsWithUnequalChoiceMadeReturnsFalse()
        {
            // Arrange
            var cooperationStrategyResult = new CooperationStrategyResult { ChoiceMade = CooperationChoice.Cooperate };
            var unequalCooperationStrategyResult = new CooperationStrategyResult { ChoiceMade = CooperationChoice.Defect };

            // Act
            var objectsAreEqual = cooperationStrategyResult.Equals(unequalCooperationStrategyResult);

            // Assert
            Assert.False(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with the payoff
        /// not equal will return <c>false</c>.
        /// </summary>
        [Fact]
        public void EqualsWithUnequalPayoffReturnsFalse()
        {
            // Arrange
            var cooperationStrategyResult = new CooperationStrategyResult { Payoff = CooperationChoicesPayoff.DefaultPayoffForDefectAndDefect };
            var unequalCooperationStrategyResult = new CooperationStrategyResult { Payoff = CooperationChoicesPayoff.DefaultPayoffForDefectAndCooperate };

            // Act
            var objectsAreEqual = cooperationStrategyResult.Equals(unequalCooperationStrategyResult);

            // Assert
            Assert.False(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with the cooperation strategy result instances
        /// not equal will return <c>false</c>.
        /// </summary>
        [Fact]
        public void EqualsWithUnequalCooperationStrategyResultInstancesReturnsFalse()
        {
            // Arrange
            var cooperationStrategyResult = new CooperationStrategyResult { Strategy = new NaiveCooperationStrategy() };
            var unequalCooperationStrategyResult = new CooperationStrategyResult { Strategy = new NaiveCooperationStrategy() };

            // Act
            var objectsAreEqual = cooperationStrategyResult.Equals(unequalCooperationStrategyResult);

            // Assert
            Assert.False(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with a choice made that is equal
        /// will return <c>true</c>.
        /// </summary>
        [Fact]
        public void EqualsWithEqualChoiceMadeReturnsTrue()
        {
            // Arrange
            var cooperationStrategyResult = new CooperationStrategyResult { ChoiceMade = CooperationChoice.Cooperate };
            object equalCooperationStrategyResult = new CooperationStrategyResult { ChoiceMade = CooperationChoice.Cooperate };

            // Act
            var objectsAreEqual = cooperationStrategyResult.Equals(equalCooperationStrategyResult);

            // Assert
            Assert.True(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with a payoff that is equal
        /// will return <c>true</c>.
        /// </summary>
        [Fact]
        public void EqualsWithEqualPayoffReturnsTrue()
        {
            // Arrange
            var cooperationStrategyResult = new CooperationStrategyResult { Payoff = CooperationChoicesPayoff.DefaultPayoffForDefectAndDefect };
            object equalCooperationStrategyResult = new CooperationStrategyResult { Payoff = CooperationChoicesPayoff.DefaultPayoffForDefectAndDefect };

            // Act
            var objectsAreEqual = cooperationStrategyResult.Equals(equalCooperationStrategyResult);

            // Assert
            Assert.True(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with a strategy that is equal
        /// will return <c>true</c>.
        /// </summary>
        [Fact]
        public void EqualsWithEqualStrategyReturnsTrue()
        {
            // Arrange
            var strategy = new NaiveCooperationStrategy();
            var cooperationStrategyResult = new CooperationStrategyResult { Strategy = strategy };
            object equalCooperationStrategyResult = new CooperationStrategyResult { Strategy = strategy };

            // Act
            var objectsAreEqual = cooperationStrategyResult.Equals(equalCooperationStrategyResult);

            // Assert
            Assert.True(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method on two new <see cref="CooperationStrategyResult"/>
        /// instances will return <c>true</c>.
        /// </summary>
        [Fact]
        public void EqualsWithUnchangedNewCooperationStrategyResultInstancesReturnsTrue()
        {
            // Arrange
            var cooperationStrategyResult = new CooperationStrategyResult();
            var otherCooperationStrategyResult = new CooperationStrategyResult();

            // Act
            var objectsAreEqual = cooperationStrategyResult.Equals(otherCooperationStrategyResult);

            // Assert
            Assert.True(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method on two new <see cref="System.Object"/>
        /// instances will return <c>true</c>.
        /// </summary>
        [Fact]
        public void EqualsWithUnchangedNewObjectInstancesReturnsTrue()
        {
            // Arrange
            var cooperationStrategyResult = new CooperationStrategyResult();
            var otherCooperationStrategyResult = new CooperationStrategyResult();

            // Act
            var objectsAreEqual = cooperationStrategyResult.Equals((object)otherCooperationStrategyResult);

            // Assert
            Assert.True(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with a <see cref="CooperationStrategyResult"/>
        /// that is actually the same instance will return <c>true</c>.
        /// </summary>
        [Fact]
        public void EqualsWithSameCooperationStrategyResultInstanceReturnsTrue()
        {
            // Arrange
            var cooperationStrategyResult = new CooperationStrategyResult();

            // Act
            var objectsAreEqual = cooperationStrategyResult.Equals(cooperationStrategyResult);

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
            var cooperationStrategyResult = new CooperationStrategyResult();

            // Act
            var objectsAreEqual = cooperationStrategyResult.Equals((object)cooperationStrategyResult);

            // Assert
            Assert.True(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with a <c>null</c> <see cref="CooperationStrategyResult"/>
        /// will return <c>false</c>.
        /// </summary>
        [Fact]
        public void EqualsWithNullCooperationStrategyResultReturnsFalse()
        {
            // Arrange
            var cooperationStrategyResult = new CooperationStrategyResult();
            CooperationStrategyResult comparisonCooperationStrategyResult = null;

            // Act
            var objectsAreEqual = cooperationStrategyResult.Equals(comparisonCooperationStrategyResult);

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
            var cooperationStrategyResult = new CooperationStrategyResult();
            CooperationStrategyResult comparisonCooperationStrategyResult = null;

            // Act
            var objectsAreEqual = cooperationStrategyResult.Equals((object)comparisonCooperationStrategyResult);

            // Assert
            Assert.False(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with equal <see cref="CooperationStrategyResult"/>
        /// instances will return <c>true</c>.
        /// </summary>
        [Fact]
        public void EqualsWithEqualCooperationStrategyResultReturnsTrue()
        {
            // Arrange
            var cooperationStrategyResult = new CooperationStrategyResult();
            var equalCooperationStrategyResult = new CooperationStrategyResult();

            // Act
            var objectsAreEqual = cooperationStrategyResult.Equals(equalCooperationStrategyResult);

            // Assert
            Assert.True(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with equal <see cref="System.Object"/>
        /// instances will return <c>true</c>.
        /// </summary>
        [Fact]
        public void EqualsWithEqualObjectReturnsTrue()
        {
            // Arrange
            var cooperationStrategyResult = new CooperationStrategyResult();
            var equalCooperationStrategyResult = new CooperationStrategyResult();

            // Act
            var objectsAreEqual = cooperationStrategyResult.Equals((object)equalCooperationStrategyResult);

            // Assert
            Assert.True(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with a <see cref="CooperationStrategyResult"/>
        /// that is actually the same instance will return <c>true</c>.
        /// </summary>
        [Fact]
        public void EqualsWithStrategyThatIsSameInstanceReturnsTrue()
        {
            // Arrange
            var cooperationStrategyResult = new CooperationStrategyResult();

            // Act
            var objectsAreEqual = cooperationStrategyResult.Equals(cooperationStrategyResult);

            // Assert
            Assert.True(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with an <see cref="System.Object"/>
        /// that is actually the same instance will return <c>true</c>.
        /// </summary>
        [Fact]
        public void EqualsWithObjectThatIsSameInstanceReturnsTrue()
        {
            // Arrange
            var cooperationStrategyResult = new CooperationStrategyResult();

            // Act
            var objectsAreEqual = cooperationStrategyResult.Equals((object)cooperationStrategyResult);

            // Assert
            Assert.True(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the GetHashCode method with a <c>null</c>
        /// <see cref="CooperationStrategy"/> does not throw an exception.
        /// </summary>
        [Fact]
        public void GetHashCodeWithNullStrategyDoesNotThrowException()
        {
            // Arrange
            var cooperationStrategyResult = new CooperationStrategyResult { Strategy = null };

            // Act
            cooperationStrategyResult.GetHashCode();

            // Assert
        }

        /// <summary>
        /// Test that calling the GetHashCode method on two <see cref="CooperationStrategyResult"/>
        /// instances that have just been created will return equal hash codes.
        /// </summary>
        [Fact]
        public void GetHashCodeWithUnchangedNewInstancesReturnsEqualHashCodes()
        {
            // Arrange
            var cooperationStrategyResult = new CooperationStrategyResult();
            var otherCooperationStrategyResult = new CooperationStrategyResult();

            // Act
            var hashCode = cooperationStrategyResult.GetHashCode();
            var otherHashCode = otherCooperationStrategyResult.GetHashCode();

            // Assert
            Assert.Equal(hashCode, otherHashCode);
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
            var strategy = new NaiveCooperationStrategy();
            var cooperationStrategyResult = new CooperationStrategyResult { Strategy = strategy, ChoiceMade = CooperationChoice.Defect, Payoff = CooperationChoicesPayoff.DefaultPayoffForDefectAndDefect };
            var otherCooperationStrategyResult = new CooperationStrategyResult { Strategy = strategy, ChoiceMade = CooperationChoice.Defect, Payoff = CooperationChoicesPayoff.DefaultPayoffForDefectAndDefect };

            // Act
            var hashCode = cooperationStrategyResult.GetHashCode();
            var otherHashCode = otherCooperationStrategyResult.GetHashCode();

            // Assert
            Assert.Equal(hashCode, otherHashCode);
        }

        /// <summary>
        /// Test that calling the GetHashCode method on two <see cref="CooperationStrategyResult"/>
        /// instances that have different choices made will return different hash codes.
        /// </summary>
        [Fact]
        public void GetHashCodeWithDifferentChoiceMadeReturnsDifferentHashCodes()
        {
            // Arrange
            var cooperationStrategyResult = new CooperationStrategyResult { ChoiceMade = CooperationChoice.Cooperate };
            var otherCooperationStrategyResult = new CooperationStrategyResult { ChoiceMade = CooperationChoice.Defect };

            // Act
            var hashCode = cooperationStrategyResult.GetHashCode();
            var otherHashCode = otherCooperationStrategyResult.GetHashCode();

            // Assert
            Assert.NotEqual(hashCode, otherHashCode);
        }

        /// <summary>
        /// Test that calling the GetHashCode method on two <see cref="CooperationStrategyResult"/>
        /// instances that have different cooperation strategies will return different hash codes.
        /// </summary>
        [Fact]
        public void GetHashCodeWithDifferentCooperationStrategiesReturnsDifferentHashCodes()
        {
            // Arrange
            var cooperationStrategyResult = new CooperationStrategyResult { Strategy = new NaiveCooperationStrategy() };
            var otherCooperationStrategyResult = new CooperationStrategyResult { Strategy = new EvilCooperationStrategy() };

            // Act
            var hashCode = cooperationStrategyResult.GetHashCode();
            var otherHashCode = otherCooperationStrategyResult.GetHashCode();

            // Assert
            Assert.NotEqual(hashCode, otherHashCode);
        }

        /// <summary>
        /// Test that calling the GetHashCode method on two <see cref="CooperationStrategyResult"/>
        /// instances that have different payoffs will return different hash codes.
        /// </summary>
        [Fact]
        public void GetHashCodeWithDifferentPayoffReturnsDifferentHashCodes()
        {
            // Arrange
            var cooperationStrategyResult = new CooperationStrategyResult { Payoff = CooperationChoicesPayoff.DefaultPayoffForCooperateAndDefect };
            var otherCooperationStrategyResult = new CooperationStrategyResult { Payoff = CooperationChoicesPayoff.DefaultPayoffForDefectAndCooperate };

            // Act
            var hashCode = cooperationStrategyResult.GetHashCode();
            var otherHashCode = otherCooperationStrategyResult.GetHashCode();

            // Assert
            Assert.NotEqual(hashCode, otherHashCode);
        }
    }
}