using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongodbConnect.Models.GIS;
using MongodbConnect.Repository;

namespace MongodbConnect.Models.StreetAddress
{
    public class StreetAddressDocument: IMongoEntity
    {
       
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("streetAddressId")]
        public int StreetAddressId { get; set; }

        [BsonElement("streetAddress")]
        public string StreetAddress { get; set; }

      
        [BsonElement("localityName")]
        public string LocalityName { get; set; }

        [BsonElement("streetAddressStatusDescription")]
        public string StreetAddressStatusDescription { get; set; }


        [BsonElement("occupationLevelDescription")]
        public string OccupationLevelDescription { get; set; }
        public MultiPoint geometry { get; set; }

    }


}
