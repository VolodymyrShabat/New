using System;

namespace ConsoleApp2
{
    /*3.	Написати функцію з двома параметрами – список чисел і предикат. 
     * Функція повинна повернути суму тих членів послідовності, які задовільняють предикат.*/
/*6.    Створити вдасний делегат для завдання 3 і 
 * перевірити виконання цього завдання для двох предикатів – перший перевіряє чи число є парним, 
 * другий – перевіряє чи число є повним квадратом іншого цілого числа.*/
class Program
{
    static bool IsPrime(int number)
    {
        if (number == 0 || number == 1 || number == 2)
            return true;
        else
        {
            for (int i = 2; i < Math.Sqrt(number)+1; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
    }
    static Predicate<int> IfPrime = IsPrime;/*delegate(int x) { return IsPrime(x); };*/
    static Predicate<int> IfSquare = IsSquare;/*delegate(int x) { return IsSquare(x); } ;*/
    delegate int Mydelegate(int[]arr, Predicate<int> p);
    static bool IsSquare(int number)
    {
        if (number == 0 || number == 1)
            return true;
        else
        {
                for (int i = 1; i * i <= number; i++)
                {

                    // If (i * i = n) 
                    if ((number % i == 0) && (number / i == i))
                    {
                        return true;
                    }
                }
                return false;
            }
    }

    static int func(int[] arr, Predicate<int> IfPrime)
    {
        int sum = 0;
        foreach (var item in arr)
        {
            if(IfPrime(item))
            {
                sum += item;
            }
        }
        return sum;
    }
   

        static void Main(string[] args)
    {
            int n = 12;
            Console.WriteLine(IfPrime(n));
            int[] arr = { 1, 2, 3, 4, 5, 6 };
            Mydelegate p = func;
            int res = p(arr, IfPrime);
            Console.WriteLine(res);
            res= p(arr, IfSquare);
            Console.WriteLine(res);
        }
}
}
