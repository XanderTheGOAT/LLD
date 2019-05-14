using LightLinkSDK.Models;
using LightLinkSDK.Models.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightLinkSDK.Profiles
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
