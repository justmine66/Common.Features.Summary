using Common.Features.Summary.Data;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Common.Features.Summary.Random
{
    /// <summary>
    /// 随机生成器
    /// </summary>
    public class RandomGenerator
    {
        private static readonly RandomNumberGenerator CryptoRandom = RandomNumberGenerator.Create();

        /// <summary>
        /// 生成一个随机字符串
        /// </summary>
        /// <returns></returns>
        public static string RandomString()
        {
            var bytes = new byte[32];
            CryptoRandom.GetBytes(bytes);
            var correlationId = Base64UrlTextEncoder.Encode(bytes);
            return correlationId;
        }
    }
}
