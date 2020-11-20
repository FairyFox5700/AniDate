using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Account.Dal.Abstract;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Account.Dal.Impl
{
    public class GenericRepository<TKey,TEntity> :IRepository<TKey,TEntity>
    where TEntity:class
    where TKey : struct
    {
        private readonly DbContext _context;

        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> DbSet => _context.Set<TEntity>();
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var item = await _context
                .Set<TEntity>()
                .AddAsync(entity);

            await _context.SaveChangesAsync();
            return item.Entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            var item = _context.Set<TEntity>()
                .Remove(entity);
            await _context.SaveChangesAsync();
            return item.Entity;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await _context.Set<TEntity>()
                .FindAsync(id);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            var result = _context.Set<TEntity>().Where(predicate);
            return await result.ToListAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Set<TEntity>().CountAsync();
        }

        private async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
#if DEBUG
            catch (DbUpdateConcurrencyException dbException)
            {
                Console.WriteLine(string.Empty, "This concurrency exception occured");
                throw;
            }
            catch (DbUpdateException ex)
            {
                if (ex.GetBaseException() is PostgresException pgException)
                {
                    switch (pgException.SqlState)
                    {
                        case "23505":
                            Console.WriteLine(string.Empty, "This entity exists in the database");
                            throw;
                        default:
                            throw;
                    }
                }
            }
#endif
            catch (Exception exception)
            {
                throw ;
            }
        }
    }
}