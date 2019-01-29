using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;
using MongoDB.Driver.Linq;


namespace MongodbConnect.Repository
{
    public abstract class BaseMongoRepository<TEntity> : IRepository<TEntity> where TEntity : IMongoEntity
    {
        protected abstract IMongoCollection<TEntity> Collection { get; }

        protected string _connectionName { get; set; }

        public virtual async Task<TEntity> GetByIdAsync(string inputId)
        {
            ObjectId inputIDObj = new ObjectId(inputId);
            return await Collection.Find(x => x.Id.Equals(inputIDObj)).FirstOrDefaultAsync();
        }


        public virtual async Task<TEntity> SaveAsync(TEntity entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Id.ToString()))
            {
                entity.Id = new ObjectId(ObjectId.GenerateNewId().ToString());
            }

            await Collection.ReplaceOneAsync(
                x => x.Id.Equals(entity.Id),
                entity,
                new UpdateOptions
                {
                    IsUpsert = true
                });

            return entity;
        }



        public virtual async Task<bool> DeleteAsync(string inputId)
        {
            ObjectId inputIDObj = new ObjectId(inputId);

            DeleteResult result = await Collection.DeleteOneAsync(x => x.Id.Equals(inputIDObj));


            return result.IsAcknowledged;
        }

        public virtual bool Delete(string inputId)
        {
            ObjectId inputIDObj = new ObjectId(inputId);

            DeleteResult result = Collection.DeleteOne(x => x.Id.Equals(inputIDObj));

            return result.IsAcknowledged;
        }

        public virtual async Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Collection.Find(predicate).ToListAsync();
        }


        public virtual ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
        {
            return Collection.Find(predicate).ToList();
        }

        public virtual PagingResult<TEntity> FindAllWithPaging(Expression<Func<TEntity, bool>> predicate, int skip, int numberofRecords)
        {
            var querydb = Collection.AsQueryable().Where(predicate);

            PagingResult<TEntity> currentPageResult = new PagingResult<TEntity>();

            currentPageResult.TotalCount = querydb.Count();
            currentPageResult.CurrentPage = skip;
            currentPageResult.NumberofRecordsPerPage = numberofRecords;

            currentPageResult.CurrentData = querydb.Skip(skip * numberofRecords).Take(numberofRecords).ToList();

            return currentPageResult;

        }




        public virtual async Task<PagingResult<TEntity>> FindAllWithPagingAsync(Expression<Func<TEntity, bool>> predicate, int skip, int numberofRecords)
        {
            var querydb = Collection.Find(predicate);

            PagingResult<TEntity> currentPageResult = new PagingResult<TEntity>();

            var totalCount = querydb.CountDocumentsAsync();

            currentPageResult.CurrentPage = skip;
            currentPageResult.NumberofRecordsPerPage = numberofRecords;

            var currentData = querydb.Skip(skip * numberofRecords).Limit(numberofRecords).ToListAsync();

            await Task.WhenAll(totalCount, currentData);  /**Important show how to wait for all async actions to finish **/

            currentPageResult.CurrentData = currentData.Result;
            currentPageResult.TotalCount = (int)totalCount.Result;

            return currentPageResult;

        }


        public virtual TEntity FindOne(Expression<Func<TEntity, bool>> predicate)
        {
            return Collection.Find(predicate).FirstOrDefault();
        }

        public virtual async Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Collection.Find(predicate).FirstOrDefaultAsync();
        }


        ////
        public virtual IMongoQueryable<TEntity> FindAllQueryable(Expression<Func<TEntity, bool>> predicate)
        {
            return Collection.AsQueryable().Where(predicate);
        }


    }
}
