using LightLink.Models.Generic;
using System.Collections.Generic;

namespace LightLink.Profiles
{
    public class CompanyProfile
    {
        public User User { get; private set; }
        Dictionary<string, Device> devices = new Dictionary<string, Device>();
        public CompanyProfile(CompanyProfile profile)
        {
            devices = profile.devices;
        }

        public CompanyProfile(IEnumerable<Device> devices, User user)
        {
            foreach (var device in devices)
            {
                this.devices.Add(device.DeviceInfo.Model, device);
            }
            User = user;
        }
    }
}
