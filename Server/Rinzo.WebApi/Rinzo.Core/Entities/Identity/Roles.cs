namespace JobLeet.WebApi.JobLeet.Core.Entities.Identity
{
    /// <summary>
    /// Represents a role in the system, defining a set of permissions or responsibilities.
    /// </summary>
    public class Roles
    {
        /// <summary>
        /// Gets or sets the unique identifier for the role.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the role (e.g., Admin, User, etc.).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the normalized name of the role, used for case-insensitive lookups.
        /// </summary>
        public string NormalizedName { get; set; }

        /// <summary>
        /// Gets or sets a unique string used to ensure the role is updated correctly in concurrency scenarios.
        /// </summary>
        public string ConcurrencyStamp { get; set; }

        /// <summary>
        /// Gets or sets the collection of claims associated with the role.
        /// </summary>
        public ICollection<RoleClaims> RoleClaims { get; set; }

        /// <summary>
        /// Gets or sets the collection of user-role associations, representing the users assigned to this role.
        /// </summary>
        public ICollection<UserRoles> UserRoles { get; set; }
    }
}
