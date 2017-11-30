using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Common.Features.Summary.Extensions
{
    /// <summary>
    /// 时间扩展
    /// </summary>
    internal static class DateTimeExtensions
    {
        /// <summary>
        /// 是否超过指定时间
        /// </summary>
        /// <param name="creationTime">源时间</param>
        /// <param name="seconds">指定秒</param>
        /// <param name="now">比较时间</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static bool HasExceeded(this DateTime creationTime, int seconds, DateTime now)
        {
            return (now > creationTime.AddSeconds(seconds));
        }

        /// <summary>
        /// 获取生命周期（单位：秒）
        /// </summary>
        /// <param name="creationTime"></param>
        /// <param name="now"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static int GetLifetimeInSeconds(this DateTime creationTime, DateTime now)
        {
            return ((int)(now - creationTime).TotalSeconds);
        }

        /// <summary>
        /// 是否过期
        /// </summary>
        /// <param name="expirationTime"></param>
        /// <param name="now"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static bool HasExpired(this DateTime? expirationTime, DateTime now)
        {
            if (expirationTime.HasValue &&
                expirationTime.Value.HasExpired(now))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 是否过期
        /// </summary>
        /// <param name="expirationTime"></param>
        /// <param name="now"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static bool HasExpired(this DateTime expirationTime, DateTime now)
        {
            if (now > expirationTime)
            {
                return true;
            }

            return false;
        }
    }
}
