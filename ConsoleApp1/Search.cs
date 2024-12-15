using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Search
    {
        public static int FindIndex(int[] array, int element)
        {
            int left = 0;
            int right = array.Length - 1;
            while(left < right)
            {
                int middly = (right + left) / 2;
                if (array[middly] >= element)
                    right = middly;
                else
                    left = middly + 1;
            }
            return array[left] == element ? right : -1;
        }
    }
}
