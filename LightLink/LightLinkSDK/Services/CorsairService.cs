using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CUE.NET;
using CUE.NET.Brushes;
using CUE.NET.Devices;
using CUE.NET.Devices.Generic.Enums;
using CUE.NET.Effects;
using CUE.NET.Groups;
using LightLinkSDK.Models;
using LightLinkSDK.Models.Generic;
using LightLinkSDK.Services.Generic;

namespace LightLinkSDK.Services
{
    public class CorsairService : IGenericColorService
    {
        #region Properties / Data Fields
        private static CorsairService service;
        private CorsairService()
        {
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
            Console.WriteLine(pathVar + "iCUE.exe");
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
            foreach (var device in CueSDK.InitializedDevices)
            {
                device.Brush = new SolidColorBrush(color);
            }
            CueSDK.UpdateMode = UpdateMode.Continuous;
        }

        public void ChangeMouseColor(CompanyColor color)
        {
            if (color is null) throw new Exception("Color can't be null");
            CueSDK.MouseSDK.Brush = new SolidColorBrush(color);
        }

        public void ChangeKeyboardColor(CompanyColor color)
        {
            if (color is null) throw new Exception("Color can't be null");
            CueSDK.KeyboardSDK.Brush = new SolidColorBrush(color);
        }

        public void ChangeHeadsetColor(CompanyColor color)
        {
            if (color is null) throw new Exception("Color can't be null");
            CueSDK.HeadsetSDK.Brush = new SolidColorBrush(color);
        }

        public void ChangeHeadsetStandColor(CompanyColor color)
        {
            if (color is null) throw new Exception("Color can't be null");
            CueSDK.HeadsetStandSDK.Brush = new SolidColorBrush(color);
        }

        public void ChangeMousematColor(CompanyColor color)
        {
            if (color is null) throw new Exception("Color can't be null");
            CueSDK.MousematSDK.Brush = new SolidColorBrush(color);
        }

        public IEnumerable<IDevice> GetInitializedDevices()
        {
            //return CueSDK.InitializedDevices;
            throw new NotImplementedException();
        }

        public String GetServiceName()
        {
            return "Corsair";
        }

        #endregion
    }
}
