using StockApp.Api.Core.Application.Interfaces;
using StockApp.Api.Core.Helper;
using StockApp.Api.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace StockApp.Api.Persistance.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : TrackedAggregateRoot<Guid>, new()
    {
        private readonly StockAppContext _context;

        public GenericRepository(StockAppContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            if (entity == null)
            {
                 throw new ArgumentNullException(nameof(entity));
            }
            await  _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
      
        public async Task DeleteAsync(Guid id)
        {
            var entityObject = await _context.Set<T>().FindAsync(id);

            if (entityObject != null)
            {
                if (entityObject is TrackedAggregateRoot<Guid> deletableEntity)
                {
                    deletableEntity.IsDeleted = true;
              
                }
                else
                {
                    throw new Exception($"{typeof(T)} does not implement ISoftDeletable interface.");
                }

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"{typeof(T)}, {id} Not Found");
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().Where(x=>x.IsDeleted==false).ToListAsync();
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            T? entity = await _context.Set<T>().AsNoTracking().Where(x => x.IsDeleted == false).SingleOrDefaultAsync(filter);

            if (entity == null)
            {
                throw new Exception($"{typeof(T)}, {filter} Not Found");
            }

            return entity;
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            T? entity = await _context.Set<T>().FindAsync(id);
            if(entity.IsDeleted==true) throw new Exception($"{typeof(T)}, {id} Not Found");
            if (entity == null)
            {
                 throw new Exception($"{typeof(T)}, {id} Not Found");
            }

            return entity;
        }

        public async Task<T> UpdateAsync( T entity)
        {
          
            if (entity == null)
            {
                throw new Exception($"You must enter a value,{typeof(T)} , {entity} ");
            }
            _context.Entry(entity).State= EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
