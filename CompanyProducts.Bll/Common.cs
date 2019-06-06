using System;
namespace CompanyProducts.Bll
{
    using System.Configuration;

    public static class Common
    {
        public static bool UseMockFiles => ConfigurationManager.AppSettings["UseMockFiles"] == bool.TrueString.ToLower();

        public static string GetProductFilePath()
        {
            if (UseMockFiles)
            {
                return $@"{AppDomain.CurrentDomain.BaseDirectory}Resources\ProductsData.json";
            }
            else
            {
                return ConfigurationManager.AppSettings["JsonProductsFilePath"];
            }
        }
    }
}
