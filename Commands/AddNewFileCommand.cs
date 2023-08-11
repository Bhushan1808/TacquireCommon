using Microsoft.AspNetCore.Mvc;
using MongoDbWebAPI.Commands.Interfaces;
using System;
using System.Threading.Tasks;
using MongoDbWebAPI.Services.Interfaces;
using MongoDbWebAPI.Models;

namespace MongoDbWebAPI.Commands
{
    public class AddNewFileCommand : IAddNewFileCommand
    {
        private readonly IAddNewFileService _addNewFileService;

        public AddNewFileCommand(IAddNewFileService addNewFileService)
        {
            _addNewFileService = addNewFileService;
        }
        public async Task<IActionResult> AddNewFile(FileModel requestedParameter)
        {
            try
            {
                var response = _addNewFileService.AddFileIntoMongoDb(requestedParameter);
                return new OkObjectResult(response);
            }
            catch(Exception ex)
            {

                return new StatusCodeResult(500);
            }
        }
    }
}
