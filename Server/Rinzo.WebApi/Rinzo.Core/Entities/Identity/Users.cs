namespace JobLeet.WebApi.JobLeet.Core.Entities.Identity
{
    /// <summary>
    /// Represents a user in the system.
    /// </summary>
    public class Users
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the normalized username of the user, typically used for lookups and comparisons.
        /// </summary>
        public string NormalizedUserName { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the normalized email address of the user, typically used for lookups and comparisons.
        /// </summary>
        public string NormalizedEmail { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user's email address has been confirmed.
        /// </summary>
        public bool EmailConfirmed { get; set; }

        /// <summary>
        /// Gets or sets the hashed password of the user.
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets a unique identifier used to identify the user's security-related data.
        /// </summary>
        public string SecurityStamp { get; set; }

        /// <summary>
        /// Gets or sets a unique identifier used for concurrency checks to detect conflicting updates.
        /// </summary>
        public string ConcurrencyStamp { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the user.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user's phone number has been confirmed.
        /// </summary>
        public bool PhoneNumberConfirmed { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether two-factor authentication is enabled for the user.
        /// </summary>
        public bool TwoFactorEnabled { get; set; }

        /// <summary>
        /// Gets or sets the end date and time of the user's lockout period, if any.
        /// </summary>
        public DateTimeOffset? LockoutEnd { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user can be locked out.
        /// </summary>
        public bool LockoutEnabled { get; set; }

        /// <summary>
        /// Gets or sets the number of failed login attempts for the user.
        /// </summary>
        public int AccessFailedCount { get; set; }

        /// <summary>
        /// Gets or sets the collection of claims associated with the user.
        /// </summary>
        public ICollection<UserClaims> Claims { get; set; }

        /// <summary>
        /// Gets or sets the collection of login information associated with the user.
        /// </summary>
        public ICollection<UserLogins> Logins { get; set; }

        /// <summary>
        /// Gets or sets the collection of roles associated with the user.
        /// </summary>
        public ICollection<UserRoles> UserRoles { get; set; }

        /// <summary>
        /// Gets or sets the collection of tokens associated with the user.
        /// </summary>
        public ICollection<UserTokens> Tokens { get; set; }
    }
}
