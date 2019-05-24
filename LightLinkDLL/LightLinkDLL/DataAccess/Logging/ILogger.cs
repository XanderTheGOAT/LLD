using System;
using LightLinkModels;

namespace LightLinkDLL.DataAccess
{
    public interface ILogger
    {
        void LogError(Exception error);
        void Log(object value);
    }
}