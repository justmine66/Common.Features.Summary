using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Features.Summary.Events.Infrastructure
{
    public static class EventIds
    {
        //////////////////////////////////////////////////////
        /// Error related events
        //////////////////////////////////////////////////////
        private const int ErrorEventsStart = 3000;

        public const int UnhandledException = ErrorEventsStart + 0;
    }
}
