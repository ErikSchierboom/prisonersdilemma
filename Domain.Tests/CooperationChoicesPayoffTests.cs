namespace StudioDonder.PrisonersDilemma.Domain.Tests
{
    using Xunit;

    /// <summary>
    /// Tests for the <see cref="CooperationChoicesPayoff"/> class.
    /// </summary>
    public class CooperationChoicesPayoffTests
    {
        /// <summary>
        /// Test that calling the constructor will automatically initialize the PayoffForCooperateAndCooperate
        /// property to the correct default value.
        /// </summary>
        [Fact]
        public void ConstructorInitializesPayoffForCooperateAndCooperateToDefaultValue()
        {
            // Arrange

            // Act
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();

            // Assert
            Assert.Equal(CooperationChoicesPayoff.DefaultPayoffForCooperateAndCooperate, cooperationChoicesPayoff.PayoffForCooperateAndCooperate);
        }

        /// <summary>
        /// Test that calling the constructor will automatically initialize the PayoffForCooperateAndDefect
        /// property to the correct default value.
        /// </summary>
        [Fact]
        public void ConstructorInitializesPayoffForCooperateAndDefectToDefaultValue()
        {
            // Arrange

            // Act
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();

            // Assert
            Assert.Equal(CooperationChoicesPayoff.DefaultPayoffForCooperateAndDefect, cooperationChoicesPayoff.PayoffForCooperateAndDefect);
        }

        /// <summary>
        /// Test that calling the constructor will automatically initialize the PayoffForDefectAndCooperate
        /// property to the correct default value.
        /// </summary>
        [Fact]
        public void ConstructorInitializesPayoffForDefectAndCooperateToDefaultValue()
        {
            // Arrange

            // Act
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();

            // Assert
            Assert.Equal(CooperationChoicesPayoff.DefaultPayoffForDefectAndCooperate, cooperationChoicesPayoff.PayoffForDefectAndCooperate);
        }

        /// <summary>
        /// Test that calling the constructor will automatically initialize the PayoffForDefectAndDefect
        /// property to the correct default value.
        /// </summary>
        [Fact]
        public void ConstructorInitializesPayoffForDefectAndDefectToDefaultValue()
        {
            // Arrange

            // Act
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();

            // Assert
            Assert.Equal(CooperationChoicesPayoff.DefaultPayoffForDefectAndDefect, cooperationChoicesPayoff.PayoffForDefectAndDefect);
        }

        /// <summary>
        /// Test that calling the Calculate method with both choices equal to 
        /// <see cref="CooperationChoice.Cooperate"/> will return the correct payoff.
        /// </summary>
        [Fact]
        public void CalculatePayoffWithCooperationChoiceIsCooperateAndOtherCooperationChoiceIsCooperateReturnsCorrectPayoff()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();

            // Act
            var payoff = cooperationChoicesPayoff.Calculate(CooperationChoice.Cooperate, CooperationChoice.Cooperate);

            // Assert
            Assert.Equal(CooperationChoicesPayoff.DefaultPayoffForCooperateAndCooperate, payoff);
        }

        /// <summary>
        /// Test that calling the Calculate method with the first cooperation choice
        /// is <see cref="CooperationChoice.Cooperate"/> and the other is <see cref="CooperationChoice.Defect"/> 
        /// will return the correct payoff.
        /// </summary>
        [Fact]
        public void CalculatePayoffWithCooperationChoiceIsCooperateAndOtherCooperationChoiceIsDefectReturnsCorrectPayoff()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();

            // Act
            var payoff = cooperationChoicesPayoff.Calculate(CooperationChoice.Cooperate, CooperationChoice.Defect);

            // Assert
            Assert.Equal(CooperationChoicesPayoff.DefaultPayoffForCooperateAndDefect, payoff);
        }

        /// <summary>
        /// Test that calling the Calculate method with the first cooperation choice
        /// is <see cref="CooperationChoice.Defect"/> and the other is <see cref="CooperationChoice.Cooperate"/> 
        /// will return the correct payoff.
        /// </summary>
        [Fact]
        public void CalculatePayoffWithCooperationChoiceIsDefectAndOtherCooperationChoiceIsCooperateReturnsCorrectPayoff()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();

            // Act
            var payoff = cooperationChoicesPayoff.Calculate(CooperationChoice.Defect, CooperationChoice.Cooperate);

            // Assert
            Assert.Equal(CooperationChoicesPayoff.DefaultPayoffForDefectAndCooperate, payoff);
        }

        /// <summary>
        /// Test that calling the Calculate method with both choices equal to 
        /// <see cref="CooperationChoice.Defect"/> will return the correct payoff.
        /// </summary>
        [Fact]
        public void CalculatePayoffWithCooperationChoiceIsDefectAndOtherCooperationChoiceIsDefectReturnsCorrectPayoff()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();

            // Act
            var payoff = cooperationChoicesPayoff.Calculate(CooperationChoice.Defect, CooperationChoice.Defect);

            // Assert
            Assert.Equal(CooperationChoicesPayoff.DefaultPayoffForDefectAndDefect, payoff);
        }

        /// <summary>
        /// Test that calling the Calculate method with both choices equal to 
        /// <see cref="CooperationChoice.Cooperate"/> and a changed payoff will return the correct payoff.
        /// </summary>
        [Fact]
        public void CalculatePayoffWithChangedPayoffForCooperationChoiceIsCooperateAndOtherCooperationChoiceIsCooperateReturnsCorrectPayoff()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();
            const int NewPayoffForCooperateAndCooperate = 2 * CooperationChoicesPayoff.DefaultPayoffForCooperateAndCooperate;

            // Act
            cooperationChoicesPayoff.PayoffForCooperateAndCooperate = NewPayoffForCooperateAndCooperate;
            var payoff = cooperationChoicesPayoff.Calculate(CooperationChoice.Cooperate, CooperationChoice.Cooperate);

            // Assert
            Assert.Equal(NewPayoffForCooperateAndCooperate, payoff);
        }

        /// <summary>
        /// Test that calling the Calculate method with the first cooperation choice
        /// is <see cref="CooperationChoice.Cooperate"/> and the other is <see cref="CooperationChoice.Defect"/> 
        /// and a changed payoff will return the correct payoff.
        /// </summary>
        [Fact]
        public void CalculatePayoffWithChangedPayoffForCooperationChoiceIsCooperateAndOtherCooperationChoiceIsDefectReturnsCorrectPayoff()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();
            const int NewPayoffForCooperateAndDefect = 2 * CooperationChoicesPayoff.DefaultPayoffForCooperateAndDefect;

            // Act
            cooperationChoicesPayoff.PayoffForCooperateAndDefect = NewPayoffForCooperateAndDefect;
            var payoff = cooperationChoicesPayoff.Calculate(CooperationChoice.Cooperate, CooperationChoice.Defect);

            // Assert
            Assert.Equal(NewPayoffForCooperateAndDefect, payoff);
        }

        /// <summary>
        /// Test that calling the Calculate method with the first cooperation choice
        /// is <see cref="CooperationChoice.Defect"/> and the other is <see cref="CooperationChoice.Cooperate"/> 
        /// and a changed payoff will return the correct payoff.
        /// </summary>
        [Fact]
        public void CalculatePayoffWithChangedPayoffForCooperationChoiceIsDefectAndOtherCooperationChoiceIsCooperateReturnsCorrectPayoff()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();
            const int NewPayoffForDefectAndCooperate = 2 * CooperationChoicesPayoff.DefaultPayoffForDefectAndCooperate;

            // Act
            cooperationChoicesPayoff.PayoffForDefectAndCooperate = NewPayoffForDefectAndCooperate;
            var payoff = cooperationChoicesPayoff.Calculate(CooperationChoice.Defect, CooperationChoice.Cooperate);

            // Assert
            Assert.Equal(NewPayoffForDefectAndCooperate, payoff);
        }

        /// <summary>
        /// Test that calling the Calculate method with both choices equal to 
        /// <see cref="CooperationChoice.Defect"/> and a changed payoff will return the correct payoff.
        /// </summary>
        [Fact]
        public void CalculatePayoffWithChangedPayoffForCooperationChoiceIsDefectAndOtherCooperationChoiceIsDefectReturnsCorrectPayoff()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();
            const int NewPayoffForDefectAndDefect = 2 * CooperationChoicesPayoff.DefaultPayoffForDefectAndDefect;

            // Act
            cooperationChoicesPayoff.PayoffForDefectAndDefect = NewPayoffForDefectAndDefect;
            var payoff = cooperationChoicesPayoff.Calculate(CooperationChoice.Defect, CooperationChoice.Defect);

            // Assert
            Assert.Equal(NewPayoffForDefectAndDefect, payoff);
        }

        /// <summary>
        /// Test that calling the Equals method on two new <see cref="CooperationChoicesPayoff"/>
        /// instances will return <c>true</c>.
        /// </summary>
        [Fact]
        public void EqualsWithUnchangedNewCooperationChoicesPayoffInstancesReturnsTrue()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();
            var otherCooperationChoicesPayoff = new CooperationChoicesPayoff();

            // Act
            var objectsAreEqual = cooperationChoicesPayoff.Equals(otherCooperationChoicesPayoff);

            // Assert
            Assert.True(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method on two new <see cref="CooperationChoicesPayoff"/>
        /// instances with different payoffs for cooperate and cooperate will return <c>false</c>.
        /// </summary>
        [Fact]
        public void EqualsWithUnequalPayoffForCooperateAndCooperateReturnsFalse()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff { PayoffForCooperateAndCooperate = 1 };
            var otherCooperationChoicesPayoff = new CooperationChoicesPayoff { PayoffForCooperateAndCooperate = 2 };

            // Act
            var objectsAreEqual = cooperationChoicesPayoff.Equals(otherCooperationChoicesPayoff);

            // Assert
            Assert.False(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method on two new <see cref="CooperationChoicesPayoff"/>
        /// instances with different payoffs for cooperate and defect will return <c>false</c>.
        /// </summary>
        [Fact]
        public void EqualsWithUnequalPayoffForCooperateAndDefectReturnsFalse()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff { PayoffForCooperateAndDefect = 1 };
            var otherCooperationChoicesPayoff = new CooperationChoicesPayoff { PayoffForCooperateAndDefect = 2 };

            // Act
            var objectsAreEqual = cooperationChoicesPayoff.Equals(otherCooperationChoicesPayoff);

            // Assert
            Assert.False(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method on two new <see cref="CooperationChoicesPayoff"/>
        /// instances with different payoffs for defect and cooperate will return <c>false</c>.
        /// </summary>
        [Fact]
        public void EqualsWithUnequalPayoffForDefectAndCooperateReturnsFalse()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff { PayoffForDefectAndCooperate = 1 };
            var otherCooperationChoicesPayoff = new CooperationChoicesPayoff { PayoffForDefectAndCooperate = 2 };

            // Act
            var objectsAreEqual = cooperationChoicesPayoff.Equals(otherCooperationChoicesPayoff);

            // Assert
            Assert.False(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method on two new <see cref="CooperationChoicesPayoff"/>
        /// instances with different payoffs for defect and defect will return <c>false</c>.
        /// </summary>
        [Fact]
        public void EqualsWithUnequalPayoffForDefectAndDefectReturnsFalse()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff { PayoffForDefectAndDefect = 1 };
            var otherCooperationChoicesPayoff = new CooperationChoicesPayoff { PayoffForDefectAndDefect = 2 };

            // Act
            var objectsAreEqual = cooperationChoicesPayoff.Equals(otherCooperationChoicesPayoff);

            // Assert
            Assert.False(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method on two new <see cref="System.Object"/>
        /// instances will return <c>true</c>.
        /// </summary>
        [Fact]
        public void EqualsWithUnchangedNewObjectInstancesReturnsTrue()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();
            var otherCooperationChoicesPayoff = new CooperationChoicesPayoff();

            // Act
            var objectsAreEqual = cooperationChoicesPayoff.Equals((object)otherCooperationChoicesPayoff);

            // Assert
            Assert.True(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with a <see cref="CooperationChoicesPayoff"/>
        /// that is actually the same instance will return <c>true</c>.
        /// </summary>
        [Fact]
        public void EqualsWithSameCooperationChoicesPayoffInstanceReturnsTrue()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();

            // Act
            var objectsAreEqual = cooperationChoicesPayoff.Equals(cooperationChoicesPayoff);

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
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();

            // Act
            var objectsAreEqual = cooperationChoicesPayoff.Equals((object)cooperationChoicesPayoff);

            // Assert
            Assert.True(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with a <c>null</c> <see cref="CooperationChoicesPayoff"/>
        /// will return <c>false</c>.
        /// </summary>
        [Fact]
        public void EqualsWithNullCooperationChoicesPayoffReturnsFalse()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();
            CooperationChoicesPayoff comparisonCooperationChoicesPayoff = null;

            // Act
            var objectsAreEqual = cooperationChoicesPayoff.Equals(comparisonCooperationChoicesPayoff);

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
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();
            CooperationChoicesPayoff comparisonCooperationChoicesPayoff = null;

            // Act
            var objectsAreEqual = cooperationChoicesPayoff.Equals((object)comparisonCooperationChoicesPayoff);

            // Assert
            Assert.False(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with equal <see cref="CooperationChoicesPayoff"/>
        /// instances will return <c>true</c>.
        /// </summary>
        [Fact]
        public void EqualsWithEqualCooperationChoicesPayoffReturnsTrue()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();
            var equalCooperationChoicesPayoff = new CooperationChoicesPayoff();

            // Act
            var objectsAreEqual = cooperationChoicesPayoff.Equals(equalCooperationChoicesPayoff);

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
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();
            var equalCooperationChoicesPayoff = new CooperationChoicesPayoff();

            // Act
            var objectsAreEqual = cooperationChoicesPayoff.Equals((object)equalCooperationChoicesPayoff);

            // Assert
            Assert.True(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with a <see cref="CooperationChoicesPayoff"/>
        /// that is actually the same instance will return <c>true</c>.
        /// </summary>
        [Fact]
        public void EqualsWithCooperationChoicesPayoffThatIsSameInstanceReturnsTrue()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();

            // Act
            var objectsAreEqual = cooperationChoicesPayoff.Equals(cooperationChoicesPayoff);

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
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();

            // Act
            var objectsAreEqual = cooperationChoicesPayoff.Equals((object)cooperationChoicesPayoff);

            // Assert
            Assert.True(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the GetHashCode method on two <see cref="CooperationChoicesPayoff"/>
        /// instances that have just been created will return equal hash codes.
        /// </summary>
        [Fact]
        public void GetHashCodeWithUnchangedNewInstancesReturnsEqualHashCodes()
        {
            // Arrange
            var cooperationChoicesPayoff = new CooperationChoicesPayoff();
            var otherCooperationChoicesPayoff = new CooperationChoicesPayoff();

            // Act
            var hashCode = cooperationChoicesPayoff.GetHashCode();
            var otherHashCode = otherCooperationChoicesPayoff.GetHashCode();

            // Assert
            Assert.Equal(hashCode, otherHashCode);
        }

        /// <summary>
        /// Test that calling the GetHashCode method on two <see cref="CooperationChoicesPayoff"/>
        /// instances that refer to the same cooperation strategy but a different cooperation choice
        /// will return equal hash codes.
        /// </summary>
        [Fact]
        public void GetHashCodeWithEqualValuesReturnsEqualHashCodes()
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
            Assert.Equal(hashCode, otherHashCode);
        }

        /// <summary>
        /// Test that calling the GetHashCode method on two <see cref="CooperationChoicesPayoff"/>
        /// instances that have different payoffs for cooperate and cooperate will return different hash codes.
        /// </summary>
        [Fact]
        public void GetHashCodeWithDifferentPayoffForCooperateAndCooperateReturnsDifferentHashCodes()
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
            Assert.NotEqual(hashCode, otherHashCode);
        }

        /// <summary>
        /// Test that calling the GetHashCode method on two <see cref="CooperationChoicesPayoff"/>
        /// instances that have different payoffs for cooperate and defect will return different hash codes.
        /// </summary>
        [Fact]
        public void GetHashCodeWithDifferentPayoffForCooperateAndDefectReturnsDifferentHashCodes()
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
            Assert.NotEqual(hashCode, otherHashCode);
        }

        /// <summary>
        /// Test that calling the GetHashCode method on two <see cref="CooperationChoicesPayoff"/>
        /// instances that have different payoffs for defect and cooperate will return different hash codes.
        /// </summary>
        [Fact]
        public void GetHashCodeWithDifferentPayoffForDefectAndCooperateReturnsDifferentHashCodes()
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
            Assert.NotEqual(hashCode, otherHashCode);
        }

        /// <summary>
        /// Test that calling the GetHashCode method on two <see cref="CooperationChoicesPayoff"/>
        /// instances that have different payoffs for defect and defect will return different hash codes.
        /// </summary>
        [Fact]
        public void GetHashCodeWithDifferentPayoffForDefectAndDefectReturnsDifferentHashCodes()
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
            Assert.NotEqual(hashCode, otherHashCode);
        }
    }
}