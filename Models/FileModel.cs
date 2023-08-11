using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDbWebAPI.Models
{
    public class FileModel
    {
        public Guid _id { get; set; }

        [JsonProperty("currentTimeStamp")]
        public string CurrentTimeStamp { get; set; }

        [JsonProperty("currentTimeZone")]
        public string CurrentTimeZone { get; set; }

        [JsonProperty("file")]
        public string File { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("userInfo")]
        public string UserInfo { get; set; }

        [JsonProperty("fileName")]
        public string FileName { get; set; }

        [JsonProperty("fileContent")]
        public string FileContent { get; set; }
    }
}
