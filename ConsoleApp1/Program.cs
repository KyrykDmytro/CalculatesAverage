using System.Linq;
using System.Net.Http.Headers;

namespace ConsoleApp1
{
    public class Program
    {
        public static string GetLongest(IEnumerable<string> words)
        {
            return words
                .Min(word => (-(word.Length), word)).Item2;
        }
        public static void Main()
        {
            Console.WriteLine(GetLongest(new[] { "azaz", "as", "sdsd" }));
            Console.WriteLine(GetLongest(new[] { "zzzz", "as", "sdsd" }));
            Console.WriteLine(GetLongest(new[] { "as", "12345", "as", "sds" }));
            MyLINQ.Main1();
        }
    }   
}