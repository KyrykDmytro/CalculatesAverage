using System;

namespace LimitedSizeStack;
class LimitedSizeStackItem<T>
{
    public T Value { get; set; }
    public LimitedSizeStackItem<T> Next { get; set; }
    public LimitedSizeStackItem<T> Prev { get; set; }
}
public class LimitedSizeStack<T>
{
    LimitedSizeStackItem<T> haed;
    LimitedSizeStackItem<T> tail;
    int limit;
    public int Count { get; private set; }
    public LimitedSizeStack(int undoLimit)
    {
        limit = undoLimit;
    }

    public void Push(T item)
    {
        if (haed == null)
            haed = tail = new LimitedSizeStackItem<T> { Value = item, Next = null };
        else
        {
            var itemNext = new LimitedSizeStackItem<T> { Value = item, Next = null };
            tail.Next = itemNext;
            itemNext.Prev = tail;
            tail = itemNext;
        }
        Count++;
        if (Count > limit)
            ForgetFirstItem();
    }

    public T Pop()
    {
        if (tail == null)
            throw new InvalidOperationException();
        T value = tail.Value;
        tail = tail.Prev;
        if (tail == null)
            haed = null;
        else
            tail.Next = null;
        Count--;
        return value;
    }

    private void ForgetFirstItem()
    {
        haed = haed.Next;
        if (haed == null)
            tail = null;
        else
            haed.Prev = null;
        Count--;
    }
}