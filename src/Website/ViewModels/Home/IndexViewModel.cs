namespace PrisonersDilemma.Website.ViewModels.Home
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using PrisonersDilemma.Domain;
    using PrisonersDilemma.Website.Controllers;

    /// <summary>
    /// The model for the <see cref="HomeController.Index"/> action.
    /// </summary>
    public class IndexViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndexViewModel"/> class.
        /// </summary>
        public IndexViewModel()
        {
            // Set default values to prevent the user from having to come 
            // up with sensible defaults himself
            this.NumberOfRounds = 10;
            this.PayoffForCooperateAndCooperate = 3;
            this.PayoffForCooperateAndDefect = 0;
            this.PayoffForDefectAndCooperate = 5;
            this.PayoffForDefectAndDefect = 1;
        }

        /// <summary>
        /// Gets or sets the number of rounds used in the simulation.
        /// </summary>
        /// <remarks>
        /// We limit the valid values for this property to prevent overly large values from
        /// placing a lot of stress on the CPU.
        /// </remarks>
        /// <value>
        /// The number of rounds.
        /// </value>
        [Required]
        [Range(1, 100)]
        [Display(Name = "Number of rounds")]
        public uint NumberOfRounds { get; set; }

        /// <summary>
        /// Gets or sets the payoff for cooperate and cooperate.
        /// </summary>
        [Required]
        [Display(Name = "Payoff for cooperate and cooperate")]
        public int PayoffForCooperateAndCooperate { get; set; }

        /// <summary>
        /// Gets or sets the payoff for cooperate and defect.
        /// </summary>
        [Required]
        [Display(Name = "Payoff for cooperate and defect")]
        public int PayoffForCooperateAndDefect { get; set; }

        /// <summary>
        /// Gets or sets the payoff for defect and cooperate.
        /// </summary>
        [Required]
        [Display(Name = "Payoff for defect and cooperate")]
        public int PayoffForDefectAndCooperate { get; set; }

        /// <summary>
        /// Gets or sets the payoff for defect and defect.
        /// </summary>
        [Required]
        [Display(Name = "Payoff for defect and defect")]
        public int PayoffForDefectAndDefect { get; set; }

        /// <summary>
        /// Gets or sets the strategy fitnesses.
        /// </summary>
        /// <remarks>
        /// This property will only be set if a succesful simulation has been done.
        /// </remarks>
        /// <value>
        /// The strategy fitnesses.
        /// </value>
        public IList<CooperationStrategyFitness> StrategyFitnesses { get; set; }
    }
}