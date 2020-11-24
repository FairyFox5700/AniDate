using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Account.Dal.Impl;
using Account.Dal.Abstract.Repositories;

namespace Account.Dal.Impl.Repositories
{
    public class Repository<TKey> : IRepository<TKey> where TKey : class
    {
        protected AppDbContext dbContext;
        private DbSet<TKey> _entities;

        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            _entities = dbContext.Set<TKey>();
        }

        public async Task<int> Create(TKey entity)
        {
            _entities.Add(entity);
            return await Task.FromResult(0);
        }

        public async Task<TKey> Read(int id)
        {
            return await Task.FromResult(_entities.Find(id));
        }

        public async Task<int> Update(TKey entity)
        {

            _entities.Update(entity);
            return await Task.FromResult(0);
        }

        public async Task<int> Delete(int id)
        {
            _entities.Remove(dbContext.Set<TKey>().Find(id));
            return await Task.FromResult(0);
        }
    }
}
