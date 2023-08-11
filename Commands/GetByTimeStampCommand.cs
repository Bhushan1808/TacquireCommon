using Microsoft.AspNetCore.Mvc;
using MongoDbWebAPI.Commands.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using MongoDbWebAPI.Services.Interfaces;

namespace MongoDbWebAPI.Commands
{
    public class GetByTimeStampCommand : IGetByTimeStampCommand
    {
        private readonly IGetByTimeStampService _getByTimeStampService;
        public GetByTimeStampCommand(IGetByTimeStampService getByTimeStampService)
        {
            _getByTimeStampService= getByTimeStampService;
        }
        public async Task<IActionResult> ExecuteAsync(string timeStamp,CancellationToken cancellationToken = default)
        {
            try
            {
                var response = _getByTimeStampService.GetData(timeStamp);
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
