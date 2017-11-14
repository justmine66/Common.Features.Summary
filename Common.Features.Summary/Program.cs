using Common.Features.Summary.Random;
using System;

namespace Common.Features.Summary
{
    class Program
    {
        static void Main(string[] args)
        {
            //RandomUtils.RandomString();
            Console.WriteLine(new SystemClock().UtcNow);

            Console.Read();
        }
    }
}