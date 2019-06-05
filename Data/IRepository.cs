namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Models;

    public interface IRepository<T> where T : IRecord
    {

        IQueryable<T> GetAll();

        IQueryable<T> Find(Expression<Func<T, bool>> where);
    }
}
