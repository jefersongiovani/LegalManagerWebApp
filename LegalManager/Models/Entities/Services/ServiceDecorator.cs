// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 03-18-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 03-22-2022
// ***********************************************************************
// <copyright file="ServiceDecorator.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegalManager.Models.Entities.Services
{
    /// <summary>
    /// @author Jeferson G.D. Schneider
    /// </summary>
    public abstract class ServiceDecorator : Service {

        //Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceDecorator"/> class.
        /// </summary>
        public ServiceDecorator() {
        }

        //Attributes
        /// <summary>
        /// Gets or sets the service.
        /// </summary>
        /// <value>The service.</value>
        public Service service
        {
            get;
            set; 
        }
    }
}