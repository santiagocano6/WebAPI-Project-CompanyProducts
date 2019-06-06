namespace CompanyProducts.WebAPI.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using CompanyProducts.DataModels;

    [DataContract]
    public class ProductsReponse
    {
        public ProductsReponse(string category, int shownProducts, int hiddenProducts, ICollection<Product> products)
        {
            Category = category;
            ShownProducts = shownProducts;
            HiddenProducts = hiddenProducts;
            Products = products;
        }

        [DataMember(Name = "category")]
        public string Category { get; }

        [DataMember(Name = "shownproducts")]
        public int ShownProducts { get; }

        [DataMember(Name = "hiddenproducts")]
        public int HiddenProducts { get; }

        [DataMember(Name = "products")]
        ICollection<Product> Products { get; }
    }
}