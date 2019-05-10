using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LightLinkSDK;
using LightLinkSDK.Helpers;

namespace LightLinkDLLTester
{
    [TestClass]
    public class HelperTester
    {
        [TestMethod]
        public void ConvertsHexToProperInteger()
        {
            int expected = 4328875;
            int actual = 0;
            actual = ColorHelper.ConvertHexToInt("420DAB");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IntegerToHexProperly()
        {
            String expected = "420dab";
            String actual = "";

            actual = ColorHelper.ConvertIntToHex(4328875);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IntegerToRGB()
        {
            byte[] expected = new byte[] { 66, 13, 171 };
            byte[] actual = new byte[3];
            actual = ColorHelper.ConvertIntToRGB(4328875);
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
                Assert.AreEqual(expected[i], actual[i]);

        }
    }
}
