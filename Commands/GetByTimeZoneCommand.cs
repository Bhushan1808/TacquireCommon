using Microsoft.AspNetCore.Mvc;
using MongoDbWebAPI.Commands.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using MongoDbWebAPI.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace MongoDbWebAPI.Commands
{
    public class GetByTimeZoneCommand : IGetByTimeZoneCommand
    {
        private readonly IGetByTimeZoneService _getByTimeZoneService;
        public GetByTimeZoneCommand(IGetByTimeZoneService getByTimeZoneService)
        {
            _getByTimeZoneService = getByTimeZoneService;
        }
        public async Task<IActionResult> ExecuteAsync(string timeZone,CancellationToken cancellationToken = default)
        {
            try
            {
                var response = _getByTimeZoneService.GetData(int.Parse(timeZone));
                if (response.Count > 0)
                {
                    return new OkObjectResult(response);
                }
                else
                {
                    return new StatusCodeResult(204);
                }
            }
            catch(Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }
    }
}
