using System;
using System.Collections.Generic;
using System.Text;

namespace Test.WeakEventHanlderTest
{
    public class TodoEngine
    {
        public static TodoEngine Instance = new TodoEngine();

        public EventHandler<TodoEvent> Todo_changed;

        public void TiggerChange(int index)
        {
            if (Todo_changed != null)
            {
                Todo_changed(this, new TodoEvent(index) );
            }
        }
    }
}
