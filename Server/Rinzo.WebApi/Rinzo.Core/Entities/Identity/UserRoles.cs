namespace JobLeet.WebApi.JobLeet.Core.Entities.Identity
{
    /// <summary>
    /// Represents the association between a user and a role.
    /// </summary>
    public class UserRoles
    {
        /// <summary>
        /// Gets or sets the unique identifier of the user associated with the role.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the role associated with the user.
        /// </summary>
        public string RoleId { get; set; }

        /// <summary>
        /// Gets or sets the user associated with the role.
        /// </summary>
        public Users User { get; set; }

        /// <summary>
        /// Gets or sets the role associated with the user.
        /// </summary>
        public Roles Role { get; set; }
    }
}
