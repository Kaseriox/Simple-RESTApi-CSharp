using Database.Models;

namespace Articles.API.Repository;

public interface IGenericRepository<TEntity>
    where TEntity : class, IEntity
{
    IQueryable<TEntity> GetAll();

    Task<TEntity> GetById(int id);

    Task Create(TEntity entity);

    Task Update(TEntity entity);

    Task Delete(int id);
}