using System;
using System.Collections.Generic;
using System.Text;

namespace Test.WeakEventHanlderTest
{
    public class TodoEvent : EventArgs
    {
        public int Index { get; private set; }
        public DateTimeOffset CreatedTime { get; private set; } = DateTimeOffset.Now;

        public TodoEvent(int index)
        {
            this.Index = index;
        }
    }
}
