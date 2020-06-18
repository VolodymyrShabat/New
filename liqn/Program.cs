using System;
using System.Linq;
namespace liqn
{

    
    class A
    {
       public void fun()
        {
            Console.WriteLine("Welcome");
        }
       
    }
    class B : A 
    {
        public void fun()
        {
            base.fun();
            Console.WriteLine("Welcome TO Softserve");
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            B b = new B();
            b.fun();
            int a = new int();
            Console.WriteLine(a);
        }
    }
}
