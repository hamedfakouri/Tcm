using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Log.MongoDb
{
    public class ApiLog
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("Request")]
        public string Request { get; set; }
        [BsonElement("Response")]
        public string Response { get; set; }
        [BsonElement("LogStartTime")] public string LogStartTime { get; set; }
        [BsonElement("LogEndTime")] public string LogEndTime { get; set; }





        [BsonElement("SqlCode")] public string SqlCode { get; set; }
        [BsonElement("UnitOfWorkError")] public string UnitOfWorkError { get; set; }
        [BsonElement("AccessToken")] public string AccessToken { get; set; }





    }
}
