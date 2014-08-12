namespace PrisonersDilemma.Website.Tests.Controllers
{
    using System.Web.Mvc;
    using System.Web.Routing;

    using MvcContrib.TestHelper;

    using PrisonersDilemma.Website.Controllers;
    using PrisonersDilemma.Website.ViewModels.Home;

    using Xunit;

    public class HomeControllerTests
    {
        [Fact]
        public void IndexActionRespondsToCorrectUrl()
        {
            // Arrange
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Act

            // Assert
            "~/".ShouldMapTo<HomeController>(c => c.Index());
        }

        [Fact]
        public void IndexGetActionReturnsViewResult()
        {
            // Arrange
            var homeController = new HomeController();

            // Act
            var viewResult = homeController.Index();

            // Assert
            Assert.IsType<ViewResult>(viewResult);
        }

        [Fact]
        public void IndexGetActionReturnsViewResultWithModelSetToDefaultInstance()
        {
            // Arrange
            var homeController = new HomeController();

            // Act
            var viewResult = homeController.Index();

            // Assert
            Assert.NotNull(viewResult.Model);
        }

        [Fact]
        public void IndexPostActionReturnsViewResult()
        {
            // Arrange
            var homeController = new HomeController();

            // Act
            var viewResult = homeController.Index(new IndexViewModel());

            // Assert
            Assert.IsType<ViewResult>(viewResult);
        }

        [Fact]
        public void IndexPostActionReturnsViewResultWithModelSetToInstanceSupplied()
        {
            // Arrange
            var homeController = new HomeController();
            var indexViewModel = new IndexViewModel();

            // Act
            var viewResult = homeController.Index(indexViewModel);

            // Assert
            Assert.Same(indexViewModel, viewResult.Model);
        }

        [Fact]
        public void IndexPostActionWithInvalidModelDoesNotRunSimulation()
        {
            // Arrange
            var homeController = new HomeController();
            homeController.ModelState.AddModelError("Invalid", "Invalid model data");

            // Act
            var viewResult = homeController.Index(new IndexViewModel());

            // Assert
            Assert.Null(((IndexViewModel)viewResult.Model).StrategyFitnesses);
        }

        [Fact]
        public void IndexPostActionWithValidModelRunsSimulation()
        {
            // Arrange
            var homeController = new HomeController();

            // Act
            var viewResult = homeController.Index(new IndexViewModel());

            // Assert
            Assert.NotNull(((IndexViewModel)viewResult.Model).StrategyFitnesses);
        }

        [Fact]
        public void IndexPostActionWithValidModelRunsSimulationWithSuppliedValues()
        {
            // Arrange
            var homeController = new HomeController();

            // We create a model with values all different from the default. That way
            // we can know for sure if those values are used
            var indexViewModel = new IndexViewModel
                                     {
                                         NumberOfRounds = 50,
                                         PayoffForCooperateAndCooperate = 10,
                                         PayoffForCooperateAndDefect = 11,
                                         PayoffForDefectAndCooperate = 12,
                                         PayoffForDefectAndDefect = 13
                                     };

            // Act
            var viewResult = homeController.Index(indexViewModel);

            // Assert
            var viewResultModel = (IndexViewModel)viewResult.Model;
            Assert.Equal(3, viewResultModel.StrategyFitnesses.Count);
            Assert.Equal(2050, viewResultModel.StrategyFitnesses[0].TotalPayoff);
            Assert.Equal(2549, viewResultModel.StrategyFitnesses[1].TotalPayoff);
            Assert.Equal(2148, viewResultModel.StrategyFitnesses[2].TotalPayoff);
        }
    }
}