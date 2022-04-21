// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 04-01-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-01-2022
// ***********************************************************************
// <copyright file="MediatorCase.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using LegalManager.Models.Entities.Clients;
using LegalManager.Models.Entities.Documents;
using LegalManager.Models.Entities.Users;
using System;
using System.Collections.Generic;

namespace LegalManager.Models.Entities.Cases
{
    /// <summary>
    /// Entity class that provide the specifics of an mediation case, like multiple clients,
    /// and the ability to destroy all documents after the case is closed.
    /// @author Jeferson G.D. Schneider
    /// </summary>

    public class MediatorCase : Case {


        //Constructor (empty) for the  EF Core
        /// <summary>
        /// Initializes a new instance of the <see cref="MediatorCase"/> class.
        /// </summary>
        /// Empty constructor for EF Core
        public MediatorCase() {
        }


        //Attributes

        /// <summary>
        /// Gets or sets the clients.
        /// </summary>
        /// <value>The clients.</value>
        public List<Client> clients { get; set; }

        /// <summary>
        /// Gets or sets the total cost.
        /// </summary>
        /// <value>The total cost.</value>
        public double TotalCost { get; set; }


        //Methods


    }
}