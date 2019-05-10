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
        static IGenericColorService service = new CorsairService();

        [AssemblyInitialize]
        public static void Initialize(TestContext context)
        {
            service.Start();
        }

        [TestMethod]
        public void ChangeColors()
        {
            service.ChangeAllColors(new CompanyColor("00ff00"));
            Thread.Sleep(100);
        }

        [TestMethod]
        public void Creating_Two_CorsairServices_Throws_InvalidOperationException()
        {
            Assert.ThrowsException<InvalidOperationException>(() => new CorsairService());
        }

        [AssemblyCleanup]
        public static void CleanUp()
        {
            service.Stop();
            service.Dispose();
        }
    }
}
