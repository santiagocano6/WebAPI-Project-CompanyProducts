namespace CompanyProductsAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using Data;
    using Data.ORM;
    using Models;

    public class ProductsController : ApiController
    {
        public IEnumerable<Product> Get(Category.CategoryType category)
        {
            string fileName = @"C:\GAP\React\WebAPI-Project-CompanyProducts\CompanyProductsAPI\bin\Resources\ProductsData.json";
            var jsonTextFile = new JsonTextFile(fileName);
            var productRepository = new GenericRepository<Product>(jsonTextFile);

            IQueryable<Product> datos;

            switch (category)
            {
                case Category.CategoryType.All:
                    datos = productRepository.GetAll();
                    break;

                case Category.CategoryType.Office:
                case Category.CategoryType.Services:
                case Category.CategoryType.Tech:
                    datos = productRepository.Find(product => product.Categories.Contains(category.ToString()));
                    break;

                default:
                    throw new ArgumentException("The category is not valid");
            }

            return datos.ToList();
        }
    }
}
