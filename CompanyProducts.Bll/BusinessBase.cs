namespace CompanyProducts.Bll
{
    using System.Linq;
    using CompanyProducts.Data;
    using CompanyProducts.DataModels;

    public abstract class BusinessBase<T> where T : IRecord
    {
        internal IRepository<T> DataRepository { get; set; }

        internal BusinessBase(IRepository<T> dataRepository)
        {
            DataRepository = dataRepository;
        }
    }
}
