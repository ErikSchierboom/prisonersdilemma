namespace PrisonersDilemma.Domain.Tests
{
    using Xunit;

    /// <summary>
    /// The cooperation strategy tests base.
    /// </summary>
    public abstract class CooperationStrategyTestsBase
    {
        /// <summary>
        /// Test that calling the Equals method on different instances will return <c>true</c>.
        /// </summary>
        [Fact]
        public void EqualsWithDifferentEvilCooperationStrategyInstancesReturnsTrue()
        {
            // Arrange
            var strategy = this.CreateStrategy();
            var otherStrategy = this.CreateStrategy();

            // Act
            var objectsAreEqual = strategy.Equals(otherStrategy);

            // Assert
            Assert.True(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method on different instances will return <c>true</c>.
        /// </summary>
        [Fact]
        public void EqualsWithDifferentObjectInstancesReturnsTrue()
        {
            // Arrange
            var strategy = this.CreateStrategy();
            var otherStrategy = this.CreateStrategy();

            // Act
            var objectsAreEqual = strategy.Equals((object)otherStrategy);

            // Assert
            Assert.True(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method on another cooperation strategy
        /// instance will return <c>false</c>.
        /// </summary>
        [Fact]
        public void EqualsWithOtherCooperationStrategyInstanceReturnsFalse()
        {
            // Arrange
            var strategy = this.CreateStrategy();
            var otherStrategy = this.CreateDifferentStrategy();

            // Act
            var objectsAreEqual = strategy.Equals(otherStrategy);

            // Assert
            Assert.False(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with the same instance will return <c>true</c>.
        /// </summary>
        [Fact]
        public void EqualsWithSameEvilCooperationStrategyInstanceReturnsTrue()
        {
            // Arrange
            var strategy = this.CreateStrategy();

            // Act
            var objectsAreEqual = strategy.Equals(strategy);

            // Assert
            Assert.True(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with the same instance will return <c>true</c>.
        /// </summary>
        [Fact]
        public void EqualsWithSameObjectInstanceReturnsTrue()
        {
            // Arrange
            var strategy = new EvilCooperationStrategy();

            // Act
            var objectsAreEqual = strategy.Equals((object)strategy);

            // Assert
            Assert.True(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the GetHashCode method on another cooperation strategy
        /// instance will return different hash codes.
        /// </summary>
        [Fact]
        public void GetHashCodeWithOtherCooperationStrategyInstanceReturnsDifferentHashCodes()
        {
            // Arrange
            var strategy = this.CreateStrategy();
            var otherStrategy = this.CreateDifferentStrategy();

            // Act
            var hashcode = strategy.GetHashCode();
            var otherHashcode = otherStrategy.GetHashCode();

            // Assert
            Assert.NotEqual(hashcode, otherHashcode);
        }

        /// <summary>
        /// Test that calling the GetHashCode method on another cooperation strategy
        /// instance of the same type will return the same hash codes.
        /// </summary>
        [Fact]
        public void GetHashCodeWithSameCooperationStrategyInstanceReturnsSameHashCodes()
        {
            // Arrange
            var strategy = this.CreateStrategy();
            var otherStrategy = this.CreateStrategy();

            // Act
            var hashcode = strategy.GetHashCode();
            var otherHashcode = otherStrategy.GetHashCode();

            // Assert
            Assert.Equal(hashcode, otherHashcode);
        }

        /// <summary>
        /// Test that the Name property is not <c>null</c>.
        /// </summary>
        [Fact]
        public void NameIsNotNull()
        {
            // Arrange

            // Act
            var strategy = this.CreateStrategy();

            // Assert
            Assert.NotNull(strategy.Name);
        }

        /// <summary>
        /// Test that the Name property returns the correct name.
        /// </summary>
        [Fact]
        public void NameReturnsCorrectName()
        {
            // Arrange

            // Act
            var strategy = this.CreateStrategy();

            // Assert
            Assert.Equal(this.GetCorrectName(), strategy.Name);
        }

        /// <summary>
        /// Test that the Description property is not <c>null</c>.
        /// </summary>
        [Fact]
        public void DescriptionIsNotNull()
        {
            // Arrange

            // Act
            var strategy = this.CreateStrategy();

            // Assert
            Assert.NotNull(strategy.Description);
        }

        /// <summary>
        /// Test that the Description property returns the correct description.
        /// </summary>
        [Fact]
        public void DescriptionReturnsCorrectDescription()
        {
            // Arrange

            // Act
            var strategy = this.CreateStrategy();

            // Assert
            Assert.Equal(this.GetCorrectDescription(), strategy.Description);
        }

        /// <summary>
        /// Gets the correct name.
        /// </summary>
        /// <returns>The name.</returns>
        protected abstract string GetCorrectName();

        /// <summary>
        /// Gets the correct description.
        /// </summary>
        /// <returns>The description.</returns>
        protected abstract string GetCorrectDescription();

        /// <summary>
        /// The create strategy.
        /// </summary>
        /// <returns>The strategy.</returns>
        protected abstract CooperationStrategy CreateStrategy();

        /// <summary>
        /// The create different strategy.
        /// </summary>
        /// <returns>The strategy.</returns>
        protected abstract CooperationStrategy CreateDifferentStrategy();
    }
}