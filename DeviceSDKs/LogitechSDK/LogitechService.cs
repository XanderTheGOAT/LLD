using LedCSharp;
using LightLink.Models.Colors;
using LightLink.Models.Devices;
using LightLink.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace LogitechSDK
{
    public class LogitechService : IGenericColorService
    {
        public Process process;
        public bool IsStarted { get; private set; }

        public LogitechService()
        {

        }

        public void ChangeAllColors(CompanyColor color)
        {
            int r = (int)(((float)color.R / 255) * 100);
            int g = (int)(((float)color.G / 255) * 100);
            int b = (int)(((float)color.B / 255) * 100);
            LogitechGSDK.LogiLedSetLighting(r, g, b);
        }

        [DllImport("User32.dll")]
        private static extern int ShowWindow(IntPtr ptr, int state);

        private void StartLogitech()
        {
            Environment.SetEnvironmentVariable("LCore_Path", "C:\\Program Files\\Logitech Gaming Software\\");
            RunLogitech("LCore_Path");
        }

        private void RunLogitech(String path)
        {
            String pathVar = Environment.GetEnvironmentVariable(path);
            if (pathVar is null) throw new Exception("Environment Variable doesn't exist");

            if (File.Exists(pathVar + "LCore.exe"))
            {
                process = Process.Start(pathVar + "LCore.exe");
                while (process.MainWindowHandle == IntPtr.Zero)
                {
                    var cueProcesses = Process.GetProcessesByName("Logitech Gaming Software");
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
            throw new NotImplementedException();
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
            return "Logitech";
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
            StartLogitech();
            LogitechGSDK.LogiLedInit();
        }

        public void Stop()
        {
            process.Kill();
        }
    }
}
