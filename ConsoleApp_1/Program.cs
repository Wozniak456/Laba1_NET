using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static SimpleLINQ.Program.CarData;
namespace SimpleLINQ
{
    class Program
    {
        /// <summary>
        /// дані про авто
        /// </summary>
        public class CarData
        {
            public int id;
            public List<int> ownerID = new List<int>();
            public int year; // рік випуску
            public string brand;  // марка авто
            public string model; //модель
            public string bodyType; //тип кузову
            public string manufacturer; //виробник
            public string vin_code;    //номер шасі (VIN-код)
            public string color;    //колір
            public string technicalState;  //технічний стан
            /// <summary>
            /// Конструктор
            /// </summary>
            public CarData(int id, int year, string brand,
                string model, string bodyType, string manufacturer,
                string vin_code, string color,
                string technicalState, params int[] OwnId)
            {
                this.id = id;
                this.year = year;
                this.brand = brand;
                this.model = model;
                this.bodyType = bodyType;
                this.manufacturer = manufacturer;
                this.vin_code = vin_code;
                this.color = color;
                this.technicalState = technicalState;
                foreach (int item in OwnId)
                {
                    this.ownerID.Add(item);
                }
            }
            /// <summary>
            /// Приведення до строкового типу
            /// </summary>
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"\nid = {this.id};\t\t\t\t\tyear = {this.year};\t\t\tbrand = {this.brand}");
                sb.AppendLine($"model = {this.model};\t\t\tbodyType = {this.bodyType};\t\tmanufacturer = {this.manufacturer}");
                sb.AppendLine($"vin_code = {this.vin_code};\t\t\tcolor = {this.color};\t\t");
                sb.AppendLine($"technicalState = {this.technicalState}");
                sb.Append($"ID of owners: ");
                foreach (int item in ownerID)
                {
                    sb.Append(item + " ");
                }
                Console.WriteLine();
                return sb.ToString();
            }
            public class DataEqualityComparer : IEqualityComparer<CarData>
            {
                public bool Equals(CarData x, CarData y)
                {
                    bool result = false;
                    if (x.id == y.id && x.year == y.year && x.brand == y.brand
                        && x.model == y.model && x.bodyType == y.bodyType
                        && x.manufacturer == y.manufacturer && x.vin_code == y.vin_code
                        && x.color == y.color
                        && x.technicalState == y.technicalState)
                        result = true;
                    return result;
                }

                public int GetHashCode(CarData obj)
                {
                    return obj.id;
                }
            }
        }
        //Приклад даних
        static List<CarData> d1 = new List<CarData>()
        {
            new CarData(1, 2009, "BMW", "BMW 5 GT", "Hatchback","Germany", "nomer1", "grey", "класний",5,3),
            new CarData(2, 2020, "Toyota", "BMW X3 SUV", "Hatchback","Germany", "nomer2", "white", "дуже класний",6),
            new CarData(3, 2013, "BMW", "BMW X6", "new hatchback","Germany", "nomer3", "pink", "кошмар просто",7,1,2),
            new CarData(4, 2021, "Ferrari", "BMW OMG", "Hatchback","Germany", "nome4", "black", "фiфтi фiфтi",8),
            new CarData(5, 2009, "Ford", "Ford 5 GT", "Hatchback","USA", "nomer5", "grey", "поганий", 0),
            new CarData(6, 1999, "Lamborghini", "Ford RT", "Hatchback","USA", "nomer6", "red", "не оч(",0),
            new CarData(7, 2016, "Ford", "Ford G8", "new h.back","USA", "nomer7", "pink", "брррр",4),
            new CarData(8, 1999, "Ford", "Ford PO", "Hatchback","USA", "nomer8", "black", "ну ок",0)
        };
        static List<CarData> d1_for_distinct = new List<CarData>()
        {
            new CarData(1, 2009, "BMW", "BMW 5 GT", "Hatchback","Germany", "nomer1", "grey", "класний",5,3),
            new CarData(1, 2009, "BMW", "BMW 5 GT", "Hatchback","Germany", "nomer", "grey", "класний",5,3),
            new CarData(1, 2009, "BMW", "BMW 5 GT", "Hatchback","Germany", "nomer1", "grey", "класний",5,3),
            new CarData(2, 2020, "Car", "Car 6 G7T", "Hatchback","Azerbaidzhan", "nomer", "red", "класний",2,3),
            new CarData(2, 2020, "Car", "Car 6 G7T", "Hatchback","Azerbaidzhan", "nomer", "red", "класний",2,3),
            new CarData(3, 2007, "Car", "Car 6 G7T", "Hatchback","Azerbaidzhan", "nomer", "red", "класний",2,3)
        };
        static List<CarData> d1_2_ = new List<CarData>()
        {
            new CarData(1, 2009, "BMW", "BMW 5 KL", "Hatchback","Germany", "nomer1", "grey", "класний",5,3),
            new CarData(2, 2020, "Car", "Car 6 G7T", "Hatchback","Azerbaidzhan", "nomer", "red", "класний",2,3),
            new CarData(3, 2005, "Car", "Car 6 G7T", "Hatchback","Azerbaidzhan", "nomer", "red", "класний",2,3)
        };
        public static void PrintCar(CarData car)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"id = {car.id};\t\t\tyear = {car.year};\t\t\tbrand = {car.brand}");
            sb.AppendLine($"model = {car.model};\tbodyType = {car.bodyType};\t\tmanufacturer = {car.manufacturer}");
            sb.AppendLine($"vCode = {car.vin_code};\t\tcolor = {car.color};\t\t");
            sb.AppendLine($"technicalState = {car.technicalState}");
            sb.Append($"ID of owners: ");
            foreach (int item in car.ownerID)
            {
                sb.Append(item + " ");
            }
            Console.WriteLine(sb);
            Console.WriteLine();
        }
        public class Person
        {
            public string firstName;
            public string lastName;
            public string midName;
            public DateTime birthday;
            public Person(string fn, string ln, string mn, DateTime bd)
            {
                this.firstName = fn;
                this.lastName = ln;
                this.midName = mn;
                this.birthday = bd;
            }
        }
        public class CarOwner : Person
        {
            public int ID;
            public int carID;
            public CarOwner(int id, string fn, string ln, string mn, DateTime bd, int carId)
                : base(fn, ln, mn, bd)
            {
                this.ID = id;
                this.carID = carId;
            }
            public string PrintPerson()
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"OwnerID={this.ID},\tfirstName = {this.firstName},\tlastName = {this.lastName},\tmidName = {this.midName},\tbirthDate = {this.birthday}");
                sb.AppendLine($"ID of car(-s): {this.carID}");
                Console.WriteLine();
                return sb.ToString();
            }
        }
        static List<CarOwner> d2 = new List<CarOwner>()
        {
            new CarOwner(1, "Sofiia", "Vozniak", "Petrivna", new DateTime(2002,9,30),3),
            new CarOwner(2, "Anna", "Pozniak", "Ihorivna", new DateTime(2003,8,29),3),
            new CarOwner(3, "Karina", "Kozniak", "Oksanivna", new DateTime(2003,7,28),1),
            new CarOwner(4, "Anna", "Lozniak", "Bohdanivna", new DateTime(2002,6,27),7),
            new CarOwner(5, "Bohdan", "Vozniak", "Petrovych", new DateTime(2001,5,26),1),
            new CarOwner(6, "Maks", "Tozniak", "Zelenskii", new DateTime(2000,4,25),2),
            new CarOwner(7, "Petro", "Mozniak", "Arestovych", new DateTime(2000,3,24),3),
            new CarOwner(8, "Pedro", "Nazniak", "MidName", new DateTime(1997,3,24),4)
        };
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Прості запити\n");
            Console.ResetColor();

            PrintGreen("Проста вибірка елементів\n");
            var q1 = from x in d1
                     select x;
            foreach (var x in q1)
                PrintCar(x);

            PrintGreen("Вибірка окремого поля (проекція)\n");
            var q2 = from x in d1
                     select x.technicalState;
            foreach (var x in q2)
                Console.WriteLine(x);

            PrintGreen("Створення нового об'єкту анонімного типу");
            var q3 = from x in d1
                     select new { id = x.id, model = x.model, year = x.year };
            var zminna =  new { id = 1, model = "", year = 2001};
            foreach (var x in q3)
            {
                zminna = x;
                Console.WriteLine(x);
            }

            PrintGreen("Умови");
            var q4 = from x in d1
                     where x.id > 1 && (x.year < 2016 || x.color == "black")
                     select x;
            foreach (var x in q4)
                PrintCar(x);

            PrintGreen("Вибірка значення конкретного типу");
            object[] array = new object[] { 123, "рядок 1", true, "рядок 2", new DateTime(2000, 4, 25), new DateTime(2024, 6, 28) };
            var q5 = from x in array
                     //OfType<DateTime>()
                     select x.GetType();

            foreach (var x in q5)
                Console.WriteLine(x);
            object[] array12 = new object[] { 123, "рядок 1", true, "рядок 2", new DateTime(2000, 4, 25), new DateTime(2024, 6, 28) };
            foreach (var x in array12)
            {
                if (x is DateTime)
                {
                    Console.WriteLine(x);
                }
            }
            PrintGreen("Сортування");
            var q6 = from x in d1
                     where x.id > 1 && (x.year < 2016 || x.color == "black")
                     orderby x.year descending, x.id descending
                     select x;
            foreach (var x in q6)
                PrintCar(x);

            PrintGreen("Сортування з використанням розширюючих методів");
            var q7 = d1.Where((x) =>
            {
                return x.id > 1 && (x.year < 2016 || x.color == "black");
            }).OrderByDescending(x => x.year).ThenByDescending(x => x.id);
            foreach (var x in q7)
                PrintCar(x);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Оператори поділу");
            PrintGreen("Використання SkipWhile и TakeWhile");
            var q9 = d1.SkipWhile(x => (x.id < 4)).TakeWhile(x => x.id <= 7);
            foreach (var x in q9)
                PrintCar(x);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("З'єднання");
            PrintGreen("Inner Join з використанням Where");
            var q11 = from x in d1
                      from y in d2
                      where x.id == y.carID
                      select new { carID = y.carID, carBrend = x.brand, ownName = y.firstName };
            foreach (var x in q11)
                Console.WriteLine(x);
            PrintGreen("Inner Join з використанням Join");
            var q12 = from x in d1
                      join y in d2 on x.id equals y.carID
                      select new { v1 = y.firstName, v2 = y.lastName, v3 = x.brand, v4 = x.year };
            foreach (var x in q12)
                Console.WriteLine(x);
            PrintGreen("Inner Join (зберігаємо об'єкт)");
            var q13 = from x in d1
                      join y in d2 on x.id equals y.carID
                      select new { v1 = y.ID, v2 = y.firstName, d2Group = x.ToString() };
            foreach (var x in q13)
                Console.WriteLine(x);
            //Обираємо всі елементи з d2 та якщо є пов'язані з d1 (outer join)
            //В temp поміщуємо всю групу, далі її елементи перебираємо окремо
            PrintGreen("Group Join");
            var q14 = from x in d2
                      join y in d1 on x.carID equals y.id into temp
                      select new { v1 = x.firstName, v2 = x.ID, d2Group = temp };
            foreach (var x in q14)
            {
                Console.WriteLine();
                Console.WriteLine($"OwnerName = {x.v1}, OwnerId = {x.v2}");
                foreach (var y in x.d2Group)
                    PrintCar(y);
            }
            PrintGreen("\nCross Join и Group Join");
            var q15 = from x in d1
                      join y in d2 on x.id equals y.carID into temp
                      from t in temp
                      select new { v1 = x.year, v2 = t.firstName, cnt = temp.Count() };
            foreach (var x in q15)
                Console.WriteLine(x);
            PrintGreen("Outer Join");
            var q16 = from x in d1
                      join y in d2 on x.id equals y.carID into temp
                      from t in temp.DefaultIfEmpty()
                      select new { v1 = x.year, v3 = x.brand, v2 = ((t == null) ? "null" : t.firstName) };
            foreach (var x in q16)
                Console.WriteLine(x);
            PrintGreen("Використання Join для складених ключів");
            var q17 = from x in d1
                      join y in d1_for_distinct on new { x.id, x.year } equals new { y.id, y.year } into details
                      from d in details
                      select d;
            foreach (var x in q17)
                Console.WriteLine(x);
            //Дії над множинами
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Дії над множинами");
            PrintGreen("Distinct - для значень");
            var q18 = (from x in d1 select x.year).Distinct();
            foreach (var x in q18)
                Console.WriteLine(x);
            PrintGreen("Distinct - для об'єктів");
            var q19 = (from x in d1_for_distinct select x).Distinct(new DataEqualityComparer());
            foreach (var x in q19)
                Console.WriteLine(x);
            PrintGreen("Union - об'єднання з виключенням дублікатів");
            int[] i1 = new int[] { 1, 6, 3, 4 };
            int[] i1_1 = new int[] { 2, 3, 4, 1 };
            int[] i2 = new int[] { 2, 3, 4, 5 };
            foreach (var x in i1.Union(i2))
                Console.WriteLine(x);
            PrintGreen("Union - об'єднання для об'єктів без виключенням дублікатів");
            foreach (var x in d1.Union(d1_for_distinct))
                Console.WriteLine(x);
            PrintGreen("Union - об'єднання для об'єктів з виключенням дублікатів 1");
            foreach (var x in d1.Union(d1_for_distinct, new DataEqualityComparer()))
                Console.WriteLine(x);
            PrintGreen("Union - об'єднання для объектів з виключенням дублікатів 2");
            foreach (var x in d1.Union(d1_for_distinct).Union(d1_2_).Distinct(new DataEqualityComparer()))
                Console.WriteLine(x);
            PrintGreen("Concat - об'єднання без виключення дублікатів");
            foreach (var x in i1.Concat(i2))
                Console.WriteLine(x);
            PrintGreen("SequenceEqual - перевірка співпадіння та порядку слідування");
            Console.WriteLine(i1.SequenceEqual(i1));
            Console.WriteLine(i1.SequenceEqual(i2));
            PrintGreen("Intersect - перетин множин");
            foreach (var x in i1.Intersect(i2))
                Console.WriteLine(x);
            PrintGreen("Intersect - перетин множин для об'єктів");
            foreach (var x in d1.Intersect(d1_for_distinct, new DataEqualityComparer()))
                Console.WriteLine(x);
            PrintGreen("Except - різниця множин");
            foreach (var x in i1.Except(i2))
                Console.WriteLine(x);
            PrintGreen("Except - різниця множин для об'єктів");
            foreach (var x in d1.Except(d1_for_distinct, new DataEqualityComparer()))
                Console.WriteLine(x);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nФункції агрегування\n");
            PrintGreen("Count - кількість елементів");
            Console.WriteLine(d1.Count());
            PrintGreen("Count - кількість з умовою");
            Console.WriteLine(d1.Count(x => x.id > 3));
            PrintGreen("Aggregate - агрегування значень");
            var qa1 = d1.Aggregate(new CarData(0, 0, "", "", "", "", "", "", ""), (total, next) =>
            {
                if (next.id > 1) total.id += next.id;
                return total;
            });
            Console.WriteLine(qa1);
            PrintGreen("Групування");
            var q20 = from x in d1.Union(d1_2_)
                      group x by x.year into g
                      select new { Key = g.Key, Values = g };
            foreach (var x in q20)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nГрупування за роком: " + x.Key);
                Console.ResetColor();
                foreach (var y in x.Values)
                    Console.WriteLine(" " + y);
            }
            PrintGreen("Групування з функціями агрегування");
            var q21 = from x in d1.Union(d1_2_)
                      group x by x.year into g
                      select new { Key = g.Key, Values = g, cnt = g.Count(), cnt1 = g.Count(x => x.id > 1), sum = g.Sum(x => x.id), min = g.Min(x => x.id) };
            foreach (var x in q21)
            {
                Console.WriteLine(x);
                foreach (var y in x.Values)
                    Console.WriteLine(" " + y);
            }
            PrintGreen("Групування - Any");
            var q22 = from x in d1.Union(d1_2_)
                      group x by x.year into g
                      where g.Any(x => x.id > 3)
                      select new { Key = g.Key, Values = g };
            foreach (var x in q22)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nГрупування за роком: " + x.Key);
                Console.ResetColor();
                foreach (var y in x.Values)
                    Console.WriteLine(" " + y);
            }
            PrintGreen("Групування - All");
            var q23 = from x in d1.Union(d1_2_)
                      group x by x.year into g
                      where g.All(x => x.id > 2)
                      select new { Key = g.Key, Values = g };
            foreach (var x in q23)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nГрупування за роком: " + x.Key);
                Console.ResetColor();
                foreach (var y in x.Values)
                    Console.WriteLine(" " + y);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Перетворення даних");
            PrintGreen("Результат перетворюється в масив");
            var q24 = (from x in d1 select x).ToArray();
            Console.WriteLine(q24.GetType().Name);
            foreach (var x in q24)
                Console.WriteLine(x);
            PrintGreen("Результат перетворюється в Dictionary");
            var q25 = (from x in d1 select x).ToDictionary(x => x.id);
            Console.WriteLine(q25.GetType().Name);
            foreach (var x in q25)
                Console.WriteLine(x);
            PrintGreen("Результат перетворюється в Lookup");
            var q26 = (from x in d1_for_distinct select x).ToLookup(x => x.id);
            Console.WriteLine(q26.GetType().Name);
            foreach (var x in q26)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\n" + x.Key + " запис"); Console.ResetColor();
                foreach (var y in x)
                    Console.WriteLine(" " + y);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Отримання елемента");
            PrintGreen("Перший елемент з вибірки");
            var f1 = (from x in d2 select x).First(x => x.ID == 1);
            Console.WriteLine(f1.PrintPerson());
            PrintGreen("Перший елемент з вибірки або значення за замовчанням");
            var f2 = (from x in d2 select x).FirstOrDefault(x => x.ID == 10);
            Console.WriteLine(f2 == null ? "null" : f2.ToString());
            PrintGreen("Елемент в заданій позиції");
            var f3 = (from x in d2 select x).ElementAt(2);
            Console.WriteLine(f3.PrintPerson());
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Генерація послідовностей");
            PrintGreen("Range");
            foreach (var x in Enumerable.Range(2, 6))
                Console.WriteLine(x);
            PrintGreen("Repeat");
            foreach (var x in Enumerable.Repeat<int>(110, 4))
                Console.WriteLine(x);
            Console.ReadLine();
        }
        public static void PrintGreen(string str)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(str);
            Console.ResetColor();
        }
    }
}