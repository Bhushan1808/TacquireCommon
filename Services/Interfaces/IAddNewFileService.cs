using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDbWebAPI.Models;

namespace MongoDbWebAPI.Services.Interfaces
{
    public interface IAddNewFileService
    {
        object AddFileIntoMongoDb(FileModel data);
    }
}
