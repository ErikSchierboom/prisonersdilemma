namespace StudioDonder.PrisonersDilemma.Domain
{
    using System;

    using Validation;

    /// <summary>
    /// The cooperation strategy base.
    /// </summary>
    public abstract class CooperationStrategy : IEquatable<CooperationStrategy>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CooperationStrategy"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        protected CooperationStrategy(string name, string description)
        {
            Requires.NotNull(name, "name");
            Requires.NotNull(description, "description");

            this.Name = name;
            this.Description = description;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the description.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Chooses the specified opponent last choice.
        /// </summary>
        /// <param name="opponentLastChoice">The opponent last choice.</param>
        /// <returns></returns>
        public abstract CooperationChoice Choose(CooperationChoice opponentLastChoice);

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return this.Equals(obj as CooperationStrategy);
        }

        /// <summary>
        /// Determines whether the specified <see cref="CooperationStrategy"/> is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="CooperationStrategy"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="CooperationStrategy"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(CooperationStrategy other)
        {
            return other != null && string.Equals(this.Name, other.Name);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}