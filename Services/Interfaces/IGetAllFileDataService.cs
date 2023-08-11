using Microsoft.AspNetCore.Mvc;
using MongoDbWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDbWebAPI.Services.Interfaces
{
    public interface IGetAllFileDataService
    {
        List<FileModel> GetAllDataFromMongoDb();
    }
}
