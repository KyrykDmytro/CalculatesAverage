using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketGoogle;

public class Indexer : IIndexer
{
	private Dictionary<int, string[]> dictionry;

	public void Add(int id, string documentText)
	{
		dictionry.Add(id, documentText);
	}

	public List<int> GetIds(string word)
	{
		var result = new List<int>();
		foreach (int id in dictionry.Keys)
		{ 
			if (dictionry[id].Contains(word))
			{
				result.Add(id);
			}
		}
		return result;
	}

	public List<int> GetPositions(int id, string word)
	{
		var result = new List<int>();
		string document = dictionry[id];
		int flag = 0;
		result.Add(document.IndexOf(word));
        return result;
    }

    public void Remove(int id)
	{
		dictionry.Remove(id);
	}

	public Indexer()
	{
		dictionry = new Dictionary<int, string>();
    }
}