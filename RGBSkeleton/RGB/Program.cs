using LightLink.Models.Colors;
using LightLink.Services;
using System;
using System.Threading;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Linq;

namespace RGB
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            PrintAllThings();

        }

        public static IEnumerable<IGenericColorService> FindAllServices()
        {
            List<IGenericColorService> services = new List<IGenericColorService>();
            var currentDir = Directory.GetCurrentDirectory() + "\\";
            var directoryInfo = new DirectoryInfo(currentDir);
            var files = directoryInfo.GetFiles("*.dll");
            foreach (var file in files)
            {
                Assembly assembly = null;
                try
                {
                    assembly = Assembly.LoadFrom(currentDir + file.Name);
                }
                catch (BadImageFormatException) { }
                if (assembly != null)
                    foreach (var type in assembly.ExportedTypes.Where(t => t.GetInterfaces().Contains(typeof(IGenericColorService)) && !t.IsInterface))
                    {
                        var c = type.GetConstructors(BindingFlags.NonPublic);
                        var service = type.GetConstructors()[0].Invoke(null);
                        services.Add(service as IGenericColorService);
                    }
            }
            return services;
        }

        private static void PrintAllThings()
        {
            var services = FindAllServices();
            Random randySavage = new Random();
            foreach (var service in services)
            {
                if (service.GetServiceName().Equals("Logitech"))
                {
                    service.Start();
                    Console.WriteLine(service.GetServiceName());
                    while (Console.ReadLine() != "n")
                    {
                        byte r = (byte)randySavage.Next(255);
                        byte g = (byte)randySavage.Next(255);
                        byte b = (byte)randySavage.Next(255);
                        service.ChangeAllColors(new CompanyColor(r,g,b));
                        Console.WriteLine("Changed");
                    }
                    service.Stop();
                }
            }
        }

    }
}
