using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public delegate int StringComparer(string x, string y);

    internal class Delegate
    {
        Func<int, int> f;//<- заготовлений делігат з оргументом int ш  повиртаємим числом int
        Action<int> a;//<- заготовлений делігат який нічого не повертає

        //Метод Sort делегирует интерфейсу IComparer функциональность(патрн делегірованя)
        //по сравнению элементов массива
        public static void Sort<T>(T[] array, Func<T, T, int> comparer)
        {
            for (int i = array.Length - 1; i > 0; i--)
                for (int j = 1; j <= i; j++)
                {
                    var element1 = array[j - 1];
                    var element2 = array[j];
                    if (comparer(element1, element2) > 0)
                    {
                        var temporary = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = temporary;
                    }
                }
        }

        //Но для обеспечения делегирования приходится писать 
        //слишком много инфраструктурного кода: объявлять класс,
        //реализовывать интерфейс. Задача: сократить объем инфраструктурного кода
        public static int CompareStringLength(string x, string y)
        {
            return x.Length.CompareTo(y.Length);
        }

        class Comparer
        {
            public bool Descending { get; set; }
            public int CompareStrings(string x, string y)
            {
                return x.CompareTo(y) * (Descending ? -1 : 1);
            }
        }

        public static void Main1()
        {
            var strings = new[] { "A", "B", "AA" };
            //SortStrings(strings, new StringComparer(CompareStringLength));
            Sort(strings, CompareStringLength);//<-сахар
            Sort(strings, delegate (string x, string y)//<- сахар, анонімні делігати
            {
                return x.Length.CompareTo(y.Length);
            });
            bool Descending = true;
            Func<string, string, int> cmp = (x, y) => 
            {
                Descending = false;
                return x.CompareTo(y) * (Descending ? -1 : 1); 
            };
            Sort(strings, (x, y) => x.Length.CompareTo(y.Length));//<- сахар, лямбда-вираз
            Sort(strings, new Comparer { Descending = false }.CompareStrings);
            Lambda.Main1();
        }
        public class Lambda
        {
            static Random rnd = new Random();

            public static void Main1()
            {
                Func<int, int> f = x => x + 1;

                Console.WriteLine(f(1));

                Func<int> generator = () => rnd.Next();

                Console.WriteLine(generator());

                Func<double, double, double> h = (a, b) =>
                {
                    b = a % b;
                    return b % a;
                };

                Action<int> print = x => Console.WriteLine(x);

                print(generator());

                Action printRandomNumber = () => Console.WriteLine(rnd.Next());
                Action printRandomNumber1 = () => print(generator());

                //Когда локальная переменная используется внутри лямбда-выражения - это замыкание
                bool Descending = true;
                Func<string, string, int> cmp =
                    (x, y) => x.CompareTo(y) * (Descending ? -1 : 1);
            }
        }
        class Closure//<-Замыкание
        {
            public static void Main1()
            {
                var functions = new List<Func<int, int>>();

                for (int i = 0; i < 10; i++)
                    functions.Add(x => x + i);

                //Этот код выведет десять раз "10", потому что i ушла в замыкание
                //и общая для всех лямбд в списке
                foreach (var e in functions)
                    Console.WriteLine(e(0));

                functions = new List<Func<int, int>>();

                for (int i = 0; i < 10; i++)
                {
                    var j = i;
                    functions.Add(x => x + j);
                }

                //Этот код выведет числа от 0 до 10,
                //потому что j - локальная для цикла,
                //и соответственно своя на каждой итерации и у каждой лямбды
                foreach (var e in functions)
                    Console.WriteLine(e(0));
            }
        }
    }
}
