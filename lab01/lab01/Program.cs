using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab01
{
    class Program
    {
        static void Main(string[] arg)
        {
            
            double a = ReadDouble("Введите коэффициент А: ");
            //Console.WriteLine("Вы ввели коэффициент А = " + a);
            double b = ReadDouble("Введите коэффициент B: ");
            double c = ReadDouble("Введите коэффициент С: ");
            double x1, x2;
            x1 = 0;
            x2 = 0;
            printResault(x1, x2,a,b,c);

            Console.ReadLine();
        } 
 
        /// <summary>
        /// Вывод параметров командной строки
        /// </summary>
        /// <param name="args"></param>
        static void CommandLineArgs(string[] args)
        { 
 
            /*   
             *   Необходимо установить параметры командной строки (несколько слов через пробел)
             *   в пункте меню "Project", "название проекта Properties"
             *   вкладка "Debug", поле ввода "Command Line Arguments"
             *   */
             
 
            //Вывод параметров командной строки 1
            Console.WriteLine("\nВывод параметров командной строки 1:");
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine("Параметр [{0}] = {1}", i, args[i]);
            } 
 
  
            //Вывод параметров командной строки 2   
            Console.WriteLine("\nВывод параметров командной строки 2:");
            int i2 = 0;
            foreach (string param in args) 
            {
                Console.WriteLine("Параметр [{0:F5}] = {1}", i2, param);
                i2++;  
            }

        } 

        ///<summary>
        ///ввод вещественного числа
        ///</summary>
        ///<param name="message">Подсказка при вводе</param>
        ///<returns></returns>
        
        static double ReadDouble(string message)
        {
            string resaultString;
            double resaultDouble;
            bool flag;

            do
            {
                Console.Write(message);
                resaultString = Console.ReadLine();

                //Первый способ
                flag = double.TryParse(resaultString, out resaultDouble);

                //второй споособ с catch
                if (!flag)
                {
                    Console.WriteLine(" Необходимо ввети вещественное число");
                }
            } while (!flag);
            return resaultDouble;
        }

        /// <summary>
        /// вывод корней квадратного уравнения
        /// </summary>
        /// <param name="x1">первый корень</param> 
        /// <param name="x2">второй корень</param>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        static void printResault(double x1, double x2, double a, double b, double c)
        {
            double D;
            D = (b * b - 4 * c*a);
            if (D<0)
            {
                Console.WriteLine("Корней не существует");
            }
            if (D==0)
            {
                x1 = (b*(-1) - Math.Sqrt(D)) / (2 * a);
                Console.WriteLine("Корень уравнения: " + x1);
            }
            if (D > 0)
            {
                x1 = (b*(-1) - Math.Sqrt(D)) / (2 * a);
                x2 = (b*(-1) + Math.Sqrt(D)) / (2 * a);
                if ((x1 >= 0) && (x2 >= 0))
                {
                    Console.WriteLine("Первый корень уравнения: +" + Math.Sqrt(x1).ToString());
                    Console.WriteLine("Второй корень уравнения: -" + Math.Sqrt(x1).ToString());
                    Console.WriteLine("Третий корень уравнения: +" + Math.Sqrt(x2).ToString());
                    Console.WriteLine("Четвертый корень уравнения: -" + Math.Sqrt(x2).ToString());
                }
                else
                {
                    bool f;
                    f = true;
                    if(x1<0)
                    {
                        if (x2 < 0) 
                        {
                            f = false;
                        }
                        else
                        {
                            Console.WriteLine("Первый корень уравнения: +" + Math.Sqrt(x2).ToString());
                            Console.WriteLine("Первый корень уравнения: -" + Math.Sqrt(x2).ToString());
                        }
                    }
                    if (x2 < 0)
                    {
                        if (x1 < 0)
                        {
                            f = false;
                        }
                        else
                        {
                            Console.WriteLine("Первый корень уравнения: +" + Math.Sqrt(x1).ToString());
                            Console.WriteLine("Первый корень уравнения: -" + Math.Sqrt(x1).ToString());
                        }
                    }
                    if (f==false)
                    {
                        Console.WriteLine("Корней нет");
                    }
                }
            }
        }


    }
}

