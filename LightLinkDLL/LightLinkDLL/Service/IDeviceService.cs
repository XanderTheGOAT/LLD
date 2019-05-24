using LightLink.Models.Devices;
using System.Collections.Generic;

namespace LightLink.Services
{
    public interface IDeviceService
    {
        /// <summary>
        /// Will refresh current devices with newly detected devices
        /// </summary>
        void Refresh();

        IEnumerable<IDeviceInfo> GetInitializedDevices();
    }
}
