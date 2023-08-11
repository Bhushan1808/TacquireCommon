using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MongoDbWebAPI.Commands.Interfaces
{
    public interface IGetByTimeStampCommand
    {
        Task<IActionResult> ExecuteAsync(string timeStamp,CancellationToken cancellationToken = default(CancellationToken));

    }
}
