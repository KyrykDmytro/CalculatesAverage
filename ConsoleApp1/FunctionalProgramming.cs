using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class FunctionalProgramming
    {

        #region LINQ
        class Student
        {
            public string LastName { get; set; }
            public string Group { get; set; }
        }
        public static void Main1()
        {
            var students = new List<Student>() {
                new Student { LastName="Jones", Group="FT-1" },
                new Student { LastName="Adams", Group="FT-1" },
                new Student { LastName="Williams", Group="KN-1"},
                new Student { LastName="Brown", Group="KN-1"}
            };
            //с помощью LINQ можно написать так:
            IEnumerable<string> result = students
                .Where(z => z.Group == "KN-1")
                .Select(z => z.LastName);
            //це ліниві методи(yield return) для того визиваются спецефічно:
            //"Видає значення тоді коли його попросять"
            //yield return визиваєтся тоді коли треба настипний елемент IEnumerable
            //foreach(in Main) -> Select -> Where -> lambda(in Where) <- Select -> lambda(in Select) <- foreac(in Main)
            foreach (var i in result)
                Console.WriteLine(i);
        }
        
        #endregion
        public static Func<double, double> Derivative(Func<double, double> f)
        {
            var eps = 1e-10;
            return x => (f(x + eps) - f(x)) / eps;
        }
    }
}
