namespace CompanyProducts.Data.ORM
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using CompanyProducts.DataModels;
    using Newtonsoft.Json;

    public class JsonTextFile
    {
        private readonly object fileLock = new object();
        private readonly string FileName;

        public JsonTextFile(string fileName)
        {
            FileName = fileName;
        }

        public IQueryable<T> ReturnData<T>() where T : IRecord
        {
            string json;
            lock (fileLock)
            {
                string path = FileName;
                var reader = new StreamReader(path);
                json = reader.ReadToEnd();
            }

            var data = JsonConvert.DeserializeObject<ICollection<T>>(json);
            return data.AsQueryable<T>();
        }
    }
}
