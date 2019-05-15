using CorsairSDK;
using LightLink.Models.Colors;
using LightLink.Services;
using System;
using LogitechSDK;
using System.Threading;
using System.Drawing;

namespace RGB
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            FindAllServices();
        }

        public static void FindAllServices()
        {
            IGenericColorService service = new LogitechService();
            service.Start();

            service.ChangeAllColors(new CompanyColor(Color.Orange.R, Color.Orange.G, Color.Orange.B));
            Thread.Sleep(1000);
            service.Stop();
        }

    }
}
