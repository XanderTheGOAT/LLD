using RGBPlugInDLL.Models.Colors;

namespace RGBPlugInDLL.Services
{
    public interface IColorService
    {
        /// <summary>
        /// Will refresh current devices with newly detected devices
        /// </summary>
        void Refresh();

        /// <summary>
        /// Will change All Initialized Device Brush to the passed in color
        /// </summary>
        /// <param name="color"></param>
        void ChangeAllColors(CompanyColor color);
        /// <summary>
        /// Will change All Initialized Device Brush to a random color
        /// </summary>
        void ChangeAllColors();
        /// <summary>
        /// Will change Mouse Brush to the passed in color
        /// </summary>
        /// <param name="color"></param>
        void ChangeMouseColor(CompanyColor color);
        /// <summary>
        /// Will change Mousemat Brush to the passed in color
        /// </summary>
        /// <param name="color"></param>
        void ChangeMousematColor(CompanyColor color);
        /// <summary>
        /// Will change Keyboard Brush to the passed in color
        /// </summary>
        /// <param name="color"></param>
        void ChangeKeyboardColor(CompanyColor color);
        /// <summary>
        /// Will change Headset Brush to the passed in color
        /// </summary>
        /// <param name="color"></param>
        void ChangeHeadsetColor(CompanyColor color);
        /// <summary>
        /// Will change HeadsetStand Brush to the passed in color
        /// </summary>
        /// <param name="color"></param>
        void ChangeHeadsetStandColor(CompanyColor color);
    }
}
