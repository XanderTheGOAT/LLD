using RGBPlugInDLL.Extensions;
using System.Diagnostics;

namespace LightLink.Models.Colors
{
    [DebuggerDisplay("[A: {A}, R: {R}, G: {G}, B: {B}, ARGB: {ARGB}]")]
    public class CompanyColor
    {
        #region Proprties and Fields

        /// <summary>
        /// Alpha Red Green Blue Values Added together
        /// </summary>
        public int ARGB => A + R + G + B;

        /// <summary>
        /// Red Green Blue Values Added together
        /// </summary>
        public int RGB => R + G + B;

        /// <summary>
        /// Alpha byte value
        /// </summary>
        public byte A { get; set; }

        /// <summary>
        /// Red byte value
        /// </summary>
        public byte R { get; set; }
        /// <summary>
        /// Green byte value
        /// </summary>
        public byte G { get; set; }

        /// <summary>
        /// Blue byte value
        /// </summary>
        public byte B { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Saves the RGB values from one CompanyColor to another
        /// </summary>
        /// <param name="color"></param>
        public CompanyColor(CompanyColor color)
        {
            A = color.A;
            R = color.R;
            G = color.G;
            B = color.B;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyColor"/> class using only Hex-Values.
        /// Converts Hex to byte[] for RGB.
        /// </summary>
        /// <param name="hex">The hex value of a RGB color of this <see cref="CompanyColor"/>.</param>
        public CompanyColor(string hex)
        {
            byte[] rgb = hex.ConvertHexToInt().ConvertIntToRGB();
            A = 255;
            R = rgb[0];
            G = rgb[1];
            B = rgb[2];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyColor"/> class using only RGB-Values. 
        /// Alpha defaults to 255.
        /// </summary>
        /// <param name="a">The alpha component value of this <see cref="CompanyColor"/>.</param>
        /// <param name="r">The red component value of this <see cref="CompanyColor"/>.</param>
        /// <param name="g">The green component value of this <see cref="CompanyColor"/>.</param>
        /// <param name="b">The blue component value of this <see cref="CompanyColor"/>.</param>
        public CompanyColor(byte a, byte r, byte g, byte b)
        {
            A = a;
            R = r;
            G = g;
            B = b;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyColor"/> class using ARGB-Values. 
        /// </summary>
        /// <param name="r">The red component value of this <see cref="CompanyColor"/>.</param>
        /// <param name="g">The green component value of this <see cref="CompanyColor"/>.</param>
        /// <param name="b">The blue component value of this <see cref="CompanyColor"/>.</param>
        public CompanyColor(byte r, byte g, byte b) : this(255, r, g, b)
        { }
        #endregion

        #region Operators
        /// <summary>
        /// Converts the individual byte-values of this <see cref="CompanyColor"/> to a human-readable string.
        /// </summary>
        /// <returns>A string that contains the individual byte-values and int value of this <see cref="CompanyColor"/>. For example "[A: 255, R: 255, G: 0, B: 0]".</returns>
        public override string ToString()
        {
            return $"[A: {A}, R: {R}, G: {G}, B: {B}, ARGB: {ARGB}]";
        }
        #endregion
    }
}