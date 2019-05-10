using CUE.NET.Devices;
using CUE.NET.Devices.Generic;
using LightLinkSDK.Models.Generic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightLinkSDK.Models.Generic
{
    public class Device
    {
        public Device()
        {}

        public Device(ICueDevice device)
        {
            DeviceInfo = new GenericDeviceInfo(device);
        }

        public GenericDeviceInfo DeviceInfo { get; }

        public static implicit operator Device(AbstractCueDevice device)
        {
            return new Device(device);
        }
    }
}
