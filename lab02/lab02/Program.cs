using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab02
{
    /// <summary>
    /// Абстрактный класс фигур
    /// </summary>
    abstract class Geom_figure : IComparable
    {
        public string Type
        {
            get
            {
                return this._Type;
            }
            protected set
            {
                this._Type = value;
            }
        }
        string _Type;
        public abstract double Area();

        /// <summary>
        /// переопределение метода Object
        /// </summary>

        public override string ToString()
        {
            return this.Type + " площадью " + this.Area().ToString();
        }
        public int CompareTo(object obj)
        {
            Geom_figure p = (Geom_figure)obj;
            if (this.Area() < p.Area()) { return -1; }
                    else if (this.Area() == p.Area()) { return 0; }
            else { return 1; };
        }

    }
    ///<summary>
    /// интерфейс вывода 
    ///</summary>
    
    interface Iprint
    {
        void print();
    }

    /// <summary>
    /// класс прямоугольников 
    /// </summary>

    class Rectangle : Geom_figure
    {
        double weight;
        double height;
        public Rectangle(double ph, double pw)
        {
            weight = pw;
            height = ph;
            this.Type = "Прямоугольник";
        }
        public override double Area()
        {
            double result = this.weight * this.height;
            return result;
        }
        public void print()
        {
            Console.WriteLine(this.ToString());
        }
    }
    class Square : Rectangle, Iprint
    {
        public Square(double size)
            : base(size, size)
        {
            this.Type = "Квадрат";
        }
    }
    class Circle : Geom_figure
    {
        private double radius;
        public Circle(double r)
        {
            this.radius = r;
            this.Type = "круг";
        }
        public override double Area()
        {
            double result;
            result = Math.PI * this.radius * this.radius;
            return result;
        }
        public void  Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
    class Program
    {
        static double inout(string str)
        {
            double f;
            try
            {
                f = double.Parse(str);
                return f;
            }
            catch (Exception e)
            {
                Console.WriteLine("вы ввели не число:" + e.Message);
                Console.WriteLine("подробное описание ошибки:" + e.StackTrace);
                Console.WriteLine("\nпопробуйте снова");
                return 0;
            }
        }
        static void Main(string[] args)
        {
            double heigt, weight,area;
            string str;
            ///<summary>
            ///работа с классом прямоугольников
            /// </summary>
            Console.WriteLine("введите длину прямоугольника: ");
            do
            {
                str = Console.ReadLine();
                heigt = inout(str);
            } while (heigt == 0);
            Console.WriteLine("введите ширину прямоугольника: ");
            do
            {
                str = Console.ReadLine();
                weight = inout(str);
            } while (weight == 0);
            Rectangle rect = new Rectangle(heigt,weight);
            area = rect.Area();
            rect.print();
            

            ///<summary>
            ///работа с классом квадратов
            /// </summary>
            Console.WriteLine("введите длину стороны квадрата: ");
            do
            {
                str = Console.ReadLine();
                heigt = inout(str);
            } while (heigt == 0);
            Square sq = new Square(heigt);
            area = sq.Area();
            sq.print();

            ///<summary>
            ///работа с классом круг
            /// </summary>
            Console.WriteLine("введите длину радиуса круга: ");
            do
            {
                str = Console.ReadLine();
                heigt = inout(str);
            } while (heigt == 0);
            Circle cr = new Circle(heigt);
            cr.Area();
            cr.Print();
            Console.ReadLine();






        }
    }
}
