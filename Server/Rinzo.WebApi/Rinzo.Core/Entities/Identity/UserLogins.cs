namespace JobLeet.WebApi.JobLeet.Core.Entities.Identity
{
    /// <summary>
    /// Represents the login information for a user, including external login providers.
    /// </summary>
    public class UserLogins
    {
        /// <summary>
        /// Gets or sets the name of the login provider (e.g., Google, Facebook).
        /// </summary>
        public string LoginProvider { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the provider (e.g., provider key).
        /// </summary>
        public string ProviderKey { get; set; }

        /// <summary>
        /// Gets or sets the display name for the login provider (e.g., the name displayed on the login UI).
        /// </summary>
        public string ProviderDisplayName { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the user associated with the login.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the user associated with the login information.
        /// </summary>
        public Users User { get; set; }
    }
}
