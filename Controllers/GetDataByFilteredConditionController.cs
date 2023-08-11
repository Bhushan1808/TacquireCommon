using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDbWebAPI.Commands.Interfaces;
using Microsoft.AspNetCore.Http;
using MongoDbWebAPI.Models;

namespace MongoDbWebAPI.Controllers
{
    [ApiController]
    [Route("GetDataByFilteration")]
    public class GetDataByFilteredConditionController : Controller
    {
        private readonly Lazy<IGetByTimeStampRangeCommand> _getByTimeStampRangeCommand;
        private readonly Lazy<IGetByDeveloperNameCommand> _getByDeveloperNameCommand;
        private readonly Lazy<IGetByTimeStampCommand> _getByTimeStampCommand;
        private readonly Lazy<IGetByTimeZoneCommand> _getByTimeZoneCommand;
        private readonly Lazy<IGetAllFileDataCommand> _getAllFileDataCommand;

        public GetDataByFilteredConditionController(Lazy<IGetAllFileDataCommand> getAllFileDataCommand, Lazy<IGetByTimeStampRangeCommand> getByTimeStampRangeCommand, Lazy<IGetByDeveloperNameCommand> getByDeveloperNameCommand, Lazy<IGetByTimeStampCommand> getByTimeStampCommand, Lazy<IGetByTimeZoneCommand> getByTimeZoneCommand)
        {
            _getByTimeStampRangeCommand = getByTimeStampRangeCommand;
            _getByDeveloperNameCommand = getByDeveloperNameCommand;
            _getByTimeStampCommand = getByTimeStampCommand;
            _getByTimeZoneCommand = getByTimeZoneCommand;
            _getAllFileDataCommand = getAllFileDataCommand;
        }

        [HttpGet]
        [Route("GetAllData")]
        [ProducesResponseType(typeof(List<FileModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllData()
        {
            var response = await _getAllFileDataCommand.Value.GetAllFileData();
            return response;
        }

        [HttpGet]
        [Route("GetByTimeStampRange")]
        [ProducesResponseType(typeof(List<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByTimeStampRange([FromQuery] string startDate,[FromQuery] string endDate)
        {
            var response = await _getByTimeStampRangeCommand.Value.ExecuteAsync(startDate,endDate);
            return response;
        }

        [HttpGet]
        [Route("GetByName")]
        [ProducesResponseType(typeof(List<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByDeveloperName([FromQuery]string name)
        {
            var response = await _getByDeveloperNameCommand.Value.ExecuteAsync(name);
            return response;
        }

        [HttpGet]
        [Route("GetByTimeStamp")]
        [ProducesResponseType(typeof(List<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByTimeStamp([FromQuery]string timeStamp)
        {
            var response = await _getByTimeStampCommand.Value.ExecuteAsync(timeStamp);
            return response;
        }

        [HttpGet]
        [Route("GetByTimeZone")]
        [ProducesResponseType(typeof(List<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByTimeZone([FromQuery] string timeZone)
        {
            var response = await _getByTimeZoneCommand.Value.ExecuteAsync(timeZone);
            return response;
        }
    }
}
