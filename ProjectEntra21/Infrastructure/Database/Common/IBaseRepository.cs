﻿using ProjectEntra21.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectEntra21.Infrastructure.Database.Common
{
    public interface IBaseRepository<T> where T : PatternEntity
    {
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task InsertOrUpdate(T entity);
        Task<IList<T>> SelectMore(Expression<Func<T, bool>> filter = null);
        Task<T> SelectOne(Expression<Func<T, bool>> filter = null);
    }
}
