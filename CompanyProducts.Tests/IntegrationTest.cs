namespace CompanyProductAPI.Tests
{
    using System;
    using System.Configuration;
    using System.Linq;
    using CompanyProducts.DataModels;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Bll = CompanyProducts.Bll;

    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void Configure()
        {
            ConfigurationManager.AppSettings["UseMockFiles"] = bool.TrueString;
        }

        [TestMethod]
        public void Create_MultipleInstances_ReturnsSingleInstance()
        {
            var productsBll = Bll.Products.CreateInstance();
            var productsBll2 = Bll.Products.CreateInstance();

            Assert.AreEqual(productsBll, productsBll2, "Both instances are different");
        }

        [TestMethod]
        public void Get_AllCategories_ReturnsTenRecordsAndZeroHidden()
        {
            Category.CategoryType category = Category.CategoryType.All;
            var productsBll = Bll.Products.CreateInstance();
            productsBll.GetData(category, out IQueryable<Product> datos, out int hiddenProducts, out int shownProducts);

            Assert.AreEqual(10, datos.Count());
            Assert.AreEqual(0, hiddenProducts);
            Assert.AreEqual(10, shownProducts);
        }

        [TestMethod]
        public void Get_TechCategory_Returns7RecordsAnd3Hidden()
        {
            Category.CategoryType category = Category.CategoryType.Tech;
            var productsBll = Bll.Products.CreateInstance();
            productsBll.GetData(category, out IQueryable<Product> datos, out int hiddenProducts, out int shownProducts);

            Assert.AreEqual(7, datos.Count());
            Assert.AreEqual(3, hiddenProducts);
            Assert.AreEqual(7, shownProducts);
        }

        [TestMethod]
        public void Get_ServicesCategory_Returns5RecordsAnd5Hidden()
        {
            Category.CategoryType category = Category.CategoryType.Services;
            var productsBll = Bll.Products.CreateInstance();
            productsBll.GetData(category, out IQueryable<Product> datos, out int hiddenProducts, out int shownProducts);

            Assert.AreEqual(5, datos.Count());
            Assert.AreEqual(5, hiddenProducts);
            Assert.AreEqual(5, shownProducts);
        }

        [TestMethod]
        public void Get_OfficeCategory_Returns5RecordsAnd5Hidden()
        {
            Category.CategoryType category = Category.CategoryType.Office;
            var productsBll = Bll.Products.CreateInstance();
            productsBll.GetData(category, out IQueryable<Product> datos, out int hiddenProducts, out int shownProducts);

            Assert.AreEqual(5, datos.Count());
            Assert.AreEqual(5, hiddenProducts);
            Assert.AreEqual(5, shownProducts);
        }
    }
}
