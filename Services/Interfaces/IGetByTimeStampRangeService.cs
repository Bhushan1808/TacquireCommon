using MongoDbWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDbWebAPI.Services.Interfaces
{
    public interface IGetByTimeStampRangeService
    {
        List<FileModel> GetData(string startDate, string endDate);
    }
}
