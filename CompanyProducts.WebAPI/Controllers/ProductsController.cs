namespace CompanyProducts.WebAPI.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;
    using CompanyProducts.WebAPI.Models;
    using CompanyProducts.Data;
    using CompanyProducts.Data.ORM;
    using CompanyProducts.DataModels;

    public class ProductsController : ApiController
    {
        public ProductsReponse Get(Category.CategoryType category)
        {
            string fileName = @"C:\GAP\React\WebAPI-Project-CompanyProducts\CompanyProducts.WebAPI\bin\Resources\ProductsData.json";
            var jsonTextFile = new JsonTextFile(fileName);
            var productRepository = new GenericRepository<Product>(jsonTextFile);

            IQueryable<Product> datos;
            int totalProducts, hiddenProducts, shownProducts;
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

            shownProducts = totalProducts - hiddenProducts;

            var productsReponse = new ProductsReponse(category.ToString(), shownProducts, hiddenProducts, datos.ToList());
            return productsReponse;
        }
    }
}
