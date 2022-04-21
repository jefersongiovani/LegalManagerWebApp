using System;

namespace LegalManager.Models
{
    /// <summary>
    /// Class ApplicationUserViewModel.
    /// 
    /// This class is used as a view model to update some attributes of the users.
    /// 
    /// 
    /// <author>Jeferson Giovani D. Schneider</author>
    /// </summary>
    public class ApplicationUserViewModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>The start date.</value>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [user status].
        /// </summary>
        /// <value><c>true</c> if [user status]; otherwise, <c>false</c>.</value>
        public bool UserStatus { get; set; }

        /// <summary>
        /// Gets or sets the personal email.
        /// </summary>
        /// <value>The personal email.</value>
        public string PersonalEmail { get; set; }
        /// <summary>
        /// Gets or sets the digital sign identifier.
        /// </summary>
        /// <value>The digital sign identifier.</value>
        public int DigitalSignId { get; set; }
    }
}
