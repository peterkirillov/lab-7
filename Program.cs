using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Lab7
{
    class Program
    {
        static List<Worker> workers = new List<Worker>()
            {
                new Worker(1, "Андреев", 23),
                new Worker(2, "Болотин", 27),
                new Worker(3, "Лосева", 24),
                new Worker(4, "Громов", 25),
                new Worker(5, "Афанасьев", 23),
                new Worker(6, "Саадуев", 26),
                new Worker(7, "Зенгер", 27),
                new Worker(8, "Цветкова", 25),
                new Worker(9, "Нурлыева", 24),
                new Worker(10, "Фадеев", 23),
                new Worker(11, "Кочкин", 27),
                new Worker(12, "Корнеева", 26),
                new Worker(13, "Абросимова", 25),
                new Worker(14, "Желанкина", 24),
                new Worker(15, "Шевчук", 23),
                new Worker(16, "Соколов", 27),
                new Worker(17, "Коционова", 26),
                new Worker(18, "Кулаков", 27),
                new Worker(19, "Силаев", 24),
                new Worker(20, "Чиженков", 23)
            };

        static List<Department> deps = new List<Department>()
        {
            new Department(23, "Литература"),
            new Department(24, "Программирование"),
            new Department(25, "Музыка"),
            new Department(26, "Рисование"),
            new Department(27, "Физика"),
        };

        static List<workers_department> w_d = new List<workers_department>()
            {
                new workers_department(1 , 23),
                new workers_department(2 , 27),
                new workers_department(3 , 24),
                new workers_department(4 , 25),
                new workers_department(5 , 23),
                new workers_department(6 , 26),
                new workers_department(7 , 27),
                new workers_department(8 , 25),
                new workers_department(9 , 24),
                new workers_department(10 , 23),
                new workers_department(11 , 27),
                new workers_department(12 , 26),
                new workers_department(13 , 25),
                new workers_department(14 , 24),
                new workers_department(15 , 23),
                new workers_department(16 , 27),
                new workers_department(17 , 26),
                new workers_department(18 , 27),
                new workers_department(19 , 24),
                new workers_department(20 , 23)
            };







        static void Main(string[] args)
        {
            Console.WriteLine("Просмотрите результаты для всех запросов со ссылкой 1:M\n");
            Console.WriteLine("Список всех работников и отделов, отсортированных по подразделениям: ");

            var que1 = from x in workers
                       orderby x.ID_Dep descending, x.ID_W descending
                       select x;
            foreach (var x in que1) Console.WriteLine(x);


            Console.WriteLine("\nСписок всех работников с первым «А» в фамилии: ");

            var que2 = from x in workers
                       where x.Surname[0] is 'A'
                       orderby x.Surname ascending, x.ID_W descending
                       select x;
            foreach (var x in que2)
                Console.WriteLine(x);


            Console.WriteLine("\nИнформация обо всех отделах и о количестве работников в каждом: ");

            var que3 = from x in deps
                       join y in workers on x.ID_Dep equals y.ID_Dep into temp
                       from t in temp
                       select new { Department = x.Name_Dep, ID = x.ID_Dep, count = temp.Count() };
            que3 = que3.Distinct();
            foreach (var x in que3)
                Console.WriteLine(x);


            Console.WriteLine("\nСписок отделов, в которых все рабочие фамилии начинаются с буквы «A»: ");
            var que4 = from x in workers
                       join y in que2 on x.ID_Dep equals y.ID_Dep into temp
                       from t in temp
                       select new { ID_of_Department = x.ID_Dep, count = temp.Count() };
            que4 = que4.Distinct();
            var que4_2 = from x in que3
                         from y in que4
                         where (x.count == y.count) && (x.ID == y.ID_of_Department)
                         select new { ID_of_Department = x.ID };
            que4_2 = que4_2.Distinct();
            foreach (var x in que4_2)
                Console.WriteLine(x);

            Console.WriteLine("\nСписок отделов, в которых по крайней мере один рабочий " +
                 "имеет фамилию, начинающуюся с «A»: ");
            var que5 = from x in workers
                       where x.Surname[0] is 'A'
                       select new { v1 = x.ID_Dep };
            que5 = que5.Distinct();
            var que5_2 = from x in deps
                         from y in que5
                         where x.ID_Dep == y.v1
                         select new { v1 = x.Name_Dep };
            que5_2 = que5_2.Distinct();
            foreach (var x in que5_2)
                Console.WriteLine(x);

            Console.WriteLine("\nПросмотрите результаты для всех запросов со ссылкой M:M\n");

            Console.WriteLine("Все отделы и рабочие в каждом отделе: ");
            var que6_1 = from y in deps
                         join l in w_d on y.ID_Dep equals l.ID_Dep into temp2
                         from t2 in temp2
                         select new { id = y.ID_Dep, name = y.Name_Dep };
            que6_1 = que6_1.Distinct();
            foreach (var y in que6_1)
            {
                Console.WriteLine("\n\n" + y + "\n");
                var que6_2 = from x in w_d
                             where (y.id == x.ID_Dep)
                             select new { id_w = x.ID_W };
                que6_2 = que6_2.Distinct();
                var que6_3 = from t in workers
                             from t2 in que6_2
                             where t2.id_w == t.ID_W
                             select new { id = t.ID_W, surname = t.Surname };
                que6_3 = que6_3.Distinct();
                foreach (var t in que6_3)
                    Console.WriteLine(t);
            }

            Console.WriteLine("\nСписок всех отделов и количество работников в каждом отделе: ");
            var que7_1 = from x in deps
                         join l in w_d on x.ID_Dep equals l.ID_Dep into temp2
                         from t2 in temp2
                         select new { id = x.ID_Dep, name = x.Name_Dep };
            que7_1 = que7_1.Distinct();
            foreach (var x in que7_1)
            {
                Console.WriteLine("\n" + x);
                int N = 0;
                var que7_2 = from y in w_d
                             where (x.id == y.ID_Dep)
                             select new { id_w = y.ID_W };
                que7_2 = que7_2.Distinct();
                foreach (var t2 in que7_2)
                    foreach (var t in workers)
                        if (t2.id_w == t.ID_W)
                            N++;
                Console.WriteLine("Число сотрудников " + N);
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения");
            Console.Read();

        }
    }
}
