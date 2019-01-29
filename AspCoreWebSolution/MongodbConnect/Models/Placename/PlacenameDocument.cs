using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongodbConnect.Models.GIS;
using MongodbConnect.Repository;



namespace MongodbConnect.Models.Placename
{
    public class PlacenameDocument : IMongoEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("locality")]
        public string Locality { get; set; }

        [BsonElement("placeName")]
        public string PlaceName { get; set; }

        [BsonElement("placeNameId")]
        public int PlaceNameId { get; set; }

        public MultiPoint geometry { get; set; }

       
    }
}
