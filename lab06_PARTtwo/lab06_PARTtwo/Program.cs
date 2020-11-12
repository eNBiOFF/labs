using System;
using System.Reflection;


namespace lab06_PARTtwo
{
    class Program
    {
        [AttributeUsage(AttributeTargets.Property,AllowMultiple = false,Inherited = false)]
        class new_attribute : Attribute
        {
            public new_attribute() { }
            public new_attribute(string DescriptionParam)
            {
                Description = DescriptionParam;
            }
            public string Description { get; set; }
            

        }

        public static bool GetPropertyAttribute( PropertyInfo checktype,Type attributeType, out object atribute)
        {
            bool resault = false;
            atribute = null;
            var isAttr = checktype.GetCustomAttributes(attributeType, false);
            if (isAttr.Length > 0)
            {
                resault = true;
                atribute = isAttr[0];
            }
            return resault;
        }

        class exmpl : IComparable
        {
            public exmpl() { }
            public exmpl(string str) { }
            public exmpl(int a) { }
            [new_attribute("описание метода meth")]
            public string meth1
            {
                get { return _meth1; }
                set { _meth1 = value; }
            }
            private string _meth1;
            public int Plus(int x,int a) { return x + a; }
            public int minus(int x, int a) { return x - a; }
            [new_attribute("описание метода meth2")]
            public double meth2
            {
                get;
                private set;
            }
            public int meth3
            { get; private set; }

            public int field;
            public int CompareTo(object obj)
            {
                return 0;
            }
            

        }
       
        static void Main(string[] args)
        {
            exmpl ex = new exmpl();
            Type t = ex.GetType();
           
            Console.WriteLine("информация о типе:");
            Console.WriteLine("тип " + t.FullName + " унаследован от " + t.BaseType.FullName);
            Console.WriteLine("Пространстов имен" + t.Namespace);
            Console.WriteLine("сборка" + t.AssemblyQualifiedName);
            Console.WriteLine("\nконстуроры ");
            foreach(var x in t.GetConstructors())
            {
                Console.WriteLine(x.ToString());
            }
            Console.WriteLine("\nметоды");
            foreach(var x in t.GetMethods())
            {
                Console.WriteLine(x.ToString());
            }
            Console.WriteLine("\nсвойства ");
            foreach(var x in t.GetProperties())
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("\nсвойства помеченные атрибутом");
            foreach(var x in t.GetProperties())
            {
                object obj;
                if (GetPropertyAttribute(x,typeof(new_attribute),out obj))
                {
                    new_attribute attr = obj as new_attribute;
                     Console.WriteLine(x.Name + " "+attr.Description.ToString());
                }
            }
            Console.WriteLine("\nполя данных(public)");
            foreach(var x in t.GetFields())
            {
                Console.WriteLine(x.ToString());
            }
            

            ex = (exmpl)t.InvokeMember(null,BindingFlags.CreateInstance,null,null,new object[] { });
            object[] obji= new object[] { 3, 2 };
            object res = t.InvokeMember("Plus", BindingFlags.InvokeMethod,null,ex,obji);
            Console.WriteLine("\nplus(3,2)={0}", res);
            

        }
    }
}
