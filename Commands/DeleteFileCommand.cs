using Microsoft.AspNetCore.Mvc;
using MongoDbWebAPI.Commands.Interfaces;
using MongoDbWebAPI.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace MongoDbWebAPI.Commands
{
    public class DeleteFileCommand : IDeleteFileCommand
    {
        private readonly IDeleteFileService _deleteFileService;
        public DeleteFileCommand(IDeleteFileService deleteFileService)
        {
            _deleteFileService = deleteFileService;
        }
        public async Task<IActionResult> DeleteById(string id)
        {
            try
            {
                var response=_deleteFileService.DeletFromMongo(id);
                return new OkObjectResult(response);
            }
            catch(Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }
    }
}
