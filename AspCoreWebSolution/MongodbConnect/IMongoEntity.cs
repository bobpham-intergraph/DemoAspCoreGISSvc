using System;
using MongoDB.Bson;

namespace MongodbConnect
{
    public interface IMongoEntity
    {
        ObjectId Id { get; set; }
    }
}
