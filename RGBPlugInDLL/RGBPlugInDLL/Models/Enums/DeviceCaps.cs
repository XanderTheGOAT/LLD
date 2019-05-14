using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGBPlugInDLL.Models.Enums
{
    [Flags]
    public enum DeviceCaps
    {
        /// <summary>
        /// For devices that do not support any SDK functions
        /// </summary>
        None = 0,

        /// <summary>
        /// For devices that has controlled lighting
        /// </summary>
        Lighting = 1
    }
}
