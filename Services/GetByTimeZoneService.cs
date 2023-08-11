using MongoDbWebAPI.Models;
using MongoDbWebAPI.Services.Interfaces;
using System.Collections.Generic;

namespace MongoDbWebAPI.Services
{
    public class GetByTimeZoneService: IGetByTimeZoneService
    {
        private readonly DataBaseOperationHandler _dataBaseOperationHandler;
        public GetByTimeZoneService(DataBaseOperationHandler dataBaseOperationHandler)
        {
            _dataBaseOperationHandler = dataBaseOperationHandler;
        }
        public List<FileModel> GetData(int timeZone)
        {
            var response = _dataBaseOperationHandler.GetAllDataFromCollection(timeZone);
            return response;
        }
    }
}
