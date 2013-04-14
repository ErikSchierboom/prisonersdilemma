namespace StudioDonder.PrisonersDilemma.Website.Tests.App_Start
{
    using System.Linq;
    using System.Web.Mvc;

    using StudioDonder.PrisonersDilemma.Website.App_Start;

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