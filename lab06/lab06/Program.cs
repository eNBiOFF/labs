using System;

namespace lab06
{
    class Program
    {

        delegate void del(int a, string b);

        static void plus(int a, string b)
        {
            int z;
            z = 0;
            if ((int.TryParse(b, out z) == true) )
            {
                z = a + z;
                Console.WriteLine("cумма чисел = " + z);
                
            }
            else
            {
                Console.WriteLine("вы ввели не число");
            }
        }
        static void minus(int a,string b)
        {
            int z;
            z = 0;
            if ((int.TryParse(b, out z) == true))
            {
                z = z - a;
                Console.WriteLine("рзность чисел = " + z);

            }
            else
            {
                Console.WriteLine("вы ввели не число");
            }

        }

        static void del_meth(del delpar)
        {
            string d;
            Console.WriteLine("введите целове число:");
            d=Console.ReadLine();
            delpar(5, d);
        }

        

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            del dili;
            string str;
            Console.WriteLine("введите целое число");
            str = Console.ReadLine();
            dili = plus;
            dili(5, str);
            del_meth(plus);
            del_meth(minus);
            del lumbda = (a, b) => { Console.WriteLine("шалость удалась! наши числа:" + b.ToString() + ' ' + a.ToString()); };
            del_meth(lumbda);
        }
    }
}
