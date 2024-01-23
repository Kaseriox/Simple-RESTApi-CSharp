using Articles.API.Exceptions;
using Database.Data;
using Database.Models;


namespace Articles.API.Repository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
{
    private readonly ArticleContext _articleContext;

    public GenericRepository(ArticleContext articleContext)
    {
        _articleContext = articleContext;
    }

    public IQueryable<TEntity> GetAll()
    {
        try
        {
            return _articleContext.Set<TEntity>();
        }
        catch (Exception e)
        {
            throw new DatabaseException("Error occured while getting " + typeof(TEntity), e);
        }
        
    }

    public async Task<TEntity> GetById(int id)
    {
        try
        {
            return await _articleContext.Set<TEntity>().FindAsync(id) ?? 
                   throw new DatabaseException( typeof(TEntity) + " by such Id doesn't exist");
        }
        catch (Exception e)
        {
            throw new DatabaseException("Error occured while getting " + typeof(TEntity) + " By id", e);
        }
    }

    public async Task Create(TEntity entity)
    {
        try
        {
            await _articleContext.Set<TEntity>().AddAsync(entity);
            await _articleContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new DatabaseException("Error occured while creating new " + typeof(TEntity), e);
        }
        
    }

    public async Task Update(TEntity entity)
    {
        try
        {
            _articleContext.Set<TEntity>().Update(entity);
            await _articleContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new DatabaseException("Error occured while updating " + nameof(TEntity), e);
        }
        
    }

    public async Task Delete(int id)
    {
        try
        {
            var entity = await GetById(id);
            _articleContext.Set<TEntity>().Remove(entity);
            await _articleContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new DatabaseException("Error occured while deleting " + nameof(TEntity), e);
        }
        
    }
}