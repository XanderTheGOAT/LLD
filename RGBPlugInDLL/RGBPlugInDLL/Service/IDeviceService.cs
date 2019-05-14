using RGBPlugInDLL.Models.Devices;
using System.Collections.Generic;

namespace RGBPlugInDLL.Services
{
    public interface IDeviceService
    {
        IEnumerable<IDeviceInfo> GetInitializedDevices();
    }
}
