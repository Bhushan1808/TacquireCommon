using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDbWebAPI.Commands.Interfaces;
using MongoDbWebAPI.Models;
using Microsoft.AspNetCore.Http;

namespace MongoDbWebAPI.Controllers
{
    [ApiController]
    [Route("MongoDbFileController")]
    public class MongoDbFileController : Controller
    {
        private readonly Lazy<IGetAllFileDataCommand> _getAllFileDataCommand;
        private readonly Lazy<IAddNewFileCommand> _addNewFileCommand;
        private readonly Lazy<IDeleteFileCommand> _deleteFileCommand;
        public MongoDbFileController(Lazy<IGetAllFileDataCommand> getAllFileDataCommand,Lazy<IAddNewFileCommand> addNewFileCommand, Lazy<IDeleteFileCommand> deleteFileCommand)
        {
            _getAllFileDataCommand = getAllFileDataCommand;
            _addNewFileCommand = addNewFileCommand;
            _deleteFileCommand = deleteFileCommand;
        }

        [HttpPost]
        [Route("AddFileAndData")]
        [ProducesResponseType(typeof(List<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddNewFile([FromForm]FileModel requestedParameter)
        {
            var response = await _addNewFileCommand.Value.AddNewFile(requestedParameter);
            return response;
        }

        [HttpDelete]
        [Route("DeleteFile")]
        [ProducesResponseType(typeof(List<FileModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteFile([FromQuery] string fileName)
        {
            var response = await _deleteFileCommand.Value.DeleteById(fileName);
            return response;
        }

    }
}
