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
        protected MongoDbContext _dbcontext;
        public MongoDbContext DbContext
        {
            get
            {
                if (_dbcontext == null)
                {
                    string cs = ConfigurationManager.ConnectionStrings["MongoDb"].ConnectionString;

                    string dbName = ConfigurationManager.AppSettings["MongoDbConnectionName"].ToString();


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
                    string collectionName = ConfigurationManager.AppSettings["ParkCollection"].ToString();
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
                    string collectionName = ConfigurationManager.AppSettings["RatingUnitCollection"].ToString();
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
                    string collectionName = ConfigurationManager.AppSettings["StreetAddressCollection"].ToString();
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
                    string collectionName = ConfigurationManager.AppSettings["PlaceNameCollection"].ToString();
                    _placenameRepository = new PlacenameRepository(DbContext, collectionName);
                }

                return _placenameRepository;
            }
        }

    }
}
