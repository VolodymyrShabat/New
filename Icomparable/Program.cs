using System;

namespace Icomparable
{
    class Student : IComparable
    {
        public string Group { get; set; }

        public string Name { get; set; }

        public string K { get; }

        public Student(string Group, string Name, string K)
        {
            if (K == "Name" || K == "Group")
            {
                this.Group = Group;
                this.Name = Name;
                this.K = K;
            }
            else
                throw new Exception("Wrong input");

        }

        public Student()
        {
            this.Group = "";
            this.Name = "";
            this.K = "";
        }

        public int CompareTo(object obj)
        {
            if (obj is Student)
            {
                Student st = (Student)obj;
                if (this.K == "Name")
                    return this.Name.CompareTo(st.Name);
                else if (this.K == "Group")
                    return this.Group.CompareTo(st.Group);
                else
                    throw new Exception("Default value of compareble item");
            }
            else
                throw new Exception("Wrong type of data");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student st = new Student();
            Student st1 = new Student("Kyryl", "Pmi-22", "Name");
            Console.WriteLine(st.CompareTo(st1));
        }
    }
}
