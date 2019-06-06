using System;
namespace CompanyProducts.Bll
{
    using System.Configuration;

    public static class Common
    {
        private static bool UseMockFiles => ConfigurationManager.AppSettings["UseMockFiles"].ToLower() == bool.TrueString.ToLower();

        public static string GetProductFilePath()
        {
            if (UseMockFiles)
            {
                return $@"{AppDomain.CurrentDomain.BaseDirectory}\Resources\ProductsData.json";
            }
            else
            {
                return ConfigurationManager.AppSettings["JsonProductsFilePath"];
            }
        }
    }
}
