namespace JobLeet.WebApi.JobLeet.Core.Entities.Identity
{
    /// <summary>
    /// Represents a claim associated with a user.
    /// </summary>
    public class UserClaims
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user claim.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the user to whom the claim belongs.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the type of the claim (e.g., role, permission, etc.).
        /// </summary>
        public string ClaimType { get; set; }

        /// <summary>
        /// Gets or sets the value of the claim.
        /// </summary>
        public string ClaimValue { get; set; }

        /// <summary>
        /// Gets or sets the user associated with this claim.
        /// </summary>
        public Users User { get; set; }
    }
}
