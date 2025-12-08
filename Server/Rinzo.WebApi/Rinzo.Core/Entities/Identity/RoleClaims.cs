namespace JobLeet.WebApi.JobLeet.Core.Entities.Identity
{
    /// <summary>
    /// Represents the claims associated with a specific role.
    /// </summary>
    public class RoleClaims
    {
        /// <summary>
        /// Gets or sets the unique identifier for the claim.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the role to which the claim is associated.
        /// </summary>
        public string RoleId { get; set; }

        /// <summary>
        /// Gets or sets the type of the claim (e.g., "Permission" or "Scope").
        /// </summary>
        public string ClaimType { get; set; }

        /// <summary>
        /// Gets or sets the value of the claim (e.g., "ReadAccess", "Admin").
        /// </summary>
        public string ClaimValue { get; set; }

        /// <summary>
        /// Gets or sets the role associated with the claim.
        /// </summary>
        public Roles Role { get; set; }
    }
}
