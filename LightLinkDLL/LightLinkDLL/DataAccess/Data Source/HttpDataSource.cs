using System;
using System.Collections.Generic;
using System.Text;
using LightLinkModels;

namespace LightLinkDLL.DataAccess
{
    public class HttpDataSource : IDataSource
    {
        public string BaseUrl { get; }
        public HttpDataSource(string baseUrl)
        {
            BaseUrl = baseUrl;
        }
        public Profile GetProfile()
        {
            throw new NotImplementedException();
        }
        public void UpdateData(Computer computer)
        {
            throw new NotImplementedException();
        }
    }
}
