using LightLinkModels;

namespace LightLinkDLL.DataAccess
{
    public interface IDataSource
    {
        Profile GetProfile();
        void UpdateData(Computer computer);
    }
}