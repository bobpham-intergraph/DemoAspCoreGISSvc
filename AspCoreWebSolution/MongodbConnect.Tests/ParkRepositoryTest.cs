using Microsoft.Extensions.Configuration;
using MongodbConnect.FeatureRepository;
using MongodbConnect.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MongodbConnect.Tests
{
    public class ParkRepositoryTest
    {
        private ParkRepository _parkRepository;

        public ParkRepositoryTest()
        {
            var _configuration = ConfigHelper.GetConfig();

            string cs = _configuration.GetConnectionString("MongoDb").ToString();

            string dbName = _configuration.GetSection("MongoDbConnectionName").Value.ToString();

            string collectionName = _configuration.GetSection("ParkCollection").Value.ToString();

            var _dbcontext = new MongoDbContext(cs, dbName);

            _parkRepository = new ParkRepository(_dbcontext, collectionName);

        }

        [Fact]
        public void TestFindParkByName()
        {

            string parkName = "Beach";
            int total = _parkRepository.FindParkByName(parkName).Count();
            
            int totalUpperCase = _parkRepository.FindParkByName(parkName.ToUpper()).Count();
                       
            Assert.Equal<int>(total, totalUpperCase);

        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 0)]
        [InlineData(2, 1)]
        public void TestParkById(int id, int expectedResult)
        {
            int output = _parkRepository.FindParkById(id).Count();

            Assert.Equal<int>(output, expectedResult);
        }
    }
}
