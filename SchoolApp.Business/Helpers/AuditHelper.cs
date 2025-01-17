// <copyright file="AuditHelper.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

namespace SchoolApp.Business.Helpers
{
    using SchoolApp.Data.Models;

    /// <summary>
    /// The audit helper.
    /// </summary>
    public static class AuditHelper
    {
        /// <summary>
        /// Set audit properties.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="user">The user.</param>
        public static void SetAuditProperties(Audit entity, string user)
        {
            var currentTime = DateTime.UtcNow;

            // Check if the entity is newly created
            if (entity.CreatedDate == default(DateTime))
            {
                entity.CreatedDate = currentTime;
                entity.CreatedBy = user;
            }

            // Update audit properties for updates
            entity.UpdatedDate = currentTime;
            entity.UpdatedBy = user;
        }
    }
}
