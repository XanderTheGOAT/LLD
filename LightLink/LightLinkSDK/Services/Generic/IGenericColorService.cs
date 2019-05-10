using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightLinkSDK.Services.Generic
{
    public interface IGenericColorService : IColorService, IDeviceService, IStartable
    {
        /// <summary>
        /// Gets the name of the current service
        /// </summary>
        /// <returns>String of the service name. For Example: iCue</returns>
        String GetServiceName();
    }
}
