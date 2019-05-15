using CUE.NET.Devices.Generic;
using LightLink.Converters;
using LightLink.Models.Colors;

namespace CorsairSDK
{
    public class CorsairColorConverter :  IColorConverter<CorsairColor>
    {
        public CompanyColor ConvertToCompanyColor(CorsairColor color)
        {
            return new CompanyColor(color.A, color.R, color.G, color.B);
        }

        public CorsairColor ConvertToGenericColor(CompanyColor color)
        {
            return new CorsairColor(color.A, color.R, color.G, color.B);
        }

    }
}
