using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUE.NET.Devices;
using CUE.NET.Devices.Generic.Enums;
using LightLinkSDK.Models.Generic.Enums;

namespace LightLinkSDK.Models.Generic
{
    public class GenericDeviceInfo : IDevice
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

        public GenericDeviceInfo(IDevice device)
        {
            Type = device.Type;
            Model = device.Model;
            CapsMask = device.CapsMask;
        }
        public GenericDeviceInfo(ICueDevice device)
        {
            Type = (DeviceType)device.DeviceInfo.Type;
            Model = device.DeviceInfo.Model;
            CapsMask = (DeviceCaps)device.DeviceInfo.CapsMask;
        }
    }
}
