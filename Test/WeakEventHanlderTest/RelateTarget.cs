using System;
using System.Collections.Generic;
using System.Text;

namespace Test.WeakEventHanlderTest
{
    public class RelateTarget
    {
        public void TodoThing(object sender, TodoEvent e)
        {
            Console.WriteLine("TodoThing 已执行 {0}", e.CreatedTime.ToString("s"));
        }
    }
}
