using MongoDbWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDbWebAPI.Services.Interfaces
{
    public interface IGetByTimeZoneService
    {
        List<FileModel> GetData(int timeZone);
    }
}
