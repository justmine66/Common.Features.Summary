﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Features.Summary
{
    /// <summary>
    /// Provides access to the normal system clock with precision in seconds.
    /// </summary>
    public class SystemClock : ISystemClock
    {
        /// <summary>
        /// Retrieves the current system time in UTC.
        /// </summary>
        public DateTimeOffset UtcNow
        {
            get
            {
                // the clock measures whole seconds only, to have integral expires_in results, and
                // because milliseconds do not round-trip serialization formats
                var utcNowPrecisionSeconds = new DateTime((DateTime.UtcNow.Ticks / TimeSpan.TicksPerSecond) * TimeSpan.TicksPerSecond, DateTimeKind.Utc);
                return new DateTimeOffset(utcNowPrecisionSeconds);
            }
        }
    }
}
