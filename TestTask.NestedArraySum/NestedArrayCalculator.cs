using System;
using System.Collections.Generic;
using System.Linq;

namespace TestTask.NestedArraySum
{
    public class NestedArrayCalculator
    {
        private readonly List<Tuple<int[], int>> _cache = new List<Tuple<int[], int>>();
        /// <summary>
        /// Пошук вкладеного масиву, у якій сума є максимальною. Складність O(n^2)~ n*(n-1)/2
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public int[] NestedArraySum(params int[] array)
        {
            while (array.Length > 0)
            {
                int length = array.Length;
                for (int i = 0; i < length; i++)
                {
                    int[] tmp = new int[length - i];
                    for (int j = 0; j < tmp.Length; j++)
                    {
                        tmp[j] = array[j];
                    }
                    _cache.Add(new Tuple<int[], int>(tmp, tmp.Sum()));
                }
                array = PopFirstElement(array);
            }
            return _cache.FirstOrDefault(x => x.Item2 == _cache.Max(c => c.Item2))?.Item1;
        }
        /// <summary>
        /// Відкидання першого елементу з масиву
        /// </summary>
        /// <typeparam name="T">тип</typeparam>
        /// <param name="array">масив</param>
        /// <returns></returns>
        private static T[] PopFirstElement<T>(T[] array)
        {
            T[] newArray = new T[array.Length - 1];
            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = array[i + 1];
            }
            return newArray;
        }
    }
}
