using Framework.Log.MongoDb.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Log.MongoDb
{
    public class LogService : ILogService<ApiLog>
    {
        protected MongoClient _client;
        protected BsonDocument filter = null;
        protected IMongoDatabase _db;
        public ApiLog Log { get ; set;}


        public LogService(MongoSetting mongoSetting)
        {
            _client = new MongoClient(mongoSetting.serverUrl);
            _db = _client.GetDatabase(mongoSetting.databaseName);          
            Log = new ApiLog();
        }


        public IEnumerable<ApiLog> GetLogs()
        {


            var collection = _db.GetCollection<ApiLog>("ApiLogs");
            var docs = collection.Find(filter).ToList();
            return docs;

        }


        public ApiLog GetLog(ObjectId id)
        {
            var res = Query<ApiLog>.EQ(p => p.Id, id);
            return null;
            //  return _db.GetCollection<ApiLog>("ApiLogs").InsertOne(res);
        }

        public ApiLog Create(ApiLog p)
        {


            _db.GetCollection<ApiLog>("ApiLogs").InsertOne(p);
            return p;
        }

        public void Update(ObjectId id, ApiLog p)
        {
            p.Id = id;
            var res = Query<ApiLog>.EQ(pd => pd.Id, id);
            var operation = Update<ApiLog>.Replace(p);
            //_db.GetCollection<ApiLog>("ApiLogs").UpdateOne(res, operation);
        }
        public void Remove(ObjectId id)
        {
            var res = Query<ApiLog>.EQ(e => e.Id, id);
            // var operation = _db.GetCollection<ApiLog>("ApiLogs").Remove(res);
        }

    }
}
