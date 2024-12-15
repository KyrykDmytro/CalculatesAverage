//Подмножества

static void MakeSubsets(bool[] subset, int position)
{
    if (position == subset.Length)
    {
        foreach(var e in subset){
            Console.Write(e ? 1 : 0);
        }
        Console.WriteLine();
        return;
    }
    subset[position] = false;
    MakeSubsets(subset, position + 1);
    subset[position] = true;
    MakeSubsets(subset, position + 1);
}

//Перестановки
static void MakePermutations(int[] permutation, int position)
{
    if (position == permutation.Length)
    {
        foreach(var e in permutation){
            Console.Write(e);
        }
        Console.WriteLine();
        return;
    }

    for (int i = 0; i < permutation.Length; i++)
    {
        var index = Array.IndexOf(permutation, i, 0, position);
        if (index != -1)
            continue;
        permutation[position] = i;
        MakePermutations(permutation, position + 1);
    }
}

//Размещения
static void MakeCombinations(bool[] combination, int elementsLeft, int position)
{
	if (elementsLeft == 0)
	{
		foreach (var c in combination)
			Console.Write(c ? 1 : 0);
		Console.WriteLine();
		return;
	}
	if (position == combination.Length)
		return;

	combination[position] = true;
	MakeCombinations(combination, elementsLeft - 1, position + 1);
	combination[position] = false;
	MakeCombinations(combination, elementsLeft, position + 1);
}