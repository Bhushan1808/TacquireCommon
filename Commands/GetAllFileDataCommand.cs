using Microsoft.AspNetCore.Mvc;
using MongoDbWebAPI.Commands.Interfaces;
using System;
using System.Threading.Tasks;
using MongoDbWebAPI.Services.Interfaces;

namespace MongoDbWebAPI.Commands
{
    public class GetAllFileDataCommand : IGetAllFileDataCommand
    {
        private readonly IGetAllFileDataService _getAllFileDataService;
        public GetAllFileDataCommand(IGetAllFileDataService getAllFileDataService)
        {
            _getAllFileDataService = getAllFileDataService;
        }
        public async Task<IActionResult> GetAllFileData()
        {
            try
            {
                var respnose = _getAllFileDataService.GetAllDataFromMongoDb();
                if (respnose.Count > 0)
                {
                    return new OkObjectResult(respnose);
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
