using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public interface IDataStorageAdapter<T>
    {
        List<T> Load(string filePath);
        void Save(string filePath, List<T> data);
    }
}
