using LightLink.Models.Enums;

namespace LightLink.Models.Devices
{
    public interface IDeviceInfo
    {
        DeviceType Type { get; }
        string Model { get; }
        DeviceCaps CapsMask { get; }
    }
}
