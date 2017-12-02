using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Features.Summary.Events.Infrastructure
{
    /// <summary>
    /// Indicates if the event is a success or fail event.
    /// </summary>
    public enum EventTypes
    {
        /// <summary>
        /// Success event
        /// </summary>
        Success = 1,

        /// <summary>
        /// Failure event
        /// </summary>
        Failure = 2,

        /// <summary>
        /// Information event
        /// </summary>
        Information = 3,
        
        /// <summary>
        /// Error event
        /// </summary>
        Error = 4
    }
}
