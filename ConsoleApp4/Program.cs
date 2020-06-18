using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
namespace ConsoleApp4
{/*1.	Створити клас  Person з полями name та age. Перевизначити для нього метод  ToString(). 
    Клас повинен реалізувати інтерфейс IComparable для порівняння об’єктів цього класу за віком. 
2.	Для класу Person додати конструктори, та методи сереалізації-десереалізації в XML форматі
3.	Клас Person повинен реалізувати інтерфейс IDisposable
4.	Створити клас Worker, який наслідує клас Person із завдання 7, додавши до нього поле salary. Створити список рендомних працівників. Посортувати їх 1) по зарплаті, 2) по віку 
*/

    [Serializable]
    class AgeComparer:IComparer
    {
        public int Compare(object ob1,object ob2)
        {
            if(ob1 is Worker&&ob2 is Worker)
            {
                Worker w1 = (Worker)ob1;
                Worker w2 = (Worker)ob2;
                return w1.Age.CompareTo(w2.Age);
            }
            else
            {
                throw new Exception();
            }
        }
    }

    [Serializable]
    class SalaryComparer:IComparer
    {
        public int Compare(object ob1,object ob2)
        {
            if (ob1 is Worker && ob2 is Worker)
            {
                Worker w1 = (Worker)ob1;
                Worker w2 = (Worker)ob2;
                return w1.Salary.CompareTo(w2.Salary);
            }
            else
                throw new Exception();
        }
    }

    [Serializable]
    class Person:IComparable
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return "Name: " + Name + "\n" + "Age: " + Age;
        }
        public override bool Equals(object obj)
        {
            if (obj is Person)
            {
                Person p = (Person)obj;
                return (this.Age == p.Age && this.Name == p.Name);
            }
            else
                return false;
        }
        public int CompareTo(object obj)
        {
            if(obj is Person)
            {
                Person p = (Person)obj;
                return this.Age.CompareTo(p.Age);
            }
            else
            {
                throw new Exception();
            }
        }


        public Person(string Name,int Age)
        {
            this.Name = Name;
            this.Age = Age;

        }
        public Person()
        {
            this.Name = "";
            this.Age = 0;
        }
        public void Serialize()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Person));
            using (FileStream fs = new FileStream(@"C:\Users\lenovo\Desktop\new.xml", FileMode.OpenOrCreate))
            {
                Person i = new Person();
                i.Age = this.Age;
                i.Name = this.Name;
                formatter.Serialize(fs, i);
            }
        }
    }

    [Serializable]
    class Worker:Person,IComparable
    {
        public float Salary { get; set; }
        public Worker():base()
        {

        }
        public Worker( string Name, int Age,float Salary) : base(Name,Age)
        {
            this.Salary = Salary;
        }
        public int CompareTo(object obj)
        {
            if (obj is Worker)
            {
                Worker w = (Worker)obj;
                return this.Salary.CompareTo(w.Salary);
            }
            else
                throw new Exception();
        }
        public override string ToString()
        {
            return base.ToString()+"\n"+"Salary: "+Salary;
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            Worker p1 = new Worker("Volodymyr", 19,2000);
            Person p2 = new Person("Kyryl", 25);
            Worker p3 = new Worker("Pass", 18,100);            //Worker[] arr = { p1, p2, p3 };
            //Array.Sort(arr, new SalaryComparer());
            //foreach (var item in arr)
            //{
            //    Console.WriteLine(item);
            //}
            //Array.Sort(arr, new AgeComparer());
            //Console.WriteLine();
            //foreach (var item in arr)
            //{
            //    Console.WriteLine(item);
            //}

            p2.Serialize();

        }
    }
}
