using LightLink.Models.Devices;
using LightLink.Models.Enums;

namespace LightLink.Models.Generic
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

        public GenericDeviceInfo(string model, DeviceType type, DeviceCaps caps)
        {
            Type = type;
            Model = model;
            CapsMask = caps;
        }
    }
}
