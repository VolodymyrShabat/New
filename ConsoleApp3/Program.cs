using System;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace ConsoleApp3
{
    class Program
    {/*5.	Сериалізувати отримані послідовності із завдань 1 і 3 у бінарному формати у файл*/
        static void Main(string[] args)
        { 

            BinaryFormatter formatter = new BinaryFormatter();
            using(FileStream fs = new FileStream(@"C:\Users\lenovo\Desktop\new.txt",FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, '1');
            }
            
        }
    }
}
