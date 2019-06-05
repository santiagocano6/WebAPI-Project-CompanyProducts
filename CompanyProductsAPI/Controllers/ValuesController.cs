namespace CompanyProductsAPI.Controllers
{
    using Models;
    using System.Collections.Generic;
    using System.Web.Http;

    public class ProductsController : ApiController
    {
        public IEnumerable<Product> Get(Category.CategoryType category)
        {
            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "This is my name",
                    Description = "This is my description",
                    Brand = "This is my brand",
                    PhotoUrl = "https://thisismyurl.com",
                    Price = 1000000,
                    Stock = 12312312,
                    Categories = new List<string> { "Office", "Services" }
                }
            };

            return products;
        }
    }
}
