using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Log.MongoDb.Interfaces
{
    public interface IApiLogService : ILogService<ApiLog>
    {
         ApiLog Log { get; set; }



    }
}
