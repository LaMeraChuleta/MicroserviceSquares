using MicroserviceSquare.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceSquare.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly SquareCatalogContext _SquareCatalogContext;

        public Repository(SquareCatalogContext squareCatalogContext)
        {
            _SquareCatalogContext = squareCatalogContext;
        }
        public IQueryable<TEntity> GetAll()
        {
            return _SquareCatalogContext.Set<TEntity>();
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await _SquareCatalogContext.AddAsync(entity);
                await _SquareCatalogContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                _SquareCatalogContext.Update(entity);
                await _SquareCatalogContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }
    }
}
