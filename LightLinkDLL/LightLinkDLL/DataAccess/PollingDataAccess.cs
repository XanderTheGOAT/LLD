using System;
using System.Collections.Generic;
using System.Text;
using LightLinkModels;

namespace LightLinkDLL.DataAccess
{
    public partial class PollingDataAccess : IDataAccessService
    {
        public IObservable<Profile> ProfileChanged { get; }
        public IDataSource Source { get; }

        public PollingDataAccess(double interval, IDataSource source)
        {
            if (source is null) throw new ArgumentNullException("source cannot be null.");
            ProfileChanged = new PollingObservable(interval, source);
            Source = source;
        }

        public void UpdateData(Computer computer)
        {
            Source.UpdateData(computer);
        }
    }
}
