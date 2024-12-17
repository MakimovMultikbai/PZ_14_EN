using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class CsvAdapter<T> : IDataStorageAdapter<T> where T : class, new()
    {
        private readonly CsvAdapterSettings settings;

        public CsvAdapter(CsvAdapterSettings settings)
        {
            this.settings = settings;
        }

        public List<T> Load(string filePath)
        {
            var data = new List<T>();

            if (!File.Exists(filePath))
                return data;

            var lines = File.ReadAllLines(filePath);
            if (settings.HasHeaders)
            {
                lines = lines.Skip(1).ToArray();
            }

            foreach (var line in lines)
            {
                if (typeof(T) == typeof(Product))
                {
                    var product = Product.FromCsv(line) as T;
                    if (product != null)
                        data.Add(product);
                }
                else
                {
                    throw new NotImplementedException("Сериализация других типов не поддерживается.");
                }
            }

            return data;
        }

        public void Save(string filePath, List<T> data)
        {
            var lines = new List<string>();

            if (settings.HasHeaders)
            {
                lines.Add("Id,Name,Price");
            }

            lines.AddRange(data.Select(d => d.ToString()));
            File.WriteAllLines(filePath, lines);
        }
    }

    public class CsvAdapterSettings
    {
        public bool HasHeaders { get; set; } = true;
    }
}
