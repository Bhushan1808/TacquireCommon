using MongoDbWebAPI.Models;
using MongoDbWebAPI.Services.Interfaces;


namespace MongoDbWebAPI.Services
{
    public class AddNewFileService : IAddNewFileService
    {
        private readonly DataBaseOperationHandler _dataBaseOperationHandler;
        public AddNewFileService(DataBaseOperationHandler dataBaseOperationHandler)
        {
            _dataBaseOperationHandler = dataBaseOperationHandler;
        }
        public object AddFileIntoMongoDb(FileModel requestedParameter)
        {
            var response=_dataBaseOperationHandler.InsertIntoCollection(requestedParameter);
            return response;
        }
    }
}
