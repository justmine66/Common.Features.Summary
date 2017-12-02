using Common.Features.Summary.Events.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Features.Summary.Events
{
    /// <summary>
    /// Event for unhandled exceptions
    /// </summary>
    /// <seealso cref="IdentityServer4.Events.Event" />
    public class UnhandledExceptionEvent : Event
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnhandledExceptionEvent"/> class.
        /// </summary>
        /// <param name="ex">The ex.</param>
        public UnhandledExceptionEvent(Exception ex)
            : base(EventCategories.Error,
                  "Unhandled Exception",
                  EventTypes.Error,
                  EventIds.UnhandledException,
                  ex.Message)
        {
            Details = ex.ToString();
        }

        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        /// <value>
        /// The details.
        /// </value>
        public string Details { get; set; }
    }
}
