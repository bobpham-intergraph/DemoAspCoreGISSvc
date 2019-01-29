using Microsoft.Extensions.Configuration;
using MongodbConnect.FeatureRepository;
using MongodbConnect.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace MongodbConnect
{
    public class UnitOfWork
    {
        private IConfiguration _configuration;
        public UnitOfWork(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected MongoDbContext _dbcontext;
        public MongoDbContext DbContext
        {
            get
            {
                if (_dbcontext == null)
                {
                    string cs = _configuration.GetConnectionString("MongoDb").ToString();

                    string dbName = _configuration.GetSection("MongoDbConnectionName").Value.ToString();   


                    _dbcontext = new MongoDbContext(cs, dbName);
                }
                return _dbcontext;
            }
        }

        private ParkRepository _parkRepository;
        
        public ParkRepository ParkRepository
        {

            get
            {
                if (_parkRepository == null)
                {
                    string collectionName = _configuration.GetSection("ParkCollection").Value.ToString();
                    _parkRepository = new ParkRepository(DbContext, collectionName);
                }

                return _parkRepository;
            }           
        }


        private RatingUnitRepository _ratingUnitRepository;

        public RatingUnitRepository RatingUnitRepository
        {

            get
            {
                if (_ratingUnitRepository == null)
                {
                    string collectionName = _configuration.GetSection("RatingUnitCollection").Value.ToString(); 
                    _ratingUnitRepository = new RatingUnitRepository(DbContext, collectionName);
                }

                return _ratingUnitRepository;
            }
        }

        private StreetAddressRepository _streetAddressRepository;

        public StreetAddressRepository StreetAddressRepository
        {

            get
            {
                if (_streetAddressRepository == null)
                {
                    string collectionName = _configuration.GetSection("StreetAddressCollection").Value.ToString(); 
                    _streetAddressRepository = new StreetAddressRepository(DbContext, collectionName);
                }

                return _streetAddressRepository;
            }
        }

        private PlacenameRepository _placenameRepository;

        public PlacenameRepository PlacenameRepository
        {

            get
            {
                if (_placenameRepository == null)
                {
                    string collectionName = _configuration.GetSection("PlaceNameCollection").Value.ToString();
                    _placenameRepository = new PlacenameRepository(DbContext, collectionName);
                }

                return _placenameRepository;
            }
        }

    }
}
