using Microsoft.AspNetCore.Mvc;
using MongoDbWebAPI.Commands.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using MongoDbWebAPI.Services.Interfaces;

namespace MongoDbWebAPI.Commands
{
    public class GetByDeveloperNameCommand : IGetByDeveloperNameCommand
    {
        private readonly IGetByDeveloperNameService _getByDeveloperNameService;

        public GetByDeveloperNameCommand(IGetByDeveloperNameService getByDeveloperNameService)
        {
            _getByDeveloperNameService = getByDeveloperNameService;
        }
        public async Task<IActionResult> ExecuteAsync(string name,CancellationToken cancellationToken = default)
        {
            try
            {
                var response = _getByDeveloperNameService.GetData(name);
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
