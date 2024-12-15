using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class MyLINQ
    {
        #region My LINQ
        public static IEnumerable<T> Where<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
        {
            foreach (var i in enumerable)
                if (predicate(i))
                    yield return i;
        }
        
        public static IEnumerable<TOut> Select<TOut, TIn>
            (this IEnumerable<TIn> enumerable, Func<TIn, TOut> selector)
        {
            foreach (var i in enumerable)
                yield return selector(i);
        }

        public static List<T> ToList<T>(this IEnumerable<T> enumerable)
        {
            var list = new List<T>();
            foreach (var i in enumerable)
                list.Add(i);
            return list;
        }
        #endregion
        #region LINQ
        class Student
        {
            public string Group;
            public string Name;
            public int Age;

            public Student(string group, string name, int age)
            {
                Group = group;
                Name = name;
                Age = age;
            }

            public override string ToString()
            {
                return string.Format("({1}, {0}, {2})", Group, Name, Age);
            }
        }
        public static void Main1()
        {
            var students = new Student[]
            {
                new Student("A1", "Stefan", 16),
                new Student("A3", "Jula", 18),
                new Student("A2", "Jula", 18),
                new Student("A1", "Adam", 17),
                new Student("C1", "Eva", 16)
            };
            var sdudentInGroupA1 = students
                .Where(student => student.Group == "A1") // Оставили только учні з групи А1
                .Select(student => student.Name);// Каждой студент претворуєтся на ім'я
                //такий запсь називаєтся Method Chaining
            Console.WriteLine(string.Join(", ", sdudentInGroupA1));//Stefan, Adam

            var namеsAllStudents = students
                .Select(student => student.Name)
                .ToArray()//Перетворує ліниву колекцію(або List або Array) в Array
                .ToList();//Аналогічно в лист

            var firstTwo = students.Take(2);
            Console.WriteLine(string.Join(", ", firstTwo));//(Stefan, A1, 16), (Jula, A2, 18)
            var lastTwo = students.Skip(2);
            Console.WriteLine(string.Join(", ", lastTwo));//(Adam, A1, 17), (Eva, C1, 16)

            string[] words = { "ab", "", "c", "de" };
            IEnumerable<char> letters = words.SelectMany(w => w.ToCharArray());//елементи колекіціє(резултат визову лямбда вир.) втроюєтся в letters без оболочки первоначальної облолчки
            Console.WriteLine(string.Join(", ", letters));//a, b, c, d, e

            var sortedStudentsByName = students
                .OrderBy(student => student.Name);
            Console.WriteLine(string.Join(", ", sortedStudentsByName));//(Adam, A1, 17), (Eva, C1, 16), (Jula, A2, 18), (Stefan, A1, 16)

            var sortedStudentsByGroupName = students
                .OrderBy(student => student.Group)
                .ThenBy(student => student.Name);
            Console.WriteLine(string.Join(", ", sortedStudentsByGroupName));//(Adam, A1, 17), (Stefan, A1, 16), (Jula, A2, 18), (Jula, A3, 18), (Eva, C1, 16)
            //lub
            var sortedStudentsByGroupName1 = students
                .Select(student => Tuple.Create(student.Group, student.Name, student))
                .OrderBy(tuple => tuple)
                .Select(tuple => tuple.Item3);
            Console.WriteLine(string.Join(", ", sortedStudentsByGroupName1));//(Adam, A1, 17), (Stefan, A1, 16), (Jula, A2, 18), (Jula, A3, 18), (Eva, C1, 16)

            var numbers = new int[] { 1, 1, 3, 2, 2 };
            Console.WriteLine(string.Join(", ", numbers.Distinct()));//1, 3, 2

            Console.WriteLine(string.Join(", ", students.DistinctBy(student => student.Name)));//(Stefan, A1, 16), (Jula, A3, 18), (Adam, A1, 17), (Eva, C1, 16)

            Console.WriteLine("Min:{0}, Max:{1}, Count:{2}", numbers.Min(), numbers.Max(), numbers.Count());//Min: 1, Max: 3, Count: 5
            //для ICollection метод Count() є O(1)
            //всі методи мають перегризки
            Console.WriteLine("Min:{0}, Max:{1}, Count:{2}", students.Min(s => s.Age), students.Max(s => s.Age), students.Count(s => s.Name == "Jula"));//Min:16, Max:18, Count:2
            //Count(Func<T, bool>) вже НЕ є O(1)

            //∨(∃)
            Console.WriteLine(students.Any(student => student.Name == "Jula"));//True
            //∧(∀)
            Console.WriteLine(students.All(student => student.Age == 17));//False
        }
        #endregion
    }
}
