using MongoDbWebAPI.Models;
using MongoDbWebAPI.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace MongoDbWebAPI.Services
{
    public class GetByTimeStampService: IGetByTimeStampService
    {
        private readonly DataBaseOperationHandler _dataBaseOperationHandler;
        public GetByTimeStampService(DataBaseOperationHandler dataBaseOperationHandler)
        {
            _dataBaseOperationHandler = dataBaseOperationHandler;
        }
        public List<FileModel> GetData(string date)
        {
            var response = _dataBaseOperationHandler.GetAllDataFromCollection(DateTime.Parse(date));
            return response;
        }
    }
}
