using LightLinkSDK.Models;
using LightLinkSDK.Models.Generic;
using LightLinkSDK.Services;
using LightLinkSDK.Services.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LightLinkDLLTester
{
    [TestClass]
    public class CorsairTester
    {
        static IGenericColorService service = CorsairService.Instance;

        [AssemblyInitialize]
        public static void Initialize(TestContext context)
        {
            service.Start();
        }

        [TestMethod]
        public void ChangeColors()
        {
            Random r = new Random();
            IGenericColorService lService = new LogitechService();
            lService.Start();
            lService.ChangeAllColors(new CompanyColor(0, 255, 0));
            service.ChangeAllColors();
            Thread.Sleep(2000);
            while (true)
            {
                byte red = (byte)(r.Next(150) + 105);
                byte green = (byte)(r.Next(150) + 1);
                byte blue = (byte)(r.Next(150) + 1);

                lService.ChangeAllColors(new CompanyColor(red, green, blue));
                service.ChangeAllColors(new CompanyColor(red, green, blue));
                Thread.Sleep(2000);
                red = (byte)(r.Next(150) + 1);
                green = (byte)(r.Next(150) + 105);
                blue = (byte)(r.Next(150) + 1);
                lService.ChangeAllColors(new CompanyColor(red, green, blue));
                service.ChangeAllColors(new CompanyColor(red, green, blue));
                Thread.Sleep(2000);
                red = (byte)(r.Next(150) + 1);
                green = (byte)(r.Next(150) + 1);
                blue = (byte)(r.Next(150) + 105);
                lService.ChangeAllColors(new CompanyColor(red, green, blue));
                service.ChangeAllColors(new CompanyColor(red, green, blue));
                Thread.Sleep(2000);
            }
            lService.Stop();
        }

        [AssemblyCleanup]
        public static void CleanUp()
        {
            service.Stop();
        }
    }
}
