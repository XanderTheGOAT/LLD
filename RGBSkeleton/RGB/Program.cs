using LightLink.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

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
            var services = new List<IGenericColorService>();
            var directoryInfo = new DirectoryInfo(".");
            var files = directoryInfo.GetFiles("*.dll");
            foreach (var file in files)
            {
                Assembly assembly = null;
                try
                {
                    assembly = Assembly.LoadFrom(file.FullName);
                    foreach (var type in assembly.GetTypes().Where(t => typeof(IGenericColorService).IsAssignableFrom(t) &&!t.IsInterface))
                    {
                        var service = type.GetConstructor(Array.Empty<Type>()).Invoke(Array.Empty<object>());
                        services.Add(service as IGenericColorService);
                    }
                }
                catch (BadImageFormatException e)
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
                //if (service.GetServiceName().Equals("Logitech"))
                //{
                //    service.Start();
                //    while (Console.ReadLine() != "n")
                //    {
                //        byte r = (byte)randySavage.Next(255);
                //        byte g = (byte)randySavage.Next(255);
                //        byte b = (byte)randySavage.Next(255);
                //        service.ChangeAllColors(new CompanyColor(r,g,b));
                //        Console.WriteLine("Changed");
                //    }
                //    service.Stop();
                //}
            }
        }

    }
}
