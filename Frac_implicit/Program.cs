using System;
using System.Data;

namespace Frac_implicit
{
    class Frac
    {
        public int Up { get; set; }
        public int Down { get; }

        public Frac(int Up=0,int Down=1)
        {
            if (Down == 0)
                throw new DivideByZeroException();
            else
            {
                this.Up = Up;
                this.Down = Down;
            }
        }
        public static implicit operator Frac(int n) 
        {
            return new Frac(n);
        }
        public static implicit operator int(Frac f)
        {
            return (int)(f.Up/f.Down);
        }
        public override string ToString()
        {
            return Up + "/" + Down;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Frac f = new Frac(1, 2);
            int t = f;
            Frac l = t;
            Console.WriteLine(t);
            Console.WriteLine(f);
        }
    }
}
