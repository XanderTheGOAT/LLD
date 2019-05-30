using System;
using System.Collections.Generic;
using System.Timers;
using LightLinkModels;
using static LightLinkDLL.DataAccess.PollingDataAccess;

namespace LightLinkDLL.DataAccess
{
    internal class PollingObservable : IObservable<Profile>
    {
        private readonly ICollection<IObserver<Profile>> observers;
        public Timer Timer { get; }
        public PollingObservable(double interval, IDataSource source)
        {

            if (source is null) throw new ArgumentNullException("source cannot be null.");
            Timer = new Timer
            {
                Interval = interval
            };
            Timer.Elapsed += (s, e) => NotifySubscribers(source.GetProfile());
            Timer.Start();
            observers = new List<IObserver<Profile>>();
        }
        private void NotifySubscribers(Profile data)
        {

            foreach (var observer in observers)
            {
                observer.OnNext(data);
            }
        }
        public IDisposable Subscribe(IObserver<Profile> observer)
        {
            if (observer is null) throw new ArgumentNullException("observer cannot be null.");
            return new Unsubscribe<Profile>(observer, observers);
        }


    }
}