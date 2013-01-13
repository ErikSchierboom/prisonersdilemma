namespace StudioDonder.PrisonersDilemma.Domain.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests for the <see cref="CooperationStrategyResult"/> class.
    /// </summary>
    [TestClass]
    public class CooperationStrategyResultTests
    {
        /// <summary>
        /// Test that calling the Equals method with the choice made
        /// not equal will return <c>false</c>.
        /// </summary>
        [TestMethod]
        public void Equals_WithUnequalChoiceMade_ReturnsFalse()
        {
            // Arrange
            var cooperationStrategyResult = new CooperationStrategyResult { ChoiceMade = CooperationChoice.Cooperate };
            var unequalCooperationStrategyResult = new CooperationStrategyResult { ChoiceMade = CooperationChoice.Defect };

            // Act
            var objectsAreEqual = cooperationStrategyResult.Equals(unequalCooperationStrategyResult);

            // Assert
            Assert.IsFalse(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with the payoff
        /// not equal will return <c>false</c>.
        /// </summary>
        [TestMethod]
        public void Equals_WithUnequalPayoff_ReturnsFalse()
        {
            // Arrange
            var cooperationStrategyResult = new CooperationStrategyResult { Payoff = CooperationChoicesPayoff.DefaultPayoffForDefectAndDefect };
            var unequalCooperationStrategyResult = new CooperationStrategyResult { Payoff = CooperationChoicesPayoff.DefaultPayoffForDefectAndCooperate };

            // Act
            var objectsAreEqual = cooperationStrategyResult.Equals(unequalCooperationStrategyResult);

            // Assert
            Assert.IsFalse(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with the cooperation strategy result instances
        /// not equal will return <c>false</c>.
        /// </summary>
        [TestMethod]
        public void Equals_WithUnequalCooperationStrategyResultInstances_ReturnsFalse()
        {
            // Arrange
            var cooperationStrategyResult = new CooperationStrategyResult { Strategy = new NaiveCooperationStrategy() };
            var unequalCooperationStrategyResult = new CooperationStrategyResult { Strategy = new NaiveCooperationStrategy() };

            // Act
            var objectsAreEqual = cooperationStrategyResult.Equals(unequalCooperationStrategyResult);

            // Assert
            Assert.IsFalse(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with a choice made that is equal
        /// will return <c>true</c>.
        /// </summary>
        [TestMethod]
        public void Equals_WithEqualChoiceMade_ReturnsTrue()
        {
            // Arrange
            var cooperationStrategyResult = new CooperationStrategyResult { ChoiceMade = CooperationChoice.Cooperate };
            object equalCooperationStrategyResult = new CooperationStrategyResult { ChoiceMade = CooperationChoice.Cooperate };

            // Act
            var objectsAreEqual = cooperationStrategyResult.Equals(equalCooperationStrategyResult);

            // Assert
            Assert.IsTrue(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with a payoff that is equal
        /// will return <c>true</c>.
        /// </summary>
        [TestMethod]
        public void Equals_WithEqualPayoff_ReturnsTrue()
        {
            // Arrange
            var cooperationStrategyResult = new CooperationStrategyResult { Payoff = CooperationChoicesPayoff.DefaultPayoffForDefectAndDefect };
            object equalCooperationStrategyResult = new CooperationStrategyResult { Payoff = CooperationChoicesPayoff.DefaultPayoffForDefectAndDefect };

            // Act
            var objectsAreEqual = cooperationStrategyResult.Equals(equalCooperationStrategyResult);

            // Assert
            Assert.IsTrue(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with a strategy that is equal
        /// will return <c>true</c>.
        /// </summary>
        [TestMethod]
        public void Equals_WithEqualStrategy_ReturnsTrue()
        {
            // Arrange
            var strategy = new NaiveCooperationStrategy();
            var cooperationStrategyResult = new CooperationStrategyResult { Strategy = strategy };
            object equalCooperationStrategyResult = new CooperationStrategyResult { Strategy = strategy };

            // Act
            var objectsAreEqual = cooperationStrategyResult.Equals(equalCooperationStrategyResult);

            // Assert
            Assert.IsTrue(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method on two new <see cref="CooperationStrategyResult"/>
        /// instances will return <c>true</c>.
        /// </summary>
        [TestMethod]
        public void Equals_WithUnchangedNewCooperationStrategyResultInstances_ReturnsTrue()
        {
            // Arrange
            var cooperationStrategyResult = new CooperationStrategyResult();
            var otherCooperationStrategyResult = new CooperationStrategyResult();

            // Act
            var objectsAreEqual = cooperationStrategyResult.Equals(otherCooperationStrategyResult);

            // Assert
            Assert.IsTrue(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method on two new <see cref="System.Object"/>
        /// instances will return <c>true</c>.
        /// </summary>
        [TestMethod]
        public void Equals_WithUnchangedNewObjectInstances_ReturnsTrue()
        {
            // Arrange
            var cooperationStrategyResult = new CooperationStrategyResult();
            var otherCooperationStrategyResult = new CooperationStrategyResult();

            // Act
            var objectsAreEqual = cooperationStrategyResult.Equals((object)otherCooperationStrategyResult);

            // Assert
            Assert.IsTrue(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with a <see cref="CooperationStrategyResult"/>
        /// that is actually the same instance will return <c>true</c>.
        /// </summary>
        [TestMethod]
        public void Equals_WithSameCooperationStrategyResultInstance_ReturnsTrue()
        {
            // Arrange
            var cooperationStrategyResult = new CooperationStrategyResult();

            // Act
            var objectsAreEqual = cooperationStrategyResult.Equals(cooperationStrategyResult);

            // Assert
            Assert.IsTrue(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with a <see cref="System.Object"/>
        /// that is actually the same instance will return <c>true</c>.
        /// </summary>
        [TestMethod]
        public void Equals_WithSameObjectInstance_ReturnsTrue()
        {
            // Arrange
            var cooperationStrategyResult = new CooperationStrategyResult();

            // Act
            var objectsAreEqual = cooperationStrategyResult.Equals((object)cooperationStrategyResult);

            // Assert
            Assert.IsTrue(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with a <c>null</c> <see cref="CooperationStrategyResult"/>
        /// will return <c>false</c>.
        /// </summary>
        [TestMethod]
        public void Equals_WithNullCooperationStrategyResult_ReturnsFalse()
        {
            // Arrange
            var cooperationStrategyResult = new CooperationStrategyResult();
            CooperationStrategyResult comparisonCooperationStrategyResult = null;

            // Act
            var objectsAreEqual = cooperationStrategyResult.Equals(comparisonCooperationStrategyResult);

            // Assert
            Assert.IsFalse(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with a <c>null</c> <see cref="System.Object"/>
        /// will return <c>false</c>.
        /// </summary>
        [TestMethod]
        public void Equals_WithNullObject_ReturnsFalse()
        {
            // Arrange
            var cooperationStrategyResult = new CooperationStrategyResult();
            CooperationStrategyResult comparisonCooperationStrategyResult = null;

            // Act
            var objectsAreEqual = cooperationStrategyResult.Equals((object)comparisonCooperationStrategyResult);

            // Assert
            Assert.IsFalse(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with equal <see cref="CooperationStrategyResult"/>
        /// instances will return <c>true</c>.
        /// </summary>
        [TestMethod]
        public void Equals_WithEqualCooperationStrategyResult_ReturnsTrue()
        {
            // Arrange
            var cooperationStrategyResult = new CooperationStrategyResult();
            var equalCooperationStrategyResult = new CooperationStrategyResult();

            // Act
            var objectsAreEqual = cooperationStrategyResult.Equals(equalCooperationStrategyResult);

            // Assert
            Assert.IsTrue(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with equal <see cref="System.Object"/>
        /// instances will return <c>true</c>.
        /// </summary>
        [TestMethod]
        public void Equals_WithEqualObject_ReturnsTrue()
        {
            // Arrange
            var cooperationStrategyResult = new CooperationStrategyResult();
            var equalCooperationStrategyResult = new CooperationStrategyResult();

            // Act
            var objectsAreEqual = cooperationStrategyResult.Equals((object)equalCooperationStrategyResult);

            // Assert
            Assert.IsTrue(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with a <see cref="CooperationStrategyResult"/>
        /// that is actually the same instance will return <c>true</c>.
        /// </summary>
        [TestMethod]
        public void Equals_WithStrategyThatIsSameInstance_ReturnsTrue()
        {
            // Arrange
            var cooperationStrategyResult = new CooperationStrategyResult();

            // Act
            var objectsAreEqual = cooperationStrategyResult.Equals(cooperationStrategyResult);

            // Assert
            Assert.IsTrue(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with an <see cref="System.Object"/>
        /// that is actually the same instance will return <c>true</c>.
        /// </summary>
        [TestMethod]
        public void Equals_WithObjectThatIsSameInstance_ReturnsTrue()
        {
            // Arrange
            var cooperationStrategyResult = new CooperationStrategyResult();

            // Act
            var objectsAreEqual = cooperationStrategyResult.Equals((object)cooperationStrategyResult);

            // Assert
            Assert.IsTrue(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the GetHashCode method with a <c>null</c>
        /// <see cref="CooperationStrategy"/> does not throw an exception.
        /// </summary>
        [TestMethod]
        public void GetHashCode_WithNullStrategy_DoesNotThrowException()
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
        [TestMethod]
        public void GetHashCode_WithUnchangedNewInstances_ReturnsEqualHashCodes()
        {
            // Arrange
            var cooperationStrategyResult = new CooperationStrategyResult();
            var otherCooperationStrategyResult = new CooperationStrategyResult();

            // Act
            var hashCode = cooperationStrategyResult.GetHashCode();
            var otherHashCode = otherCooperationStrategyResult.GetHashCode();

            // Assert
            Assert.AreEqual(hashCode, otherHashCode);
        }

        /// <summary>
        /// Test that calling the GetHashCode method on two <see cref="CooperationStrategyResult"/>
        /// instances that refer to the same cooperation strategy but a different cooperation choice
        /// will return equal hash codes.
        /// </summary>
        [TestMethod]
        public void GetHashCode_WithEqualValues_ReturnsEqualHashCodes()
        {
            // Arrange
            var strategy = new NaiveCooperationStrategy();
            var cooperationStrategyResult = new CooperationStrategyResult { Strategy = strategy, ChoiceMade = CooperationChoice.Defect, Payoff = CooperationChoicesPayoff.DefaultPayoffForDefectAndDefect };
            var otherCooperationStrategyResult = new CooperationStrategyResult { Strategy = strategy, ChoiceMade = CooperationChoice.Defect, Payoff = CooperationChoicesPayoff.DefaultPayoffForDefectAndDefect };

            // Act
            var hashCode = cooperationStrategyResult.GetHashCode();
            var otherHashCode = otherCooperationStrategyResult.GetHashCode();

            // Assert
            Assert.AreEqual(hashCode, otherHashCode);
        }

        /// <summary>
        /// Test that calling the GetHashCode method on two <see cref="CooperationStrategyResult"/>
        /// instances that have different choices made will return different hash codes.
        /// </summary>
        [TestMethod]
        public void GetHashCode_WithDifferentChoiceMade_ReturnsDifferentHashCodes()
        {
            // Arrange
            var cooperationStrategyResult = new CooperationStrategyResult { ChoiceMade = CooperationChoice.Cooperate };
            var otherCooperationStrategyResult = new CooperationStrategyResult { ChoiceMade = CooperationChoice.Defect };

            // Act
            var hashCode = cooperationStrategyResult.GetHashCode();
            var otherHashCode = otherCooperationStrategyResult.GetHashCode();

            // Assert
            Assert.AreNotEqual(hashCode, otherHashCode);
        }

        /// <summary>
        /// Test that calling the GetHashCode method on two <see cref="CooperationStrategyResult"/>
        /// instances that have different cooperation strategies will return different hash codes.
        /// </summary>
        [TestMethod]
        public void GetHashCode_WithDifferentCooperationStrategies_ReturnsDifferentHashCodes()
        {
            // Arrange
            var cooperationStrategyResult = new CooperationStrategyResult { Strategy = new NaiveCooperationStrategy() };
            var otherCooperationStrategyResult = new CooperationStrategyResult { Strategy = new EvilCooperationStrategy() };

            // Act
            var hashCode = cooperationStrategyResult.GetHashCode();
            var otherHashCode = otherCooperationStrategyResult.GetHashCode();

            // Assert
            Assert.AreNotEqual(hashCode, otherHashCode);
        }

        /// <summary>
        /// Test that calling the GetHashCode method on two <see cref="CooperationStrategyResult"/>
        /// instances that have different payoffs will return different hash codes.
        /// </summary>
        [TestMethod]
        public void GetHashCode_WithDifferentPayoff_ReturnsDifferentHashCodes()
        {
            // Arrange
            var cooperationStrategyResult = new CooperationStrategyResult { Payoff = CooperationChoicesPayoff.DefaultPayoffForCooperateAndDefect };
            var otherCooperationStrategyResult = new CooperationStrategyResult { Payoff = CooperationChoicesPayoff.DefaultPayoffForDefectAndCooperate };

            // Act
            var hashCode = cooperationStrategyResult.GetHashCode();
            var otherHashCode = otherCooperationStrategyResult.GetHashCode();

            // Assert
            Assert.AreNotEqual(hashCode, otherHashCode);
        }
    }
}