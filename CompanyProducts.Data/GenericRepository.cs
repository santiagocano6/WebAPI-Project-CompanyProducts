namespace CompanyProducts.Data
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using CompanyProducts.Data.ORM;
    using CompanyProducts.DataModels;

    public class GenericRepository<T> : IRepository<T> where T : IRecord
    {
        private readonly JsonTextFile DbSet;

        public GenericRepository(JsonTextFile jsonTextFile)
        {
            DbSet = jsonTextFile;
        }

        public IQueryable<T> GetAll()
        {
            return DbSet.ReturnData<T>();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> where)
        {
            var data = DbSet.ReturnData<T>();
            return data.Where(where);
        }
    }
}