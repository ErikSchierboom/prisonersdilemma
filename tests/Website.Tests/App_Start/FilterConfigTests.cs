namespace PrisonersDilemma.Website.Tests
{
    using System.Linq;
    using System.Web.Mvc;

    using Xunit;

    public class FilterConfigTests
    {
        [Fact]
        public void RegisterGlobalFiltersRegistersHandleErrorAttribute()
        {
            // Arrange
            var globalFilterCollection = new GlobalFilterCollection();

            // Act
            FilterConfig.RegisterGlobalFilters(globalFilterCollection);

            // Assert
            Assert.True(globalFilterCollection.Any(f => f.Instance.GetType() == typeof(HandleErrorAttribute)));
        }
    }
}