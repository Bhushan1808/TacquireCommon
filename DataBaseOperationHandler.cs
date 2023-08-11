using MongoDB.Driver;
using System;
using System.Collections.Generic;
using MongoDbWebAPI.Models;
using MongoDB.Bson;
using MongoDbWebAPI.NewFolder;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace MongoDbWebAPI
{
    public class DataBaseOperationHandler
    {
        private readonly AppSetting _appSetting;
        private readonly IMongoDatabase dataBase;
        private readonly IMongoCollection<FileModel> _collection;
        private readonly ILogger<DataBaseOperationHandler> _logger;

        public DataBaseOperationHandler(IOptions<AppSetting> appSetting, ILogger<DataBaseOperationHandler> logger)
        {
            _appSetting = appSetting.Value;
            var client = new MongoClient(_appSetting.ConnectionString);
            dataBase=client.GetDatabase(_appSetting.Database);
            _collection = dataBase.GetCollection<FileModel>(_appSetting.Collection);
            _logger = logger;
        }

        public FileModel InsertIntoCollection(FileModel requestedParam)
        {
                _collection.InsertOne(requestedParam);
                return requestedParam;   
        }

        public List<FileModel> GetAllDataFromCollection()
        {
            var timer = new Stopwatch();
            timer.Start();
            var wholeCollectionData =  _collection.Find(new BsonDocument()).ToList();
            timer.Stop();
            _logger.LogError("Fitching all data time:"+timer.ElapsedMilliseconds.ToString());

            return wholeCollectionData;
        }

        //var highExamScoreFilter = Builders<BsonDocument>.Filter.ElemMatch<BsonValue>(
        //                            "scores", new BsonDocument { { "type", "exam" },
        //                            { "score", new BsonDocument { { "$gte", 95 } } }
        //                            });
        public List<FileModel> GetAllDataFromCollection(string name)
        {
            var timer = new Stopwatch();
            timer.Start();
            var filteredData = _collection.Find(obj=>obj.Name.ToLower().StartsWith(name.ToLower())).ToList();
            timer.Stop();
            _logger.LogError("ByName Time:"+timer.ElapsedMilliseconds.ToString());
            return filteredData;
        }

        public List<FileModel> GetAllDataFromCollection(DateTime startDate,DateTime endDate)
        {
            var timer = new Stopwatch();
            timer.Start();
            var filteredData = _collection.Find(obj => DateTime.Parse(obj.CurrentTimeStamp) >= startDate && DateTime.Parse(obj.CurrentTimeStamp) <= endDate).ToList();
            timer.Stop();
            _logger.LogError("TimeStampRange time:"+timer.ElapsedMilliseconds.ToString());
            return filteredData;
        }

        public List<FileModel> GetAllDataFromCollection(int timeZone)
        {
            var timer = new Stopwatch();
            timer.Start();
            var filteredData = _collection.Find(obj=>obj.CurrentTimeZone==timeZone.ToString()).ToList();
            timer.Stop();
            _logger.LogError("TimeZone Time:"+timer.ElapsedMilliseconds.ToString());
            return filteredData;
        }

        public List<FileModel> GetAllDataFromCollection(DateTime dateTime)
        {
            var timer = new Stopwatch();
            timer.Start();
            var filteredData = _collection.Find(obj => DateTime.Parse(obj.CurrentTimeStamp) == dateTime).ToList();
            timer.Stop();
            _logger.LogError("Timestamp Time:"+timer.ElapsedMilliseconds.ToString());
            return filteredData;
        }

        public List<FileModel> DeleteDataFromCollection(string id)
        {
            var filteredData = _collection.Find(obj=>obj.FileName==id).ToList();
            var timer = new Stopwatch();
            timer.Start();
            var filter = Builders<FileModel>.Filter.Eq("FileName", id);
            _collection.DeleteOneAsync(filter);
            timer.Stop();
            _logger.LogError("Delete Time:"+timer.ElapsedMilliseconds.ToString());
            return filteredData;
        }
    }
}
