using RGBPlugInDLL.Models.Devices;
using RGBPlugInDLL.Models.Enums;

namespace LightLinkSDK.Models.Generic
{
    public class GenericDeviceInfo : IDeviceInfo
    {
        /// <summary>
        /// Gets the device type. (<see cref="DeviceType" />)
        /// </summary>
        public DeviceType Type { get; }

        /// <summary>
        /// Gets the device model (like “K95RGB”).
        /// </summary>
        public string Model { get; }

        /// <summary>
        /// Get a flag that describes device capabilities. (<see cref="DeviceCaps" />)
        /// </summary>
        public DeviceCaps CapsMask { get; }

        public GenericDeviceInfo(IDeviceInfo device)
        {
            Type = device.Type;
            Model = device.Model;
            CapsMask = device.CapsMask;
        }
    }
}
