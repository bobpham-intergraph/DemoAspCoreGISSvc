using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongodbConnect.Models.GIS;
using MongodbConnect.Repository;

namespace MongodbConnect.Models.Park
{
    public class ParkDocument : IMongoEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("parkName")]
        public string ParkName { get; set; }

       
        [BsonElement("parkTypeDescription")]
        public string ParkTypeDescription { get; set; }
       
        [BsonElement("parkId")]
        public int ParkId { get; set; }
        public MultiPolygon geometry { get; set; }

    }
}
