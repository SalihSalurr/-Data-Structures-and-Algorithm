using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Power_Sum
{
    class Program
    {
        static int powerSum(int X, int N, int num = 1)
        {
            int temp = power(num, N);
            if (power(num, N) == X)
            {
                return 1;
            }
            else if (power(num, N) > X)
            {
                return 0;
            }
            else
            {
                return powerSum(X, N, num + 1) + powerSum(X - temp, N, num + 1);
            }
        }

        static int power(int x, int exp)
        {
            return exp == 1 ? x : x * power(x, exp - 1);
        }

        static void Main(String[] args)
        {
            int X = Convert.ToInt32(Console.ReadLine());
            int N = Convert.ToInt32(Console.ReadLine());
            int result = powerSum(X, N);
            Console.WriteLine(result);
        }
    }
}
