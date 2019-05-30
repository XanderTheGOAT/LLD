using System;
using System.Collections.Generic;

namespace LightLinkDLL.DataAccess
{
    public partial class PollingDataAccess
    {
        public sealed class Unsubscribe<T> : IDisposable
        {
            private IObserver<T> Observer { get; }
            private ICollection<IObserver<T>> Observers { get; }

            public Unsubscribe(IObserver<T> observer, ICollection<IObserver<T>> observers)
            {
                Observer = observer;
                Observers = observers;
                Observers.Add(Observer);
            }


            public void Dispose()
            {
                Observers.Remove(Observer);
            }
        }
    }
}
