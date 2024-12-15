using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Algorithms
    {
        public static bool IsCorrectString(string str)
        {
            var stack = new Stack<char>();
            var dict = new Dictionary<char, char>()
                { {'(', ')' }, {'[', ']' }, {'{', '}' }, {'<', '>' } };
            foreach (var symbol in str)
            {
                if (dict.Keys.Contains(symbol)) stack.Push(symbol);
                else if (dict.Values.Contains(symbol))
                {
                    if (stack.Count == 0) return false;
                    var openBacket = stack.Pop();
                    if (dict[openBacket] != symbol) return false;

                }
                else return false;
            }
            return stack.Count == 0;
        }
        public static int ReversePolishNotation(string str)
        {
            var operations = new Dictionary<char, Func<int, int, int>>();
            operations['+'] = (a, b) => a + b;
            operations['-'] = (a, b) => a - b;
            operations['*'] = (a, b) => a * b;
            operations['/'] = (a, b) => a / b;

            var stack = new Stack<int>();
            foreach(char symbol in str)
            {
                if (symbol >= '0' && symbol <= '9')
                    stack.Push(symbol - '0');
                else if (operations.ContainsKey(symbol))
                    stack.Push(operations[symbol](stack.Pop(), stack.Pop()));
                else
                    throw new ArgumentException();
            }
            return stack.Pop();
        }
    }
}
