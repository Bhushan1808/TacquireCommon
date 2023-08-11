using MongoDbWebAPI.Models;
using MongoDbWebAPI.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace MongoDbWebAPI.Services
{
    public class GetByTimeStampRangeService: IGetByTimeStampRangeService
    {
        private readonly DataBaseOperationHandler _dataBaseOperationHandler;
        public GetByTimeStampRangeService(DataBaseOperationHandler dataBaseOperationHandler)
        {
            _dataBaseOperationHandler = dataBaseOperationHandler;
        }
        public List<FileModel> GetData(string startDate, string endDate)
        {
            var response = _dataBaseOperationHandler.GetAllDataFromCollection(DateTime.Parse(startDate), DateTime.Parse(endDate));
            return response;
        }
    }
}
