using MongoDbWebAPI.Models;
using MongoDbWebAPI.Services.Interfaces;
using System.Collections.Generic;


namespace MongoDbWebAPI.Services
{
    public class GetAllFileDataService : IGetAllFileDataService
    {
        private readonly DataBaseOperationHandler _dataBaseOperationHandler;
        public GetAllFileDataService(DataBaseOperationHandler dataBaseOperationHandler)
        {
            _dataBaseOperationHandler = dataBaseOperationHandler;
        }
        public List<FileModel> GetAllDataFromMongoDb()
        {
            var response = _dataBaseOperationHandler.GetAllDataFromCollection();
            return response;
        }
    }
}
