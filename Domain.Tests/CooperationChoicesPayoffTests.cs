namespace StudioDonder.PrisonersDilemma.Domain.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests for the <see cref="CooperationChoicesPayoff"/> class.
    /// </summary>
    [TestClass]
    public class CooperationChoicesPayoffTests
    {
        /// <summary>
        /// Test that calling the constructor will automatically initialize the PayoffForCooperateAndCooperate
        /// property to the correct default value.
        /// </summary>
        [TestMethod]
        public void Constructor_InitializesPayoffForCooperateAndCooperate_ToDefaultValue()
        {
            // Arrange

            // Act
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();

            // Assert
            Assert.AreEqual(CooperationChoicesPayoff.DefaultPayoffForCooperateAndCooperate, cooperationChoicesPayoff.PayoffForCooperateAndCooperate);
        }

        /// <summary>
        /// Test that calling the constructor will automatically initialize the PayoffForCooperateAndDefect
        /// property to the correct default value.
        /// </summary>
        [TestMethod]
        public void Constructor_InitializesPayoffForCooperateAndDefect_ToDefaultValue()
        {
            // Arrange

            // Act
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();

            // Assert
            Assert.AreEqual(CooperationChoicesPayoff.DefaultPayoffForCooperateAndDefect, cooperationChoicesPayoff.PayoffForCooperateAndDefect);
        }

        /// <summary>
        /// Test that calling the constructor will automatically initialize the PayoffForDefectAndCooperate
        /// property to the correct default value.
        /// </summary>
        [TestMethod]
        public void Constructor_InitializesPayoffForDefectAndCooperate_ToDefaultValue()
        {
            // Arrange

            // Act
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();

            // Assert
            Assert.AreEqual(CooperationChoicesPayoff.DefaultPayoffForDefectAndCooperate, cooperationChoicesPayoff.PayoffForDefectAndCooperate);
        }

        /// <summary>
        /// Test that calling the constructor will automatically initialize the PayoffForDefectAndDefect
        /// property to the correct default value.
        /// </summary>
        [TestMethod]
        public void Constructor_InitializesPayoffForDefectAndDefect_ToDefaultValue()
        {
            // Arrange

            // Act
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();

            // Assert
            Assert.AreEqual(CooperationChoicesPayoff.DefaultPayoffForDefectAndDefect, cooperationChoicesPayoff.PayoffForDefectAndDefect);
        }

        /// <summary>
        /// Test that calling the Calculate method with both choices equal to 
        /// <see cref="CooperationChoice.Cooperate"/> will return the correct payoff.
        /// </summary>
        [TestMethod]
        public void CalculatePayoff_WithCooperationChoiceIsCooperateAndOtherCooperationChoiceIsCooperate_ReturnsCorrectPayoff()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();

            // Act
            var payoff = cooperationChoicesPayoff.Calculate(CooperationChoice.Cooperate, CooperationChoice.Cooperate);

            // Assert
            Assert.AreEqual(CooperationChoicesPayoff.DefaultPayoffForCooperateAndCooperate, payoff);
        }

        /// <summary>
        /// Test that calling the Calculate method with the first cooperation choice
        /// is <see cref="CooperationChoice.Cooperate"/> and the other is <see cref="CooperationChoice.Defect"/> 
        /// will return the correct payoff.
        /// </summary>
        [TestMethod]
        public void CalculatePayoff_WithCooperationChoiceIsCooperateAndOtherCooperationChoiceIsDefect_ReturnsCorrectPayoff()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();

            // Act
            var payoff = cooperationChoicesPayoff.Calculate(CooperationChoice.Cooperate, CooperationChoice.Defect);

            // Assert
            Assert.AreEqual(CooperationChoicesPayoff.DefaultPayoffForCooperateAndDefect, payoff);
        }

        /// <summary>
        /// Test that calling the Calculate method with the first cooperation choice
        /// is <see cref="CooperationChoice.Defect"/> and the other is <see cref="CooperationChoice.Cooperate"/> 
        /// will return the correct payoff.
        /// </summary>
        [TestMethod]
        public void CalculatePayoff_WithCooperationChoiceIsDefectAndOtherCooperationChoiceIsCooperate_ReturnsCorrectPayoff()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();

            // Act
            var payoff = cooperationChoicesPayoff.Calculate(CooperationChoice.Defect, CooperationChoice.Cooperate);

            // Assert
            Assert.AreEqual(CooperationChoicesPayoff.DefaultPayoffForDefectAndCooperate, payoff);
        }

        /// <summary>
        /// Test that calling the Calculate method with both choices equal to 
        /// <see cref="CooperationChoice.Defect"/> will return the correct payoff.
        /// </summary>
        [TestMethod]
        public void CalculatePayoff_WithCooperationChoiceIsDefectAndOtherCooperationChoiceIsDefect_ReturnsCorrectPayoff()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();

            // Act
            var payoff = cooperationChoicesPayoff.Calculate(CooperationChoice.Defect, CooperationChoice.Defect);

            // Assert
            Assert.AreEqual(CooperationChoicesPayoff.DefaultPayoffForDefectAndDefect, payoff);
        }

        /// <summary>
        /// Test that calling the Calculate method with both choices equal to 
        /// <see cref="CooperationChoice.Cooperate"/> and a changed payoff will return the correct payoff.
        /// </summary>
        [TestMethod]
        public void CalculatePayoff_WithChangedPayoffForCooperationChoiceIsCooperateAndOtherCooperationChoiceIsCooperate_ReturnsCorrectPayoff()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();
            const int NewPayoffForCooperateAndCooperate = 2 * CooperationChoicesPayoff.DefaultPayoffForCooperateAndCooperate;

            // Act
            cooperationChoicesPayoff.PayoffForCooperateAndCooperate = NewPayoffForCooperateAndCooperate;
            var payoff = cooperationChoicesPayoff.Calculate(CooperationChoice.Cooperate, CooperationChoice.Cooperate);

            // Assert
            Assert.AreEqual(NewPayoffForCooperateAndCooperate, payoff);
        }

        /// <summary>
        /// Test that calling the Calculate method with the first cooperation choice
        /// is <see cref="CooperationChoice.Cooperate"/> and the other is <see cref="CooperationChoice.Defect"/> 
        /// and a changed payoff will return the correct payoff.
        /// </summary>
        [TestMethod]
        public void CalculatePayoff_WithChangedPayoffForCooperationChoiceIsCooperateAndOtherCooperationChoiceIsDefect_ReturnsCorrectPayoff()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();
            const int NewPayoffForCooperateAndDefect = 2 * CooperationChoicesPayoff.DefaultPayoffForCooperateAndDefect;

            // Act
            cooperationChoicesPayoff.PayoffForCooperateAndDefect = NewPayoffForCooperateAndDefect;
            var payoff = cooperationChoicesPayoff.Calculate(CooperationChoice.Cooperate, CooperationChoice.Defect);

            // Assert
            Assert.AreEqual(NewPayoffForCooperateAndDefect, payoff);
        }

        /// <summary>
        /// Test that calling the Calculate method with the first cooperation choice
        /// is <see cref="CooperationChoice.Defect"/> and the other is <see cref="CooperationChoice.Cooperate"/> 
        /// and a changed payoff will return the correct payoff.
        /// </summary>
        [TestMethod]
        public void CalculatePayoff_WithChangedPayoffForCooperationChoiceIsDefectAndOtherCooperationChoiceIsCooperate_ReturnsCorrectPayoff()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();
            const int NewPayoffForDefectAndCooperate = 2 * CooperationChoicesPayoff.DefaultPayoffForDefectAndCooperate;

            // Act
            cooperationChoicesPayoff.PayoffForDefectAndCooperate = NewPayoffForDefectAndCooperate;
            var payoff = cooperationChoicesPayoff.Calculate(CooperationChoice.Defect, CooperationChoice.Cooperate);

            // Assert
            Assert.AreEqual(NewPayoffForDefectAndCooperate, payoff);
        }

        /// <summary>
        /// Test that calling the Calculate method with both choices equal to 
        /// <see cref="CooperationChoice.Defect"/> and a changed payoff will return the correct payoff.
        /// </summary>
        [TestMethod]
        public void CalculatePayoff_WithChangedPayoffForCooperationChoiceIsDefectAndOtherCooperationChoiceIsDefect_ReturnsCorrectPayoff()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();
            const int NewPayoffForDefectAndDefect = 2 * CooperationChoicesPayoff.DefaultPayoffForDefectAndDefect;

            // Act
            cooperationChoicesPayoff.PayoffForDefectAndDefect = NewPayoffForDefectAndDefect;
            var payoff = cooperationChoicesPayoff.Calculate(CooperationChoice.Defect, CooperationChoice.Defect);

            // Assert
            Assert.AreEqual(NewPayoffForDefectAndDefect, payoff);
        }

        /// <summary>
        /// Test that calling the Equals method on two new <see cref="CooperationChoicesPayoff"/>
        /// instances will return <c>true</c>.
        /// </summary>
        [TestMethod]
        public void Equals_WithUnchangedNewCooperationChoicesPayoffInstances_ReturnsTrue()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();
            var otherCooperationChoicesPayoff = new CooperationChoicesPayoff();

            // Act
            var objectsAreEqual = cooperationChoicesPayoff.Equals(otherCooperationChoicesPayoff);

            // Assert
            Assert.IsTrue(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method on two new <see cref="CooperationChoicesPayoff"/>
        /// instances with different payoffs for cooperate and cooperate will return <c>false</c>.
        /// </summary>
        [TestMethod]
        public void Equals_WithUnequalPayoffForCooperateAndCooperate_ReturnsFalse()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff { PayoffForCooperateAndCooperate = 1 };
            var otherCooperationChoicesPayoff = new CooperationChoicesPayoff { PayoffForCooperateAndCooperate = 2 };

            // Act
            var objectsAreEqual = cooperationChoicesPayoff.Equals(otherCooperationChoicesPayoff);

            // Assert
            Assert.IsFalse(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method on two new <see cref="CooperationChoicesPayoff"/>
        /// instances with different payoffs for cooperate and defect will return <c>false</c>.
        /// </summary>
        [TestMethod]
        public void Equals_WithUnequalPayoffForCooperateAndDefect_ReturnsFalse()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff { PayoffForCooperateAndDefect = 1 };
            var otherCooperationChoicesPayoff = new CooperationChoicesPayoff { PayoffForCooperateAndDefect = 2 };

            // Act
            var objectsAreEqual = cooperationChoicesPayoff.Equals(otherCooperationChoicesPayoff);

            // Assert
            Assert.IsFalse(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method on two new <see cref="CooperationChoicesPayoff"/>
        /// instances with different payoffs for defect and cooperate will return <c>false</c>.
        /// </summary>
        [TestMethod]
        public void Equals_WithUnequalPayoffForDefectAndCooperate_ReturnsFalse()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff { PayoffForDefectAndCooperate = 1 };
            var otherCooperationChoicesPayoff = new CooperationChoicesPayoff { PayoffForDefectAndCooperate = 2 };

            // Act
            var objectsAreEqual = cooperationChoicesPayoff.Equals(otherCooperationChoicesPayoff);

            // Assert
            Assert.IsFalse(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method on two new <see cref="CooperationChoicesPayoff"/>
        /// instances with different payoffs for defect and defect will return <c>false</c>.
        /// </summary>
        [TestMethod]
        public void Equals_WithUnequalPayoffForDefectAndDefect_ReturnsFalse()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff { PayoffForDefectAndDefect = 1 };
            var otherCooperationChoicesPayoff = new CooperationChoicesPayoff { PayoffForDefectAndDefect = 2 };

            // Act
            var objectsAreEqual = cooperationChoicesPayoff.Equals(otherCooperationChoicesPayoff);

            // Assert
            Assert.IsFalse(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method on two new <see cref="System.Object"/>
        /// instances will return <c>true</c>.
        /// </summary>
        [TestMethod]
        public void Equals_WithUnchangedNewObjectInstances_ReturnsTrue()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();
            var otherCooperationChoicesPayoff = new CooperationChoicesPayoff();

            // Act
            var objectsAreEqual = cooperationChoicesPayoff.Equals((object)otherCooperationChoicesPayoff);

            // Assert
            Assert.IsTrue(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with a <see cref="CooperationChoicesPayoff"/>
        /// that is actually the same instance will return <c>true</c>.
        /// </summary>
        [TestMethod]
        public void Equals_WithSameCooperationChoicesPayoffInstance_ReturnsTrue()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();

            // Act
            var objectsAreEqual = cooperationChoicesPayoff.Equals(cooperationChoicesPayoff);

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
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();

            // Act
            var objectsAreEqual = cooperationChoicesPayoff.Equals((object)cooperationChoicesPayoff);

            // Assert
            Assert.IsTrue(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with a <c>null</c> <see cref="CooperationChoicesPayoff"/>
        /// will return <c>false</c>.
        /// </summary>
        [TestMethod]
        public void Equals_WithNullCooperationChoicesPayoff_ReturnsFalse()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();
            CooperationChoicesPayoff comparisonCooperationChoicesPayoff = null;

            // Act
            var objectsAreEqual = cooperationChoicesPayoff.Equals(comparisonCooperationChoicesPayoff);

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
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();
            CooperationChoicesPayoff comparisonCooperationChoicesPayoff = null;

            // Act
            var objectsAreEqual = cooperationChoicesPayoff.Equals((object)comparisonCooperationChoicesPayoff);

            // Assert
            Assert.IsFalse(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with equal <see cref="CooperationChoicesPayoff"/>
        /// instances will return <c>true</c>.
        /// </summary>
        [TestMethod]
        public void Equals_WithEqualCooperationChoicesPayoff_ReturnsTrue()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();
            var equalCooperationChoicesPayoff = new CooperationChoicesPayoff();

            // Act
            var objectsAreEqual = cooperationChoicesPayoff.Equals(equalCooperationChoicesPayoff);

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
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();
            var equalCooperationChoicesPayoff = new CooperationChoicesPayoff();

            // Act
            var objectsAreEqual = cooperationChoicesPayoff.Equals((object)equalCooperationChoicesPayoff);

            // Assert
            Assert.IsTrue(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with a <see cref="CooperationChoicesPayoff"/>
        /// that is actually the same instance will return <c>true</c>.
        /// </summary>
        [TestMethod]
        public void Equals_WithCooperationChoicesPayoffThatIsSameInstance_ReturnsTrue()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();

            // Act
            var objectsAreEqual = cooperationChoicesPayoff.Equals(cooperationChoicesPayoff);

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
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();

            // Act
            var objectsAreEqual = cooperationChoicesPayoff.Equals((object)cooperationChoicesPayoff);

            // Assert
            Assert.IsTrue(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the GetHashCode method on two <see cref="CooperationChoicesPayoff"/>
        /// instances that have just been created will return equal hash codes.
        /// </summary>
        [TestMethod]
        public void GetHashCode_WithUnchangedNewInstances_ReturnsEqualHashCodes()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();
            var otherCooperationChoicesPayoff = new CooperationChoicesPayoff();

            // Act
            var hashCode = cooperationChoicesPayoff.GetHashCode();
            var otherHashCode = otherCooperationChoicesPayoff.GetHashCode();

            // Assert
            Assert.AreEqual(hashCode, otherHashCode);
        }

        /// <summary>
        /// Test that calling the GetHashCode method on two <see cref="CooperationChoicesPayoff"/>
        /// instances that refer to the same cooperation strategy but a different cooperation choice
        /// will return equal hash codes.
        /// </summary>
        [TestMethod]
        public void GetHashCode_WithEqualValues_ReturnsEqualHashCodes()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff
                {
                    PayoffForCooperateAndCooperate = CooperationChoicesPayoff.DefaultPayoffForCooperateAndCooperate,
                    PayoffForCooperateAndDefect = CooperationChoicesPayoff.DefaultPayoffForCooperateAndDefect,
                    PayoffForDefectAndCooperate = CooperationChoicesPayoff.DefaultPayoffForDefectAndCooperate,
                    PayoffForDefectAndDefect = CooperationChoicesPayoff.DefaultPayoffForDefectAndDefect,
                };
            var otherCooperationChoicesPayoff = new CooperationChoicesPayoff
                {
                    PayoffForCooperateAndCooperate = CooperationChoicesPayoff.DefaultPayoffForCooperateAndCooperate,
                    PayoffForCooperateAndDefect = CooperationChoicesPayoff.DefaultPayoffForCooperateAndDefect,
                    PayoffForDefectAndCooperate = CooperationChoicesPayoff.DefaultPayoffForDefectAndCooperate,
                    PayoffForDefectAndDefect = CooperationChoicesPayoff.DefaultPayoffForDefectAndDefect,
                };

            // Act
            var hashCode = cooperationChoicesPayoff.GetHashCode();
            var otherHashCode = otherCooperationChoicesPayoff.GetHashCode();

            // Assert
            Assert.AreEqual(hashCode, otherHashCode);
        }

        /// <summary>
        /// Test that calling the GetHashCode method on two <see cref="CooperationChoicesPayoff"/>
        /// instances that have different payoffs for cooperate and cooperate will return different hash codes.
        /// </summary>
        [TestMethod]
        public void GetHashCode_WithDifferentPayoffForCooperateAndCooperate_ReturnsDifferentHashCodes()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff
                {
                    PayoffForCooperateAndCooperate = CooperationChoicesPayoff.DefaultPayoffForCooperateAndCooperate,
                };
            var otherCooperationChoicesPayoff = new CooperationChoicesPayoff
                {
                    PayoffForCooperateAndCooperate = CooperationChoicesPayoff.DefaultPayoffForCooperateAndCooperate + 1,
                };

            // Act
            var hashCode = cooperationChoicesPayoff.GetHashCode();
            var otherHashCode = otherCooperationChoicesPayoff.GetHashCode();

            // Assert
            Assert.AreNotEqual(hashCode, otherHashCode);
        }

        /// <summary>
        /// Test that calling the GetHashCode method on two <see cref="CooperationChoicesPayoff"/>
        /// instances that have different payoffs for cooperate and defect will return different hash codes.
        /// </summary>
        [TestMethod]
        public void GetHashCode_WithDifferentPayoffForCooperateAndDefect_ReturnsDifferentHashCodes()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff
                {
                    PayoffForCooperateAndDefect = CooperationChoicesPayoff.DefaultPayoffForCooperateAndDefect,
                };
            var otherCooperationChoicesPayoff = new CooperationChoicesPayoff
                {
                    PayoffForCooperateAndDefect = CooperationChoicesPayoff.DefaultPayoffForCooperateAndDefect + 1,
                };

            // Act
            var hashCode = cooperationChoicesPayoff.GetHashCode();
            var otherHashCode = otherCooperationChoicesPayoff.GetHashCode();

            // Assert
            Assert.AreNotEqual(hashCode, otherHashCode);
        }

        /// <summary>
        /// Test that calling the GetHashCode method on two <see cref="CooperationChoicesPayoff"/>
        /// instances that have different payoffs for defect and cooperate will return different hash codes.
        /// </summary>
        [TestMethod]
        public void GetHashCode_WithDifferentPayoffForDefectAndCooperate_ReturnsDifferentHashCodes()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff
                {
                    PayoffForDefectAndCooperate = CooperationChoicesPayoff.DefaultPayoffForDefectAndCooperate,
                };
            var otherCooperationChoicesPayoff = new CooperationChoicesPayoff
                {
                    PayoffForDefectAndCooperate = CooperationChoicesPayoff.DefaultPayoffForDefectAndCooperate + 1,
                };

            // Act
            var hashCode = cooperationChoicesPayoff.GetHashCode();
            var otherHashCode = otherCooperationChoicesPayoff.GetHashCode();

            // Assert
            Assert.AreNotEqual(hashCode, otherHashCode);
        }

        /// <summary>
        /// Test that calling the GetHashCode method on two <see cref="CooperationChoicesPayoff"/>
        /// instances that have different payoffs for defect and defect will return different hash codes.
        /// </summary>
        [TestMethod]
        public void GetHashCode_WithDifferentPayoffForDefectAndDefect_ReturnsDifferentHashCodes()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff
                {
                    PayoffForDefectAndDefect = CooperationChoicesPayoff.DefaultPayoffForDefectAndDefect,
                };
            var otherCooperationChoicesPayoff = new CooperationChoicesPayoff
                {
                    PayoffForDefectAndDefect = CooperationChoicesPayoff.DefaultPayoffForDefectAndDefect + 1,
                };

            // Act
            var hashCode = cooperationChoicesPayoff.GetHashCode();
            var otherHashCode = otherCooperationChoicesPayoff.GetHashCode();

            // Assert
            Assert.AreNotEqual(hashCode, otherHashCode);
        }
    }
}