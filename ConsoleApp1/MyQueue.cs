using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MyQueue<T> : IEnumerable<T>
    {
        QueueItem<T> head;
        QueueItem<T> tail;

        public bool IsEmpty { get { return head == null; }  }

        public IEnumerator<T> GetEnumerator()
        {
            var current = head;
            while(current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #region 

        public void Enqueue(T value)
        {
            if(head == null)
            {
                head = tail = new QueueItem<T>() { Value = value, Next = null };
            }
            else
            {
                var item = new QueueItem<T>() { Value = value, Next = null };
                tail.Next = item;
                tail = item;
            }
        }
        public T Dequeue()
        {
            if (tail == null) throw new InvalidOperationException();
            var result = head.Value;
            head = head.Next;
            if(head == null)
            {
                tail = null;
            }
            return result;
        }

        #endregion
    }
    public class QueueItem<TValue>
    {
        public TValue Value { get; set; }
        public QueueItem<TValue> Next { get; set; }
    }
}
