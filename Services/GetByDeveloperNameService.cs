using MongoDbWebAPI.Models;
using MongoDbWebAPI.Services.Interfaces;
using System.Collections.Generic;

namespace MongoDbWebAPI.Services
{
    public class GetByDeveloperNameService: IGetByDeveloperNameService
    {
        private readonly DataBaseOperationHandler _dataBaseOperationHandler;
        public GetByDeveloperNameService(DataBaseOperationHandler dataBaseOperationHandler) 
        {
            _dataBaseOperationHandler = dataBaseOperationHandler;
        }
        public List<FileModel> GetData(string name)
        {
            var response= _dataBaseOperationHandler.GetAllDataFromCollection(name);
            return response;
        }
    }
}
