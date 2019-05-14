using RGBPlugInDLL.Models.Enums;

namespace RGBPlugInDLL.Models.Devices
{
    public interface IDeviceInfo
    {
        DeviceType Type { get; }
        string Model { get; }
        DeviceCaps CapsMask { get; }
    }
}
