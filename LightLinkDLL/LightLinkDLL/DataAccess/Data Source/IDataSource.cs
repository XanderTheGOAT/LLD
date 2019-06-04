using LightLinkModels;
using System;

namespace LightLinkDLL.DataAccess
{
    public interface IDataSource : IDisposable
    {
        Profile GetProfile();
        void UpdateData(Computer computer);
    }
}