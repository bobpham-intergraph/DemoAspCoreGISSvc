using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;
using MongoDB.Driver.Linq;
using MongodbConnect.Models.RatingUnit;
using MongodbConnect.Repository;

namespace MongodbConnect.FeatureRepository
{
    public class RatingUnitRepository : BaseMongoRepository<RatingUnitDocument>
    {
        private const string CollectionName = "ratingunits";

        private readonly MongoDbContext _dataContext;

        public RatingUnitRepository(MongoDbContext dataContext, string connectionName)
        {
            _dataContext = dataContext;
            _connectionName = connectionName;
        }

        protected override IMongoCollection<RatingUnitDocument> Collection =>
            _dataContext.Database.GetCollection<RatingUnitDocument>(_connectionName);


        public virtual IMongoQueryable<RatingUnitDocument> FindRatingUnitByName(string phrase)
        {
            Expression<Func<RatingUnitDocument, bool>> predicate = p => p.StreetAddress.ToLower().Contains(phrase.ToLower());

            return Collection.AsQueryable().Where(predicate);
        }

      
        public virtual PagingResult<RatingUnitDocument> FindRatingUnitByNamePaging(string phrase, int numberofrecords, int page)
        {
            Expression<Func<RatingUnitDocument, bool>> predicate = p => p.StreetAddress.ToLower().Contains(phrase.ToLower());

            return FindAllWithPaging(predicate, page - 1, numberofrecords);
        }


        public virtual IMongoQueryable<RatingUnitDocument> FindRatingUnitById(int id)
        {
            Expression<Func<RatingUnitDocument, bool>> predicate = p => p.RatingUnitId == id;

            return Collection.AsQueryable().Where(predicate);
        }
    }
}
