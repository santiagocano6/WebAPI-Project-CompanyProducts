namespace CompanyProductsAPI.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;
    using CompanyProductsAPI.Models;
    using Data;
    using Data.ORM;
    using DataModels;

    public class ProductsController : ApiController
    {
        public async Task<ProductsReponse> Get(Category.CategoryType category)
        {
            string fileName = @"C:\GAP\React\WebAPI-Project-CompanyProducts\CompanyProductsAPI\bin\Resources\ProductsData.json";
            var jsonTextFile = new JsonTextFile(fileName);
            var productRepository = new GenericRepository<Product>(jsonTextFile);

            IQueryable<Product> datos;
            int totalProducts, hiddenProducts;
            switch (category)
            {
                case Category.CategoryType.All:
                    datos = productRepository.GetAll();
                    totalProducts = datos.Count();
                    hiddenProducts = 0;
                    break;

                case Category.CategoryType.Office:
                case Category.CategoryType.Services:
                case Category.CategoryType.Tech:
                    datos = productRepository.GetAll();
                    totalProducts = datos.Count();

                    datos = datos.Where(product => product.Categories.Contains(category.ToString()));
                    hiddenProducts = totalProducts - datos.Count();
                    break;

                default:
                    throw new ArgumentException("The category is not valid");
            }

            var productsReponse = new ProductsReponse(category.ToString(), totalProducts, hiddenProducts, datos.ToList());
            return productsReponse;
        }
    }
}
