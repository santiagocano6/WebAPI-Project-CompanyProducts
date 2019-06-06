namespace CompanyProducts.WebAPI.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using CompanyProducts.WebAPI.Models;
    using CompanyProducts.DataModels;
    using Bll = CompanyProducts.Bll;

    public class ProductsController : ApiController
    {
        public ProductsReponse Get(Category.CategoryType category)
        {
            var productsBll = Bll.Products.CreateInstance();
            productsBll.GetData(category, out IQueryable<Product> datos, out int hiddenProducts, out int shownProducts);

            var productsReponse = new ProductsReponse(category.ToString(), shownProducts, hiddenProducts, datos.ToList());
            return productsReponse;
        }
    }
}
