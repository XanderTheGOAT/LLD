using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using CUE.NET;
using CUE.NET.Brushes;
using CUE.NET.Devices.Generic;
using CUE.NET.Devices.Generic.Enums;
using CUE.NET.Effects;
using LightLink.Models.Colors;
using LightLink.Models.Devices;
using LightLink.Models.Enums;
using LightLink.Services;

namespace CorsairSDK
{
    public class CorsairService : IRGBLightService
    {
        #region Properties / Data Fields
        private static CorsairService service;
        public CorsairService()
        {
            ///CueSDK.UpdateMode = UpdateMode.Continuous;
        }

        public static CorsairService Instance
        {
            get
            {
                if (service == null)
                    service = new CorsairService();
                return service;
            }
        }
        public Process process;
        public bool IsStarted { get; private set; }
        #endregion

        #region Methods
        [DllImport("User32.dll")]
        private static extern int ShowWindow(IntPtr ptr, int state);

        private void StartICUE()
        {
            Environment.SetEnvironmentVariable("ICUE_Path", "C:\\Program Files (x86)\\Corsair\\CORSAIR iCUE Software\\");
            RunICUE("ICUE_Path");
        }

        private void RunICUE(String path)
        {
            String pathVar = Environment.GetEnvironmentVariable(path);
            if (pathVar is null) throw new Exception("Environment Variable doesn't exist");

            if (File.Exists(pathVar + "iCUE.exe"))
            {
                process = Process.Start(pathVar + "iCUE.exe");
                while (process.MainWindowHandle == IntPtr.Zero)
                {
                    var cueProcesses = Process.GetProcessesByName("iCUE");
                    if (cueProcesses != null)
                        foreach (var cueProcess in cueProcesses)
                        {
                            process = cueProcess;
                        }
                }
                //Wait(5);
                //process.Refresh();
                var pointer = process.MainWindowHandle;
                ShowWindow(pointer, 0);
                Thread.Sleep(1800);
            }
        }
        public void Start()
        {
            if (IsStarted) throw new InvalidOperationException("One Instance already exists");
            IsStarted = true;
            StartICUE();
            CueSDK.Initialize(true);
        }
        public void Refresh()
        {
            CueSDK.ReinitializeDevices(true);
        }

        public void Restart()
        {
            CueSDK.Reinitialize();
        }

        public void Stop()
        {
            if (process == null) throw new Exception("Process hasn't been started");
            process.Kill();
        }

        public void AddEffect(IEffect effect, int ticks)
        {

        }

        public void ChangeAllColors(CompanyColor color)
        {
            if (color is null) throw new Exception("Color can't be null");
            CorsairColorConverter corsairColor = new CorsairColorConverter();
            foreach (var device in CueSDK.InitializedDevices)
            {
                device.Brush = new SolidColorBrush(new CorsairColor(corsairColor.ConvertToGenericColor(color)));
            }
            CueSDK.UpdateMode = UpdateMode.Continuous;
            Thread.Sleep(1000);
        }

        public void ChangeAllColors()
        {
            foreach (var device in CueSDK.InitializedDevices)
            {
                device.Brush = new RandomColorBrush();
            }
            CueSDK.UpdateMode = UpdateMode.Continuous;
            Thread.Sleep(10000);
        }

        public void ChangeMouseColor(CompanyColor color)
        {
            if (color is null) throw new Exception("Color can't be null");
            CueSDK.UpdateMode = UpdateMode.Continuous;
            CorsairColorConverter corsairColor = new CorsairColorConverter();
            CueSDK.MouseSDK.Brush = new SolidColorBrush(new CorsairColor(corsairColor.ConvertToGenericColor(color)));
            Thread.Sleep(10000);
        }

        public void ChangeKeyboardColor(CompanyColor color)
        {
            if (color is null) throw new Exception("Color can't be null");
            CueSDK.UpdateMode = UpdateMode.Continuous;
            CorsairColorConverter corsairColor = new CorsairColorConverter();
            CueSDK.KeyboardSDK.Brush = new SolidColorBrush(new CorsairColor(corsairColor.ConvertToGenericColor(color)));
            Thread.Sleep(1000);
        }

        public void ChangeHeadsetColor(CompanyColor color)
        {
            if (color is null) throw new Exception("Color can't be null");
            CueSDK.UpdateMode = UpdateMode.Continuous;
            CorsairColorConverter corsairColor = new CorsairColorConverter();
            CueSDK.HeadsetSDK.Brush = new SolidColorBrush(new CorsairColor(corsairColor.ConvertToGenericColor(color)));
            Thread.Sleep(1000);
        }

        public void ChangeHeadsetStandColor(CompanyColor color)
        {
            if (color is null) throw new Exception("Color can't be null");
            CueSDK.UpdateMode = UpdateMode.Continuous;
            CorsairColorConverter corsairColor = new CorsairColorConverter();
            CueSDK.HeadsetStandSDK.Brush = new SolidColorBrush(new CorsairColor(corsairColor.ConvertToGenericColor(color)));
            Thread.Sleep(1000);
        }

        public void ChangeMousematColor(CompanyColor color)
        {
            if (color is null) throw new Exception("Color can't be null");
            CueSDK.UpdateMode = UpdateMode.Continuous;
            CorsairColorConverter corsairColor = new CorsairColorConverter();
            CueSDK.MousematSDK.Brush = new SolidColorBrush(new CorsairColor(corsairColor.ConvertToGenericColor(color)));
            Thread.Sleep(1000);
        }

        public String GetServiceName()
        {
            return "Corsair";
        }

        public IEnumerable<IDeviceInfo> GetInitializedDevices()
        {
            List<IDeviceInfo> deviceInfos = new List<IDeviceInfo>();
            foreach (var device in CueSDK.InitializedDevices)
            {
                deviceInfos.Add(new LightLink.Models.Generic.GenericDeviceInfo(device.DeviceInfo.Model, (DeviceType)((int)device.DeviceInfo.Type),DeviceCaps.Lighting));
            }
            return deviceInfos;
        }
        #endregion
    }
}
