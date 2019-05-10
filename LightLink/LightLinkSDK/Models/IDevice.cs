using LightLinkSDK.Models.Generic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightLinkSDK.Models
{
    public interface IDevice
    {
        DeviceType Type { get; }
        string Model { get; }
        DeviceCaps CapsMask {get; }
    }
}
