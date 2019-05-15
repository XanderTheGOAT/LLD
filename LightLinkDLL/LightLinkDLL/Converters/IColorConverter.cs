using LightLink.Models.Colors;

namespace LightLink.Converters
{
    /// <summary>
    /// Used to convert an object to a company color.
    /// </summary>
    /// <typeparam name="T">Will define what object will be converted from and to company color.</typeparam>
    public interface IColorConverter<Color>
    {
        /// <summary>
        /// Converts a <see cref="Color" /> to a <see cref="CompanyColor" />.
        /// </summary>
        /// <param name="color">The <see cref="Color"/> to convert.</param>
        CompanyColor ConvertToCompanyColor(Color color);
        
        /// <summary>
        /// Converts a <see cref="CompanyColor" /> to a <see cref="T" />.
        /// </summary>
        /// <param name="color">The <see cref="CompanyColor"/> to convert.</param>
        Color ConvertToGenericColor(CompanyColor color);

    }
}
