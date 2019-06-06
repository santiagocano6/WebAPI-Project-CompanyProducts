namespace CompanyProducts.Data.ORM
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using CompanyProducts.DataModels;
    using Newtonsoft.Json;

    public sealed class JsonTextFile
    {
        private readonly object fileLock = new object();
        private readonly string FileName;

        public JsonTextFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("fileName", "fileName from JsonTextFile cannot null neither empty");
            }

            FileName = fileName;
        }

        public IQueryable<T> ReturnData<T>() where T : IRecord
        {
            string json;
            lock (fileLock)
            {
                var reader = new StreamReader(FileName);
                json = reader.ReadToEnd();
            }

            var data = JsonConvert.DeserializeObject<ICollection<T>>(json);
            return data.AsQueryable<T>();
        }
    }
}
