namespace CompanyProducts.Bll
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CompanyProducts.Data;
    using CompanyProducts.Data.ORM;
    using CompanyProducts.DataModels;

    public class Products : BusinessBase<Product>
    {
        private static Products _classInstance = null;

        private Products(IRepository<Product> dataRepository) : base(dataRepository) { }

        public static Products CreateInstance()
        {
            if(_classInstance == null)
            {
                string fileName = Common.GetProductFilePath();
                var jsonTextFile = new JsonTextFile(fileName);
                var productRepository = new GenericRepository<Product>(jsonTextFile);

                return new Products(productRepository);
            }

            return _classInstance;
        }

        public void GetData(Category.CategoryType category, out IQueryable<Product> datos, out int hiddenProducts, out int shownProducts)
        {
            int totalProducts;
            switch (category)
            {
                case Category.CategoryType.All:
                    datos = base.DataRepository.GetAll();
                    totalProducts = datos.Count();
                    hiddenProducts = 0;
                    break;

                case Category.CategoryType.Office:
                case Category.CategoryType.Services:
                case Category.CategoryType.Tech:
                    datos = base.DataRepository.GetAll();
                    totalProducts = datos.Count();

                    datos = datos.Where(product => product.Categories.Contains(category.ToString()));
                    hiddenProducts = totalProducts - datos.Count();
                    break;

                default:
                    throw new ArgumentException("The category is not valid");
            }

            shownProducts = totalProducts - hiddenProducts;
        }
    }
}
