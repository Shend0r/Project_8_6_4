using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Project_8_6_4.Binaries
{
    [Serializable]
    internal class Data
    {
        public Data() { }

        public static object Read(string FilePath)
        {
            var chekFile = System.IO.File.Exists(FilePath);
            var setData = default(object);

            if (chekFile == true)
            {
                using (var fileStream = new System.IO.FileStream(FilePath, System.IO.FileMode.OpenOrCreate))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    setData = formatter.Deserialize(fileStream);
                }
            }
            else
            {
                Console.WriteLine("Файл {0} отсутствует, не удалось извлечь данные.", FilePath);
            }

            return setData;
        }

        public static void Write(string FilePath, string Data)
        {
            using (var fileStream = new System.IO.FileStream(FilePath, System.IO.FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, Data);
            }
        }
    }
}
