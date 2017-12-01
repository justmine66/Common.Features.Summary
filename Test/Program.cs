using System;
using Microsoft.Extensions.Primitives;
using System.Collections.Specialized;
using Newtonsoft.Json;
using System.Linq;
using Common.Features.Summary.Infrastructure;
using Test.WeakEventHanlderTest;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var relate = new RelateTarget();
            TodoEngine.Instance.Todo_changed += new WeakEventHandler<TodoEvent>(relate.TodoThing);

            for (int i = 0; i < 10; i++)
            {
                TodoEngine.Instance.TiggerChange(i);
            }

            Console.Read();
        }
    }
}
