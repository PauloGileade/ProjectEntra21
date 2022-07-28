
using Microsoft.EntityFrameworkCore;
using ProjectEntra21.src.Domain.Common;
using ProjectEntra21.src.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectEntra21.src.Infrastructure.Database.Common
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : PatternEntity
    {
        protected readonly DatabaseContext Context;
        protected readonly DbSet<T> Dbset;

        protected BaseRepository(DatabaseContext context)
        {
            Context = context;
            Dbset = Context.Set<T>();
        }

        public async Task Delete(T entity)
        {
            Dbset.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task Insert(T entity)
        {
            await Dbset.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public Task InsertOrUpdate(T entity)
        {
            if (Dbset.Any(x => x.Id == entity.Id))

                return Update(entity);


            return Insert(entity);
        }

        public async Task<IList<T>> SelectMore(Expression<Func<T, bool>> filter = null)
        {
            if (filter == null)

                return await Dbset.ToListAsync();


            return await Dbset.Where(filter).ToListAsync();
        }

        public virtual async Task<T> SelectOne(Expression<Func<T, bool>> filter = null)
        {
            return await Dbset.Where(filter).FirstOrDefaultAsync();
        }

        public virtual async Task Update(T entity)
        {
            Dbset.Update(entity);
            await Context.SaveChangesAsync();
        }
    }
}
