using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LightLinkModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LightLinkDLL.DataAccess.Data_Source
{
    public class FileDataSource : IDataSource
    {
        public string FilePath { get; }
        public FileDataSource(string filePath)
        {
            if (filePath is null) throw new ArgumentNullException("filePath cannot be null.");
            FilePath = filePath;
        }
        public Profile GetProfile()
        {
            var jsonValue = File.ReadAllText(FilePath);
            var jObj = JsonConvert.DeserializeObject<JObject>(jsonValue);
            var jsonProfile = jObj["profile"];
            return JsonConvert.DeserializeObject<Profile>(jsonProfile.ToString());
        }

        public void UpdateData(Computer computer)
        {
            var jsonValue = File.ReadAllText(FilePath);
            var jObj = JsonConvert.DeserializeObject<JObject>(jsonValue);
            jObj["computer"] = JToken.FromObject(computer);

            File.WriteAllText(FilePath, jObj.ToString());
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
