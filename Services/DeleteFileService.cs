using MongoDbWebAPI.Models;
using MongoDbWebAPI.Services.Interfaces;
using System.Collections.Generic;

namespace MongoDbWebAPI.Services
{
    public class DeleteFileService: IDeleteFileService
    {
        private readonly DataBaseOperationHandler _dataBaseOperationHandler;
        public DeleteFileService(DataBaseOperationHandler dataBaseOperationHandler)
        {
            _dataBaseOperationHandler = dataBaseOperationHandler;
        }

        public List<FileModel> DeletFromMongo(string id)
        {
            var response= _dataBaseOperationHandler.DeleteDataFromCollection(id);
            return response;
        }
    }
}
