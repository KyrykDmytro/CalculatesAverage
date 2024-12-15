using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1Test
{
    internal class LambdaPractical
    {
        private static readonly Func<int> zero = () => 0 ;
        private static readonly Func<int, string> toString = (number) => number.ToString() ; 
        private static readonly Func<double, double, double> add = (x, y) => x + y;
        private static readonly Action<string> print = Console.WriteLine;
        [Test]
        public static void Main1()
        {
            Assert.AreEqual(0, zero());

            Assert.AreEqual("42", toString(42));
            Assert.AreEqual("123", toString(123));

            Assert.AreEqual(3.14, add(1.1, 2.04));
            Assert.AreEqual(0, add(-1, 1));

            print("passed!");
        }
    }
}
