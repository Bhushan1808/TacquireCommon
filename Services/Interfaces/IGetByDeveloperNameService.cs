using MongoDbWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDbWebAPI.Services.Interfaces
{
    public interface IGetByDeveloperNameService
    {
        List<FileModel> GetData(string name);
    }
}
