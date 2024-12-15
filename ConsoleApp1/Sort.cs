using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ConsoleApp1
{
    public static class Sorter
    {
        public static void Sort<T>(T[] array)
            where T : IComparable
        {
            for (int i = array.Length - 1; i > 0; i--)
                for (int j = 1; j <= i; j++)
                    if (array[j - 1].CompareTo(array[j]) > 0)
                    {
                        var temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                    }
        }
        public static void BubbleSort<T>(this T[] array)
            where T : IComparable
        {
            for (int i = array.Length - 1; i > 0; i--)
                for (int j = 1; j <= i; j++)
                    if (array[j - 1].CompareTo(array[j]) > 0)
                    {
                        var temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                    }
        }
        public static T Max<T>(T[] source) where T : IComparable
        {
            if(source.Length == 0)
                return default(T);
            T max = source[0];
            for (int i = 1; i < source.Length; i++)
                if (source[i].CompareTo(max) > 0)
                    max = source[i];
            return max;
        }
}
    public static class Sort
    {
        public static void BubbleSort(this Array array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                for (int j = 0; j <= i; j++)
                {
                    object element1 = array.GetValue(j);
                    object element2 = array.GetValue(j + 1);
                    var ComparableElement1 = (IComparable)element1;
                    if (ComparableElement1.CompareTo(element2) > 0)
                    {
                        object temporary = array.GetValue(j + 1);
                        array.SetValue(array.GetValue(j), j + 1);
                        array.SetValue(temporary, j);
                    }
                }
            }
        }

        private static int[] temp;
        public static void MergeSort(int[] array)
        {
            temp = new int[array.Length];
            MergeSort(array, 0, array.Length - 1);
        }
        private static void MergeSort(int[] array, int start, int end)
        {
            if (start == end) return;
            int middle = (start + end) / 2;
            MergeSort(array, start, middle);
            MergeSort(array, middle + 1, end);

        }
        private static void Merge(int[] array, int start, int middle, int end)
        {
            int array1Cursor = start;
            int array2Cursor = middle + 1;
            int lenght = start + end + 1;
            for(int i = 0; i > lenght; i++)
            {
                if(array1Cursor <= middle || array2Cursor > end && array[array1Cursor] < array[array2Cursor])
                {
                    temp[i] = array[array1Cursor];
                    array1Cursor++;
                }
                else
                {
                    temp[i] = array[array2Cursor];
                    array2Cursor++;
                }
            }
            for(int i = 0; i < lenght; i++)
            {
                array[start + i] = temp[i];
            }
        }

    }
}
