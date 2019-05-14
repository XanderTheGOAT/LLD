namespace LightLink.Services
{
    public interface IGenericColorService : IColorService, IDeviceService, IStartable
    {
        /// <summary>
        /// Gets the name of the current service
        /// </summary>
        /// <returns>String of the service name. For Example: iCue</returns>
        string GetServiceName();
    }
}
