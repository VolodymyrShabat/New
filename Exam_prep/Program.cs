using System;
using System.Text;
using System.IO;
namespace Exam_prep
{/*2.	Зчитати вміст файлу, де задані числа  в шістнадцятковій системі числення
 AAFF    BCDF     1FF4    123D9     CC11D3
Отримати їх суму і вивести на консоль у вісімковій системі.
*/
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fStream = File.OpenRead(@"C:\Users\lenovo\Desktop\files.txt"))
            {
                byte[] array = new byte[fStream.Length];
                fStream.Read(array, 0, array.Length);
                string[] text=Encoding.ASCII.GetString(array).Split("    ");
                int sum = 0;
                for (int i = 0; i < text.Length; i++)
                {
                    sum += Convert.ToInt32(text[i],16);
                }
                Console.WriteLine(sum);
                Console.WriteLine(Convert.ToString(sum, 8));
            }
            Console.WriteLine("Hello World!");
        }
    }
}
