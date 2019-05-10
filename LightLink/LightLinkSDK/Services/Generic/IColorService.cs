using LightLinkSDK.Models.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightLinkSDK.Services.Generic
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
