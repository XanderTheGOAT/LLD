using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightLink.Models.Colors;
using LightLink.Models.Devices;
using LightLink.Models.Enums;
using LightLink.Services;
using RGBLibrary;
using RGBLibrary.Models;

namespace LightLinkSDK.Services
{
    public class LightLinkService : IRGBLightService
    {
        public void ChangeAllColors(CompanyColor color)
        {
            throw new NotImplementedException();
        }

        public void ChangeAllColors()
        {
            throw new NotImplementedException();
        }

        public void ChangeHeadsetColor(CompanyColor color)
        {
            throw new NotImplementedException();
        }

        public void ChangeHeadsetStandColor(CompanyColor color)
        {
            throw new NotImplementedException();
        }

        public void ChangeKeyboardColor(CompanyColor color)
        {
            throw new NotImplementedException();
        }

        public void ChangeMouseColor(CompanyColor color)
        {
            Device mouse = new Device("1b1c", "1b2e");
            int currentZone = 1;
            Command command = new Command();
            command.AddCommand("7");
            command.AddCommand("22");
            command.AddCommand("" + currentZone);
            command.AddCommand("1");
            command.AddCommand("0");
            command.AddCommand(color.R);
            command.AddCommand(color.G);
            command.AddCommand(color.B);
            mouse.RequestToSendFeatureReport(command.CommandList.ToArray());
        }

        public void ChangeMousematColor(CompanyColor color)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IDeviceInfo> GetInitializedDevices()
        {
            List<IDeviceInfo> deviceInfos = new List<IDeviceInfo>();
            deviceInfos.Add(new LightLink.Models.Generic.GenericDeviceInfo("M65 RGB PRO", DeviceType.Mouse, DeviceCaps.Lighting));
            return deviceInfos;
        }

        public string GetServiceName()
        {
            throw new NotImplementedException();
        }

        public void Refresh()
        {
            throw new NotImplementedException();
        }

        public void Restart()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
