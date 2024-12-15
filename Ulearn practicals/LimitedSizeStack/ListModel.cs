using System;
using System.Collections.Generic;

namespace LimitedSizeStack;

public class ListModel<TItem>
{
	private LimitedSizeStack<TItem> stack;
    public List<TItem> Items { get; }
	public int UndoLimit;
        
	public ListModel(int undoLimit) : this(new List<TItem>(), undoLimit)
	{
	}

	public ListModel(List<TItem> items, int undoLimit)
	{
		Items = items;
		UndoLimit = undoLimit;
		stack = new LimitedSizeStack<TItem>(undoLimit);
		foreach (TItem i in items)
			stack.Push(i);
	}

	public void AddItem(TItem item)
	{
		Items.Add(item);
	}

	public void RemoveItem(int index)
	{
		Items.RemoveAt(index);
	}

	public bool CanUndo()
	{
		return false;
	}

	public void Undo()
	{
		throw new NotImplementedException();
	}
}