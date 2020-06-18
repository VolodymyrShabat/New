using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace ConsoleApp5
{
    [Serializable]
    public class Person
    {
        bool disposed = false;
        public string Name { get; set; }
        public int Age { get; set; }

        // стандартный конструктор без параметров
        public Person()
        { }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
   
        public void Serialize()
        {

            XmlSerializer formatter = new XmlSerializer(typeof(Person));
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(@"C:\Users\lenovo\Desktop\persons.xml", FileMode.OpenOrCreate))
            {
                Person i = new Person();
                i.Age = this.Age;
                i.Name = this.Name;
                formatter.Serialize(fs, i);
                Console.WriteLine("Объект сериализован");
            }
        }
        public void Deserialize()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Person));
            using (FileStream fs = new FileStream(@"C:\Users\lenovo\Desktop\persons.xml", FileMode.OpenOrCreate))
            {
                Person newPerson = (Person)formatter.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Имя: {newPerson.Name} --- Возраст: {newPerson.Age}");
            }
        }

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
        //protected virtual void Dispose(bool disposing)
        //{
        //    if (disposed)
        //        return;
        //    if(disposing)

        //}
    }
    class Program
    {
        static void Main(string[] args)
        {
            // объект для сериализации
            Person person = new Person("kyryl", 19);
            Console.WriteLine("Объект создан");
            person.Serialize();
            person.Deserialize();
            // передаем в конструктор тип класса
            

            // десериализация
            
        }
    }
}
