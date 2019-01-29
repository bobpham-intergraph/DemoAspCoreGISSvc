using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using MongodbConnect.Models.Park;
using MongodbConnect.Repository;
using System.Linq;
using Xunit;

namespace MongodbConnect.Tests
{
    public class DBContextTest
    {
        protected MongoDbContext _dbcontext;
        public DBContextTest()
        {
            var _configuration = ConfigHelper.GetConfig();
            string cs = _configuration.GetConnectionString("MongoDb").ToString();

            string dbName = _configuration.GetSection("MongoDbConnectionName").Value.ToString();

            _dbcontext = new MongoDbContext(cs, dbName);            
        }


        [Fact]
        public void FindParkCollection()
        {
            IMongoCollection<ParkDocument> _parkCollection = _dbcontext.Database.GetCollection<ParkDocument>("parks_test");

            Assert.NotNull(_parkCollection);
        }

        [Fact]
        public void FindParkCollectionCount()
        {
            IMongoCollection<ParkDocument> _parkCollection = _dbcontext.Database.GetCollection<ParkDocument>("parks_test");

            long count = _parkCollection.AsQueryable().Count();
            Assert.True(count > 0);
        }

    }
}
