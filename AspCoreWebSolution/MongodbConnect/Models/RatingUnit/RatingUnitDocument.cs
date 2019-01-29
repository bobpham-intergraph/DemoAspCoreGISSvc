using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongodbConnect.Models.GIS;
using MongodbConnect.Repository;

namespace MongodbConnect.Models.RatingUnit
{
    public class RatingUnitDocument : IMongoEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("localityName")]
        public string LocalityName { get; set; }
      
        [BsonElement("streetAddress")]
        public string StreetAddress { get; set; }

        [BsonElement("occupationLevelDescription")]
        public string OccupationLevelDescription { get; set; }

        [BsonElement("ratingUnitId")]
        public int RatingUnitId { get; set; }
        public MultiPolygon geometry { get; set; }

      
    }
}
