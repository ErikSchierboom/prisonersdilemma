namespace StudioDonder.PrisonersDilemma.Website.Controllers
{
    using System.Web.Mvc;

    using StudioDonder.PrisonersDilemma.Domain;
    using StudioDonder.PrisonersDilemma.Website.ViewModels.Home;

    /// <summary>
    /// This controller will allow the user to pit the available strategies against each other.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Show the page in which the user can configure and run the simulation.
        /// </summary>
        /// <returns>The view result.</returns>
        [HttpGet]
        public ViewResult Index()
        {
            return this.View(new IndexViewModel());
        }

        /// <summary>
        /// Show the page in which the results of the simulation are shown (provided the
        /// parameters supplied are valid).
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>The view result.</returns>
        [HttpPost]
        public ViewResult Index(IndexViewModel model)
        {
            // Only perform the simulation when the data that was entered was valid
            if (ModelState.IsValid)
            {
                // Create the fitness evaluator using the configuration specified by the user
                var fitnessEvaluator = new CooperationStrategiesFitnessEvaluator
                                           {
                                               NumberOfRounds = model.NumberOfRounds,
                                               CooperationChoicesPayoff =
                                                   {
                                                       PayoffForCooperateAndCooperate = model.PayoffForCooperateAndCooperate, 
                                                       PayoffForCooperateAndDefect = model.PayoffForCooperateAndDefect, 
                                                       PayoffForDefectAndCooperate = model.PayoffForDefectAndCooperate, 
                                                       PayoffForDefectAndDefect = model.PayoffForDefectAndDefect
                                                   }
                                           };

                // Evaluate the fitness of the strategies
                model.StrategyFitnesses = fitnessEvaluator.Evaluate();
            }

            return this.View(model);
        }
    }
}