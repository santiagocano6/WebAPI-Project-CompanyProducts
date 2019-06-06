namespace CompanyProducts.Data
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using CompanyProducts.DataModels;

    public interface IRepository<T> where T : IRecord
    {

        IQueryable<T> GetAll();

        IQueryable<T> Find(Expression<Func<T, bool>> where);
    }
}
