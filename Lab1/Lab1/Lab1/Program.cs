using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            double A = 0, B = 0, C=0;
            GetValue('A', out A);
            GetValue('B', out B);
            GetValue('C', out C);
            Console.WriteLine("Введёные числа: А({0}), B({1}), C({2})\n", A, B, C);

            double D = B * B - 4 * A * C;
            double x1, x2;

            if (D >= 0)
            {
                double sq = Math.Sqrt(D);
                x1 = (-B + sq) / (2 * A);
                x2 = (-B - sq) / (2 * A);

                if (D == 0) Console.WriteLine("D = {0}, x1 = x2 = {1}", D, x1);
                else Console.WriteLine("D = {0}, x1 = {1}, x2 = {2}", D, x1, x2);
            }
            else Console.WriteLine("Ошибка. Дискриминант = {0} меньше 0. Корней нет", D);
            
            Console.ReadLine();
        }

        static void GetValue(char name, out double X)
        {
            while (true)
            {
                Console.Write("Введите коэфициент {0}: ", name);
                string str = Console.ReadLine();
                try
                {
                    X = double.Parse(str);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Вы ввели не число: " + e.Message);
                    Console.WriteLine("\nПопробуйте ещё раз");
                    continue;
                }
                break;
            }
        }
    }
}