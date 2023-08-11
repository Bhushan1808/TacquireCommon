using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MongoDbWebAPI.Commands.Interfaces
{
    public interface IGetByDeveloperNameCommand
    {
        Task<IActionResult> ExecuteAsync(string name,CancellationToken cancellationToken = default(CancellationToken));

    }
}
