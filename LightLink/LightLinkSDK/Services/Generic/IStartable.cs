using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightLinkSDK.Services.Generic
{
    public interface IStartable
    {
        /// <summary>
        /// Do NOT start the program more than once.
        /// </summary>
        /// <exception cref="InvalidOperationException">When Program is started more than once.</exception>
        void Start();

        /// <summary>
        /// Properly restart the program by closing it and opening a new program
        /// </summary>
        void Restart();

        /// <summary>
        /// Kills the programs current process. 
        /// </summary>
        void Stop();

        /// <summary>
        /// Refreshes Values such as Devices. Mainly used for new devices plugged after Start.
        /// </summary>
        void Refresh();
    }
}
