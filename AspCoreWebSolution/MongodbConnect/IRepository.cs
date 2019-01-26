using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MongodbConnect
{
    public interface IRepository<TEntity> where TEntity : IMongoEntity
    {
        Task<TEntity> GetByIdAsync(string inputId);

        Task<TEntity> SaveAsync(TEntity entity);

        Task<bool> DeleteAsync(string inputId);

        Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate);

        IMongoQueryable<TEntity> FindAllQueryable(Expression<Func<TEntity, bool>> predicate);

        TEntity FindOne(Expression<Func<TEntity, bool>> predicate);
    }
}
