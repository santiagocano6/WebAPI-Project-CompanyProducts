namespace Data.ORM
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Models;
    using Newtonsoft.Json;

    public class JsonTextFile
    {
        private readonly string FileName;

        public JsonTextFile(string fileName)
        {
            FileName = fileName;
        }

        public IQueryable<T> ReturnData<T>() where T : IRecord
        {
            string path = FileName;
            var reader = new StreamReader(path);
            string json = reader.ReadToEnd();

            var data = JsonConvert.DeserializeObject<ICollection<T>>(json);
            return data.AsQueryable<T>();
        }
    }
}
