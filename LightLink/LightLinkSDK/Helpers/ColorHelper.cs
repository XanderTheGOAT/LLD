using LightLinkSDK.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightLinkSDK.Helpers
{
    public class ColorHelper
    {
        #region Hex/Decimal Conversion

        /// <summary>
        /// Converts an int value to Hexadecimal
        /// </summary>
        /// <param name="number">The Number that will be converted to Hex</param>
        /// <returns>Hex value of the <param name="number"> passed in</returns>
        public static String ConvertIntToHex(int number)
        {
            return number.ToString("x");
        }

        /// <summary>
        /// Converts a Hex Number to an int
        /// </summary>
        /// <param name="hex">Hex value</param>
        /// <returns>The int of the <param name="hex"/> value</returns>
        public static int ConvertHexToInt(String hex)
        {
            if (IsStringHex(hex))
                return int.Parse(hex, NumberStyles.HexNumber);

            throw new FormatException("Hex number is too big for int or not a valid format");
        }

        /// <summary>
        /// Check if the string passed in is a valid Hexadecimal Number
        /// </summary>
        /// <param name="hex">Hexadecimal value that will be validated</param>
        /// <returns>If the String is a valid HexNumber</returns>
        public static bool IsStringHex(String hex)
        {
            int value = 0;
            return int.TryParse(hex, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out value);
        }

        #endregion

        #region Byte/Decimal Conversion
        /// <summary>
        /// Uses an int and turns it into RGB byte values
        /// </summary>
        /// <param name="number">The number being converted to byte[] RGB</param>
        /// <returns>byte[] of the RGB values in the RGB order byte[0] is equal to R</returns>
        public static byte[] ConvertIntToRGB(int number)
        {
            byte[] rgb = new byte[3];
            for (int i = 0; i < rgb.Length; i++)
            {
                rgb[(rgb.Length-1) - i] = (byte) (number >> 8 * i);
            }
            return rgb;
        }
        #endregion
    }
}
