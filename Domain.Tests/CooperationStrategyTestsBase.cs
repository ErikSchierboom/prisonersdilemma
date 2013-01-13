namespace StudioDonder.PrisonersDilemma.Domain.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The cooperation strategy tests base.
    /// </summary>
    [TestClass]
    public abstract class CooperationStrategyTestsBase
    {
        /// <summary>
        /// Test that calling the Equals method on different instances will return <c>true</c>.
        /// </summary>
        [TestMethod]
        public void Equals_WithDifferentEvilCooperationStrategyInstances_ReturnsTrue()
        {
            // Arrange
            var strategy = this.CreateStrategy();
            var otherStrategy = this.CreateStrategy();

            // Act
            var objectsAreEqual = strategy.Equals(otherStrategy);

            // Assert
            Assert.IsTrue(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method on different instances will return <c>true</c>.
        /// </summary>
        [TestMethod]
        public void Equals_WithDifferentObjectInstances_ReturnsTrue()
        {
            // Arrange
            var strategy = this.CreateStrategy();
            var otherStrategy = this.CreateStrategy();

            // Act
            var objectsAreEqual = strategy.Equals((object)otherStrategy);

            // Assert
            Assert.IsTrue(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method on another cooperation strategy
        /// instance will return <c>false</c>.
        /// </summary>
        [TestMethod]
        public void Equals_WithOtherCooperationStrategyInstance_ReturnsFalse()
        {
            // Arrange
            var strategy = this.CreateStrategy();
            var otherStrategy = this.CreateDifferentStrategy();

            // Act
            var objectsAreEqual = strategy.Equals(otherStrategy);

            // Assert
            Assert.IsFalse(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with the same instance will return <c>true</c>.
        /// </summary>
        [TestMethod]
        public void Equals_WithSameEvilCooperationStrategyInstance_ReturnsTrue()
        {
            // Arrange
            var strategy = this.CreateStrategy();

            // Act
            var objectsAreEqual = strategy.Equals(strategy);

            // Assert
            Assert.IsTrue(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the Equals method with the same instance will return <c>true</c>.
        /// </summary>
        [TestMethod]
        public void Equals_WithSameObjectInstance_ReturnsTrue()
        {
            // Arrange
            var strategy = new EvilCooperationStrategy();

            // Act
            var objectsAreEqual = strategy.Equals((object)strategy);

            // Assert
            Assert.IsTrue(objectsAreEqual);
        }

        /// <summary>
        /// Test that calling the GetHashCode method on another cooperation strategy
        /// instance will return different hash codes.
        /// </summary>
        [TestMethod]
        public void GetHashCode_WithOtherCooperationStrategyInstance_ReturnsDifferentHashCodes()
        {
            // Arrange
            var strategy = this.CreateStrategy();
            var otherStrategy = this.CreateDifferentStrategy();

            // Act
            var hashcode = strategy.GetHashCode();
            var otherHashcode = otherStrategy.GetHashCode();

            // Assert
            Assert.AreNotEqual(hashcode, otherHashcode);
        }

        /// <summary>
        /// Test that calling the GetHashCode method on another cooperation strategy
        /// instance of the same type will return the same hash codes.
        /// </summary>
        [TestMethod]
        public void GetHashCode_WithSameCooperationStrategyInstance_ReturnsSameHashCodes()
        {
            // Arrange
            var strategy = this.CreateStrategy();
            var otherStrategy = this.CreateStrategy();

            // Act
            var hashcode = strategy.GetHashCode();
            var otherHashcode = otherStrategy.GetHashCode();

            // Assert
            Assert.AreEqual(hashcode, otherHashcode);
        }

        /// <summary>
        /// Test that the Name property is not <c>null</c>.
        /// </summary>
        [TestMethod]
        public void Name_IsNotNull()
        {
            // Arrange

            // Act
            var strategy = this.CreateStrategy();

            // Assert
            Assert.IsNotNull(strategy.Name);
        }

        /// <summary>
        /// Test that the Name property returns the correct name.
        /// </summary>
        [TestMethod]
        public void Name_ReturnsCorrectName()
        {
            // Arrange

            // Act
            var strategy = this.CreateStrategy();

            // Assert
            Assert.AreEqual(this.GetCorrectName(), strategy.Name);
        }

        /// <summary>
        /// Test that the Description property is not <c>null</c>.
        /// </summary>
        [TestMethod]
        public void Description_IsNotNull()
        {
            // Arrange

            // Act
            var strategy = this.CreateStrategy();

            // Assert
            Assert.IsNotNull(strategy.Description);
        }

        /// <summary>
        /// Test that the Description property returns the correct description.
        /// </summary>
        [TestMethod]
        public void Description_ReturnsCorrectDescription()
        {
            // Arrange

            // Act
            var strategy = this.CreateStrategy();

            // Assert
            Assert.AreEqual(this.GetCorrectDescription(), strategy.Description);
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