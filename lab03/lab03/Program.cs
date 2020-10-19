using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab03
{
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
        public void Print()
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

        public class SimpleListItem<T> 
             
        {
            public T data { get; set; }
            public SimpleListItem<T> next { get; set; }

            public SimpleListItem(T param)
            {
                this.data = param;
            }

        }
        public class SimpleList<T> : IEnumerable<T>
            where T : IComparable
        {
            protected SimpleListItem<T> first = null;
            protected SimpleListItem<T> last = null;
            public int count
            {
                get { return _count; }
                protected set { _count = value; }
            }
            int _count;

            public void Add(T element)
            {
                SimpleListItem<T> NewItem = new SimpleListItem<T>(element);
                this.count++;
                if (last == null)
                {
                    this.first = NewItem;
                    this.last = NewItem;
                }
                else
                {
                    this.last.next = NewItem;
                    this.last = NewItem;
                }
                
            }
            public SimpleListItem<T> Getitem(int number)
            {
                if ((number < 0) || (number >= this.count))
                {
                    throw new Exception("Выход за границу индекса");
                }
                SimpleListItem<T> current = this.first;
                int i = 0;
                while(i< number)
                {
                    current = current.next;
                    i++;
                }
                return current;

            }

            public T get(int number)
            {
                return Getitem(number).data;
            }

            public IEnumerator<T> GetEnumerator()
            {
                SimpleListItem<T> current = this.first;

                while(current != null)
                {
                    yield return current.data;
                    current = current.next;
                }
            }
            System.Collections.IEnumerator
                System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            public void Sort()
            {
                Sort(0, this.count - 1);
            }

            private void Sort(int low, int high)
            {
                int i = low;
                int j = high;
                T x = get((low + high) / 2);
                do
                {
                    while (get(i).CompareTo(x) < 0) ++i;
                    while (get(j).CompareTo(x) > 0) --j;
                    if (i == j)
                    {
                        Swap(i, j);
                        ++i; ++j;
                    }
                } while (i <= j);
                if (low < j) Sort(low, j);
                if (i < high) Sort(i, high);
            }

            private void Swap(int i, int j)
            {
                SimpleListItem<T> ci = Getitem(i);
                SimpleListItem<T> cj = Getitem(j);
                T temp = ci.data;
                ci.data = cj.data;
                cj.data = temp;
            }
        }

        public class SimpleStack<T> : SimpleList<T> where T : IComparable
        {
            public void push(T element)
            {
                Add(element);
            }

            public T pop()
            {
                T Resault = default(T);
                if (this.count == 0) return Resault;
                if ( this.count == 1)
                {
                    Resault = this.first.data;
                    this.first = null;
                    this.last = null;
                }
                else
                {
                    SimpleListItem<T> newLast = this.Getitem(this.count-2);
                    Resault = newLast.next.data;
                    this.last = newLast;
                    newLast.next = null;
                }
                this.count--;
                return Resault;
            }
        }



        public interface IMatrixCheckEmpty<T>
        {         
            /// <summary>
            /// Возвращает пустой элемент
            /// </summary> 
            T getEmptyElement(); 

                  
            /// <summary>
            /// /// Проверка что элемент является пустым
            /// /// </summary>
            bool checkEmptyElement(T element);
        } 
            public class Matrix<T>
            {     
                  /// <summary>
                  /// Словарь для хранения значений   
                  /// </summary>
            Dictionary<string, T> _matrix = new Dictionary<string, T>();

                /// <summary>
                /// /// Количество элементов по горизонтали (максимальное количество столбцов)
                /// /// </summary>

            int maxX;

                /// <summary>        
                /// /// Количество элементов по вертикали (максимальное количество строк) 
                /// </summary>
            int maxY;
            int maxZ;

                /// <summary>
                /// /// Реализация интерфейса для проверки пустого элемента 
                /// /// </summary>
                IMatrixCheckEmpty<T> сheckEmpty;

                /// <summary>         /// Конструктор         /// </summary>    
                public Matrix(int px, int py,int pz, IMatrixCheckEmpty<T> сheckEmptyParam)
                {
                    this.maxX = px;
                    this.maxY = py;
                    this.maxZ = pz;
                    this.сheckEmpty = сheckEmptyParam;
                }

                /// <summary>         /// Индексатор для доступа к данных         /// </summary> 
                public T this[int x, int y, int z]
                {
                    set
                    {
                        CheckBounds(x, y,z);
                        string key = DictKey(x, y,z);
                        this._matrix.Add(key, value);
                    }
                    get
                    {
                        CheckBounds(x, y,z);
                        string key = DictKey(x, y,z);
                        if (this._matrix.ContainsKey(key))
                        {
                            return this._matrix[key];
                        }
                        else
                        {
                            return this.сheckEmpty.getEmptyElement();
                        }
                    }
                }

                /// <summary>         /// Проверка границ         /// </summary>
                void CheckBounds(int x, int y,int z)
                {
                    if (x < 0 || x >= this.maxX)
                    {
                        throw new ArgumentOutOfRangeException("x", "x=" + x + " выходит за границы");

                    }
                    if (y < 0 || y >= this.maxY)
                    {
                        throw new ArgumentOutOfRangeException("y", "y=" + y + " выходит за границы");
                    }
                if (z < 0 || z >= this.maxZ)
                {
                    throw new ArgumentOutOfRangeException("z", "z=" + z + " выходит за границы");
                }
                }

                /// <summary>         /// Формирование ключа         /// </summary>
                string DictKey(int x, int y, int z)
                {
                    return x.ToString() + "_" + y.ToString() + "_" + z.ToString();
                }

                ///<summary>         /// Приведение к строке         /// </summary>         /// <returns></returns> 
                public override string ToString()
                {
                    StringBuilder b = new StringBuilder();
                    for (int j = 0; j < this.maxY; j++)
                    {
                        b.Append("[");
                        for (int i = 0; i < this.maxX; i++)
                        {                     //Добавление разделителя-табуляции
                            if (i > 0)
                            {
                                b.Append("\t");
                            }
                        b.Append("[");
                        for (int h = 0; h < this.maxZ; h++)
                        {



                            //Если текущий элемент не пустой
                            if (!this.сheckEmpty.checkEmptyElement(this[i, j, h]))
                            {
                                //Добавить приведенный к строке текущий элемент 
                                b.Append(this[i, j, h].ToString());
                            }
                            else
                            {
                                //Иначе добавить признак пустого значения
                                b.Append(" - ");
                            }
                        }
                        b.Append("]");
                        }
                        b.Append("]\n");



                    }
                    return b.ToString();
                }
            }
        class FigureMatrixCheckEmpry : IMatrixCheckEmpty<Geom_figure>
        {
            public Geom_figure getEmptyElement()
            {
                return null;
            }
            public bool checkEmptyElement(Geom_figure element)
            {
                bool resault = false;
                if(element == null)
                {
                    resault = true;
                }
                return resault;
            }
        }
     
        static void Main(string[] args)
        {
            Rectangle rec = new Rectangle(20, 4);
            Square square = new Square(5);
            Circle cr = new Circle(5);
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++\n");
            Console.WriteLine("Array list");
            ArrayList al = new ArrayList();
            al.Add(rec);
            al.Add(square);
            al.Add(cr);

            foreach (var x in al) Console.WriteLine(x);
            Console.WriteLine("\nsort\n");
            al.Sort();
            foreach (var x in al) Console.WriteLine(x);

            Console.WriteLine("\nList<Geom_figure>");
            List<Geom_figure> fl = new List<Geom_figure>();
            fl.Add(rec);
            fl.Add(square);
            fl.Add(cr);

            foreach (var x in fl) Console.WriteLine(x);
            Console.WriteLine("\nsort\n");
            fl.Sort();
            foreach (var x in fl) Console.WriteLine(x);

            Console.WriteLine("\n++++++++++++++++++++++++++++++++++++++++++++++++++\n");
            Matrix<Geom_figure> mat = new Matrix<Geom_figure>(3,3,3, new FigureMatrixCheckEmpry() );
            mat[0, 0, 0] = rec;
            mat[1, 1, 1] = square;
            mat[2, 2, 2] = cr;
            Console.WriteLine(mat.ToString());
            
            Console.WriteLine("\n++++++++++++++++++++++++++++++++++++++++++++++++++\n");
            SimpleStack<Geom_figure> stack = new SimpleStack<Geom_figure>();
            stack.push(cr);
            stack.push(rec);
            stack.push(square);
            while(stack.count >0)
            {
                Geom_figure f = stack.pop();
                Console.WriteLine(f);
            }
            Console.ReadLine();
            


        }
    }
}
