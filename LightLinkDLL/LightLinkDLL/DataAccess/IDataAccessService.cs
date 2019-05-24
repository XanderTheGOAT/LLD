using System;
using System.Collections.Generic;
using System.Text;
using LightLinkDLL.Models.EventHandlers;
using LightLinkModels;

namespace LightLinkDLL.DataAccess
{
    public interface IDataAccessService
    {
        void UpdateData(Computer computer);
        IObservable<Profile> ProfileChanged { get; }
    }
}
