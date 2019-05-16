using System;
using System.Collections.Generic;
using System.Text;
using LightLinkDLL.Models.EventHandlers;
using LightLinkModels;

namespace LightLinkDLL.DataAccess
{
    public interface IDataAccessService
    {
        Computer GetCurrentComputer();
        void UpdateData(Computer computer);
        EventHandler<EventUpdater> ChangeDetected();
    }
}
