namespace StudioDonder.PrisonersDilemma.Website.Tests.ViewModels.Home
{
    using System.ComponentModel.DataAnnotations;

    using StudioDonder.PrisonersDilemma.Website.ViewModels.Home;

    using Xunit;
    using Xunit.Extensions;

    public class IndexViewModelTests
    {
        [Fact]
        public void ConstructorSetsDefaultValueForNumberOfRounds()
        {
            // Arrange

            // Act
            var model = new IndexViewModel();

            // Assert
            Assert.Equal<uint>(10, model.NumberOfRounds);
        }

        [Fact]
        public void ConstructorSetsDefaultValueForPayoffForCooperateAndCooperate()
        {
            // Arrange

            // Act
            var model = new IndexViewModel();

            // Assert
            Assert.Equal(3, model.PayoffForCooperateAndCooperate);
        }

        [Fact]
        public void ConstructorSetsDefaultValueForPayoffForCooperateAndDefect()
        {
            // Arrange

            // Act
            var model = new IndexViewModel();

            // Assert
            Assert.Equal(0, model.PayoffForCooperateAndDefect);
        }

        [Fact]
        public void ConstructorSetsDefaultValueForPayoffForDefectAndCooperate()
        {
            // Arrange

            // Act
            var model = new IndexViewModel();

            // Assert
            Assert.Equal(5, model.PayoffForDefectAndCooperate);
        }

        [Fact]
        public void ConstructorSetsDefaultValueForPayoffForDefectAndDefect()
        {
            // Arrange

            // Act
            var model = new IndexViewModel();

            // Assert
            Assert.Equal(1, model.PayoffForDefectAndDefect);
        }

        [Fact]
        public void DefaultInstanceIsValid()
        {
            // Arrange

            // Act
            var model = new IndexViewModel();

            // Assert
            Assert.True(ModelIsValid(model));
        }

        [Theory]
        [InlineData((uint)0)]
        [InlineData((uint)101)]
        public void ModelWithNumberOfRoundsOutOfRangeIsNotValid(uint numberOfRounds)
        {
            // Arrange
            var model = new IndexViewModel();

            // Act
            model.NumberOfRounds = numberOfRounds;

            // Assert
            Assert.False(ModelIsValid(model));
        }

        [Theory]
        [InlineData((uint)1)]
        [InlineData((uint)2)]
        [InlineData((uint)50)]
        [InlineData((uint)99)]
        [InlineData((uint)100)]
        public void ModelWithNumberOfRoundsWithinRangeIsValid(uint numberOfRounds)
        {
            // Arrange
            var model = new IndexViewModel();

            // Act
            model.NumberOfRounds = numberOfRounds;

            // Assert
            Assert.True(ModelIsValid(model));
        }

        private static bool ModelIsValid(IndexViewModel model)
        {
            return Validator.TryValidateObject(model, new ValidationContext(model, null, null), null, true);
        }
    }
}