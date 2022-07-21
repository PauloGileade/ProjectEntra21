﻿
using Microsoft.EntityFrameworkCore;
using ProjectEntra21.Domain.Common;
using ProjectEntra21.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectEntra21.Infrastructure.Database.Common
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

        public Task Delete(T entity)
        {
            Dbset.Remove(entity);
            return Task.CompletedTask;
        }

        public virtual async Task Insert(T entity)
        {
            entity.CreateAt = DateTime.Now;
            entity.LastModifiedAt = DateTime.Now;
            // await Dbset.AddAsync(entity);
            Context.Add(entity);
            await Context.SaveChangesAsync();
        }

        public Task InsertOrUpdate(T entity)
        {
            if (Dbset.Any(x => x.Id == entity.Id))
            {
                return Update(entity);
            }

            return Insert(entity);
        }

        public async Task<IList<T>> SelectMore(Expression<Func<T, bool>> filter = null)
        {
            if (filter == null)
            {
                return await Dbset.ToListAsync();
            }

            return await Dbset.Where(filter).ToListAsync();
        }

        public virtual async Task<T> SelectOne(Expression<Func<T, bool>> filter = null)
        {
            return await Dbset.Where(filter).FirstOrDefaultAsync();
        }

        public Task Update(T entity)
        {
            entity.LastModifiedAt = DateTime.Now;
            Dbset.Update(entity);

            return Task.CompletedTask;
        }
    }
}
