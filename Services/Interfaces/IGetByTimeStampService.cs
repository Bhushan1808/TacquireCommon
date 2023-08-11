using MongoDbWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDbWebAPI.Services.Interfaces
{
    public interface IGetByTimeStampService
    {
        List<FileModel> GetData(string date);
    }
}
