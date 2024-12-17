using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Facade
{
    public class XmlAdapter<T> : IDataStorageAdapter<T> where T : class, new()
    {
        public List<T> Load(string filePath)
        {
            if (!File.Exists(filePath))
                return new List<T>();

            try
            {
                var serializer = new XmlSerializer(typeof(List<T>));
                using (var reader = new StreamReader(filePath))
                {
                    return (List<T>)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при загрузке данных из XML файла: {ex.Message}");
            }
        }

        public void Save(string filePath, List<T> data)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<T>));
                using (var writer = new StreamWriter(filePath))
                {
                    serializer.Serialize(writer, data);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при сохранении данных в XML файл: {ex.Message}");
            }
        }
    }
}
