using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Common.Features.Summary.Infrastructure
{
    /// <summary>
    /// 弱应用事件处理类
    /// </summary>
    /// <typeparam name="TEventArgs"></typeparam>
    public class WeakEventHandler<TEventArgs> where TEventArgs : EventArgs
    {
        public WeakReference Reference { get; private set; }

        public MethodInfo Method { get; private set; }

        public EventHandler<TEventArgs> Handler { get; private set; }

        public WeakEventHandler(EventHandler<TEventArgs> eventHandler)
        {
            Reference = new WeakReference(eventHandler.Target);
            Method = eventHandler.Method;
            Handler = Invoke;
        }

        public void Invoke(object sender, TEventArgs e)
        {
            object target = Reference.Target;
            if (null != target)
            {
                Method.Invoke(target, new object[] { sender, e });
            }
        }

        public static implicit operator EventHandler<TEventArgs>(WeakEventHandler<TEventArgs> weakHandler)
        {
            return weakHandler.Handler;
        }
    }
}
