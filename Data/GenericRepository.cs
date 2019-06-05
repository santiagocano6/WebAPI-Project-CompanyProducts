namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using Data.ORM;
    using Models;

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