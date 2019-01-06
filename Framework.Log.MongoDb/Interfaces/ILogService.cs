using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Log.MongoDb.Interfaces
{
    public interface ILogService<T>
    {
        IEnumerable<T> GetLogs();

        T GetLog(ObjectId id);


        T Create(T p);


        void Update(ObjectId id, T p);

        void Remove(ObjectId id);
    }
}
