﻿using Neon.Entities.Implementation.Shared;
using Newtonsoft.Json;

namespace Neon.Entities {
    /// <summary>
    /// Used for creating IEntity instances that have a set of data values already initialized.
    /// </summary>
    /// <remarks>
    /// For example, a generic Orc type will have an ITemplate that defines an Orc. Spawning code
    /// will then receive the Orc ITemplate, and when it comes time to spawn it will instantiate an
    /// entity from the template, and that entity will be a derivative instance of the original Orc.
    /// </remarks>

    [JsonConverter(typeof(TemplateConverter))]
    public interface ITemplate : IQueryableEntity {
        /// <summary>
        /// Each IEntityTemplate can be uniquely identified by its TemplateId.
        /// </summary>
        int TemplateId {
            get;
        }

        /// <summary>
        /// Creates a new IEntity instance.
        /// </summary>
        IEntity InstantiateEntity();

        /// <summary>
        /// Adds a default data instance to the template. The template "owns" the passed data
        /// instance; a copy is not made of it.
        /// </summary>
        /// <remarks>
        /// If the ITemplate is currently being backed by an IGameEngine, this will throw an
        /// InvalidOperationException.
        /// </remarks>
        /// <param name="data">The data instance to copy from.</param>
        void AddDefaultData(IData data);

        /// <summary>
        /// Remove the given type of data from the template instance. New instances will not longer
        /// have this added to the template.
        /// </summary>
        /// <remarks>
        /// If the ITemplate is currently being backed by an IGameEngine, this will throw an
        /// InvalidOperationException.
        /// </remarks>
        /// <param name="accessor">The type of data to remove.</param>
        /// <returns>True if the data was removed.</returns>
        bool RemoveDefaultData(DataAccessor accessor);
    }
}