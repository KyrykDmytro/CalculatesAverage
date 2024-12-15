using Microsoft.VisualBasic;
using System.Collections;

namespace ConsoleApp1
{
    public class Sequences
    {
        //Лінива колекція
        static public IEnumerable<int> fibonacci1 = new SequencesFibonacci();
        static public IEnumerable<int> fibonacci2//синю сахар,розвиртає в відільний клас 
        {
            get
            {
                int currentValue = 1;
                int previousValue = 1;
                yield return previousValue;
                yield return currentValue;
                while (true)
                {
                    int newValue = currentValue + previousValue;
                    previousValue = currentValue;
                    currentValue = newValue;
                    yield return currentValue;
                }
            }
        }
        public static IEnumerable<int> Exponential(int multiplier)// больше сахара
        {
            var a = 1;

            while (true)
            {
                yield return a;
                a *= multiplier;
            }
        }
        public void Print()
        {
            foreach (var number in fibonacci1.Take(8))//з лінивої колекції буде водобто 8 почат. вираз.
            {
                Console.WriteLine(number);
            }
        }
        static public IEnumerable<bool[]> MakeSubset(bool[] subset, int position = 0)//рекурсія і yield return
        {
            if(position == subset.Length)
            {
                yield return subset.ToArray();
                yield break;//досрочне прервання метода
            }
            subset[position] = false;
            foreach (bool[] i in MakeSubset(subset, position + 1))
                yield return i;
            subset[position] = true;
            foreach (bool[] i in MakeSubset(subset, position + 1))
                yield return i;
        }
    }
    public class SequencesFibonacci : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()//yield return в відельному класі
        {
            int currentValue = 1;
            int previousValue = 1;
            yield return previousValue;
            yield return currentValue;
            while (true)
            {
                int newValue = currentValue + previousValue;
                previousValue = currentValue;
                currentValue = newValue;
                yield return currentValue;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    //Реаліза на пряму(в даниму крнтексті цей код не потрібен)
    public class SequencesFibonacciEnumerator : IEnumerator<int>
    {
        int currentIndex = -1;
        int currentValue = 1;
        int previousValue = 1;

        public int Current
        {
            get 
            {
                if (currentIndex == 0 || currentIndex == 1)
                    return 1;
                return currentValue;
            } 
            private set; 
        }

        object IEnumerator.Current { get { return Current; } }
        public bool MoveNext()
        {
            currentIndex++;
            if(currentIndex > 1)
            {
                int newValue = currentValue + previousValue;
                previousValue = currentValue;
                currentValue = newValue;
            }
            return true;
        }
        public void Dispose()
        {
        }

        public void Reset()
        {
        }
    }
    }
}
