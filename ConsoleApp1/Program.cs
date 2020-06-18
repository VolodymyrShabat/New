using System;
using System.Linq;
/*1.	Linq: Задана цілочисельна послідовність.
 * Витягнути в іншу послідовність всі непарні числа, 
 * зберігаючи початковий порядок елементів 
 * і видаливши всі входження (крім першого) елементів, які повторюються*/
namespace ConsoleApp1
{

    class Program
    {
        static void Main(string[] args)
        {

            int[] arr = { 11,1, 1,4, 5, 3, 2, -2, 4, 5, 2, 66, 213, 532, 2, 44, 5, 7, 99, 3 };
            var result = (from number in arr
                     where number % 2 == 1
                     select number).Distinct().ToList();
            
            foreach (var item in result)
            {
                Console.WriteLine(item) ;

            }
           
        }
    }
}