using Microsoft.AspNetCore.Mvc;
using MongoDbWebAPI.Commands.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using MongoDbWebAPI.Services.Interfaces;

namespace MongoDbWebAPI.Commands
{
    public class GetByTimeStampRangeCommand : IGetByTimeStampRangeCommand
    {
        private readonly IGetByTimeStampRangeService _getByTimeStampRangeService;
        public GetByTimeStampRangeCommand(IGetByTimeStampRangeService getByTimeStampRangeService)
        {
            _getByTimeStampRangeService = getByTimeStampRangeService;
        }
        public async Task<IActionResult> ExecuteAsync(string startDate, string endDate, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = _getByTimeStampRangeService.GetData(startDate, endDate);
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
