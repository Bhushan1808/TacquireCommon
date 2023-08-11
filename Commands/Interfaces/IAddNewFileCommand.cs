using Microsoft.AspNetCore.Mvc;
using MongoDbWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDbWebAPI.Commands.Interfaces
{
    public interface IAddNewFileCommand
    {
        Task<IActionResult> AddNewFile(FileModel data);
    }
}
