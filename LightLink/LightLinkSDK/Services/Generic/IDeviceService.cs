using LightLinkSDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightLinkSDK.Services.Generic
{
    public interface IDeviceService
    {
        IEnumerable<IDevice> GetInitializedDevices(); 
    }
}
