using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;


namespace LINQQ
{
    class Program
    {
        public class Sotrudnik
        {
            //поля требуемые по условию
            public int id { get; set; }
            public string sername { get; set; }
            public int id_link { get; set; }
            //конструкторы
            public Sotrudnik() { }
            public Sotrudnik(int i, string name, int i_l)
            {
                id = i;
                sername = name;
                id_link = i_l;
            }
            
        }
        public class Otdel
        { 
            //поля требуемые по условию
            public int id { get; set; }
            public string name { get; set; }
           
        }
        public class Sot_otd
        {
            public int id { get; set; }
            public int id_sotr { get; set; }
            public int id_otdl { get; set; }

            public Sot_otd(int id1 , int id2)
            {
                id_sotr = id1;
                id_otdl = id2;
            }
            public Sot_otd()
            {

            }
        }
        //контекст для бд
        class sotr_context : DbContext
        {
            static sotr_context()
            {
                Database.SetInitializer(new MyContexInitializer());
            }
            public sotr_context() : base("DefaultConnection")
            { }
            public DbSet<Otdel> otdels { get; set; }
            public DbSet<Sotrudnik> sotrudniks { get; set; }
            public DbSet<Sot_otd> Sotdl { get; set; }
        }
        //инициализация данных
        class MyContexInitializer : DropCreateDatabaseAlways<sotr_context>
        {
            protected override void Seed(sotr_context db)
            {
                Otdel o1 = new Otdel() { name = "Информационная безопасность" };
                Otdel o2 = new Otdel() { name = "Бухгалтерия" };
                Otdel o3 = new Otdel() { name = "Отдел кадров" };

                db.otdels.Add(o1);
                db.otdels.Add(o2);
                db.otdels.Add(o3);
                db.SaveChanges();

                Sotrudnik s1 = new Sotrudnik() { sername = "Аванов", id_link = o1.id };
                Sotrudnik s2 = new Sotrudnik() { sername = "Апшин", id_link = o1.id };
                Sotrudnik s3 = new Sotrudnik() { sername = "Каркин", id_link = o2.id };
                Sotrudnik s4 = new Sotrudnik() { sername = "Борзов", id_link = o2.id };
                Sotrudnik s5 = new Sotrudnik() { sername = "Пак", id_link = o3.id };
                Sotrudnik s6 = new Sotrudnik() { sername = "Атепанов", id_link = o3.id };

                db.sotrudniks.AddRange(new List<Sotrudnik>() { s1, s2, s3, s4, s5, s6 });
                db.SaveChanges();

                Sot_otd so1 = new Sot_otd() { id_sotr = s1.id, id_otdl = o1.id };
                Sot_otd so2 = new Sot_otd() { id_sotr = s2.id, id_otdl = o1.id };
                Sot_otd so3 = new Sot_otd() { id_sotr = s3.id, id_otdl = o2.id };
                Sot_otd so4 = new Sot_otd() { id_sotr = s4.id, id_otdl = o2.id };
                Sot_otd so5 = new Sot_otd() { id_sotr = s5.id, id_otdl = o3.id };
                Sot_otd so6 = new Sot_otd() { id_sotr = s6.id, id_otdl = o3.id };
                db.Sotdl.AddRange(new List<Sot_otd>() { so1, so2, so3, so4, so5, so6 });
                db.SaveChanges();
            }
        }
        static public bool all_value(IQueryable<Sotrudnik> list, Otdel otdl)
        {
            
            foreach(var t in list)
            {
                if(otdl.id == t.id_link)
                if (!t.sername.StartsWith("А")) return false; 
            }
            return true;
        }


        static void Main(string[] args)
        {
            using(sotr_context db = new sotr_context())
            {
               //***********************************************************************************************
                var list =
                    from otdl in db.otdels
                    join sotr in db.sotrudniks on otdl.id equals sotr.id_link into sotrgroup
                    orderby otdl.name
                    select new { ot=otdl, stgr = sotrgroup, stgrcount=sotrgroup.Count() };

                foreach(var otdl in list)
                {
                    Console.WriteLine(" отдел и сотрудники в нем:\n");
                    Console.WriteLine(otdl.ot.name);
                    foreach(var sotr in otdl.stgr)
                    {
                        Console.WriteLine(sotr.sername);
                    }
                    Console.Write("\n");
                }
                Console.WriteLine("cписок сотрудников, у которых фамилия начинается с буквы А" );
                //***********************************************************************************************
                var list_sotr_a =
                    from sotr in db.sotrudniks
                    where sotr.sername.StartsWith("А") == true
                    select sotr;

                foreach(var sotr in list_sotr_a)
                {
                    Console.WriteLine(sotr.sername);
                }

                Console.WriteLine("список отделов, в котором хотя бы у одного сотрудника фамилия начинается на А:\n");
                //***********************************************************************************************
                var list_otdl_sername_aAny =
                    from otdl in db.otdels
                    join sotr in list_sotr_a on otdl.id equals sotr.id_link into sotrA_tmp
                    select new { Name = otdl, sotrcount_a = sotrA_tmp };

                foreach(var ls in list_otdl_sername_aAny)
                {
                    if (ls.sotrcount_a.Count() > 0) Console.WriteLine(ls.Name.name);
                }

                Console.WriteLine("список отделов, в которых у все сотрудников фамилия начинается на А:\n");
                //*********************************************************************************************
                var list_otdl_sername_a =
                    from otdel in list
                    join sotr in list_sotr_a on otdel.ot.id equals sotr.id_link into tmp_sotr
                    select new {otd=otdel, tmp_sotr=tmp_sotr };

                foreach(var ls in list_otdl_sername_a)
                {
                    if (ls.otd.stgrcount == ls.tmp_sotr.Count()) Console.WriteLine(ls.otd.ot.name);
                }
                //*********************************************************************************************
                Console.WriteLine("\nсписок отделов и количество сотрудников в нем:\n");

                foreach(var ls in list)
                {
                    Console.WriteLine(ls.ot.name + ' ' + ls.stgrcount.ToString());
                }
                //*********************************************************************************************

                Console.WriteLine("\nвыборка всех сотрудников и отделов с учетом связи многие-ко-многим \n");
               
            }
            using (sotr_context db = new sotr_context())
            {
                var mn_list =
                   from otdl in db.otdels
                   join link_id_sotr in db.Sotdl on otdl.id equals link_id_sotr.id_otdl into tmp_id_sotr
                   from t in tmp_id_sotr
                   join sotr in db.sotrudniks on t.id_sotr equals sotr.id
                   group sotr by otdl.name;
                  
                

                foreach (var ls in mn_list)
                {
                    Console.WriteLine(ls.Key);
                    foreach (var ls_sotr in ls)
                    {
                        Console.WriteLine(ls_sotr.sername);

                    }
                }
                //******************************************************************************************
                Console.WriteLine("\nсписок отделов и количесво сотрудников в них\n");
                var mn_list_count =
                   from otdl in db.otdels
                   join link_id_sotr in db.Sotdl on otdl.id equals link_id_sotr.id_otdl into tmp_id_sotr
                   select new { otdl_name = otdl.name, sotr_count = tmp_id_sotr.Count() };

                foreach(var ls in mn_list_count)
                {
                    Console.WriteLine(ls.otdl_name + ' ' + ls.sotr_count);
                }

            }

            Console.ReadLine();
        }
    }
}
