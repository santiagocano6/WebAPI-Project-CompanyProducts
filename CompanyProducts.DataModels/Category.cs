namespace CompanyProducts.DataModels
{
    using System;

    public class Category
    {
        public enum CategoryType
        {
            Undefined = 0,
            All = 1,
            Tech = 2,
            Services = 3,
            Office = 4
        }

        public static CategoryType GetCategoryType(string category)
        {
            if (Enum.TryParse(category, out CategoryType categoryValue))
            {
                return categoryValue;
            }

            return CategoryType.Undefined;
        }
    }
}
