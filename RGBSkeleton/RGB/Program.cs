using LightLink.Models.Colors;
using LightLink.Services;
using LightLinkDLL.DataAccess;
using LightLinkDLL.DataAccess.Data_Source;
using LightLinkModels;
using LightLinkSDK.Services;
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

        private static IDataSource dataSource = null;

        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter a hex rgb value");
                var RGB = Console.ReadLine();
                var service = new LightLinkService();
                service.ChangeMouseColor(new CompanyColor(RGB));
                Console.Clear();
            }
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
            bool authorized = false;
            do
            {
                Console.Write("Username: ");
                string username = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();
                try
                {
                    dataSource = new HttpDataSource("http://69.27.22.253/api/", new UserLogin(username, password));
                    authorized = true;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Incorrect Username or Password");
                }
            } while (!authorized);
            PollingDataAccess dataAccess = null;
            dataAccess = new PollingDataAccess(1_500, dataSource);
            var computer = new Computer
            {
                Name = $"{Environment.MachineName}:{GetFirstNetworkCard()?.GetPhysicalAddress()?.ToString()}"
            };
            var service = new LightLinkService();
            service.Start();
            service.ChangeMouseColor(new CompanyColor("ffffffff"));
            dataAccess.ProfileChanged.Subscribe(new ColorUpdatingObserver(service));
            AddDevicesToComputer(service, computer);
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

            var directoryInfo = new DirectoryInfo("../../SDKs/.");
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


        private static string HiddenEntry()
        {
            var key = ConsoleKey.A;
            String word = "";
            do
            {
                var info = Console.ReadKey(true);
                key = info.Key;
                if (key == ConsoleKey.Backspace && word.Length > 0)
                {
                    Console.Write("\b \b");
                    word = word.Substring(0, word.Length - 1);
                }
                else if (key != ConsoleKey.Enter)
                {
                    Console.Write("*");
                    word += key.ToString();
                }
            } while (key != ConsoleKey.Enter);
            return word;
        }
    }
}
