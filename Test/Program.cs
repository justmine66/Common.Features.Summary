using System;
using Microsoft.Extensions.Primitives;
using System.Collections.Specialized;
using Newtonsoft.Json;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var values = Enumerable.Range(0, 10);

            var purge = values.Skip(1);

            Console.Read();
        }
    }
}
