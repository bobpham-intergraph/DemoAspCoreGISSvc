using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;
using MongoDB.Driver.Linq;
using MongodbConnect.Models.Placename;
using MongodbConnect.Repository;

namespace MongodbConnect.FeatureRepository
{
   public class PlacenameRepository : BaseMongoRepository<PlacenameDocument>
   {        
        private readonly MongoDbContext _dataContext;

        public PlacenameRepository(MongoDbContext dataContext, string connectionName)
        {
            _dataContext = dataContext;
            _connectionName = connectionName;
        }

        protected override IMongoCollection<PlacenameDocument> Collection =>
            _dataContext.Database.GetCollection<PlacenameDocument>(_connectionName);


        public virtual IMongoQueryable<PlacenameDocument> FindPlacenameByName(string phrase)
        {
            Expression<Func<PlacenameDocument, bool>> predicate = p => p.PlaceName.ToLower().Contains(phrase.ToLower());

            return Collection.AsQueryable().Where(predicate);
        }


        public virtual PagingResult<PlacenameDocument> FindPlacenameByNamePaging(string phrase, int numberofrecords, int page)
        {
            Expression<Func<PlacenameDocument, bool>> predicate = p => p.PlaceName.ToLower().Contains(phrase.ToLower());

            return FindAllWithPaging(predicate, page - 1, numberofrecords);
        }


        public virtual IMongoQueryable<PlacenameDocument> FindPlacenameById(int id)
        {
            Expression<Func<PlacenameDocument, bool>> predicate = p => p.PlaceNameId == id;

            return Collection.AsQueryable().Where(predicate);
        }
    }
}
