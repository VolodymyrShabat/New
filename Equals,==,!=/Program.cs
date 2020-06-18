using System;

namespace Equals______
{
    class Complex
    {
        public double Real { get; set; }
        public double Imagine { get; set; }
        public Complex(int Real=0,int Imagine=0)
        {
            this.Real = Real;
            this.Imagine = Imagine;
        }
        public override bool Equals(object obj)
        {
            if (obj is Complex)
            {
                Complex c = (Complex)obj;
                return this.Imagine == c.Imagine && this.Real == c.Real;
            }
            else
                throw new TypeLoadException();
        }

        public static bool operator ==(Complex c1,Complex c2)
        {
            return c1.Equals(c2);
        }
        public static bool operator !=(Complex c1, Complex c2)
        {
            return !c1.Equals(c2);
        }

        public override string ToString()
        {
            if (Imagine > 0)
                return Real + "+" + Imagine + "i";
            else if (Imagine < 0)
                return Real +""+ Imagine + "i";
            else
                return Real.ToString();
        }

        public override int GetHashCode()
        {
            //return this.ToString().GetHashCode();
            return HashCode.Combine(Real, Imagine);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Complex c1 = new Complex(1, 2);
            Complex c2 = new Complex(1, -2);
            Console.WriteLine(c1==c2);
            Console.WriteLine(c1);
            Console.WriteLine(c2);
            
        }
    }
}
