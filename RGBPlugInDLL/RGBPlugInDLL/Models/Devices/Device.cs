using RGBPlugInDLL.Models.Colors;

namespace LightLink.Models.Generic
{
    /// <summary>
    /// Represents a generic Device. (Keyboard, Mouse, etc...)
    /// </summary>
    public abstract class Device : IDevice
    {
        public Device()
        {}
        
        public CompanyColor Color { get; set; }
        public bool IsActive { get; set; }
        public GenericDeviceInfo DeviceInfo { get; }
    }
}
