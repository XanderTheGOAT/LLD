using System.Collections.Generic;

namespace LightLink.Services
{
    public interface IDeviceService
    {
        IEnumerable<IDeviceInfo> GetInitializedDevices();
    }
}
