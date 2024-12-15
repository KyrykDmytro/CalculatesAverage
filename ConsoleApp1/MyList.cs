using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MyList<T> : IEnumerable<T>
    {
        T[] array = null;
        int count = 0;

        public MyList()
        {
            array = new T[8];
        }

        public int Count { get { return count; } }

        void Enlarge()
        {
            throw new NotImplementedException();
        }

        public void Add(T item)
        {
            if (count == array.Length)
                Enlarge();
            array[count] = item;
            count++;
        }
        public bool Contains(T item)
        {
            for(int i = 0; i < count; i++)
                if (array[i].Equals(item))
                    return true;
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T this[int index]//син. сахар заміняє метод T GetValue(index) і void SetValue(index, T value)
        {
            get
            {
                if (index < 0 || index >= count) throw new IndexOutOfRangeException();
                return array[index]; 
            }
            set
            {
                if (index < 0 || index >= count) throw new IndexOutOfRangeException();
                array[index] = value; 
            }
        }
    }
}
