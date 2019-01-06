using Framework.Log.MongoDb.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Log.MongoDb
{
    public class ApiLogService : LogService, IApiLogService
    {

        public ApiLogService(MongoSetting mongoSetting) : base(mongoSetting)
        {

        }

       
    }
}
