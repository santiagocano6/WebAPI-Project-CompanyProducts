namespace CompanyProductsAPI.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using DataModels;

    [DataContract]
    public class ProductsReponse
    {
        public ProductsReponse(string category, int totalProducts, int hiddenProducts, ICollection<Product> products)
        {
            Category = category;
            TotalProducts = totalProducts;
            HiddenProducts = hiddenProducts;
            Products = products;
        }

        [DataMember(Name = "category")]
        public string Category { get; }

        [DataMember(Name = "totalproducts")]
        public int TotalProducts { get; }

        [DataMember(Name = "hiddenproducts")]
        public int HiddenProducts { get; }

        [DataMember(Name = "products")]
        ICollection<Product> Products { get; }
    }
}