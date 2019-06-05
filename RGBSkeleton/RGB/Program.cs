using LightLink.Models.Colors;
using LightLink.Services;
using LightLinkDLL.DataAccess;
using LightLinkDLL.DataAccess.Data_Source;
using LightLinkModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;

namespace RGB
{
    internal class Program
    {

        private static IDataSource dataSource = new HttpDataSource("https://localhost:44332/api/", new UserLogin("gxldcptrick", "Not A Secure Password"));

        public static void Main(string[] args)
        {
            InitializeApp();
            do
            {
                Console.WriteLine("Press N To Exit...");
            }
            while (Console.ReadKey().Key != ConsoleKey.N);
            dataSource.Dispose();
        }

        private static void InitializeApp()
        {
            PollingDataAccess dataAccess = null;
            dataAccess = new PollingDataAccess(1_500, dataSource);
            dataAccess.ProfileChanged.Subscribe(new LoggingObserver());
            var computer = new Computer
            {
                Name = $"{Environment.MachineName}:{GetFirstNetworkCard()?.GetPhysicalAddress()?.ToString()}"
            };
            var services = FindAllServices();
            foreach (var service in services)
            {
                service.Start();
                dataAccess.ProfileChanged.Subscribe(new ColorUpdatingObserver(service));
                AddDevicesToComputer(service, computer);
            }
            dataAccess.UpdateData(computer);
        }

        private static NetworkInterface GetFirstNetworkCard()
        {
            return NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault();
        }

        private static void AddDevicesToComputer(IRGBLightService service, Computer computer)
        {
            foreach (var device in service.GetInitializedDevices())
            {
                computer.ConnectedDevices.Add(device.Type.ToString() + ": " + device.Model);
            }
        }

        public static IEnumerable<IRGBLightService> FindAllServices()
        {
            var services = new List<IRGBLightService>();
            var directoryInfo = new DirectoryInfo(".");
            var files = directoryInfo.GetFiles("*.dll");
            foreach (var file in files)
            {
                Assembly assembly = null;
                try
                {
                    assembly = Assembly.LoadFrom(file.FullName);
                    foreach (var type in assembly.GetTypes().Where(t => typeof(IRGBLightService).IsAssignableFrom(t) && !t.IsInterface))
                    {
                        var service = type.GetConstructor(Array.Empty<Type>()).Invoke(Array.Empty<object>());
                        services.Add(service as IRGBLightService);
                    }
                }
                catch (BadImageFormatException e)
                {
                    Console.WriteLine(e);
                }
                catch (ReflectionTypeLoadException e)
                {
                    Console.WriteLine(e);
                }
            }
            return services;
        }

        private static void PrintAllThings()
        {
            var services = FindAllServices();
            var randySavage = new Random();
            foreach (var service in services.Where(s => s.GetServiceName() == "Logitech"))
            {
                Console.WriteLine(service.GetServiceName());
                if (service.GetServiceName().Equals("Logitech"))
                {
                    service.Start();
                    while (Console.ReadLine() != "n")
                    {
                        byte r = (byte)randySavage.Next(255);
                        byte g = (byte)randySavage.Next(255);
                        byte b = (byte)randySavage.Next(255);
                        service.ChangeAllColors(new CompanyColor(r, g, b));
                        Console.WriteLine("Changed");
                    }
                    service.Stop();
                }
            }
        }

    }
}
