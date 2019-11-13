using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightLink.Models.Colors;
using LightLink.Models.Devices;
using LightLink.Services;
using RGBLibrary;
using RGBLibrary.Models;

namespace LightLinkSDK.Services
{
    class LightLinkService : IRGBLightService
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
            Command command = new Command();
            command.AddCommand("7");
            command.AddCommand("22");
            command.AddCommand("34");
            command.AddCommand("1");
            mouse.RequestToSendFeatureReport(command.CommandList.ToArray());
        }

        public void ChangeMousematColor(CompanyColor color)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IDeviceInfo> GetInitializedDevices()
        {
            throw new NotImplementedException();
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
